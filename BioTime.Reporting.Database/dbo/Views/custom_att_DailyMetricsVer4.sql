

CREATE VIEW [dbo].[custom_att_DailyMetricsVer4]
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
        ISNULL(b.worked_minutes, 0) AS worked_minutes,

        -- planned OT minutes from DailyBase / timetable
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
        b.effective_scheduled_in,
        b.effective_scheduled_out,
        ISNULL(b.effective_required_work_minutes, 0) AS effective_required_work_minutes
    FROM dbo.custom_att_DailyBase b
),
base2 AS
(
    SELECT
        b1.*,

        CASE
            WHEN ISNULL(b1.use_mode, 0) = 1 THEN 'Flex'
            ELSE 'Fixed'
        END AS schedule_type,

        CASE
            WHEN b1.ot_eligible_flag = 1 THEN 1
            WHEN ISNULL(b1.use_mode, 0) = 0 AND b1.payload_ot_minutes > 0 THEN 1
            ELSE 0
        END AS effective_ot_eligible,

        CASE
            WHEN ISNULL(b1.temp_work_time_duration, 0) > 0
            THEN
                CASE
                    WHEN ISNULL(b1.temp_work_time_duration, 0) - ISNULL(b1.temp_break_minutes, 0) > 0
                    THEN ISNULL(b1.temp_work_time_duration, 0) - ISNULL(b1.temp_break_minutes, 0)
                    ELSE 0
                END
            ELSE ISNULL(b1.effective_required_work_minutes, 0)
        END AS scheduled_payable_minutes
    FROM base1 b1
),
base3 AS
(
    SELECT
        b2.*,

        -- Regular duty threshold before OT starts
        CASE
            WHEN b2.scheduled_payable_minutes - b2.payload_ot_minutes > 0
            THEN b2.scheduled_payable_minutes - b2.payload_ot_minutes
            ELSE 0
        END AS regular_required_minutes
    FROM base2 b2
),
base4 AS
(
    SELECT
        b3.*,

        -- Earned OT = actual work above regular threshold, capped by payload OT
        CASE
            WHEN b3.effective_ot_eligible = 1
             AND b3.recomputed_worked_minutes > b3.regular_required_minutes
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

        -- Regular paid minutes capped at regular duty threshold
        CASE
            WHEN b4.recomputed_worked_minutes >= b4.regular_required_minutes
            THEN b4.regular_required_minutes
            ELSE b4.recomputed_worked_minutes
        END AS regular_paid_minutes,

        -- Total paid minutes = regular paid + OT paid
        (
            CASE
                WHEN b4.recomputed_worked_minutes >= b4.regular_required_minutes
                THEN b4.regular_required_minutes
                ELSE b4.recomputed_worked_minutes
            END
            + b4.earned_ot_minutes
        ) AS total_paid_minutes,

        -- Actual work beyond full payable timetable cap
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
    b5.present_flag,
    b5.full_attendance_flag,
    b5.scheduled_in,
    b5.scheduled_out,
    b5.first_clock_in,
    b5.last_clock_out,

    -- Actual raw/attendance values
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
    b5.effective_scheduled_in,
    b5.effective_scheduled_out,
    b5.effective_required_work_minutes,

    -- Timetable/payroll rule columns
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

    -- Keep old style worked-hours field as actual worked
    CAST(b5.worked_minutes / 60.0 AS decimal(10,2)) AS worked_hours,
    CAST(b5.absence_minutes / 60.0 AS decimal(10,2)) AS absence_hours,

    -- For compatibility, required_work_hours now reflects regular required duty
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

    -- Absence measured against regular duty requirement
    CASE
        WHEN b5.regular_required_minutes - b5.recomputed_worked_minutes > 0
        THEN CAST((b5.regular_required_minutes - b5.recomputed_worked_minutes) / 60.0 AS decimal(10,2))
        ELSE CAST(0 AS decimal(10,2))
    END AS recomputed_absence_hours,

    -- Balance against regular duty threshold
    CAST((b5.recomputed_worked_minutes - b5.regular_required_minutes) / 60.0 AS decimal(10,2)) AS work_balance_hours,

    -- Excess above regular threshold
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

    -- Excess beyond full payable schedule cap
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
        WHEN ISNULL(b5.use_mode, 0) = 1 THEN 0
        WHEN b5.first_clock_in IS NULL OR b5.effective_scheduled_in IS NULL THEN 0
        WHEN b5.first_clock_in > b5.effective_scheduled_in
        THEN DATEDIFF(MINUTE, b5.effective_scheduled_in, b5.first_clock_in)
        ELSE 0
    END AS late_minutes,

    CASE
        WHEN b5.last_clock_out IS NULL OR b5.effective_scheduled_out IS NULL THEN 0
        WHEN ISNULL(b5.use_mode, 0) = 1
        THEN
            CASE
                WHEN b5.recomputed_worked_minutes >= b5.regular_required_minutes THEN 0
                ELSE b5.regular_required_minutes - b5.recomputed_worked_minutes
            END
        WHEN b5.last_clock_out < b5.effective_scheduled_out
        THEN DATEDIFF(MINUTE, b5.last_clock_out, b5.effective_scheduled_out)
        ELSE 0
    END AS early_out_minutes,

    -- Completion against regular duty only
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
        WHEN b5.first_clock_in IS NULL AND b5.last_clock_out IS NULL THEN 'NoPunch'
        WHEN b5.first_clock_in IS NOT NULL AND b5.last_clock_out IS NULL THEN 'MissingOut'
        WHEN b5.first_clock_in IS NULL AND b5.last_clock_out IS NOT NULL THEN 'MissingIn'
        WHEN b5.effective_ot_eligible = 0
         AND b5.recomputed_worked_minutes > b5.regular_required_minutes
        THEN 'ExcessWorkNoOT'
        WHEN b5.recomputed_worked_hours > 16 THEN 'ExcessiveWorkHours'
        WHEN b5.effective_scheduled_in IS NULL OR b5.effective_scheduled_out IS NULL THEN 'MissingSchedule'
        ELSE 'Normal'
    END AS anomaly_flag,

    CASE
        WHEN b5.recomputed_worked_minutes < b5.regular_required_minutes
             OR (
                b5.effective_ot_eligible = 0
                AND b5.recomputed_worked_minutes > b5.regular_required_minutes
             )
             OR (
                ISNULL(b5.use_mode, 0) = 0
                AND b5.first_clock_in IS NOT NULL
                AND b5.effective_scheduled_in IS NOT NULL
                AND b5.first_clock_in > b5.effective_scheduled_in
             )
             OR (
                ISNULL(b5.use_mode, 0) = 0
                AND b5.last_clock_out IS NOT NULL
                AND b5.effective_scheduled_out IS NOT NULL
                AND b5.last_clock_out < b5.effective_scheduled_out
             )
        THEN 1
        ELSE 0
    END AS needs_payroll_review,

    YEAR(b5.att_date) AS att_year,
    MONTH(b5.att_date) AS att_month,
    DAY(b5.att_date) AS att_day,
    DATENAME(WEEKDAY, b5.att_date) AS weekday_name
FROM base5 b5;