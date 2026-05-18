


CREATE   VIEW [dbo].[custom_att_rpt_MonthlyAttendanceRollup]
AS
/*
Layer: Reporting View
Role: Monthly aggregated attendance rollup by employee and month

Primary Source:
- dbo.custom_att_rpt_MonthlyRollupSource

Purpose:
- Aggregates monthly attendance counts and time totals from the reporting source view
- Provides reusable monthly rollup output for dashboards, review, and reporting procedures

Key Outputs:
- calendar_days
- regular / holiday / rest day counts
- present / partial / absent / not required counts
- anomaly and payroll review counts
- total_worked_minutes / total_worked_hours
- total_ot_minutes / total_ot_hours

Used by:
- Reporting consumers
- Optional monthly reporting procedures

Notes:
- Reporting-only layer
- Should not introduce independent attendance business rules
- Monthly logic should remain derived from the canonical daily attendance source
*/
SELECT
    emp_id,
    year_no,
    month_no,

    COUNT(*) AS calendar_days,

    -- Broad day categories
    SUM(CASE WHEN daily_status = 'RegularDay' THEN 1 ELSE 0 END) AS regular_days_all,
    SUM(CASE WHEN daily_status = 'Holiday' THEN 1 ELSE 0 END) AS holiday_days_all,
    SUM(CASE WHEN daily_status = 'RestDay' THEN 1 ELSE 0 END) AS rest_days_all,

    -- Refined business day categories
    SUM(CASE WHEN business_day_type = 'RegularDay' THEN 1 ELSE 0 END) AS regular_days_no_ot,
    SUM(CASE WHEN business_day_type = 'RegularDayWithOT' THEN 1 ELSE 0 END) AS regular_days_with_ot,
    SUM(CASE WHEN business_day_type = 'Holiday' THEN 1 ELSE 0 END) AS holiday_days_no_ot,
    SUM(CASE WHEN business_day_type = 'HolidayOT' THEN 1 ELSE 0 END) AS holiday_days_with_ot,
    SUM(CASE WHEN business_day_type = 'RestDay' THEN 1 ELSE 0 END) AS rest_days_no_ot,
    SUM(CASE WHEN business_day_type = 'RestDayOT' THEN 1 ELSE 0 END) AS rest_days_with_ot,

    -- Attendance
    SUM(CASE WHEN attendance_status = 'Present' THEN 1 ELSE 0 END) AS present_days,
    SUM(CASE WHEN attendance_status = 'Partial' THEN 1 ELSE 0 END) AS partial_days,
    SUM(CASE WHEN attendance_status = 'Absent' THEN 1 ELSE 0 END) AS absent_days,
    SUM(CASE WHEN attendance_status = 'NotRequired' THEN 1 ELSE 0 END) AS not_required_days,

    -- Anomalies / review
    SUM(CASE WHEN anomaly_group = 'PunchIssue' THEN 1 ELSE 0 END) AS punch_issue_days,
    SUM(CASE WHEN anomaly_group = 'BusinessRule' THEN 1 ELSE 0 END) AS business_rule_days,
    SUM(CASE WHEN needs_payroll_review = 1 THEN 1 ELSE 0 END) AS payroll_review_days,

    -- Time totals
    SUM(recomputed_worked_minutes) AS total_worked_minutes,
    SUM(ot_minutes) AS total_ot_minutes,

    CAST(SUM(recomputed_worked_minutes) / 60.0 AS decimal(10,2)) AS total_worked_hours,
    CAST(SUM(ot_minutes) / 60.0 AS decimal(10,2)) AS total_ot_hours
FROM dbo.custom_att_rpt_MonthlyRollupSource
GROUP BY
    emp_id,
    year_no,
    month_no;
