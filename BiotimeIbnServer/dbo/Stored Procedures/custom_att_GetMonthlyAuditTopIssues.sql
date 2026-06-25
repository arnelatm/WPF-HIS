
CREATE PROCEDURE dbo.custom_att_GetMonthlyAuditTopIssues
    @DateFrom date,
    @DateTo   date,
    @TopN     int = 10
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH MonthlySummary AS
    (
        SELECT
            f.year_no,
            f.month_no,
            f.emp_id,
            pe.emp_code,
            LTRIM(RTRIM(
                ISNULL(pe.first_name, '') +
                CASE
                    WHEN ISNULL(pe.last_name, '') = '' THEN ''
                    ELSE ' ' + pe.last_name
                END
            )) AS employee_name,
            d.dept_name AS department_name,

            CAST(SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN ISNULL(f.recomputed_absence_hours, 0) ELSE 0 END) AS decimal(10,2)) AS absence_hours,
            CAST(SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN ISNULL(f.late_minutes, 0) ELSE 0 END) / 60.0 AS decimal(10,2)) AS late_hours,
            CAST(SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN ISNULL(f.early_out_minutes, 0) ELSE 0 END) / 60.0 AS decimal(10,2)) AS early_out_hours,

            CAST(SUM(ISNULL(f.worked_hours, 0)) AS decimal(10,2)) AS total_worked_hours,
            CAST(SUM(ISNULL(f.ot_hours, 0)) AS decimal(10,2)) AS total_ot_hours,

            SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.punch_status = 'NoPunch' THEN 1 ELSE 0 END) AS no_punch_days,
            SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.punch_status = 'MissingOut' THEN 1 ELSE 0 END) AS missing_out_days,
            SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.punch_status = 'MissingIn' THEN 1 ELSE 0 END) AS missing_in_days,
            SUM(CASE WHEN f.anomaly_flag = 'ExcessWorkNoOT' THEN 1 ELSE 0 END) AS excess_work_no_ot_days,
            SUM(CASE WHEN ISNULL(f.anomaly_flag, 'Normal') <> 'Normal' THEN 1 ELSE 0 END) AS anomaly_days,
            SUM(CASE WHEN ISNULL(f.needs_payroll_review, 0) = 1 THEN 1 ELSE 0 END) AS review_days,

            CAST(AVG(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN f.work_completion_pct END) AS decimal(10,2)) AS avg_work_completion_pct
        FROM dbo.custom_att_fact_DailyAttendance f
        LEFT JOIN dbo.personnel_employee pe
            ON pe.id = f.emp_id
        LEFT JOIN dbo.personnel_department d
            ON d.id = pe.department_id
        WHERE f.att_date >= @DateFrom
          AND f.att_date <= @DateTo
        GROUP BY
            f.year_no,
            f.month_no,
            f.emp_id,
            pe.emp_code,
            pe.first_name,
            pe.last_name,
            d.dept_name
    )
    SELECT TOP (@TopN)
        emp_id,
        emp_code,
        employee_name,
        department_name,
        review_days,
        anomaly_days,
        no_punch_days,
        missing_out_days,
        missing_in_days,
        excess_work_no_ot_days,
        absence_hours,
        late_hours,
        early_out_hours,
        total_worked_hours,
        total_ot_hours,
        avg_work_completion_pct
    FROM MonthlySummary
    ORDER BY
        review_days DESC,
        anomaly_days DESC,
        absence_hours DESC,
        late_hours DESC;
END
