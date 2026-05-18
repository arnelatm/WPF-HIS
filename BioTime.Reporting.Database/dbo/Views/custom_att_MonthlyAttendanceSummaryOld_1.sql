
CREATE VIEW dbo.[custom_att_MonthlyAttendanceSummaryOld]
AS
WITH daily_base AS
(
    SELECT
        d.att_date,
        d.date_type,
        d.emp_id,
        d.present_flag,
        d.first_clock_in,
        d.last_clock_out,
        d.scheduled_in,
        d.scheduled_out,
        d.worked_hours,
        d.ot_hours,
        d.absence_hours,
        d.late_minutes,
        d.early_out_minutes,
        d.has_single_pair,
        d.has_missing_punch,

        CASE
            WHEN EXISTS
            (
                SELECT 1
                FROM dbo.iclock_transaction tr
                WHERE tr.emp_id = d.emp_id
                  AND d.scheduled_in IS NOT NULL
                  AND d.scheduled_out IS NOT NULL
                  AND tr.punch_time >= DATEADD(HOUR, -3, d.scheduled_in)
                  AND tr.punch_time <= DATEADD(HOUR,  3, d.scheduled_out)
            )
            THEN 1
            ELSE 0
        END AS has_raw_punch_near_shift,

        CASE
            WHEN ISNULL(d.worked_hours, 0) - ISNULL(d.ot_hours, 0) < 0 THEN 0
            ELSE ISNULL(d.worked_hours, 0) - ISNULL(d.ot_hours, 0)
        END AS regular_only_hours
    FROM dbo.custom_att_DailyAttendanceSummary d
)
SELECT
    YEAR(db.att_date) AS year_no,
    MONTH(db.att_date) AS month_no,
    db.emp_id,

    e.emp_code AS employee_code,
    LTRIM(RTRIM(
        ISNULL(e.first_name, '') +
        CASE
            WHEN ISNULL(e.last_name, '') = '' THEN ''
            ELSE ' ' + e.last_name
        END
    )) AS employee_name,

    dept.dept_name AS department_name,

    SUM(CASE WHEN db.date_type = 0 THEN 1 ELSE 0 END) AS need_present_days,

    SUM(CASE
        WHEN db.date_type = 0
         AND (
                db.present_flag = 1
                OR ISNULL(db.worked_hours, 0) > 0
                OR db.first_clock_in IS NOT NULL
                OR db.last_clock_out IS NOT NULL
                OR db.has_raw_punch_near_shift = 1
             )
        THEN 1 ELSE 0 END) AS actual_present_days,

    SUM(CASE
        WHEN db.date_type = 0
         AND NOT (
                db.present_flag = 1
                OR ISNULL(db.worked_hours, 0) > 0
                OR db.first_clock_in IS NOT NULL
                OR db.last_clock_out IS NOT NULL
                OR db.has_raw_punch_near_shift = 1
             )
        THEN 1 ELSE 0 END) AS actual_absence_days,

    SUM(CASE
        WHEN db.date_type = 0
         AND (
                db.present_flag = 1
                OR ISNULL(db.worked_hours, 0) > 0
                OR db.first_clock_in IS NOT NULL
                OR db.last_clock_out IS NOT NULL
                OR db.has_raw_punch_near_shift = 1
             )
        THEN 1 ELSE 0 END) AS computed_present_days,

    SUM(CASE
        WHEN db.date_type = 0
         AND NOT (
                db.present_flag = 1
                OR ISNULL(db.worked_hours, 0) > 0
                OR db.first_clock_in IS NOT NULL
                OR db.last_clock_out IS NOT NULL
                OR db.has_raw_punch_near_shift = 1
             )
        THEN 1 ELSE 0 END) AS computed_absence_days,

    CAST(
        100.0 * SUM(CASE
            WHEN db.date_type = 0
             AND (
                    db.present_flag = 1
                    OR ISNULL(db.worked_hours, 0) > 0
                    OR db.first_clock_in IS NOT NULL
                    OR db.last_clock_out IS NOT NULL
                    OR db.has_raw_punch_near_shift = 1
                 )
            THEN 1 ELSE 0 END)
        / NULLIF(SUM(CASE WHEN db.date_type = 0 THEN 1 ELSE 0 END), 0)
        AS decimal(6,2)
    ) AS presence_percentage,

    CAST(
        100.0 * SUM(CASE
            WHEN db.date_type = 0
             AND NOT (
                    db.present_flag = 1
                    OR ISNULL(db.worked_hours, 0) > 0
                    OR db.first_clock_in IS NOT NULL
                    OR db.last_clock_out IS NOT NULL
                    OR db.has_raw_punch_near_shift = 1
                 )
            THEN 1 ELSE 0 END)
        / NULLIF(SUM(CASE WHEN db.date_type = 0 THEN 1 ELSE 0 END), 0)
        AS decimal(6,2)
    ) AS absence_percentage,

    -- revised split
    CAST(SUM(CASE WHEN db.date_type = 0 THEN db.regular_only_hours ELSE 0 END) AS decimal(10,1)) AS regular_hours,
    CAST(SUM(CASE WHEN db.date_type = 0 THEN db.ot_hours ELSE 0 END) AS decimal(10,1)) AS normal_ot_hours,

    SUM(CASE WHEN db.date_type = 0 THEN db.late_minutes ELSE 0 END) AS late_minutes,
    SUM(CASE WHEN db.date_type = 0 THEN db.early_out_minutes ELSE 0 END) AS early_out_minutes,
    CAST(SUM(CASE WHEN db.date_type = 0 THEN db.absence_hours ELSE 0 END) AS decimal(10,1)) AS absence_hours,

    SUM(CASE WHEN db.date_type = 0 AND db.has_single_pair = 1 THEN 1 ELSE 0 END) AS single_punch_days,
    SUM(CASE WHEN db.date_type = 0 AND db.has_missing_punch = 1 THEN 1 ELSE 0 END) AS missing_punch_days,

    SUM(CASE WHEN db.date_type = 1 THEN 1 ELSE 0 END) AS holiday_days,
    SUM(CASE WHEN db.date_type = 2 THEN 1 ELSE 0 END) AS rest_days

FROM daily_base db
LEFT JOIN dbo.personnel_employee e
    ON db.emp_id = e.id
LEFT JOIN dbo.personnel_department dept
    ON e.department_id = dept.id
GROUP BY
    YEAR(db.att_date),
    MONTH(db.att_date),
    db.emp_id,
    e.emp_code,
    e.first_name,
    e.last_name,
    dept.dept_name;