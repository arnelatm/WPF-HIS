CREATE VIEW dbo.vw_EmployeeSchedule_Basic
AS
WITH Numbers AS
(
    SELECT TOP (1000)
        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
    FROM sys.all_objects
),
ExpandedSchedule AS
(
    SELECT
        s.id AS ScheduleID,
        s.employee_id,
        s.shift_id,
        DATEADD(DAY, n.n, s.start_date) AS WorkDate
    FROM att_attschedule s
    INNER JOIN Numbers n
        ON DATEADD(DAY, n.n, s.start_date) <= s.end_date
)
SELECT
    e.id AS EmployeePK,
    e.emp_code AS EmployeeCode,
    e.first_name,
    e.last_name,
    LTRIM(RTRIM(
        ISNULL(e.first_name, '') +
        CASE WHEN ISNULL(e.last_name, '') <> '' THEN ' ' + e.last_name ELSE '' END
    )) AS EmployeeName,
    d.dept_name AS DepartmentName,
    ex.WorkDate,
    DATENAME(WEEKDAY, ex.WorkDate) AS DayName,
    ex.shift_id AS ShiftID,
    sh.alias AS ShiftAlias
FROM ExpandedSchedule ex
LEFT JOIN personnel_employee e
    ON ex.employee_id = e.id
LEFT JOIN personnel_department d
    ON e.department_id = d.id
LEFT JOIN att_attshift sh
    ON ex.shift_id = sh.id;