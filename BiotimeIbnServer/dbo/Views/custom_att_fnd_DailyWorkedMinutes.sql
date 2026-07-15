


CREATE VIEW [dbo].[custom_att_fnd_DailyWorkedMinutes]
AS
/*
Layer: Foundation
Role: Daily worked-time aggregation from processed punch intervals

Primary Source:
- dbo.custom_att_fnd_WorkedIntervals

Purpose:
- Aggregates worked intervals into one daily worked-time row per employee per work date
- Provides the factual worked-time inputs used by higher attendance calculations

Key Outputs:
- worked_interval_count
- first_clock_in
- last_clock_out
- total_worked_minutes
- total_worked_hours

Used by:
- dbo.custom_att_processPayrollFacts
- dbo.Custom_att_ProcessMonthlyPayrollFacts wrapper
- dbo.custom_att_GetMonthlyFactVsRawWorkedHours

Notes:
- This is the main worked-time fact source for the attendance pipeline
- Contains no attendance-status or payroll business-rule logic
- Performance hotspot: known to be one of the heavier foundation views
*/
SELECT
    wi.emp_id,
    wi.emp_code,
    wi.work_date,
    COUNT(*) AS worked_interval_count,
    MIN(wi.in_time) AS first_clock_in,
    MAX(wi.out_time) AS last_clock_out,
    SUM(wi.worked_minutes) AS total_worked_minutes,
    CAST(SUM(wi.worked_minutes) / 60.0 AS decimal(10,2)) AS total_worked_hours
FROM dbo.custom_att_fnd_WorkedIntervals wi
GROUP BY
    wi.emp_id,
    wi.emp_code,
    wi.work_date;
