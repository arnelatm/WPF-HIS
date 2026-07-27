CREATE PROCEDURE [dbo].[custom_att_GetUnassignedOrInheritedDutyEmployees]
    @DateFrom date = NULL,
    @DateTo date = NULL,
    @EmpID int = NULL,
    @DepartmentID int = NULL,
    @GroupID int = NULL,
    @DepartmentSearch nvarchar(200) = NULL,
    @GroupSearch nvarchar(100) = NULL
AS
/*
Layer: Reporting Procedure
Role: Lists active employees/dates where duty is missing, or where resolved duty is inherited
      from attendance group or department schedule.

Included schedule sources:
- No Scheduled Duty
- Group
- Department

Excluded schedule sources:
- Temporary
- Employee

Filters:
- @DateFrom / @DateTo: attendance date range. If both are NULL, defaults to today.
- @EmpID: personnel_employee.id.
- @DepartmentID: personnel_employee.department_id.
- @GroupID: att_attemployee.group_id.
- @DepartmentSearch: optional department code/name contains search.
- @GroupSearch: optional attendance group code/name contains search.
- Attendance and schedule must both be enabled in att_attemployee.
- Attendance dates before personnel_employee.hire_date are excluded.
*/
BEGIN
    SET NOCOUNT ON;

    IF @DateFrom IS NULL AND @DateTo IS NULL
    BEGIN
        SET @DateFrom = CAST(GETDATE() AS date);
        SET @DateTo = @DateFrom;
    END;

    IF @DateFrom IS NULL
        SET @DateFrom = @DateTo;

    IF @DateTo IS NULL
        SET @DateTo = @DateFrom;

    IF @DateFrom > @DateTo
    BEGIN
        DECLARE @SwapDate date = @DateFrom;
        SET @DateFrom = @DateTo;
        SET @DateTo = @SwapDate;
    END;

    ;WITH Dates AS
    (
        SELECT @DateFrom AS att_date

        UNION ALL

        SELECT DATEADD(DAY, 1, att_date)
        FROM Dates
        WHERE att_date < @DateTo
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
          AND (@EmpID IS NULL OR e.id = @EmpID)
          AND (@DepartmentID IS NULL OR e.department_id = @DepartmentID)
          AND (@GroupID IS NULL OR ae.group_id = @GroupID)
          AND
          (
              @DepartmentSearch IS NULL
              OR d.dept_code LIKE '%' + @DepartmentSearch + '%'
              OR d.dept_name LIKE '%' + @DepartmentSearch + '%'
          )
          AND
          (
              @GroupSearch IS NULL
              OR ag.code LIKE '%' + @GroupSearch + '%'
              OR ag.name LIKE '%' + @GroupSearch + '%'
          )
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
       OR es.effective_schedule_source IN ('Group', 'Department')
    ORDER BY
        ed.dept_name,
        ed.group_name,
        ed.emp_code,
        ed.att_date
    OPTION (MAXRECURSION 0);
END;
