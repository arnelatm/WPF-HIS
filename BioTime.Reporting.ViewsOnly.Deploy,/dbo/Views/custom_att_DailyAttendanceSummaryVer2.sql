CREATE VIEW dbo.[custom_att_DailyAttendanceSummaryVer2]
AS
WITH tc AS
(
    SELECT
        t.emp_id,
        t.att_date,
        MAX(t.date_type) AS date_type,

        COUNT(*) AS timecard_rows,
        SUM(ISNULL(t.work_day, 0)) AS total_workday,

        MAX(t.present) AS present_flag,
        MAX(t.full_attendance) AS full_attendance_flag,

        MIN(t.check_in) AS scheduled_in,
        MAX(t.check_out) AS scheduled_out,

        MIN(t.clock_in) AS first_clock_in,
        MAX(t.clock_out) AS last_clock_out,

        SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'worked_hrs')) AS worked_minutes,
        SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'total_ot')) AS ot_minutes,
        SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'remaining')) AS absence_minutes
    FROM dbo.att_payloadtimecard t
    GROUP BY
        t.emp_id,
        t.att_date
),
ps AS
(
    SELECT
        p.emp_id,
        p.att_date,
        COUNT(*) AS pair_rows,
        SUM(CASE WHEN p.in_trans_id IS NULL OR p.out_trans_id IS NULL THEN 1 ELSE 0 END) AS missing_pair_rows,
        SUM(CASE WHEN p.in_trans_id IS NULL AND p.out_trans_id IS NOT NULL THEN 1 ELSE 0 END) AS missing_in_rows,
        SUM(CASE WHEN p.in_trans_id IS NOT NULL AND p.out_trans_id IS NULL THEN 1 ELSE 0 END) AS missing_out_rows,
        SUM(CASE WHEN p.in_trans_id IS NOT NULL OR p.out_trans_id IS NOT NULL THEN 1 ELSE 0 END) AS nonblank_pair_rows,
        SUM(ISNULL(p.duration, 0)) AS paired_duration_seconds,
        SUM(ISNULL(p.worked_duration, 0)) AS paired_worked_duration_seconds
    FROM dbo.att_payloadparing p
    GROUP BY
        p.emp_id,
        p.att_date
)
SELECT
    tc.emp_id,
    tc.att_date,
    tc.date_type,

    tc.timecard_rows,
    tc.total_workday,
    tc.present_flag,
    tc.full_attendance_flag,

    tc.scheduled_in,
    tc.scheduled_out,
    tc.first_clock_in,
    tc.last_clock_out,

    tc.worked_minutes,
    tc.ot_minutes,
    tc.absence_minutes,

    CAST(tc.worked_minutes / 60.0 AS decimal(10,2)) AS worked_hours,
    CAST(tc.ot_minutes / 60.0 AS decimal(10,2)) AS ot_hours,
    CAST(tc.absence_minutes / 60.0 AS decimal(10,2)) AS absence_hours,

    -- ✅ NEW: daily regular hours
    CASE
        WHEN (tc.worked_minutes - tc.ot_minutes) < 0 THEN 0
        ELSE CAST((tc.worked_minutes - tc.ot_minutes) / 60.0 AS decimal(10,2))
    END AS regular_only_hours,

    ISNULL(ps.pair_rows, 0) AS pair_rows,
    ISNULL(ps.missing_pair_rows, 0) AS missing_pair_rows,
    ISNULL(ps.missing_in_rows, 0) AS missing_in_rows,
    ISNULL(ps.missing_out_rows, 0) AS missing_out_rows,
    ISNULL(ps.nonblank_pair_rows, 0) AS nonblank_pair_rows,
    ISNULL(ps.paired_duration_seconds, 0) AS paired_duration_seconds,
    ISNULL(ps.paired_worked_duration_seconds, 0) AS paired_worked_duration_seconds,

    CASE
        WHEN tc.present_flag = 1 THEN 1
        ELSE 0
    END AS is_present,

    CASE
        WHEN tc.present_flag = 0 THEN 1
        ELSE 0
    END AS is_absent,

    CASE
        WHEN ISNULL(ps.missing_pair_rows, 0) > 0 THEN 1
        ELSE 0
    END AS has_missing_punch,

    CASE
        WHEN ISNULL(ps.nonblank_pair_rows, 0) = 1 THEN 1
        ELSE 0
    END AS has_single_pair,

    CASE
        WHEN tc.first_clock_in IS NOT NULL
         AND tc.scheduled_in IS NOT NULL
         AND tc.first_clock_in > tc.scheduled_in
        THEN DATEDIFF(MINUTE, tc.scheduled_in, tc.first_clock_in)
        ELSE 0
    END AS late_minutes,

    CASE
        WHEN tc.last_clock_out IS NOT NULL
         AND tc.scheduled_out IS NOT NULL
         AND tc.last_clock_out < tc.scheduled_out
        THEN DATEDIFF(MINUTE, tc.last_clock_out, tc.scheduled_out)
        ELSE 0
    END AS early_out_minutes

FROM tc
LEFT JOIN ps
    ON tc.emp_id = ps.emp_id
   AND tc.att_date = ps.att_date;