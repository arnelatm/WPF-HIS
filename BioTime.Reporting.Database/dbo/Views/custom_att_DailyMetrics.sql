




CREATE VIEW [dbo].[custom_att_DailyMetrics]
AS
WITH base1 AS
(
    SELECT
        b.emp_id,
        b.att_date,
        b.date_type,
        b.present_flag,
        b.full_attendance_flag,
        b.scheduled_in,
        b.scheduled_out,
        b.first_clock_in,
        b.last_clock_out,
		b.scheduled_ot_cap_minutes,
        ISNULL(b.worked_minutes, 0) AS worked_minutes,

        ISNULL(b.ot_minutes, 0) AS payload_ot_minutes,
        ISNULL(b.absence_minutes, 0) AS absence_minutes,
        ISNULL(b.required_work_minutes, 0) AS required_work_minutes,
        ISNULL(b.recomputed_worked_minutes, 0) AS recomputed_worked_minutes,
        ISNULL(b.recomputed_worked_hours, 0) AS recomputed_worked_hours,
        b.use_mode,
        ISNULL(b.temp_duration_minutes, 0) AS temp_duration_minutes,
        ISNULL(b.temp_work_time_duration, 0) AS temp_work_time_duration,
        ISNULL(b.temp_break_minutes, 0) AS temp_break_minutes,
        ISNULL(b.ot_eligible_flag, 0) AS ot_eligible_flag,

        ISNULL(b.has_temp_schedule, 0) AS has_temp_schedule_base,
        ISNULL(b.has_assigned_schedule, 0) AS has_assigned_schedule_base,
        ISNULL(b.schedule_source, 'Unscheduled') AS schedule_source_base,

        -- keep timing from DailyBase
        ISNULL(b.effective_scheduled_in, b.scheduled_in) AS effective_scheduled_in,
        ISNULL(b.effective_scheduled_out, b.scheduled_out) AS effective_scheduled_out,

        ISNULL(esr.effective_schedule_source, 'Unscheduled') AS resolved_schedule_source,
        esr.effective_shift_id,
        esr.effective_time_interval_id,

        ISNULL(esr.resolved_is_off_day, 0) AS resolved_is_off_day,

        -- base fields from ESR
        ISNULL(esr.base_is_off_day, 0) AS base_is_off_day,
        ISNULL(esr.base_required_work_minutes, 0) AS base_required_work_minutes,
        ISNULL(esr.base_schedule_source, 'Unscheduled') AS base_schedule_source,
        esr.base_shift_id,
        esr.base_time_interval_id,

		CASE
			-- Explicit Holiday (highest priority)
			WHEN b.date_type = 1 THEN 1

			-- Explicit system-defined Rest Day (second priority)
			WHEN b.date_type = 2 THEN 2

			-- Derived Rest Day from base schedule (fallback)
			WHEN ISNULL(esr.base_is_off_day, 0) = 1 THEN 2

			-- Otherwise Regular Day
			ELSE 0
		END AS base_date_type,

        CASE
            WHEN b.date_type = 1 THEN 0
            WHEN ISNULL(esr.base_is_off_day, 0) = 1 THEN 0
            WHEN ISNULL(esr.effective_schedule_source, '') = 'Temporary'
                THEN ISNULL(NULLIF(b.temp_work_time_duration, 0), b.temp_duration_minutes)
            WHEN esr.effective_schedule_source IN ('Employee', 'Group', 'Department')
                THEN ISNULL(esr.effective_required_work_minutes, 0)
            ELSE ISNULL(b.required_work_minutes, 0)
        END AS effective_required_work_minutes
    FROM dbo.custom_att_DailyBase b
    LEFT JOIN dbo.custom_att_EffectiveScheduleResolved esr
        ON esr.emp_id = b.emp_id
       AND esr.att_date = b.att_date
),
base2 AS
(
    SELECT
        b1.*,

        CASE
            WHEN b1.resolved_schedule_source = 'Temporary' THEN 1
            ELSE 0
        END AS has_temp_schedule,

        CASE
            WHEN b1.resolved_schedule_source IN ('Employee', 'Group', 'Department') THEN 1
            ELSE 0
        END AS has_assigned_schedule,

        b1.resolved_schedule_source AS schedule_source,

        CASE
            WHEN b1.resolved_schedule_source = 'Temporary' THEN 'Temporary'
            WHEN b1.resolved_schedule_source IN ('Employee', 'Group', 'Department') THEN
                CASE
                    WHEN ISNULL(b1.use_mode, 0) = 1 THEN 'AssignedFlex'
                    ELSE 'Assigned'
                END
            ELSE 'Unscheduled'
        END AS schedule_type,

        CASE
            WHEN b1.resolved_schedule_source IN ('Temporary', 'Employee', 'Group', 'Department')
                THEN ISNULL(b1.ot_eligible_flag, 0)
            ELSE 0
        END AS effective_ot_eligible,

        CASE
            WHEN b1.resolved_schedule_source = 'Unscheduled'
                THEN 0
            ELSE ISNULL(b1.effective_required_work_minutes, 0)
        END AS scheduled_payable_minutes
    FROM base1 b1
),
base3 AS
(
    SELECT
        b2.*,
        CASE
            WHEN b2.date_type = 1 THEN 0
            WHEN b2.base_is_off_day = 1 THEN 0
            WHEN ISNULL(b2.payload_ot_minutes, 0) > 0 THEN
                CASE
                    WHEN ISNULL(b2.base_required_work_minutes, 0) - ISNULL(b2.payload_ot_minutes, 0) > 0
                        THEN ISNULL(b2.base_required_work_minutes, 0) - ISNULL(b2.payload_ot_minutes, 0)
                    ELSE 0
                END
            ELSE ISNULL(b2.base_required_work_minutes, 0)
        END AS regular_required_minutes
    FROM base2 b2
),
base4 AS
(
    SELECT
        b3.*,

        CASE
            -- ✅ FIX: RestDayOT → use worked minutes capped by temp/day max
            WHEN b3.base_date_type = 2
                 AND ISNULL(b3.regular_required_minutes, 0) = 0
                 AND ISNULL(b3.recomputed_worked_minutes, 0) > 0
            THEN
                CASE
                    WHEN b3.recomputed_worked_minutes >
                         ISNULL(NULLIF(b3.temp_work_time_duration, 0), b3.temp_duration_minutes)
                    THEN ISNULL(NULLIF(b3.temp_work_time_duration, 0), b3.temp_duration_minutes)
                    ELSE b3.recomputed_worked_minutes
                END

            -- Existing logic (UNCHANGED)
            WHEN b3.recomputed_worked_minutes > b3.regular_required_minutes
            THEN
                CASE
                    WHEN b3.recomputed_worked_minutes - b3.regular_required_minutes > b3.payload_ot_minutes
                        THEN b3.payload_ot_minutes
                    ELSE b3.recomputed_worked_minutes - b3.regular_required_minutes
                END

            ELSE 0
        END AS earned_ot_minutes

    FROM base3 b3
),
base5 AS
(
    SELECT
        b4.*,

        CASE
            WHEN b4.recomputed_worked_minutes >= b4.regular_required_minutes
                THEN b4.regular_required_minutes
            ELSE b4.recomputed_worked_minutes
        END AS regular_paid_minutes,

        (
            CASE
                WHEN b4.recomputed_worked_minutes >= b4.regular_required_minutes
                    THEN b4.regular_required_minutes
                ELSE b4.recomputed_worked_minutes
            END
            + b4.earned_ot_minutes
        ) AS total_paid_minutes,

        CASE
            WHEN b4.recomputed_worked_minutes > b4.scheduled_payable_minutes
                THEN b4.recomputed_worked_minutes - b4.scheduled_payable_minutes
            ELSE 0
        END AS unpaid_excess_minutes
    FROM base4 b4
)
SELECT
    b5.emp_id,
    b5.att_date,
    b5.date_type,
    b5.base_date_type,
    b5.base_is_off_day,

    b5.present_flag,
    b5.full_attendance_flag,
    b5.effective_scheduled_in AS scheduled_in,
    b5.effective_scheduled_out AS scheduled_out,
    b5.first_clock_in,
    b5.last_clock_out,
	b5.scheduled_ot_cap_minutes,
    b5.worked_minutes,
    b5.payload_ot_minutes,
    b5.absence_minutes,
    b5.required_work_minutes,
    b5.recomputed_worked_minutes,
    b5.recomputed_worked_hours,
    b5.use_mode,
    b5.temp_duration_minutes,
    b5.temp_work_time_duration,
    b5.temp_break_minutes,
    b5.ot_eligible_flag,

    b5.has_temp_schedule,
    b5.has_assigned_schedule,
    b5.schedule_source,

    b5.base_schedule_source,
    b5.base_shift_id,
    b5.base_time_interval_id,
    b5.base_required_work_minutes,
    b5.effective_required_work_minutes,
    cfg.WorkCompletionToleranceMinutes,
    b5.resolved_schedule_source,
    b5.effective_shift_id,
    b5.effective_time_interval_id,
    b5.resolved_is_off_day,

    b5.schedule_type,
    b5.effective_ot_eligible,
    b5.scheduled_payable_minutes,
    CAST(b5.scheduled_payable_minutes / 60.0 AS decimal(10,2)) AS scheduled_payable_hours,

    b5.regular_required_minutes,
    CAST(b5.regular_required_minutes / 60.0 AS decimal(10,2)) AS regular_required_hours,

    b5.regular_paid_minutes,
    CAST(b5.regular_paid_minutes / 60.0 AS decimal(10,2)) AS regular_paid_hours,

    b5.earned_ot_minutes AS ot_minutes,
    CAST(b5.earned_ot_minutes / 60.0 AS decimal(10,2)) AS ot_hours,

    b5.total_paid_minutes,
    CAST(b5.total_paid_minutes / 60.0 AS decimal(10,2)) AS total_paid_hours,

    b5.unpaid_excess_minutes,
    CAST(b5.unpaid_excess_minutes / 60.0 AS decimal(10,2)) AS unpaid_excess_hours,

    CAST(b5.worked_minutes / 60.0 AS decimal(10,2)) AS worked_hours,
    CAST(b5.absence_minutes / 60.0 AS decimal(10,2)) AS absence_hours,
    CAST(b5.regular_required_minutes / 60.0 AS decimal(10,2)) AS required_work_hours,

    CASE
        WHEN b5.effective_scheduled_in IS NOT NULL
         AND b5.effective_scheduled_out IS NOT NULL
        THEN CAST(
            DATEDIFF(MINUTE, b5.effective_scheduled_in, b5.effective_scheduled_out) / 60.0
            AS decimal(10,2)
        )
        ELSE CAST(0 AS decimal(10,2))
    END AS required_scheduled_hours,

    CASE
        WHEN b5.regular_required_minutes - b5.recomputed_worked_minutes > 0
        THEN CAST((b5.regular_required_minutes - b5.recomputed_worked_minutes) / 60.0 AS decimal(10,2))
        ELSE CAST(0 AS decimal(10,2))
    END AS recomputed_absence_hours,

    CAST((b5.recomputed_worked_minutes - b5.regular_required_minutes) / 60.0 AS decimal(10,2)) AS work_balance_hours,

    CASE
        WHEN b5.recomputed_worked_minutes > b5.regular_required_minutes
        THEN b5.recomputed_worked_minutes - b5.regular_required_minutes
        ELSE 0
    END AS recomputed_excess_minutes,

    CASE
        WHEN b5.recomputed_worked_minutes > b5.regular_required_minutes
        THEN CAST((b5.recomputed_worked_minutes - b5.regular_required_minutes) / 60.0 AS decimal(10,2))
        ELSE CAST(0 AS decimal(10,2))
    END AS recomputed_excess_hours,

    CASE
        WHEN b5.recomputed_worked_minutes > b5.scheduled_payable_minutes
        THEN b5.recomputed_worked_minutes - b5.scheduled_payable_minutes
        ELSE 0
    END AS excess_work_minutes,

    CASE
        WHEN b5.recomputed_worked_minutes > b5.scheduled_payable_minutes
        THEN CAST((b5.recomputed_worked_minutes - b5.scheduled_payable_minutes) / 60.0 AS decimal(10,2))
        ELSE CAST(0 AS decimal(10,2))
    END AS excess_work_hours,

    CASE
        WHEN b5.effective_scheduled_in IS NULL OR b5.first_clock_in IS NULL THEN 0
        WHEN b5.effective_required_work_minutes <= 0 THEN 0
        WHEN ISNULL(b5.use_mode, 0) = 1 THEN 0
        WHEN b5.first_clock_in > DATEADD(MINUTE, cfg.LateGrace, b5.effective_scheduled_in)
        THEN DATEDIFF(MINUTE, DATEADD(MINUTE, cfg.LateGrace, b5.effective_scheduled_in), b5.first_clock_in)
        ELSE 0
    END AS late_minutes,

    CASE
        WHEN b5.effective_scheduled_out IS NULL OR b5.last_clock_out IS NULL THEN 0
        WHEN b5.effective_required_work_minutes <= 0 THEN 0
        WHEN ISNULL(b5.use_mode, 0) = 1
        THEN
            CASE
                WHEN b5.recomputed_worked_minutes >= b5.regular_required_minutes THEN 0
                ELSE b5.regular_required_minutes - b5.recomputed_worked_minutes
            END
        WHEN b5.last_clock_out < DATEADD(MINUTE, -cfg.EarlyOutGrace, b5.effective_scheduled_out)
        THEN DATEDIFF(MINUTE, b5.last_clock_out, DATEADD(MINUTE, -cfg.EarlyOutGrace, b5.effective_scheduled_out))
        ELSE 0
    END AS early_out_minutes,

    CASE
        WHEN b5.regular_required_minutes > 0
        THEN CAST(
            CASE
                WHEN (b5.recomputed_worked_minutes * 100.0 / b5.regular_required_minutes) > 100
                THEN 100
                ELSE (b5.recomputed_worked_minutes * 100.0 / b5.regular_required_minutes)
            END AS decimal(10,2)
        )
        ELSE CAST(0 AS decimal(10,2))
    END AS work_completion_pct,

    CASE
        WHEN ISNULL(b5.scheduled_payable_minutes, 0) = 0
         AND ISNULL(b5.recomputed_worked_minutes, 0) = 0
        THEN 'Normal'

        WHEN b5.base_is_off_day = 1
         AND ISNULL(b5.recomputed_worked_minutes, 0) = 0
        THEN 'Normal'

        WHEN b5.first_clock_in IS NULL AND b5.last_clock_out IS NULL THEN 'NoPunch'
        WHEN b5.first_clock_in IS NOT NULL AND b5.last_clock_out IS NULL THEN 'MissingOut'
        WHEN b5.first_clock_in IS NULL AND b5.last_clock_out IS NOT NULL THEN 'MissingIn'

        WHEN b5.base_date_type = 1
         AND b5.schedule_source = 'Unscheduled'
         AND b5.recomputed_worked_minutes > 0
         AND b5.effective_ot_eligible = 0
        THEN 'HolidayWorkedUnscheduled'

        WHEN b5.base_is_off_day = 1
         AND b5.recomputed_worked_minutes > 0
         AND b5.effective_ot_eligible = 0
        THEN 'WorkedOnAssignedOffDay'

        WHEN b5.schedule_source = 'Unscheduled'
         AND b5.recomputed_worked_minutes > 0
         AND b5.effective_ot_eligible = 0
        THEN 'WorkedOnTrueUnscheduledDay'

        WHEN b5.effective_ot_eligible = 0
         AND b5.regular_required_minutes > 0
         AND b5.recomputed_worked_minutes > b5.regular_required_minutes + cfg.ExcessThreshold
         AND b5.schedule_source <> 'Unscheduled'
        THEN 'ExcessWorkNoOT'

        WHEN b5.recomputed_worked_minutes > cfg.MaxWorkHours * 60
        THEN 'ExcessiveWorkHours'

        WHEN b5.schedule_source <> 'Unscheduled'
         AND (b5.effective_scheduled_in IS NULL OR b5.effective_scheduled_out IS NULL)
        THEN 'MissingSchedule'

        ELSE 'Normal'
    END AS anomaly_flag,

    CASE
        WHEN ISNULL(b5.scheduled_payable_minutes, 0) = 0
         AND ISNULL(b5.recomputed_worked_minutes, 0) = 0
        THEN 0

        WHEN b5.recomputed_worked_minutes < b5.regular_required_minutes
        THEN 1

        WHEN b5.base_date_type = 1
         AND b5.schedule_source = 'Unscheduled'
         AND b5.recomputed_worked_minutes > 0
         AND b5.effective_ot_eligible = 0
        THEN 1

        WHEN b5.schedule_source = 'Unscheduled'
         AND b5.recomputed_worked_minutes > 0
         AND b5.effective_ot_eligible = 0
        THEN 1

        WHEN b5.effective_ot_eligible = 0
         AND b5.regular_required_minutes > 0
         AND b5.recomputed_worked_minutes > b5.regular_required_minutes + cfg.ExcessThreshold
         AND b5.schedule_source <> 'Unscheduled'
        THEN 1

        WHEN (
            ISNULL(b5.use_mode, 0) = 0
            AND b5.first_clock_in IS NOT NULL
            AND b5.effective_scheduled_in IS NOT NULL
            AND b5.effective_required_work_minutes > 0
            AND b5.first_clock_in > DATEADD(MINUTE, cfg.LateGrace, b5.effective_scheduled_in)
        ) THEN 1

        WHEN (
            ISNULL(b5.use_mode, 0) = 0
            AND b5.last_clock_out IS NOT NULL
            AND b5.effective_scheduled_out IS NOT NULL
            AND b5.effective_required_work_minutes > 0
            AND b5.last_clock_out < DATEADD(MINUTE, -cfg.EarlyOutGrace, b5.effective_scheduled_out)
        ) THEN 1

        ELSE 0
    END AS needs_payroll_review,

    CASE
        WHEN b5.base_date_type = 1
             AND b5.recomputed_worked_minutes > 0
             AND b5.effective_ot_eligible = 0
             AND b5.schedule_source = 'Unscheduled'
        THEN 1
        ELSE 0
    END AS comp_leave_eligible_flag,

    CASE
        WHEN b5.base_date_type = 1
             AND b5.recomputed_worked_minutes > 0
             AND b5.effective_ot_eligible = 0
             AND b5.schedule_source = 'Unscheduled'
        THEN b5.recomputed_worked_minutes
        ELSE 0
    END AS comp_leave_minutes,

    CAST(
        CASE
            WHEN b5.base_date_type = 1
                 AND b5.recomputed_worked_minutes > 0
                 AND b5.effective_ot_eligible = 0
                 AND b5.schedule_source = 'Unscheduled'
            THEN b5.recomputed_worked_minutes
            ELSE 0
        END / 60.0
    AS decimal(10,2)) AS comp_leave_hours,

    YEAR(b5.att_date) AS att_year,
    MONTH(b5.att_date) AS att_month,
    DAY(b5.att_date) AS att_day,
    DATENAME(WEEKDAY, b5.att_date) AS weekday_name
FROM base5 b5
CROSS APPLY
(
    SELECT
        ISNULL(MAX(CASE WHEN config_key = 'WorkCompletionToleranceMinutes' THEN config_value END), 0) AS WorkCompletionToleranceMinutes,
        ISNULL(MAX(CASE WHEN config_key = 'ExcessThresholdMinutes' THEN config_value END), 10) AS ExcessThreshold,
        ISNULL(MAX(CASE WHEN config_key = 'LateGraceMinutes' THEN config_value END), 5) AS LateGrace,
        ISNULL(MAX(CASE WHEN config_key = 'EarlyOutGraceMinutes' THEN config_value END), 5) AS EarlyOutGrace,
        ISNULL(MAX(CASE WHEN config_key = 'MaxWorkHours' THEN config_value END), 16) AS MaxWorkHours
    FROM dbo.custom_att_Config
) cfg;