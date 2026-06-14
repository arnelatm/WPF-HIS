CREATE PROCEDURE dbo.custom_att_GetMonthlyAttendanceReport_Fast
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        f.emp_id AS emp_id,
        f.emp_code AS emp_code,
        pe.first_name AS [Employee Name],
        d.dept_name AS [Employee Department],
        f.year_no,
        f.month_no,

        SUM(CASE WHEN f.daily_status = 'RegularDay' THEN 1 ELSE 0 END) AS [Total Regular Days Needed],
        SUM(CASE WHEN f.daily_status = 'Holiday' THEN 1 ELSE 0 END) AS [No. of Holidays],
        SUM(CASE WHEN f.daily_status = 'RestDay' THEN 1 ELSE 0 END) AS [No. of Day Offs],

        SUM(CASE
                WHEN f.first_clock_in IS NOT NULL
                  OR f.last_clock_out IS NOT NULL
                THEN 1 ELSE 0
            END) AS [Total Days Present],

        CAST(SUM(ISNULL(f.recomputed_worked_minutes, 0)) / 60.0 AS decimal(10,2)) AS [Total Work Hours],
        CAST(SUM(ISNULL(f.ot_minutes, 0)) / 60.0 AS decimal(10,2)) AS [Total OT Hours],

        SUM(CASE WHEN f.attendance_status = 'Absent' THEN 1 ELSE 0 END) AS [Total Absent Days]
    FROM dbo.custom_att_fact_DailyAttendance f
    LEFT JOIN dbo.personnel_employee pe
        ON f.emp_id = pe.id
    LEFT JOIN dbo.personnel_department d
        ON pe.department_id = d.id
    WHERE f.att_date >= @DateFrom
      AND f.att_date < DATEADD(DAY, 1, @DateTo)
      AND (@EmpID IS NULL OR f.emp_id = @EmpID)
    GROUP BY
        f.emp_id,
        f.emp_code,
        pe.first_name,
        d.dept_name,
        f.year_no,
        f.month_no
    ORDER BY
        [Employee Department],
        [Employee Name];
END
