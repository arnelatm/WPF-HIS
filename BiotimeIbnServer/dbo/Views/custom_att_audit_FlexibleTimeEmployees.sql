CREATE VIEW [dbo].[custom_att_audit_FlexibleTimeEmployees]
AS
SELECT
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
    es.effective_shift_id,
    sh.alias AS effective_shift_alias,
    es.effective_time_interval_id,
    ti.alias AS effective_time_interval_alias,
    CAST('Flexible' AS varchar(30)) AS use_mode_name,
    ti.use_mode,
    ti.work_type,
    ti.in_time,
    ti.duration,
    ti.work_time_duration,

    MIN(es.att_date) AS first_flexible_schedule_date,
    MAX(es.att_date) AS last_flexible_schedule_date,
    COUNT_BIG(*) AS flexible_schedule_days
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
GROUP BY
    e.id,
    e.emp_code,
    e.first_name,
    e.last_name,
    d.dept_name,
    e.is_active,
    e.status,
    es.effective_schedule_source,
    es.effective_shift_id,
    sh.alias,
    es.effective_time_interval_id,
    ti.alias,
    ti.use_mode,
    ti.work_type,
    ti.in_time,
    ti.duration,
    ti.work_time_duration;
