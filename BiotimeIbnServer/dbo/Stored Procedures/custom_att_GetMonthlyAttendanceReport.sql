


CREATE PROCEDURE [dbo].[custom_att_GetMonthlyAttendanceReport]
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF OBJECT_ID('tempdb..#punch_agg') IS NOT NULL
        DROP TABLE #punch_agg;

    SELECT
        t.emp_id,
        CAST(t.punch_time AS date) AS att_date,
        COUNT_BIG(*) AS punch_count
    INTO #punch_agg
    FROM dbo.iclock_transaction t
    WHERE t.punch_time >= @DateFrom
      AND t.punch_time < DATEADD(DAY, 1, @DateTo)
      AND (@EmpID IS NULL OR t.emp_id = @EmpID)
    GROUP BY
        t.emp_id,
        CAST(t.punch_time AS date);

    CREATE INDEX IX_punch_agg_emp_date
        ON #punch_agg(emp_id, att_date);

    IF OBJECT_ID('tempdb..#CalendarDayType') IS NOT NULL
        DROP TABLE #CalendarDayType;

    ;WITH day_counts AS
    (
        SELECT
            att_date,
            daily_status,
            COUNT(*) AS status_count,
            ROW_NUMBER() OVER
            (
                PARTITION BY att_date
                ORDER BY COUNT(*) DESC,
                         CASE daily_status
                            WHEN 'Holiday' THEN 1
                            WHEN 'RestDay' THEN 2
                            WHEN 'RegularDay' THEN 3
                            ELSE 4
                         END
            ) AS rn
        FROM dbo.custom_att_fact_DailyAttendance
        WHERE att_date >= @DateFrom
          AND att_date <= @DateTo
        GROUP BY
            att_date,
            daily_status
    )
    SELECT
        att_date,
        daily_status AS calendar_daily_status
    INTO #CalendarDayType
    FROM day_counts
    WHERE rn = 1;

    CREATE UNIQUE CLUSTERED INDEX IX_CalendarDayType
        ON #CalendarDayType(att_date);

    IF OBJECT_ID('tempdb..#AttendanceReportSource') IS NOT NULL
        DROP TABLE #AttendanceReportSource;

    SELECT
        s.emp_id,
        s.att_date,
        s.year_no,
        s.month_no,
		c.calendar_daily_status,
		s.daily_status AS employee_daily_status,
		s.attendance_status,
        s.recomputed_worked_minutes,
        s.ot_minutes,
        s.required_scheduled_hours,
        ISNULL(p.punch_count, 0) AS punch_count
    INTO #AttendanceReportSource
    FROM dbo.custom_att_fact_DailyAttendance s
    INNER JOIN #CalendarDayType c
        ON c.att_date = s.att_date
    LEFT JOIN #punch_agg p
        ON p.emp_id = s.emp_id
       AND p.att_date = s.att_date
    WHERE s.att_date >= @DateFrom
      AND s.att_date <= @DateTo
      AND (@EmpID IS NULL OR s.emp_id = @EmpID);

    CREATE CLUSTERED INDEX IX_AttendanceReportSource
        ON #AttendanceReportSource (emp_id, year_no, month_no, att_date);

    SELECT
        r.emp_id AS IdNo,
        pe.emp_code AS [Employee Code],
        pe.first_name AS [Employee Name],
        d.dept_name AS [Employee Department],
        r.year_no,
        r.month_no,

        SUM(CASE 
                WHEN r.calendar_daily_status NOT IN ('Holiday', 'RestDay')
                THEN 1 ELSE 0 
            END) AS [Total Regular Days Needed],

		
		(
			SUM(CASE 
					WHEN r.calendar_daily_status NOT IN ('Holiday', 'RestDay')
					THEN 1 ELSE 0 
				END)
			-
			SUM(CASE 
					WHEN r.attendance_status = 'Absent'
					 AND ISNULL(r.punch_count, 0) = 0
					 AND ISNULL(r.employee_daily_status, '') NOT IN ('Holiday', 'RestDay', 'HolidayOT', 'RestDayOT')
					THEN 1 ELSE 0 
				END)
		) AS [Total Regular Days Present],

			SUM(CASE 
				WHEN r.attendance_status = 'Absent'
				 AND ISNULL(r.punch_count, 0) = 0
				 AND ISNULL(r.employee_daily_status, '') NOT IN ('Holiday', 'RestDay', 'HolidayOT', 'RestDayOT')
				THEN 1 ELSE 0 
			END) AS [Total Absent Days],

        SUM(CASE 
                WHEN r.calendar_daily_status = 'Holiday'
                THEN 1 ELSE 0 
            END) AS [No. of Holidays],

        SUM(CASE 
                WHEN r.calendar_daily_status = 'RestDay'
                THEN 1 ELSE 0 
            END) AS [No. of Day Offs],

        SUM(CASE
                WHEN r.punch_count > 0
                THEN 1 ELSE 0
            END) AS [Total Days Present],

		(
			SUM(CASE
					WHEN r.punch_count > 0
					THEN 1 ELSE 0
				END)
			-
			(
				SUM(CASE 
						WHEN r.calendar_daily_status NOT IN ('Holiday', 'RestDay')
						THEN 1 ELSE 0 
					END)
				-
				SUM(CASE 
						WHEN r.attendance_status = 'Absent'
						 AND ISNULL(r.punch_count, 0) = 0
						 AND ISNULL(r.employee_daily_status, '') NOT IN ('Holiday', 'RestDay', 'HolidayOT', 'RestDayOT')
						THEN 1 ELSE 0 
					END)
			)
		) AS [Non-Regular Days Worked],

		CASE 
			WHEN 
				SUM(CASE 
						WHEN r.attendance_status = 'Absent'
						 AND ISNULL(r.punch_count, 0) = 0
						 AND r.employee_daily_status NOT IN ('Holiday','RestDay','HolidayOT','RestDayOT')
						THEN 1 ELSE 0
					END) = 0
			THEN 1 ELSE 0
		END AS [Perfect Attendance],

		SUM(CASE 
				WHEN r.punch_count > 0
				 AND r.recomputed_worked_minutes < (r.required_scheduled_hours * 60)
				 AND r.calendar_daily_status NOT IN ('Holiday', 'RestDay')
				THEN 1 ELSE 0
			END) AS [Late / Undertime Days],

        CAST(SUM(ISNULL(r.recomputed_worked_minutes, 0)) / 60.0 AS decimal(10,2)) AS [Total Work Hours],

        CAST(SUM(ISNULL(r.ot_minutes, 0)) / 60.0 AS decimal(10,2)) AS [Total OT Hours]

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
