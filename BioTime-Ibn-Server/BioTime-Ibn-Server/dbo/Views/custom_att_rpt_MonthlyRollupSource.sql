


CREATE   VIEW [dbo].[custom_att_rpt_MonthlyRollupSource]
AS
/*
Layer: Reporting View
Role: Thin monthly rollup source derived from the canonical daily attendance view
Primary Source:
- dbo.custom_att_calc_DailyAttendanceSummary

Purpose:
- Exposes only the columns needed for monthly rollup reporting
- Keeps monthly aggregation logic separated from daily business logic

Used by:
- dbo.custom_att_rpt_MonthlyAttendanceRollup
- dbo.custom_att_GetMonthlyAttendanceRollup

Notes:
- Should remain a thin projection view
- Should not contain new business-rule logic
*/
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
FROM dbo.custom_att_calc_DailyAttendanceSummary;
