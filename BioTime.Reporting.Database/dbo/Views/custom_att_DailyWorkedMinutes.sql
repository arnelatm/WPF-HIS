
CREATE VIEW [dbo].[custom_att_DailyWorkedMinutes]
AS
SELECT
    wi.emp_id,
    wi.work_date,
    COUNT(*) AS worked_interval_count,
    MIN(wi.in_time) AS first_clock_in,
    MAX(wi.out_time) AS last_clock_out,
    SUM(wi.worked_minutes) AS total_worked_minutes,
    CAST(SUM(wi.worked_minutes) / 60.0 AS decimal(10,2)) AS total_worked_hours
FROM dbo.custom_att_WorkedIntervals wi
GROUP BY
    wi.emp_id,
    wi.work_date;