




















CREATE VIEW [dbo].[custom_att_calc_DailyMetricsVer1]
AS
/*
Layer: Calculation
Role: Daily business-rule layer that derives attendance status, OT, anomalies, and payroll flags

Primary Source:
- dbo.custom_att_calc_DailyBase
- dbo.custom_att_fnd_EffectiveScheduleResolved

Purpose:
- Applies attendance business logic to daily base data
- Determines:
    • attendance_status (Present / Partial / Absent / NotRequired)
    • regular_required_minutes and regular_paid_minutes
    • overtime (ot_minutes)
    • late and early-out penalties
    • anomaly flags and payroll review flags

Key Outputs:
- attendance_status
- regular_required_minutes
- regular_paid_minutes
- ot_minutes
- late_minutes, early_out_minutes
- anomaly_flag
- needs_payroll_review

Core Design Rules (IMPORTANT):

1. FINAL DAY CLASSIFICATION USES EFFECTIVE SCHEDULE
   - resolved_is_off_day determines whether a day is:
        • Required work day
        • Off / weekend / non-required day
   - This replaces older logic based on base_is_off_day

2. TEMPORARY SCHEDULE HAS HIGHEST PRIORITY
   - If a Temporary schedule exists:
        • Its TimeTable determines required work minutes
        • It overrides Employee / Group / Department schedule
   - A Temporary working TimeTable on a base off-day becomes a Regular workday

3. BASE SCHEDULE IS FOR REFERENCE ONLY
   - base_is_off_day and base_required_work_minutes are retained for:
        • auditing
        • reporting context
   - They DO NOT determine final attendance status

4. REQUIRED MINUTES LOGIC
   - effective_required_work_minutes is derived from:
        • Temporary TimeTable (if present)
        • Otherwise resolved Employee/Group/Department schedule
   - regular_required_minutes is derived from effective_required_work_minutes
   - Off-days / holidays have required = 0 only when they are not overridden by Temporary, Employee, Group, or Department schedules.

5. OFF-DAY WORK HANDLING
   - resolved_is_off_day = 1 AND worked > 0
        → attendance_status = 'WorkedNonRequired'
        → anomaly_flag = 'WorkedOnAssignedOffDay'
   - This applies only when no overriding Temporary working schedule exists

6. PAYROLL REVIEW RULE
   - Off-day work without anomalies does NOT trigger payroll review
   - Only exceptional conditions trigger review (missing punch, excess work, etc.)

Used by:
- dbo.custom_att_calc_DailyAttendanceSummary

Notes:
- This is the primary business-rule engine of the system
- All attendance classification logic should live here
- Avoid duplicating logic in reporting procedures or views
- Logic assumes EffectiveScheduleResolved already provides correct schedule resolution
*/

WITH punch_agg AS
(
    SELECT
        t.emp_id,
        CAST(t.work_date AS date) AS att_date,

        COUNT(*) AS punch_count,

        MIN(CASE WHEN t.corrected_punch_state = 0 THEN t.punch_time END) AS first_in,
        MAX(CASE WHEN t.corrected_punch_state = 1 THEN t.punch_time END) AS last_out,

        MIN(t.punch_time) AS first_any_punch,
        MAX(t.punch_time) AS last_any_punch
    FROM dbo.custom_att_fnd_CleanedPunches_Corrected t
    GROUP BY
        t.emp_id,
        CAST(t.work_date AS date)
),
corrected_pairs AS
(
    SELECT
        t.emp_id,
        CAST(t.work_date AS date) AS att_date,
        t.punch_time AS in_time,
        LEAD(t.punch_time) OVER (
            PARTITION BY t.emp_id, t.work_date
            ORDER BY t.punch_time, t.id
        ) AS out_time,
        t.corrected_punch_state,
        LEAD(t.corrected_punch_state) OVER (
            PARTITION BY t.emp_id, t.work_date
            ORDER BY t.punch_time, t.id
        ) AS next_punch_state
    FROM dbo.custom_att_fnd_CleanedPunches_Corrected t
),
corrected_worked AS
(
    SELECT
        emp_id,
        att_date,
        SUM(DATEDIFF(MINUTE, in_time, out_time)) AS corrected_worked_minutes
    FROM corrected_pairs
    WHERE corrected_punch_state = 0
      AND next_punch_state = 1
      AND out_time IS NOT NULL
    GROUP BY
        emp_id,
        att_date
),
base1 AS
(
    SELECT
        b.emp_id,
        b.att_date,
        b.date_type,
        b.present_flag,
        b.full_attendance_flag,
        b.scheduled_in,
        b.scheduled_out,
        CASE
			WHEN p.first_in IS NOT NULL THEN p.first_in
			WHEN ISNULL(p.punch_count, 0) >= 1 THEN p.first_any_punch
			ELSE b.first_clock_in
		END AS first_clock_in,

		CASE
			WHEN p.last_out IS NOT NULL THEN p.last_out
			ELSE b.last_clock_out
		END AS last_clock_out,

		ISNULL(p.punch_count, 0) AS punch_count,
		b.scheduled_ot_cap_minutes,
        ISNULL(b.worked_minutes, 0) AS worked_minutes,

        ISNULL(b.ot_minutes, 0) AS payload_ot_minutes,
        ISNULL(b.absence_minutes, 0) AS absence_minutes,
        ISNULL(b.required_work_minutes, 0) AS required_work_minutes,
		ISNULL(cw.corrected_worked_minutes, ISNULL(b.recomputed_worked_minutes, 0)) AS recomputed_worked_minutes,

		CAST(
			ISNULL(cw.corrected_worked_minutes, ISNULL(b.recomputed_worked_minutes, 0)) / 60.0
			AS decimal(10,2)
		) AS recomputed_worked_hours,

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
			-- Temporary schedule with required minutes overrides holiday/off-day
			WHEN esr.effective_schedule_source = 'Temporary'
				 AND ISNULL(esr.effective_required_work_minutes, 0) > 0
				 AND ISNULL(b.use_mode, 0) = 1
				THEN ISNULL(NULLIF(b.temp_work_time_duration, 0), esr.effective_required_work_minutes)

			WHEN esr.effective_schedule_source = 'Temporary'
				 AND ISNULL(esr.effective_required_work_minutes, 0) > 0
				THEN esr.effective_required_work_minutes

			-- Temporary OT-only / non-required schedule
			WHEN esr.effective_schedule_source = 'Temporary'
				THEN 0

			-- Normal schedules
			WHEN esr.effective_schedule_source IN ('Employee', 'Group', 'Department')
				THEN ISNULL(esr.effective_required_work_minutes, 0)

			-- Holiday only if not overridden
			WHEN b.date_type = 1 THEN 0

			-- Off-day only if not overridden
			WHEN ISNULL(esr.resolved_is_off_day, 0) = 1 THEN 0

			-- fallback
			ELSE ISNULL(b.required_work_minutes, 0)
		END AS effective_required_work_minutes

    FROM dbo.custom_att_calc_DailyBase b
	LEFT JOIN punch_agg p
		ON p.emp_id = b.emp_id AND p.att_date = b.att_date
    LEFT JOIN dbo.custom_att_fnd_EffectiveScheduleResolved esr
        ON esr.emp_id = b.emp_id AND esr.att_date = b.att_date
	LEFT JOIN corrected_worked cw
		ON cw.emp_id = b.emp_id
		AND cw.att_date = b.att_date
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
			WHEN ISNULL(b2.effective_required_work_minutes, 0) <= 0 THEN 0

			-- Temporary required schedule should stay regular required work
			WHEN b2.resolved_schedule_source = 'Temporary'
				 AND ISNULL(b2.effective_required_work_minutes, 0) > 0
				THEN ISNULL(b2.effective_required_work_minutes, 0)

			-- For non-temporary schedules, subtract payload OT if applicable
			WHEN ISNULL(b2.payload_ot_minutes, 0) > 0 THEN
				CASE
					WHEN ISNULL(b2.effective_required_work_minutes, 0) - ISNULL(b2.payload_ot_minutes, 0) > 0
						THEN ISNULL(b2.effective_required_work_minutes, 0) - ISNULL(b2.payload_ot_minutes, 0)
					ELSE 0
				END

			ELSE ISNULL(b2.effective_required_work_minutes, 0)
		END AS regular_required_minutes
    FROM base2 b2
),
auto_break_deduct AS
(
    SELECT
        b3.emp_id,
        b3.att_date,
        SUM(
            CASE
                WHEN bt.calc_type = 0
                 AND b3.first_clock_in IS NOT NULL
                 AND b3.last_clock_out IS NOT NULL
                 AND b3.first_clock_in < DATEADD(MINUTE, bt.duration,
                        DATEADD(MINUTE, DATEDIFF(MINUTE, CAST('00:00:00' AS time), bt.period_start), CAST(b3.att_date AS datetime)))
                 AND b3.last_clock_out > DATEADD(MINUTE, DATEDIFF(MINUTE, CAST('00:00:00' AS time), bt.period_start), CAST(b3.att_date AS datetime))
                THEN
                    DATEDIFF(
                        MINUTE,
                        CASE
                            WHEN b3.first_clock_in >
                                 DATEADD(MINUTE, DATEDIFF(MINUTE, CAST('00:00:00' AS time), bt.period_start), CAST(b3.att_date AS datetime))
                            THEN b3.first_clock_in
                            ELSE DATEADD(MINUTE, DATEDIFF(MINUTE, CAST('00:00:00' AS time), bt.period_start), CAST(b3.att_date AS datetime))
                        END,
                        CASE
                            WHEN b3.last_clock_out <
                                 DATEADD(MINUTE, bt.duration,
                                    DATEADD(MINUTE, DATEDIFF(MINUTE, CAST('00:00:00' AS time), bt.period_start), CAST(b3.att_date AS datetime)))
                            THEN b3.last_clock_out
                            ELSE DATEADD(MINUTE, bt.duration,
                                    DATEADD(MINUTE, DATEDIFF(MINUTE, CAST('00:00:00' AS time), bt.period_start), CAST(b3.att_date AS datetime)))
                        END
                    )
                ELSE 0
            END
        ) AS auto_deduct_break_minutes
    FROM base3 b3
    LEFT JOIN dbo.att_timeinterval_break_time tib
        ON tib.timeinterval_id = b3.effective_time_interval_id
    LEFT JOIN dbo.att_breaktime bt
        ON bt.id = tib.breaktime_id
    GROUP BY
        b3.emp_id,
        b3.att_date
),
base3_fixed AS
(
    SELECT
        b3.*,

        ISNULL(ab.auto_deduct_break_minutes, 0) AS auto_deduct_break_minutes,

        b3.recomputed_worked_minutes AS raw_recomputed_worked_minutes,

        CASE
            WHEN b3.recomputed_worked_minutes - ISNULL(ab.auto_deduct_break_minutes, 0) < 0
            THEN 0
            ELSE b3.recomputed_worked_minutes - ISNULL(ab.auto_deduct_break_minutes, 0)
        END AS adjusted_recomputed_worked_minutes,

        CAST(
            CASE
                WHEN b3.recomputed_worked_minutes - ISNULL(ab.auto_deduct_break_minutes, 0) < 0
                THEN 0
                ELSE b3.recomputed_worked_minutes - ISNULL(ab.auto_deduct_break_minutes, 0)
            END / 60.0
        AS decimal(10,2)) AS adjusted_recomputed_worked_hours

    FROM base3 b3
    LEFT JOIN auto_break_deduct ab
        ON ab.emp_id = b3.emp_id
       AND ab.att_date = b3.att_date
),
base4 AS
(
    SELECT
        b3.*,

        CASE
            -- ✅ FIX: RestDayOT → use worked minutes capped by temp/day max
			WHEN b3.resolved_is_off_day = 1
				 AND ISNULL(b3.regular_required_minutes, 0) = 0
				 AND ISNULL(b3.adjusted_recomputed_worked_minutes, 0) > 0
            THEN
                CASE
                    WHEN b3.adjusted_recomputed_worked_minutes >
						 ISNULL(
							 NULLIF(b3.temp_duration_minutes - b3.temp_break_minutes, 0),
							 b3.temp_duration_minutes
						 )
					THEN ISNULL(
							 NULLIF(b3.temp_duration_minutes - b3.temp_break_minutes, 0),
							 b3.temp_duration_minutes
						 )
					ELSE b3.adjusted_recomputed_worked_minutes
                END

            -- Existing logic (UNCHANGED)
            WHEN b3.adjusted_recomputed_worked_minutes > b3.regular_required_minutes
            THEN
                CASE
                    WHEN b3.adjusted_recomputed_worked_minutes - b3.regular_required_minutes > b3.payload_ot_minutes
                        THEN b3.payload_ot_minutes
                    ELSE b3.adjusted_recomputed_worked_minutes - b3.regular_required_minutes
                END

            ELSE 0
        END AS earned_ot_minutes

    FROM base3_fixed b3
),
base5 AS
(
    SELECT
        b4.*,

        CASE
            WHEN b4.adjusted_recomputed_worked_minutes >= b4.regular_required_minutes
                THEN b4.regular_required_minutes
            ELSE b4.adjusted_recomputed_worked_minutes
        END AS regular_paid_minutes,

        (
            CASE
                WHEN b4.adjusted_recomputed_worked_minutes >= b4.regular_required_minutes
                    THEN b4.regular_required_minutes
                ELSE b4.adjusted_recomputed_worked_minutes
            END
            + b4.earned_ot_minutes
        ) AS total_paid_minutes,

        CASE
            WHEN b4.adjusted_recomputed_worked_minutes > b4.scheduled_payable_minutes
                THEN b4.adjusted_recomputed_worked_minutes - b4.scheduled_payable_minutes
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
	b5.punch_count,
	b5.scheduled_ot_cap_minutes,
    b5.worked_minutes,
    b5.payload_ot_minutes,
    b5.absence_minutes,
    b5.required_work_minutes,
	b5.raw_recomputed_worked_minutes,
	CAST(b5.raw_recomputed_worked_minutes / 60.0 AS decimal(10,2)) AS raw_recomputed_worked_hours,

	b5.auto_deduct_break_minutes,
	CAST(b5.auto_deduct_break_minutes / 60.0 AS decimal(10,2)) AS auto_deduct_break_hours,

	b5.adjusted_recomputed_worked_minutes AS recomputed_worked_minutes,
	b5.adjusted_recomputed_worked_hours AS recomputed_worked_hours,
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
        WHEN b5.regular_required_minutes - b5.adjusted_recomputed_worked_minutes > 0
        THEN CAST((b5.regular_required_minutes - b5.adjusted_recomputed_worked_minutes) / 60.0 AS decimal(10,2))
        ELSE CAST(0 AS decimal(10,2))
    END AS recomputed_absence_hours,

    CAST((b5.adjusted_recomputed_worked_minutes - b5.regular_required_minutes) / 60.0 AS decimal(10,2)) AS work_balance_hours,

    CASE
        WHEN b5.adjusted_recomputed_worked_minutes > b5.regular_required_minutes
        THEN b5.adjusted_recomputed_worked_minutes - b5.regular_required_minutes
        ELSE 0
    END AS recomputed_excess_minutes,

    CASE
        WHEN b5.adjusted_recomputed_worked_minutes > b5.regular_required_minutes
        THEN CAST((b5.adjusted_recomputed_worked_minutes - b5.regular_required_minutes) / 60.0 AS decimal(10,2))
        ELSE CAST(0 AS decimal(10,2))
    END AS recomputed_excess_hours,

    CASE
        WHEN b5.adjusted_recomputed_worked_minutes > b5.scheduled_payable_minutes
        THEN b5.adjusted_recomputed_worked_minutes - b5.scheduled_payable_minutes
        ELSE 0
    END AS excess_work_minutes,

    CASE
        WHEN b5.adjusted_recomputed_worked_minutes > b5.scheduled_payable_minutes
        THEN CAST((b5.adjusted_recomputed_worked_minutes - b5.scheduled_payable_minutes) / 60.0 AS decimal(10,2))
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
                WHEN b5.adjusted_recomputed_worked_minutes >= b5.regular_required_minutes THEN 0
                ELSE b5.regular_required_minutes - b5.adjusted_recomputed_worked_minutes
            END
        WHEN b5.last_clock_out < DATEADD(MINUTE, -cfg.EarlyOutGrace, b5.effective_scheduled_out)
        THEN DATEDIFF(MINUTE, b5.last_clock_out, DATEADD(MINUTE, -cfg.EarlyOutGrace, b5.effective_scheduled_out))
        ELSE 0
    END AS early_out_minutes,

    CASE
        WHEN b5.regular_required_minutes > 0
        THEN CAST(
            CASE
                WHEN (b5.adjusted_recomputed_worked_minutes * 100.0 / b5.regular_required_minutes) > 100
                THEN 100
                ELSE (b5.adjusted_recomputed_worked_minutes * 100.0 / b5.regular_required_minutes)
            END AS decimal(10,2)
        )
        ELSE CAST(0 AS decimal(10,2))
    END AS work_completion_pct,

	CASE
		-- No required work and no work done
		WHEN ISNULL(b5.regular_required_minutes, 0) = 0
			 AND ISNULL(b5.adjusted_recomputed_worked_minutes, 0) = 0
		THEN 'NotRequired'

		-- Worked on off day / weekend / holiday / OT-only day
		WHEN ISNULL(b5.regular_required_minutes, 0) = 0
			 AND ISNULL(b5.adjusted_recomputed_worked_minutes, 0) > 0
		THEN 'WorkedNonRequired'

		-- Full or completed required work
		WHEN b5.regular_required_minutes > 0
			 AND b5.adjusted_recomputed_worked_minutes >= b5.regular_required_minutes
		THEN 'Present'

		WHEN b5.regular_required_minutes > 0
			 AND ISNULL(b5.punch_count, 0) >= 1
			 AND b5.adjusted_recomputed_worked_minutes = 0
			THEN 'Incomplete'

		-- No punch on required workday
		WHEN b5.regular_required_minutes > 0
			 AND b5.adjusted_recomputed_worked_minutes = 0
		THEN 'Absent'

		-- Worked but shortfall is within tolerance
		WHEN b5.regular_required_minutes > 0
			 AND b5.adjusted_recomputed_worked_minutes > 0
			 AND calc.shortfall_minutes <= cfg.WorkCompletionToleranceMinutes
		THEN 'PartialWithinTolerance'

		-- Worked but shortfall is beyond tolerance
		WHEN b5.regular_required_minutes > 0
			 AND b5.adjusted_recomputed_worked_minutes > 0
			 AND calc.shortfall_minutes > cfg.WorkCompletionToleranceMinutes
		THEN 'Incomplete'

		ELSE 'Unknown'
	END AS attendance_status,


    CASE
        WHEN ISNULL(b5.scheduled_payable_minutes, 0) = 0
         AND ISNULL(b5.adjusted_recomputed_worked_minutes, 0) = 0
        THEN 'Normal'

		WHEN b5.resolved_is_off_day = 1
		 AND ISNULL(b5.adjusted_recomputed_worked_minutes, 0) = 0
		THEN 'Normal'

		WHEN ISNULL(b5.punch_count, 0) = 1
		 AND b5.regular_required_minutes > 0
 		 THEN 'MissingOut'

		WHEN b5.first_clock_in IS NULL
		 AND b5.last_clock_out IS NULL
		 AND b5.regular_required_minutes > 0
		 AND calc.shortfall_minutes > cfg.WorkCompletionToleranceMinutes
		THEN 'NoPunch'
        WHEN b5.first_clock_in IS NOT NULL AND b5.last_clock_out IS NULL THEN 'MissingOut'
        WHEN b5.first_clock_in IS NULL AND b5.last_clock_out IS NOT NULL THEN 'MissingIn'
		WHEN b5.regular_required_minutes > 0
		 AND calc.shortfall_minutes > cfg.WorkCompletionToleranceMinutes
		THEN 'IncompleteWork'

        WHEN b5.base_date_type = 1
         AND b5.schedule_source = 'Unscheduled'
         AND b5.adjusted_recomputed_worked_minutes > 0
         AND b5.effective_ot_eligible = 0
        THEN 'HolidayWorkedUnscheduled'

		WHEN b5.resolved_is_off_day = 1
		 AND b5.adjusted_recomputed_worked_minutes > 0
		 AND b5.effective_ot_eligible = 0
		THEN 'WorkedOnAssignedOffDay'

        WHEN b5.schedule_source = 'Unscheduled'
         AND b5.adjusted_recomputed_worked_minutes > 0
         AND b5.effective_ot_eligible = 0
        THEN 'WorkedOnTrueUnscheduledDay'

        --WHEN b5.effective_ot_eligible = 0
        -- AND b5.regular_required_minutes > 0
        -- AND b5.adjusted_recomputed_worked_minutes > b5.regular_required_minutes + cfg.ExcessThreshold
        -- AND b5.schedule_source <> 'Unscheduled'
        --THEN 'ExcessWorkNoOT'

        WHEN b5.adjusted_recomputed_worked_minutes > cfg.MaxWorkHours * 60
        THEN 'ExcessiveWorkHours'

        WHEN b5.schedule_source <> 'Unscheduled'
         AND (b5.effective_scheduled_in IS NULL OR b5.effective_scheduled_out IS NULL)
        THEN 'MissingSchedule'

        ELSE 'Normal'
    END AS anomaly_flag,

	CASE
		-- Not required day, no work = no review
		WHEN ISNULL(b5.scheduled_payable_minutes, 0) = 0
			 AND ISNULL(b5.adjusted_recomputed_worked_minutes, 0) = 0
		THEN 0

		-- OFF / Weekend no work = no review
		WHEN b5.resolved_is_off_day = 1
		 AND ISNULL(b5.adjusted_recomputed_worked_minutes, 0) = 0
		THEN 0

		-- Missing punch = review
		WHEN b5.first_clock_in IS NOT NULL
			 AND b5.last_clock_out IS NULL
		THEN 1

		WHEN b5.first_clock_in IS NULL
			 AND b5.last_clock_out IS NOT NULL
		THEN 1

		-- Incomplete work beyond tolerance = review
		WHEN b5.regular_required_minutes > 0
			 AND calc.shortfall_minutes > cfg.WorkCompletionToleranceMinutes
		THEN 1

		-- Holiday worked unscheduled without OT eligibility = review
		WHEN b5.base_date_type = 1
			 AND b5.schedule_source = 'Unscheduled'
			 AND b5.adjusted_recomputed_worked_minutes > 0
			 AND b5.effective_ot_eligible = 0
		THEN 1

		-- Unscheduled work without OT eligibility = review
		WHEN b5.schedule_source = 'Unscheduled'
			 AND b5.adjusted_recomputed_worked_minutes > 0
			 AND b5.effective_ot_eligible = 0
		THEN 1

		-- Excess work without OT eligibility = review
		WHEN b5.effective_ot_eligible = 0
			 AND b5.regular_required_minutes > 0
			 AND b5.adjusted_recomputed_worked_minutes > b5.regular_required_minutes + cfg.ExcessThreshold
			 AND b5.schedule_source <> 'Unscheduled'
		THEN 1

		ELSE 0
	END AS needs_payroll_review,

    CASE
        WHEN b5.base_date_type = 1
             AND b5.adjusted_recomputed_worked_minutes > 0
             AND b5.effective_ot_eligible = 0
             AND b5.schedule_source = 'Unscheduled'
        THEN 1
        ELSE 0
    END AS comp_leave_eligible_flag,

    CASE
        WHEN b5.base_date_type = 1
             AND b5.adjusted_recomputed_worked_minutes > 0
             AND b5.effective_ot_eligible = 0
             AND b5.schedule_source = 'Unscheduled'
        THEN b5.adjusted_recomputed_worked_minutes
        ELSE 0
    END AS comp_leave_minutes,

    CAST(
        CASE
            WHEN b5.base_date_type = 1
                 AND b5.adjusted_recomputed_worked_minutes > 0
                 AND b5.effective_ot_eligible = 0
                 AND b5.schedule_source = 'Unscheduled'
            THEN b5.adjusted_recomputed_worked_minutes
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
) cfg
CROSS APPLY
(
    SELECT
        CASE
            WHEN b5.regular_required_minutes - b5.adjusted_recomputed_worked_minutes > 0
            THEN b5.regular_required_minutes - b5.adjusted_recomputed_worked_minutes
            ELSE 0
        END AS shortfall_minutes
) calc;
