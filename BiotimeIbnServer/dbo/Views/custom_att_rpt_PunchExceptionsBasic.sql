

CREATE VIEW [dbo].[custom_att_rpt_PunchExceptionsBasic]
AS
/*
Layer: Reporting View
Role: Basic punch-exception report for odd or incomplete punch patterns

Primary Source:
- dbo.custom_att_dbg_DailyPunchSlots

Purpose:
- Exposes readable punch-exception rows for reporting and operational review
- Classifies common odd punch-count cases such as one punch, three punches, and other odd punch totals

Key Outputs:
- employee identity
- work_date
- punch_1 to punch_6
- total_punches
- exception_type

Used by:
- Operations review
- Punch exception troubleshooting
- Reporting consumers

Notes:
- Reporting view built on top of a debug/helper source
- Intended for readable exception output, not core attendance calculation
*/
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
FROM dbo.custom_att_dbg_DailyPunchSlots
WHERE total_punches = 1
   OR total_punches % 2 = 1;
