CREATE PROCEDURE [dbo].[custom_att_PeriodicAttendanceReport]
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH Periodic AS
    (
        SELECT
            f.emp_id,
            e.emp_code,
            e.first_name,
            d.dept_name AS department_name,

            SUM(CASE WHEN f.daily_status = 'RestDay' THEN 1 ELSE 0 END) AS rest_days,
            SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) = 0
                 AND
                 (
                     f.date_type = 1
                     OR f.daily_status = 'Holiday'
                 )
                THEN 1 ELSE 0
            END) AS holiday_days,

            SUM(CASE
                WHEN f.required_scheduled_hours > 0 THEN 1
                ELSE 0
            END) AS required_work_days,

            SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                 AND
                 (
                     f.attendance_status IN ('Present', 'Partial')
                     OR ISNULL(f.worked_hours, 0) > 0
                 )
                THEN 1 ELSE 0
            END) AS actual_required_days_present,

            SUM(CASE
                WHEN f.attendance_status = 'Absent'
                THEN 1 ELSE 0
            END) AS absence_days,

            CAST(SUM(
                CASE
                    WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                    THEN ISNULL(f.worked_hours, 0)
                    ELSE 0
                END
            ) AS decimal(10,2)) AS total_worked_hours,

            CAST(SUM(
                CASE
                    WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                    THEN ISNULL(f.regular_worked_minutes, 0)
                    ELSE 0
                END
            ) / 60.0 AS decimal(10,2)) AS total_regular_hours,

            CAST(SUM(ISNULL(f.ot_minutes, 0)) / 60.0 AS decimal(10,2)) AS total_ot_hours,

            SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                THEN ISNULL(f.late_minutes, 0)
                ELSE 0
            END) AS total_late_in_minutes,
            SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                THEN ISNULL(f.actual_late_minutes, 0)
                ELSE 0
            END) AS total_actual_late_in_minutes,
            CAST(SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                THEN ISNULL(f.late_minutes, 0)
                ELSE 0
            END) / 60.0 AS decimal(10,2)) AS total_late_in_hours,

            SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                THEN ISNULL(f.early_out_minutes, 0)
                ELSE 0
            END) AS total_early_out_minutes,
            SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                THEN ISNULL(f.actual_early_out_minutes, 0)
                ELSE 0
            END) AS total_actual_early_out_minutes,
            CAST(SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                THEN ISNULL(f.early_out_minutes, 0)
                ELSE 0
            END) / 60.0 AS decimal(10,2)) AS total_early_out_hours,

            SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                THEN ISNULL(f.actual_excess_minutes, 0)
                ELSE 0
            END) AS total_excess_minutes,
            CAST(SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                THEN ISNULL(f.actual_excess_minutes, 0)
                ELSE 0
            END) / 60.0 AS decimal(10,2)) AS total_excess_hours,

            SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                 AND f.anomaly_flag IN ('MissingIn', 'MissingOut', 'NoPunch', 'IncompletePunchPair')
                THEN 1 ELSE 0
            END) AS incomplete_punch_in_or_out_days
        FROM dbo.custom_att_fact_DailyAttendance f
        LEFT JOIN dbo.personnel_employee e
            ON f.emp_id = e.id
        LEFT JOIN dbo.personnel_department d
            ON e.department_id = d.id
        WHERE f.att_date BETWEEN @DateFrom AND @DateTo
          AND (@EmpID IS NULL OR f.emp_id = @EmpID)
          AND NOT EXISTS
          (
              SELECT 1
              FROM dbo.personnel_resign r
              WHERE r.employee_id = f.emp_id
                AND f.att_date > r.resign_date
          )
        GROUP BY
            f.emp_id,
            e.emp_code,
            e.first_name,
            d.dept_name
    )
    SELECT
        p.emp_id AS emp_id,
        p.emp_code AS emp_code,
        p.first_name AS [First Name],
        p.department_name AS [Department],
        p.required_work_days + p.rest_days + p.holiday_days AS [Total Days],
        p.rest_days AS [Rest Days],
        p.holiday_days AS [Holiday],
        p.required_work_days AS [Required Work Days],
        p.actual_required_days_present AS [Actual Required Days Present],
        p.absence_days AS [Absence Days],
        CAST(
            CASE
                WHEN p.required_work_days > 0
                THEN p.actual_required_days_present * 100.0 / p.required_work_days
                ELSE 0
            END AS decimal(10,2)
        ) AS [Present %],
        CAST(
            CASE
                WHEN p.required_work_days > 0
                THEN p.absence_days * 100.0 / p.required_work_days
                ELSE 0
            END AS decimal(10,2)
        ) AS [Absent %],
        CAST(
            CASE
                WHEN p.actual_required_days_present > 0
                THEN p.total_worked_hours / p.actual_required_days_present
                ELSE 0
            END AS decimal(10,2)
        ) AS [Ave. Worked Hours Per Day],
        p.total_actual_late_in_minutes AS [Actual Late Minutes],
        p.total_actual_early_out_minutes AS [Actual Early Out Minutes],
        p.total_ot_hours AS [Total OT Hours],
        p.total_excess_hours AS [Total Excess Hrs.],
        p.incomplete_punch_in_or_out_days AS [No. of Days with Incomplete Punch in or Out],
        p.total_regular_hours AS [Total Regular (H)],
        p.total_worked_hours AS [Total Worked (H)],
        p.total_late_in_minutes AS [Total Late In Min.],
        p.total_late_in_hours AS [Total Late In Hrs.],
        p.total_early_out_minutes AS [Early Out in Min.],
        p.total_early_out_hours AS [Early Out in Hrs.],
        p.total_excess_minutes AS [Total Excess Min.]
                
    FROM Periodic p
    ORDER BY
        p.department_name,
        p.first_name;
END;
