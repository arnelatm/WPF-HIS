CREATE VIEW dbo.custom_rpt_PunchExceptionsBasic
AS
SELECT
    emp_code,
    emp_id,
    employee_name,
    work_date,
    total_punches,
    punch_1,
    punch_2,
    punch_3,
    punch_4,
    punch_5,
    punch_6,
    CASE
        WHEN total_punches = 1 THEN 'Only One Punch'
        WHEN total_punches = 3 THEN 'Three Punches / One Missing'
        WHEN total_punches = 5 THEN 'Five Punches / Unpaired'
        WHEN total_punches % 2 = 1 THEN 'Odd Number of Punches'
        ELSE 'OK'
    END AS exception_type
FROM dbo.custom_att_DailyPunchSlots
WHERE total_punches = 1
   OR total_punches % 2 = 1;