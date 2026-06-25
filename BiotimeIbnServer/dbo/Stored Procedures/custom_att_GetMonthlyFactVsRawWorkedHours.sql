CREATE PROCEDURE [dbo].[custom_att_GetMonthlyFactVsRawWorkedHours]
    @DateFrom date = NULL,
    @DateTo   date = NULL,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @DateFrom IS NULL AND @DateTo IS NULL
    BEGIN
        SET @DateFrom = DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1);
        SET @DateTo = EOMONTH(@DateFrom);
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

    ;WITH RawDaily AS
    (
        SELECT
            d.emp_id,
            d.emp_code,
            d.work_date AS att_date,
            YEAR(d.work_date) AS year_no,
            MONTH(d.work_date) AS month_no,
            d.worked_interval_count,
            d.first_clock_in AS raw_first_clock_in,
            d.last_clock_out AS raw_last_clock_out,
            ISNULL(d.total_worked_minutes, 0) AS raw_worked_minutes,
            ISNULL(d.total_worked_hours, 0) AS raw_worked_hours
        FROM dbo.custom_att_fnd_DailyWorkedMinutes d
        WHERE d.work_date BETWEEN @DateFrom AND @DateTo
          AND (@EmpID IS NULL OR d.emp_id = @EmpID)
    ),
    RawMonthly AS
    (
        SELECT
            r.emp_id,
            r.emp_code,
            r.year_no,
            r.month_no,
            COUNT(*) AS raw_days_with_work,
            SUM(r.worked_interval_count) AS raw_worked_interval_count,
            MIN(r.raw_first_clock_in) AS raw_first_clock_in,
            MAX(r.raw_last_clock_out) AS raw_last_clock_out,
            SUM(r.raw_worked_minutes) AS raw_total_worked_minutes,
            CAST(SUM(r.raw_worked_minutes) / 60.0 AS decimal(10,2)) AS raw_total_worked_hours,
            CAST(AVG(CAST(NULLIF(r.raw_worked_minutes, 0) AS decimal(10,2))) / 60.0 AS decimal(10,2)) AS raw_avg_worked_hours_per_work_day
        FROM RawDaily r
        GROUP BY
            r.emp_id,
            r.emp_code,
            r.year_no,
            r.month_no
    ),
    FactMonthly AS
    (
        SELECT
            f.emp_id,
            f.emp_code,
            f.year_no,
            f.month_no,
            COUNT(*) AS fact_calendar_days,
            SUM(CASE WHEN f.attendance_status IN ('Present', 'Partial') THEN 1 ELSE 0 END) AS fact_present_or_partial_days,
            SUM(CASE WHEN f.attendance_status = 'Present' THEN 1 ELSE 0 END) AS fact_present_days,
            SUM(CASE WHEN f.attendance_status = 'Partial' THEN 1 ELSE 0 END) AS fact_partial_days,
            SUM(CASE WHEN f.attendance_status = 'Absent' THEN 1 ELSE 0 END) AS fact_absent_days,
            SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN 1 ELSE 0 END) AS fact_required_work_days,
            SUM(CASE WHEN ISNULL(f.needs_payroll_review, 0) = 1 THEN 1 ELSE 0 END) AS fact_payroll_review_days,
            SUM(CASE WHEN ISNULL(f.anomaly_flag, 'Normal') <> 'Normal' THEN 1 ELSE 0 END) AS fact_anomaly_days,
            SUM(CASE WHEN ISNULL(f.punch_status, 'OK') <> 'OK' THEN 1 ELSE 0 END) AS fact_punch_issue_days,
            SUM(CASE WHEN f.first_clock_in IS NOT NULL OR f.last_clock_out IS NOT NULL THEN 1 ELSE 0 END) AS fact_days_with_punches,
            MIN(f.first_clock_in) AS fact_first_clock_in,
            MAX(f.last_clock_out) AS fact_last_clock_out,
            SUM(ISNULL(f.recomputed_worked_minutes, 0)) AS fact_recomputed_worked_minutes,
            CAST(SUM(ISNULL(f.recomputed_worked_minutes, 0)) / 60.0 AS decimal(10,2)) AS fact_recomputed_worked_hours,
            CAST(SUM(ISNULL(f.worked_hours, 0)) AS decimal(10,2)) AS fact_worked_hours,
            CAST(SUM(ISNULL(f.regular_worked_hours, 0)) AS decimal(10,2)) AS fact_regular_worked_hours,
            CAST(SUM(ISNULL(f.ot_hours, 0)) AS decimal(10,2)) AS fact_ot_hours,
            CAST(SUM(ISNULL(f.recomputed_absence_hours, 0)) AS decimal(10,2)) AS fact_absence_hours,
            SUM(ISNULL(f.late_minutes, 0)) AS fact_late_minutes,
            SUM(ISNULL(f.early_out_minutes, 0)) AS fact_early_out_minutes
        FROM dbo.custom_att_fact_DailyAttendance f
        WHERE f.att_date BETWEEN @DateFrom AND @DateTo
          AND (@EmpID IS NULL OR f.emp_id = @EmpID)
        GROUP BY
            f.emp_id,
            f.emp_code,
            f.year_no,
            f.month_no
    ),
    Combined AS
    (
        SELECT
            COALESCE(f.emp_id, r.emp_id) AS emp_id,
            COALESCE(f.emp_code, r.emp_code) AS emp_code,
            COALESCE(f.year_no, r.year_no) AS year_no,
            COALESCE(f.month_no, r.month_no) AS month_no,
            r.raw_days_with_work,
            r.raw_worked_interval_count,
            r.raw_first_clock_in,
            r.raw_last_clock_out,
            r.raw_total_worked_minutes,
            r.raw_total_worked_hours,
            r.raw_avg_worked_hours_per_work_day,
            f.fact_calendar_days,
            f.fact_required_work_days,
            f.fact_present_or_partial_days,
            f.fact_present_days,
            f.fact_partial_days,
            f.fact_absent_days,
            f.fact_days_with_punches,
            f.fact_payroll_review_days,
            f.fact_anomaly_days,
            f.fact_punch_issue_days,
            f.fact_first_clock_in,
            f.fact_last_clock_out,
            f.fact_recomputed_worked_minutes,
            f.fact_recomputed_worked_hours,
            f.fact_worked_hours,
            f.fact_regular_worked_hours,
            f.fact_ot_hours,
            f.fact_absence_hours,
            f.fact_late_minutes,
            f.fact_early_out_minutes
        FROM FactMonthly f
        FULL OUTER JOIN RawMonthly r
            ON r.emp_id = f.emp_id
           AND r.year_no = f.year_no
           AND r.month_no = f.month_no
    )
    SELECT
        c.emp_id,
        c.emp_code,
        LTRIM(RTRIM(
            ISNULL(e.first_name, '') +
            CASE
                WHEN ISNULL(e.last_name, '') = '' THEN ''
                ELSE ' ' + e.last_name
            END
        )) AS employee_name,
        d.dept_name AS department_name,
        c.year_no,
        c.month_no,

        ISNULL(c.raw_days_with_work, 0) AS raw_days_with_work,
        ISNULL(c.fact_days_with_punches, 0) AS fact_days_with_punches,
        ISNULL(c.fact_calendar_days, 0) AS fact_calendar_days,
        ISNULL(c.fact_required_work_days, 0) AS fact_required_work_days,
        ISNULL(c.fact_present_or_partial_days, 0) AS fact_present_or_partial_days,
        ISNULL(c.fact_present_days, 0) AS fact_present_days,
        ISNULL(c.fact_partial_days, 0) AS fact_partial_days,
        ISNULL(c.fact_absent_days, 0) AS fact_absent_days,

        ISNULL(c.raw_worked_interval_count, 0) AS raw_worked_interval_count,
        c.raw_first_clock_in,
        c.raw_last_clock_out,
        c.fact_first_clock_in,
        c.fact_last_clock_out,

        ISNULL(c.raw_total_worked_minutes, 0) AS raw_total_worked_minutes,
        ISNULL(c.fact_recomputed_worked_minutes, 0) AS fact_recomputed_worked_minutes,
        ISNULL(c.fact_recomputed_worked_minutes, 0) - ISNULL(c.raw_total_worked_minutes, 0) AS recomputed_vs_raw_minutes_diff,

        ISNULL(c.raw_total_worked_hours, 0) AS raw_total_worked_hours,
        ISNULL(c.fact_recomputed_worked_hours, 0) AS fact_recomputed_worked_hours,
        CAST(ISNULL(c.fact_recomputed_worked_hours, 0) - ISNULL(c.raw_total_worked_hours, 0) AS decimal(10,2)) AS recomputed_vs_raw_hours_diff,

        ISNULL(c.fact_worked_hours, 0) AS fact_worked_hours,
        CAST(ISNULL(c.fact_worked_hours, 0) - ISNULL(c.raw_total_worked_hours, 0) AS decimal(10,2)) AS fact_worked_vs_raw_hours_diff,

        ISNULL(c.fact_regular_worked_hours, 0) AS fact_regular_worked_hours,
        ISNULL(c.fact_ot_hours, 0) AS fact_ot_hours,
        ISNULL(c.fact_absence_hours, 0) AS fact_absence_hours,
        ISNULL(c.fact_late_minutes, 0) AS fact_late_minutes,
        ISNULL(c.fact_early_out_minutes, 0) AS fact_early_out_minutes,
        ISNULL(c.raw_avg_worked_hours_per_work_day, 0) AS raw_avg_worked_hours_per_work_day,

        ISNULL(c.fact_payroll_review_days, 0) AS fact_payroll_review_days,
        ISNULL(c.fact_anomaly_days, 0) AS fact_anomaly_days,
        ISNULL(c.fact_punch_issue_days, 0) AS fact_punch_issue_days,

        CASE
            WHEN c.fact_calendar_days IS NULL THEN 'RawWithoutFact'
            WHEN c.raw_days_with_work IS NULL
                 AND ISNULL(c.fact_days_with_punches, 0) > 0 THEN 'FactPunchesWithoutRawWorkedTime'
            WHEN c.raw_days_with_work IS NOT NULL
                 AND ISNULL(c.fact_days_with_punches, 0) = 0 THEN 'RawWorkedTimeWithoutFactPunches'
            WHEN ABS(ISNULL(c.fact_recomputed_worked_minutes, 0) - ISNULL(c.raw_total_worked_minutes, 0)) >= 1 THEN 'WorkedTimeMismatch'
            WHEN ISNULL(c.fact_payroll_review_days, 0) > 0 THEN 'PayrollReview'
            WHEN ISNULL(c.fact_anomaly_days, 0) > 0 THEN 'FactAnomaly'
            ELSE 'OK'
        END AS audit_status
    FROM Combined c
    LEFT JOIN dbo.personnel_employee e
        ON e.id = c.emp_id
    LEFT JOIN dbo.personnel_department d
        ON d.id = e.department_id
    ORDER BY
        d.dept_name,
        employee_name,
        c.year_no,
        c.month_no
    OPTION (RECOMPILE);
END;

GO
