

CREATE   PROCEDURE [dbo].[custom_att_GetMonthlyAttendanceReport]
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF OBJECT_ID('tempdb..#AttendanceReportSource') IS NOT NULL
        DROP TABLE #AttendanceReportSource;

    SELECT
        s.emp_id,
        s.att_date,
        YEAR(s.att_date)  AS year_no,
        MONTH(s.att_date) AS month_no,

        s.daily_status,
        s.business_day_type,
        s.attendance_status,
        s.first_clock_in,
        s.last_clock_out,
        s.recomputed_worked_minutes,
        s.ot_minutes
    INTO #AttendanceReportSource
    FROM dbo.custom_att_DailyAttendanceSummary s
    WHERE s.att_date >= @DateFrom
      AND s.att_date < DATEADD(DAY, 1, @DateTo)
      AND (@EmpID IS NULL OR s.emp_id = @EmpID);

    SELECT
        r.emp_id AS IdNo,
        pe.emp_code AS [Employee Code],
		pe.first_name AS [Employee Name],
        --pe.first_name
        --    + CASE WHEN pe.middle_name IS NOT NULL AND LTRIM(RTRIM(pe.middle_name)) <> '' THEN ' ' + pe.middle_name ELSE '' END
        --    + CASE WHEN pe.last_name IS NOT NULL AND LTRIM(RTRIM(pe.last_name)) <> '' THEN ' ' + pe.last_name ELSE '' END
        --    AS [Employee Name],
        d.dept_name AS [Employee Department],

        r.year_no,
        r.month_no,

        SUM(CASE WHEN r.daily_status = 'RegularDay' THEN 1 ELSE 0 END) AS [Total Regular Days Needed],
        SUM(CASE WHEN r.daily_status = 'Holiday' THEN 1 ELSE 0 END) AS [No. of Holidays],
        SUM(CASE WHEN r.daily_status = 'RestDay' THEN 1 ELSE 0 END) AS [No. of Day Offs],

        SUM(CASE
                WHEN r.first_clock_in IS NOT NULL
                  OR r.last_clock_out IS NOT NULL
                THEN 1 ELSE 0
            END) AS [Total Days Present],

        CAST(SUM(ISNULL(r.recomputed_worked_minutes, 0)) / 60.0 AS decimal(10,2)) AS [Total Work Hours],
        CAST(SUM(ISNULL(r.ot_minutes, 0)) / 60.0 AS decimal(10,2)) AS [Total OT Hours],

        SUM(CASE WHEN r.attendance_status = 'Absent' THEN 1 ELSE 0 END) AS [Total Absent Days]

    FROM #AttendanceReportSource r
    LEFT JOIN dbo.personnel_employee pe
        ON r.emp_id = pe.id
    LEFT JOIN dbo.personnel_department d
        ON pe.department_id = d.id
    GROUP BY
        r.emp_id,
        pe.emp_code,
        pe.first_name,
        d.dept_name,
        r.year_no,
        r.month_no
    ORDER BY
        [Employee Department],
        [Employee Name];
END