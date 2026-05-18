

create VIEW [dbo].[custom_att_DailyMetricsVer3]
AS
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
    b.worked_minutes,

    -- keep original payload OT separately for audit only
    b.ot_minutes AS payload_ot_minutes,

    b.absence_minutes,
    b.required_work_minutes,
    b.recomputed_worked_minutes,
    b.recomputed_worked_hours,
    b.use_mode,
    b.temp_duration_minutes,
    b.temp_work_time_duration,
    b.temp_break_minutes,
    b.ot_eligible_flag,
    b.effective_scheduled_in,
    b.effective_scheduled_out,
    b.effective_required_work_minutes,

    CAST(ISNULL(b.worked_minutes, 0) / 60.0 AS decimal(10,2)) AS worked_hours,

    -- Payable OT only on OT-eligible days
	    -- Payable OT on OT-eligible days only
    -- b.ot_minutes here is the planned/scheduled OT minutes coming from DailyBase
    CASE
        WHEN ISNULL(b.ot_eligible_flag, 0) = 1
        THEN
            CASE
                WHEN ISNULL(b.recomputed_worked_minutes, 0) >
                     CASE
                         WHEN ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.ot_minutes, 0) < 0
                         THEN 0
                         ELSE ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.ot_minutes, 0)
                     END
                THEN
                    CASE
                        WHEN
                            ISNULL(b.recomputed_worked_minutes, 0)
                            -
                            CASE
                                WHEN ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.ot_minutes, 0) < 0
                                THEN 0
                                ELSE ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.ot_minutes, 0)
                            END
                            > ISNULL(b.ot_minutes, 0)
                        THEN ISNULL(b.ot_minutes, 0)
                        ELSE
                            ISNULL(b.recomputed_worked_minutes, 0)
                            -
                            CASE
                                WHEN ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.ot_minutes, 0) < 0
                                THEN 0
                                ELSE ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.ot_minutes, 0)
                            END
                    END
                ELSE 0
            END
        ELSE 0
    END AS ot_minutes,

    CASE
        WHEN ISNULL(b.ot_eligible_flag, 0) = 1
        THEN
            CAST(
                CASE
                    WHEN ISNULL(b.recomputed_worked_minutes, 0) >
                         CASE
                             WHEN ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.ot_minutes, 0) < 0
                             THEN 0
                             ELSE ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.ot_minutes, 0)
                         END
                    THEN
                        CASE
                            WHEN
                                ISNULL(b.recomputed_worked_minutes, 0)
                                -
                                CASE
                                    WHEN ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.ot_minutes, 0) < 0
                                    THEN 0
                                    ELSE ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.ot_minutes, 0)
                                END
                                > ISNULL(b.ot_minutes, 0)
                            THEN ISNULL(b.ot_minutes, 0)
                            ELSE
                                ISNULL(b.recomputed_worked_minutes, 0)
                                -
                                CASE
                                    WHEN ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.ot_minutes, 0) < 0
                                    THEN 0
                                    ELSE ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.ot_minutes, 0)
                                END
                        END
                    ELSE 0
                END / 60.0
                AS decimal(10,2)
            )
        ELSE CAST(0 AS decimal(10,2))
    END AS ot_hours,

    -- Excess work:
    -- On OT days = only the part beyond the full scheduled requirement
    -- On non-OT days = all extra above the required work minutes
    CASE
        WHEN ISNULL(b.recomputed_worked_minutes, 0) > ISNULL(b.effective_required_work_minutes, 0)
        THEN ISNULL(b.recomputed_worked_minutes, 0) - ISNULL(b.effective_required_work_minutes, 0)
        ELSE 0
    END AS excess_work_minutes,

    CASE
        WHEN ISNULL(b.recomputed_worked_minutes, 0) > ISNULL(b.effective_required_work_minutes, 0)
        THEN CAST(
                (ISNULL(b.recomputed_worked_minutes, 0) - ISNULL(b.effective_required_work_minutes, 0)) / 60.0
                AS decimal(10,2)
             )
        ELSE CAST(0 AS decimal(10,2))
    END AS excess_work_hours,

    CAST(ISNULL(b.absence_minutes, 0) / 60.0 AS decimal(10,2)) AS absence_hours,
    CAST(ISNULL(b.effective_required_work_minutes, 0) / 60.0 AS decimal(10,2)) AS required_work_hours,

    CASE
        WHEN b.effective_scheduled_in IS NOT NULL
         AND b.effective_scheduled_out IS NOT NULL
        THEN CAST(
                DATEDIFF(MINUTE, b.effective_scheduled_in, b.effective_scheduled_out) / 60.0
                AS decimal(10,2)
             )
        ELSE CAST(0 AS decimal(10,2))
    END AS required_scheduled_hours,

    CASE
        WHEN ISNULL(b.use_mode, 0) = 1 THEN 'Flex'
        ELSE 'Fixed'
    END AS schedule_type,

    CASE
        WHEN ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.recomputed_worked_minutes, 0) > 0
        THEN CAST(
                (ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.recomputed_worked_minutes, 0)) / 60.0
                AS decimal(10,2)
             )
        ELSE CAST(0 AS decimal(10,2))
    END AS recomputed_absence_hours,

    CAST(
        (ISNULL(b.recomputed_worked_minutes, 0) - ISNULL(b.effective_required_work_minutes, 0)) / 60.0
        AS decimal(10,2)
    ) AS work_balance_hours,

    CASE
        WHEN ISNULL(b.recomputed_worked_minutes, 0) > ISNULL(b.effective_required_work_minutes, 0)
        THEN ISNULL(b.recomputed_worked_minutes, 0) - ISNULL(b.effective_required_work_minutes, 0)
        ELSE 0
    END AS recomputed_excess_minutes,

    CASE
        WHEN ISNULL(b.recomputed_worked_minutes, 0) > ISNULL(b.effective_required_work_minutes, 0)
        THEN CAST(
                (ISNULL(b.recomputed_worked_minutes, 0) - ISNULL(b.effective_required_work_minutes, 0)) / 60.0
                AS decimal(10,2)
             )
        ELSE CAST(0 AS decimal(10,2))
    END AS recomputed_excess_hours,

    CASE
        WHEN ISNULL(b.use_mode, 0) = 1 THEN 0
        WHEN b.first_clock_in IS NULL OR b.effective_scheduled_in IS NULL THEN 0
        WHEN b.first_clock_in > b.effective_scheduled_in
        THEN DATEDIFF(MINUTE, b.effective_scheduled_in, b.first_clock_in)
        ELSE 0
    END AS late_minutes,

    CASE
        WHEN b.last_clock_out IS NULL OR b.effective_scheduled_out IS NULL
        THEN 0
        WHEN ISNULL(b.use_mode, 0) = 1
        THEN
            CASE
                WHEN ISNULL(b.recomputed_worked_minutes, 0) >= ISNULL(b.effective_required_work_minutes, 0)
                THEN 0
                ELSE ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.recomputed_worked_minutes, 0)
            END
        WHEN b.last_clock_out < b.effective_scheduled_out
        THEN DATEDIFF(MINUTE, b.last_clock_out, b.effective_scheduled_out)
        ELSE 0
    END AS early_out_minutes,

    CASE
        WHEN ISNULL(b.effective_required_work_minutes, 0) > 0
        THEN CAST(
                CASE
                    WHEN (ISNULL(b.recomputed_worked_minutes, 0) * 100.0 / ISNULL(b.effective_required_work_minutes, 0)) > 100
                    THEN 100
                    ELSE (ISNULL(b.recomputed_worked_minutes, 0) * 100.0 / ISNULL(b.effective_required_work_minutes, 0))
                END
                AS decimal(10,2)
             )
        ELSE CAST(0 AS decimal(10,2))
    END AS work_completion_pct,

    CASE
        WHEN b.first_clock_in IS NULL AND b.last_clock_out IS NULL THEN 'NoPunch'
        WHEN b.first_clock_in IS NOT NULL AND b.last_clock_out IS NULL THEN 'MissingOut'
        WHEN b.first_clock_in IS NULL AND b.last_clock_out IS NOT NULL THEN 'MissingIn'
        WHEN ISNULL(b.ot_eligible_flag, 0) = 0
         AND ISNULL(b.recomputed_worked_minutes, 0) > ISNULL(b.effective_required_work_minutes, 0)
        THEN 'ExcessWorkNoOT'
        WHEN ISNULL(b.recomputed_worked_hours, 0) > 16 THEN 'ExcessiveWorkHours'
        WHEN b.effective_scheduled_in IS NULL OR b.effective_scheduled_out IS NULL THEN 'MissingSchedule'
        ELSE 'Normal'
    END AS anomaly_flag,

    CASE
        WHEN ISNULL(b.recomputed_worked_hours, 0) < (ISNULL(b.effective_required_work_minutes, 0) / 60.0)
             OR (
                ISNULL(b.ot_eligible_flag, 0) = 1
                AND ISNULL(b.recomputed_worked_minutes, 0) > ISNULL(b.effective_required_work_minutes, 0)
             )
             OR (
                ISNULL(b.ot_eligible_flag, 0) = 0
                AND ISNULL(b.recomputed_worked_minutes, 0) > ISNULL(b.effective_required_work_minutes, 0)
             )
             OR (
                ISNULL(b.use_mode, 0) = 0
                AND b.first_clock_in IS NOT NULL
                AND b.effective_scheduled_in IS NOT NULL
                AND b.first_clock_in > b.effective_scheduled_in
             )
             OR (
                ISNULL(b.use_mode, 0) = 0
                AND b.last_clock_out IS NOT NULL
                AND b.effective_scheduled_out IS NOT NULL
                AND b.last_clock_out < b.effective_scheduled_out
             )
        THEN 1
        ELSE 0
    END AS needs_payroll_review,

    YEAR(b.att_date) AS att_year,
    MONTH(b.att_date) AS att_month,
    DAY(b.att_date) AS att_day,
    DATENAME(WEEKDAY, b.att_date) AS weekday_name
FROM dbo.custom_att_DailyBase b;