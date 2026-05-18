
CREATE VIEW [dbo].[custom_att_dbg_DailyPunchCount]
AS
SELECT
    emp_code,
    emp_id,
    employee_name,
    work_date,
    COUNT(*) AS total_punches,
    MIN(punch_time) AS first_punch,
    MAX(punch_time) AS last_punch
FROM dbo.custom_att_fnd_NormalizedPunches
GROUP BY
    emp_code,
    emp_id,
    employee_name,
    work_date;
