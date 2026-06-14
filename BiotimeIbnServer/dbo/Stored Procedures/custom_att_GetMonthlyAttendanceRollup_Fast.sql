
CREATE PROCEDURE dbo.custom_att_GetMonthlyAttendanceRollup_Fast
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        f.emp_id,
        f.emp_code,
        f.year_no,
        f.month_no,

        COUNT(*) AS calendar_days,

        SUM(CASE WHEN f.daily_status = 'RegularDay' THEN 1 ELSE 0 END) AS regular_days_all,
        SUM(CASE WHEN f.daily_status = 'Holiday' THEN 1 ELSE 0 END) AS holiday_days_all,
        SUM(CASE WHEN f.daily_status = 'RestDay' THEN 1 ELSE 0 END) AS rest_days_all,

        SUM(CASE WHEN f.business_day_type = 'RegularDay' THEN 1 ELSE 0 END) AS regular_days_no_ot,
        SUM(CASE WHEN f.business_day_type = 'RegularDayWithOT' THEN 1 ELSE 0 END) AS regular_days_with_ot,
        SUM(CASE WHEN f.business_day_type = 'Holiday' THEN 1 ELSE 0 END) AS holiday_days_no_ot,
        SUM(CASE WHEN f.business_day_type = 'HolidayOT' THEN 1 ELSE 0 END) AS holiday_days_with_ot,
        SUM(CASE WHEN f.business_day_type = 'RestDay' THEN 1 ELSE 0 END) AS rest_days_no_ot,
        SUM(CASE WHEN f.business_day_type = 'RestDayOT' THEN 1 ELSE 0 END) AS rest_days_with_ot,

        SUM(CASE WHEN f.attendance_status = 'Present' THEN 1 ELSE 0 END) AS present_days,
        SUM(CASE WHEN f.attendance_status = 'Partial' THEN 1 ELSE 0 END) AS partial_days,
        SUM(CASE WHEN f.attendance_status = 'Absent' THEN 1 ELSE 0 END) AS absent_days,
        SUM(CASE WHEN f.attendance_status = 'NotRequired' THEN 1 ELSE 0 END) AS not_required_days,

        SUM(CASE WHEN f.anomaly_group = 'PunchIssue' THEN 1 ELSE 0 END) AS punch_issue_days,
        SUM(CASE WHEN f.anomaly_group = 'BusinessRule' THEN 1 ELSE 0 END) AS business_rule_days,
        SUM(CASE WHEN f.needs_payroll_review = 1 THEN 1 ELSE 0 END) AS payroll_review_days,

        SUM(f.recomputed_worked_minutes) AS total_worked_minutes,
        SUM(f.ot_minutes) AS total_ot_minutes,

        CAST(SUM(f.recomputed_worked_minutes) / 60.0 AS decimal(10,2)) AS total_worked_hours,
        CAST(SUM(f.ot_minutes) / 60.0 AS decimal(10,2)) AS total_ot_hours
    FROM dbo.custom_att_fact_DailyAttendance f
    WHERE f.att_date >= @DateFrom
      AND f.att_date < DATEADD(DAY, 1, @DateTo)
      AND (@EmpID IS NULL OR f.emp_id = @EmpID)
    GROUP BY
        f.emp_id,
        f.emp_code,
        f.year_no,
        f.month_no
    ORDER BY
        f.emp_id,
        f.emp_code,
        f.year_no,
        f.month_no;
END
