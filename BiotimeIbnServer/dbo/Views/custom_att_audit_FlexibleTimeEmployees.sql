CREATE VIEW [dbo].[custom_att_audit_FlexibleTimeEmployees]
AS
SELECT
    es.att_date,
    e.id AS emp_id,
    e.emp_code,
    e.first_name,
    e.last_name,
    LTRIM(RTRIM(
        ISNULL(e.first_name, '') +
        CASE WHEN ISNULL(e.last_name, '') <> '' THEN ' ' + e.last_name ELSE '' END
    )) AS employee_name,
    d.dept_name AS department_name,
    e.is_active,
    e.status AS employee_status,

    es.effective_schedule_source,
    CASE es.effective_schedule_source
        WHEN 'Temporary' THEN 1
        WHEN 'Employee' THEN 2
        WHEN 'Group' THEN 3
        WHEN 'Department' THEN 4
        ELSE 99
    END AS effective_schedule_priority,

    es.effective_shift_id,
    sh.alias AS effective_shift_alias,
    es.effective_time_interval_id,
    ti.alias AS effective_time_interval_alias,

    CAST('Flexible' AS varchar(30)) AS use_mode_name,
    ti.use_mode,
    ti.work_type,
    es.resolved_is_off_day,
    es.effective_required_work_minutes,
    CAST(es.effective_required_work_minutes / 60.0 AS decimal(10,2)) AS effective_required_work_hours,

    ti.in_time,
    ti.duration,
    ti.work_time_duration,
    es.effective_scheduled_in_datetime,
    es.effective_scheduled_out_datetime
FROM dbo.custom_att_fnd_EffectiveScheduleResolved es
INNER JOIN dbo.att_timeinterval ti
    ON ti.id = es.effective_time_interval_id
INNER JOIN dbo.personnel_employee e
    ON e.id = es.emp_id
LEFT JOIN dbo.personnel_department d
    ON d.id = e.department_id
LEFT JOIN dbo.att_attshift sh
    ON sh.id = es.effective_shift_id
WHERE ti.use_mode = 1
  AND ISNULL(es.resolved_is_off_day, 0) = 0
  AND ISNULL(es.effective_required_work_minutes, 0) > 0;
