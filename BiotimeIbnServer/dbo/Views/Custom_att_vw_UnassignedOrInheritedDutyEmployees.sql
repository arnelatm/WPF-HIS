CREATE VIEW [dbo].[Custom_att_vw_UnassignedOrInheritedDutyEmployees]
AS
WITH Numbers AS
(
    SELECT TOP (4000)
        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
    FROM
    (
        SELECT 1 AS n FROM (VALUES (0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) AS a(n)
        CROSS JOIN (VALUES (0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) AS b(n)
        CROSS JOIN (VALUES (0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) AS c(n)
        CROSS JOIN (VALUES (0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) AS d(n)
    ) AS tally
),
DateBounds AS
(
    SELECT
        MIN(schedule_date) AS date_from,
        MAX(schedule_date) AS date_to
    FROM
    (
        SELECT CAST(GETDATE() AS date) AS schedule_date

        UNION ALL

        SELECT start_date
        FROM dbo.att_attschedule
        WHERE start_date IS NOT NULL

        UNION ALL

        SELECT end_date
        FROM dbo.att_attschedule
        WHERE end_date IS NOT NULL

        UNION ALL

        SELECT start_date
        FROM dbo.att_groupschedule
        WHERE start_date IS NOT NULL

        UNION ALL

        SELECT end_date
        FROM dbo.att_groupschedule
        WHERE end_date IS NOT NULL

        UNION ALL

        SELECT start_date
        FROM dbo.att_departmentschedule
        WHERE start_date IS NOT NULL

        UNION ALL

        SELECT end_date
        FROM dbo.att_departmentschedule
        WHERE end_date IS NOT NULL

        UNION ALL

        SELECT att_date
        FROM dbo.att_temporaryschedule
        WHERE att_date IS NOT NULL
    ) bounds
),
Dates AS
(
    SELECT DATEADD(DAY, n.n, db.date_from) AS att_date
    FROM DateBounds db
    INNER JOIN Numbers n
        ON DATEADD(DAY, n.n, db.date_from) <= db.date_to
),
EmployeeDates AS
(
    SELECT
        e.id AS emp_id,
        e.emp_code,
        LTRIM(RTRIM(
            ISNULL(e.first_name, '') +
            CASE
                WHEN ISNULL(e.last_name, '') = '' THEN ''
                ELSE ' ' + e.last_name
            END
        )) AS employee_name,
        e.department_id,
        d.dept_code,
        d.dept_name,
        ae.group_id,
        ag.code AS group_code,
        ag.name AS group_name,
        ISNULL(ae.enable_attendance, CONVERT(bit, 0)) AS enable_attendance,
        ISNULL(ae.enable_schedule, CONVERT(bit, 0)) AS enable_schedule,
        dt.att_date
    FROM dbo.personnel_employee e
    CROSS JOIN Dates dt
    LEFT JOIN dbo.personnel_department d
        ON d.id = e.department_id
    LEFT JOIN dbo.att_attemployee ae
        ON ae.emp_id = e.id
    LEFT JOIN dbo.att_attgroup ag
        ON ag.id = ae.group_id
    WHERE e.is_active = 1
      AND ISNULL(ae.enable_attendance, CONVERT(bit, 0)) = 1
      AND ISNULL(ae.enable_schedule, CONVERT(bit, 0)) = 1
      AND (e.hire_date IS NULL OR dt.att_date >= e.hire_date)
      AND NOT EXISTS
      (
          SELECT 1
          FROM dbo.personnel_resign r
          WHERE r.employee_id = e.id
            AND dt.att_date > r.resign_date
      )
)
SELECT
    ed.emp_id,
    ed.emp_code,
    ed.employee_name,
    ed.department_id,
    ed.dept_code,
    ed.dept_name,
    ed.group_id,
    ed.group_code,
    ed.group_name,
    ed.enable_attendance,
    ed.enable_schedule,
    ed.att_date,

    CASE
        WHEN es.emp_id IS NULL THEN 'No Scheduled Duty'
        ELSE es.effective_schedule_source
    END AS schedule_source,

    CASE
        WHEN es.emp_id IS NULL THEN 1
        ELSE 0
    END AS no_schedule_flag,

    CASE
        WHEN es.effective_schedule_source IN ('Group', 'Department') THEN 1
        ELSE 0
    END AS inherited_schedule_flag,

    es.effective_shift_id,
    es.effective_time_interval_id,
    ti.alias AS timetable_name,
    es.effective_scheduled_in_datetime,
    es.effective_scheduled_out_datetime,
    CAST(ISNULL(es.effective_required_work_minutes, 0) / 60.0 AS decimal(10,2)) AS required_hours,
    es.resolved_is_off_day
FROM EmployeeDates ed
LEFT JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
    ON es.emp_id = ed.emp_id
   AND es.att_date = ed.att_date
LEFT JOIN dbo.att_timeinterval ti
    ON ti.id = es.effective_time_interval_id
WHERE es.emp_id IS NULL
   OR es.effective_schedule_source IN ('Group', 'Department');
