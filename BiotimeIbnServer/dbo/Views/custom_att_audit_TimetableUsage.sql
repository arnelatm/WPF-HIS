CREATE VIEW [dbo].[custom_att_audit_TimetableUsage]
AS
WITH ShiftTimetables AS
(
    SELECT DISTINCT
        sd.shift_id,
        sd.time_interval_id
    FROM dbo.att_shiftdetail sd
)
SELECT
    ti.id AS TimetableID,
    ti.alias AS TimetableName,
    ti.use_mode AS TimetableUseMode,
    ti.in_time AS TimetableInTime,
    ti.duration AS TimetableDurationMinutes,
    CAST('Shift' AS varchar(30)) AS UsageType,
    sh.id AS ShiftID,
    sh.alias AS ShiftName,
    CAST(NULL AS int) AS ScheduleID,
    CAST(NULL AS smallint) AS ScheduleStatus,
    CAST(NULL AS date) AS EffectiveFrom,
    CAST(NULL AS date) AS EffectiveTo,
    CAST(NULL AS varchar(20)) AS AssignedEntityType,
    CAST(NULL AS int) AS AssignedEntityID,
    CAST(NULL AS nvarchar(50)) AS AssignedEntityCode,
    CAST(NULL AS nvarchar(250)) AS AssignedEntityName
FROM dbo.att_timeinterval ti
INNER JOIN ShiftTimetables st
    ON st.time_interval_id = ti.id
INNER JOIN dbo.att_attshift sh
    ON sh.id = st.shift_id

UNION ALL

SELECT
    ti.id,
    ti.alias,
    ti.use_mode,
    ti.in_time,
    ti.duration,
    CAST('TemporarySchedule' AS varchar(30)),
    CAST(NULL AS int),
    CAST(NULL AS nvarchar(50)),
    ts.id,
    ts.status,
    ts.att_date,
    ts.att_date,
    CAST('Employee' AS varchar(20)),
    e.id,
    CAST(e.emp_code AS nvarchar(50)),
    CAST(LTRIM(RTRIM(ISNULL(e.first_name, '') + ' ' + ISNULL(e.last_name, ''))) AS nvarchar(250))
FROM dbo.att_timeinterval ti
INNER JOIN dbo.att_temporaryschedule ts
    ON ts.time_interval_id = ti.id
INNER JOIN dbo.personnel_employee e
    ON e.id = ts.employee_id

UNION ALL

SELECT
    ti.id,
    ti.alias,
    ti.use_mode,
    ti.in_time,
    ti.duration,
    CAST('EmployeeSchedule' AS varchar(30)),
    sh.id,
    sh.alias,
    s.id,
    CAST(NULL AS smallint),
    s.start_date,
    s.end_date,
    CAST('Employee' AS varchar(20)),
    e.id,
    CAST(e.emp_code AS nvarchar(50)),
    CAST(LTRIM(RTRIM(ISNULL(e.first_name, '') + ' ' + ISNULL(e.last_name, ''))) AS nvarchar(250))
FROM dbo.att_timeinterval ti
INNER JOIN ShiftTimetables st
    ON st.time_interval_id = ti.id
INNER JOIN dbo.att_attshift sh
    ON sh.id = st.shift_id
INNER JOIN dbo.att_attschedule s
    ON s.shift_id = sh.id
INNER JOIN dbo.personnel_employee e
    ON e.id = s.employee_id

UNION ALL

SELECT
    ti.id,
    ti.alias,
    ti.use_mode,
    ti.in_time,
    ti.duration,
    CAST('GroupSchedule' AS varchar(30)),
    sh.id,
    sh.alias,
    gs.id,
    gs.status,
    gs.start_date,
    gs.end_date,
    CAST('Group' AS varchar(20)),
    ag.id,
    CAST(ag.code AS nvarchar(50)),
    CAST(ag.name AS nvarchar(250))
FROM dbo.att_timeinterval ti
INNER JOIN ShiftTimetables st
    ON st.time_interval_id = ti.id
INNER JOIN dbo.att_attshift sh
    ON sh.id = st.shift_id
INNER JOIN dbo.att_groupschedule gs
    ON gs.shift_id = sh.id
INNER JOIN dbo.att_attgroup ag
    ON ag.id = gs.group_id

UNION ALL

SELECT
    ti.id,
    ti.alias,
    ti.use_mode,
    ti.in_time,
    ti.duration,
    CAST('DepartmentSchedule' AS varchar(30)),
    sh.id,
    sh.alias,
    ds.id,
    ds.status,
    ds.start_date,
    ds.end_date,
    CAST('Department' AS varchar(20)),
    d.id,
    CAST(d.dept_code AS nvarchar(50)),
    CAST(d.dept_name AS nvarchar(250))
FROM dbo.att_timeinterval ti
INNER JOIN ShiftTimetables st
    ON st.time_interval_id = ti.id
INNER JOIN dbo.att_attshift sh
    ON sh.id = st.shift_id
INNER JOIN dbo.att_departmentschedule ds
    ON ds.shift_id = sh.id
INNER JOIN dbo.personnel_department d
    ON d.id = ds.department_id;
