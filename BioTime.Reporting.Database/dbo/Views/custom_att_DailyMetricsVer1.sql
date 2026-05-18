
CREATE VIEW [dbo].[custom_att_DailyMetricsVer1]
AS
SELECT
    b.*,

    -- Core Hours
    CAST(ISNULL(b.worked_minutes, 0) / 60.0 AS decimal(10,2)) AS worked_hours,
    CAST(ISNULL(b.ot_minutes, 0) / 60.0 AS decimal(10,2)) AS ot_hours,
    CAST(ISNULL(b.absence_minutes, 0) / 60.0 AS decimal(10,2)) AS absence_hours,
    CAST(ISNULL(b.effective_required_work_minutes, 0) / 60.0 AS decimal(10,2)) AS required_work_hours,

    -- Full scheduled span
    CASE
        WHEN b.effective_scheduled_in IS NOT NULL
         AND b.effective_scheduled_out IS NOT NULL
        THEN CAST(
                DATEDIFF(
                    MINUTE,
                    b.effective_scheduled_in,
                    b.effective_scheduled_out
                ) / 60.0
                AS decimal(10,2)
             )
        ELSE CAST(0 AS decimal(10,2))
    END AS required_scheduled_hours,

    -- Schedule Type
    CASE
        WHEN ISNULL(b.use_mode, 0) = 1 THEN 'Flex'
        ELSE 'Fixed'
    END AS schedule_type,

    -- Recomputed Absence
    CASE
        WHEN ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.recomputed_worked_minutes, 0) > 0
        THEN CAST(
                (ISNULL(b.effective_required_work_minutes, 0) - ISNULL(b.recomputed_worked_minutes, 0)) / 60.0
                AS decimal(10,2)
             )
        ELSE CAST(0 AS decimal(10,2))
    END AS recomputed_absence_hours,

    -- Work Balance
    CAST(
        (ISNULL(b.recomputed_worked_minutes, 0) - ISNULL(b.effective_required_work_minutes, 0)) / 60.0
        AS decimal(10,2)
    ) AS work_balance_hours,

    -- Recomputed Excess
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

    -- Late
    CASE
        WHEN ISNULL(b.use_mode, 0) = 1 THEN 0
        WHEN b.first_clock_in IS NULL OR b.effective_scheduled_in IS NULL THEN 0
        WHEN b.first_clock_in > b.effective_scheduled_in
        THEN DATEDIFF(MINUTE, b.effective_scheduled_in, b.first_clock_in)
        ELSE 0
    END AS late_minutes,

    -- Early Out / Shortfall
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

    -- Work Completion %
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

    -- Anomaly Flag
    CASE
        WHEN b.first_clock_in IS NULL AND b.last_clock_out IS NULL THEN 'NoPunch'
        WHEN b.first_clock_in IS NOT NULL AND b.last_clock_out IS NULL THEN 'MissingOut'
        WHEN b.first_clock_in IS NULL AND b.last_clock_out IS NOT NULL THEN 'MissingIn'
        WHEN ISNULL(b.recomputed_worked_hours, 0) > 16 THEN 'ExcessiveWorkHours'
        WHEN b.effective_scheduled_in IS NULL OR b.effective_scheduled_out IS NULL THEN 'MissingSchedule'
        ELSE 'Normal'
    END AS anomaly_flag,

    -- Payroll Review Flag
    CASE
        WHEN ISNULL(b.recomputed_worked_hours, 0) < (ISNULL(b.effective_required_work_minutes, 0) / 60.0)
             OR ISNULL(b.ot_minutes, 0) > 0
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

    -- Report Helpers
    YEAR(b.att_date) AS att_year,
    MONTH(b.att_date) AS att_month,
    DAY(b.att_date) AS att_day,
    DATENAME(WEEKDAY, b.att_date) AS weekday_name

FROM dbo.custom_att_DailyBase b;