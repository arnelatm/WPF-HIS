
CREATE PROCEDURE [dbo].[custom_att_GetMonthlyAttendanceRollup]
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
/*
Layer: Reporting Procedure
Role: Returns monthly attendance rollup by employee and month
Primary Source:
- dbo.custom_att_rpt_MonthlyRollupSource

Purpose:
- Produces summarized monthly counts for regular days, holidays, rest days, attendance, anomalies, and time totals

Notes:
- Uses temp table staging and indexing for stability and performance
- Intended as a reporting wrapper, not a business-rule engine
- Business logic should remain in the canonical daily attendance layer
*/
BEGIN
    SET NOCOUNT ON;

    IF OBJECT_ID('tempdb..#MonthlySource') IS NOT NULL
        DROP TABLE #MonthlySource;

    SELECT
        emp_id,
        att_date,
        year_no,
        month_no,
        daily_status,
        business_day_type,
        attendance_status,
        anomaly_flag,
        anomaly_group,
        needs_payroll_review,
        recomputed_worked_minutes,
        ot_minutes
    INTO #MonthlySource
    FROM dbo.custom_att_rpt_MonthlyRollupSource
    WHERE att_date >= @DateFrom
      AND att_date < DATEADD(DAY, 1, @DateTo)
      AND (@EmpID IS NULL OR emp_id = @EmpID);

    CREATE CLUSTERED INDEX IX_MonthlySource
        ON #MonthlySource (emp_id, year_no, month_no, att_date);

    SELECT
        emp_id,
        year_no,
        month_no,

        COUNT(*) AS calendar_days,

        SUM(CASE WHEN daily_status = 'RegularDay' THEN 1 ELSE 0 END) AS regular_days_all,
        SUM(CASE WHEN daily_status = 'Holiday' THEN 1 ELSE 0 END) AS holiday_days_all,
        SUM(CASE WHEN daily_status = 'RestDay' THEN 1 ELSE 0 END) AS rest_days_all,

        SUM(CASE WHEN business_day_type = 'RegularDay' THEN 1 ELSE 0 END) AS regular_days_no_ot,
        SUM(CASE WHEN business_day_type = 'RegularDayWithOT' THEN 1 ELSE 0 END) AS regular_days_with_ot,
        SUM(CASE WHEN business_day_type = 'Holiday' THEN 1 ELSE 0 END) AS holiday_days_no_ot,
        SUM(CASE WHEN business_day_type = 'HolidayOT' THEN 1 ELSE 0 END) AS holiday_days_with_ot,
        SUM(CASE WHEN business_day_type = 'RestDay' THEN 1 ELSE 0 END) AS rest_days_no_ot,
        SUM(CASE WHEN business_day_type = 'RestDayOT' THEN 1 ELSE 0 END) AS rest_days_with_ot,

        SUM(CASE WHEN attendance_status = 'Present' THEN 1 ELSE 0 END) AS present_days,
        SUM(CASE WHEN attendance_status = 'Partial' THEN 1 ELSE 0 END) AS partial_days,
        SUM(CASE WHEN attendance_status = 'Absent' THEN 1 ELSE 0 END) AS absent_days,
        SUM(CASE WHEN attendance_status = 'NotRequired' THEN 1 ELSE 0 END) AS not_required_days,

        SUM(CASE WHEN anomaly_group = 'PunchIssue' THEN 1 ELSE 0 END) AS punch_issue_days,
        SUM(CASE WHEN anomaly_group = 'BusinessRule' THEN 1 ELSE 0 END) AS business_rule_days,
        SUM(CASE WHEN needs_payroll_review = 1 THEN 1 ELSE 0 END) AS payroll_review_days,

        SUM(recomputed_worked_minutes) AS total_worked_minutes,
        SUM(ot_minutes) AS total_ot_minutes,

        CAST(SUM(recomputed_worked_minutes) / 60.0 AS decimal(10,2)) AS total_worked_hours,
        CAST(SUM(ot_minutes) / 60.0 AS decimal(10,2)) AS total_ot_hours
    FROM #MonthlySource
    GROUP BY
        emp_id,
        year_no,
        month_no
    ORDER BY
        emp_id,
        year_no,
        month_no;
END
