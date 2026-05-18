
create VIEW [dbo].[vw_EmployeeSchedule_Basic]
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
        s.start_date,
        s.end_date,
        DATEADD(DAY, n.n, s.start_date) AS WorkDate,
        n.n AS DayOffset
    FROM dbo.att_attschedule s
    INNER JOIN Numbers n
        ON DATEADD(DAY, n.n, s.start_date) <= s.end_date
),
ResolvedSchedule AS
(
    SELECT
        ex.ScheduleID,
        ex.employee_id,
        ex.shift_id,
        ex.start_date,
        ex.end_date,
        ex.WorkDate,
        ex.DayOffset,
        sh.alias AS ShiftAlias,
        ISNULL(sh.shift_cycle, 1) AS shift_cycle,
        CASE
            WHEN ISNULL(sh.shift_cycle, 1) > 1
                THEN ex.DayOffset % (sh.shift_cycle * 7)
            ELSE ex.DayOffset % 7
        END AS ResolvedDayIndex
    FROM ExpandedSchedule ex
    LEFT JOIN dbo.att_attshift sh
        ON ex.shift_id = sh.id
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
    rs.WorkDate,
    DATENAME(WEEKDAY, rs.WorkDate) AS DayName,
    rs.shift_id AS ShiftID,
    rs.ShiftAlias,
    rs.shift_cycle,
    rs.ResolvedDayIndex,
    sd.time_interval_id,
    sd.in_time AS ScheduledInTime,
    sd.out_time AS ScheduledOutTime,
    CASE
        WHEN sd.shift_id IS NULL THEN 1
        ELSE 0
    END AS IsOffDay
FROM ResolvedSchedule rs
LEFT JOIN dbo.att_shiftdetail sd
    ON rs.shift_id = sd.shift_id
   AND rs.ResolvedDayIndex = sd.day_index
LEFT JOIN dbo.personnel_employee e
    ON rs.employee_id = e.id
LEFT JOIN dbo.personnel_department d
    ON e.department_id = d.id;