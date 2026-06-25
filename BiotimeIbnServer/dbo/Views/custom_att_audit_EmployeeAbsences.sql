CREATE VIEW [dbo].[custom_att_audit_EmployeeAbsences]
AS
SELECT
    f.emp_id AS EmployeeID,
    f.emp_code AS EmployeeCode,
    CAST(
        LTRIM(RTRIM(ISNULL(e.first_name, '') + ' ' + ISNULL(e.last_name, '')))
        AS nvarchar(250)
    ) AS EmployeeName,
    ti.alias AS ScheduleAlias,
    f.att_date AS DateAbsent,
    d.dept_name AS DepartmentName,
    ag.name AS GroupName,
    es.effective_schedule_source AS EffectiveScheduleSource
FROM dbo.custom_att_fact_DailyAttendance f
LEFT JOIN dbo.personnel_employee e
    ON e.id = f.emp_id
LEFT JOIN dbo.personnel_department d
    ON d.id = e.department_id
LEFT JOIN dbo.att_attemployee ae
    ON ae.emp_id = f.emp_id
LEFT JOIN dbo.att_attgroup ag
    ON ag.id = ae.group_id
LEFT JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
    ON es.emp_id = f.emp_id
   AND es.att_date = f.att_date
LEFT JOIN dbo.att_timeinterval ti
    ON ti.id = es.effective_time_interval_id
WHERE f.attendance_status = 'Absent'
  AND ae.enable_attendance = 1;
