CREATE PROCEDURE [dbo].[custom_att_PeriodicAttendanceReport]
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH FactScope AS
    (
        SELECT
            f.emp_id,
            f.att_date,
            e.emp_code,
            e.first_name,
            d.dept_name AS department_name,
            f.is_flex_duty,
            f.flex_duty_minutes,
            f.daily_status,
            f.required_scheduled_hours,
            f.date_type,
            f.attendance_status,
            f.worked_hours,
            f.sick_leave_days,
            f.annual_leave_days,
            f.compensatory_leave_days,
            f.other_paid_leave_days,
            f.unpaid_leave_days,
            f.regular_worked_minutes,
            f.ot_minutes,
            f.late_minutes,
            f.actual_late_minutes,
            f.early_out_minutes,
            f.actual_early_out_minutes,
            f.actual_excess_minutes,
            f.anomaly_flag
        FROM dbo.custom_att_fact_DailyAttendance f
        LEFT JOIN dbo.personnel_employee e
            ON f.emp_id = e.id
        INNER JOIN dbo.att_attemployee ae
            ON ae.emp_id = f.emp_id
           AND ae.enable_attendance = 1
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
    ),
    Periodic AS
    (
        SELECT
            f.emp_id,
            f.emp_code,
            f.first_name,
            f.department_name,

            MAX(CASE WHEN ISNULL(f.is_flex_duty, 0) = 1 THEN 1 ELSE 0 END) AS has_flex_duty,
            SUM(CASE WHEN ISNULL(f.is_flex_duty, 0) = 1 THEN 1 ELSE 0 END) AS flex_duty_days,
            CAST(SUM(ISNULL(f.flex_duty_minutes, 0)) AS decimal(10,2)) AS total_flex_duty_minutes,

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

            CAST(SUM(ISNULL(f.sick_leave_days, 0)) AS decimal(10,2)) AS sick_leave_days,
            CAST(SUM(ISNULL(f.annual_leave_days, 0)) AS decimal(10,2)) AS annual_leave_days,
            CAST(SUM(ISNULL(f.compensatory_leave_days, 0)) AS decimal(10,2)) AS compensatory_leave_days,
            CAST(SUM(ISNULL(f.other_paid_leave_days, 0)) AS decimal(10,2)) AS other_paid_leave_days,
            CAST(SUM(ISNULL(f.unpaid_leave_days, 0)) AS decimal(10,2)) AS unpaid_leave_days,
            CAST(SUM(
                ISNULL(f.sick_leave_days, 0)
                + ISNULL(f.annual_leave_days, 0)
                + ISNULL(f.compensatory_leave_days, 0)
                + ISNULL(f.other_paid_leave_days, 0)
            ) AS decimal(10,2)) AS total_leave_days,

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
        FROM FactScope f
        GROUP BY
            f.emp_id,
            f.emp_code,
            f.first_name,
            f.department_name
    )
    SELECT
        p.emp_id AS emp_id,
        p.emp_code AS emp_code,
        p.first_name AS [First Name],
        p.department_name AS [Department],
        CASE WHEN p.has_flex_duty = 1 THEN 'Yes' ELSE 'No' END AS [Flex Duty],
        p.flex_duty_days AS [Flex Duty Days],
        p.total_flex_duty_minutes AS [Flex Duty Minutes],
        p.required_work_days + p.rest_days + p.holiday_days AS [Total Days],
        p.rest_days AS [Rest Days],
        p.holiday_days AS [Holiday],
        p.required_work_days AS [Required Work Days],
        p.actual_required_days_present AS [Actual Required Days Present],
        CAST(p.absence_days + ISNULL(p.unpaid_leave_days, 0) AS decimal(10,2)) AS [Absence Days],
        ISNULL(p.sick_leave_days, 0) AS [Sick Leave Days],
        ISNULL(p.annual_leave_days, 0) AS [Annual Leave Days],
        ISNULL(p.compensatory_leave_days, 0) AS [Compensatory Leave Days],
        ISNULL(p.other_paid_leave_days, 0) AS [Other Paid Leave Days],
        ISNULL(p.unpaid_leave_days, 0) AS [Unpaid Leave Days],
        p.total_leave_days AS [Total Leave Days],
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
                THEN (p.absence_days + ISNULL(p.unpaid_leave_days, 0)) * 100.0 / p.required_work_days
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
