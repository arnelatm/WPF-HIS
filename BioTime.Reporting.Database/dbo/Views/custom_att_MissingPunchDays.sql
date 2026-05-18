CREATE VIEW dbo.custom_att_MissingPunchDays
AS
SELECT
    emp_code,
    emp_id,
    employee_name,
    work_date,
    total_punches,
    first_punch,
    last_punch,
    CASE
        WHEN total_punches = 1 THEN 'Only one punch'
        WHEN total_punches % 2 = 1 THEN 'Odd punch count'
        ELSE 'OK'
    END AS issue_type
FROM dbo.custom_att_DailyPunchCount
WHERE total_punches % 2 = 1;