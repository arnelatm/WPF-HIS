
CREATE   VIEW dbo.custom_att_MonthlyRollupSource
AS
SELECT
    emp_id,
    att_date,
    YEAR(att_date)  AS year_no,
    MONTH(att_date) AS month_no,
    daily_status,
    business_day_type,
    attendance_status,
    anomaly_flag,
    anomaly_group,
    needs_payroll_review,
    recomputed_worked_minutes,
    ot_minutes
FROM dbo.custom_att_DailyAttendanceSummary;