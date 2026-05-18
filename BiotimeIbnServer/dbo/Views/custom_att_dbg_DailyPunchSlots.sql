

CREATE VIEW [dbo].[custom_att_dbg_DailyPunchSlots]
AS
/*
Layer: Debug View
Role: Daily punch-slot expansion for troubleshooting raw punch patterns

Primary Source:
- dbo.custom_att_fnd_NormalizedPunches

Purpose:
- Expands daily punches into ordered slot columns (punch_1 to punch_6)
- Helps visualize incomplete, odd, or unusual punch sequences

Key Outputs:
- total_punches
- punch_1 to punch_6
- employee identity
- work_date

Used by:
- dbo.custom_att_rpt_PunchExceptionsBasic
- Debug and troubleshooting workflows

Notes:
- Debug/helper layer only
- Not a core reporting or business-rule source
- Intended for inspection and exception analysis
*/
WITH Punches AS (
    SELECT
        emp_code,
        emp_id,
        employee_name,
        work_date,
        punch_time,
        ROW_NUMBER() OVER (
            PARTITION BY emp_code, work_date
            ORDER BY punch_time
        ) AS punch_no
    FROM dbo.custom_att_fnd_NormalizedPunches
)
SELECT
    emp_code,
    emp_id,
    employee_name,
    work_date,
    MAX(CASE WHEN punch_no = 1 THEN punch_time END) AS punch_1,
    MAX(CASE WHEN punch_no = 2 THEN punch_time END) AS punch_2,
    MAX(CASE WHEN punch_no = 3 THEN punch_time END) AS punch_3,
    MAX(CASE WHEN punch_no = 4 THEN punch_time END) AS punch_4,
    MAX(CASE WHEN punch_no = 5 THEN punch_time END) AS punch_5,
    MAX(CASE WHEN punch_no = 6 THEN punch_time END) AS punch_6,
    COUNT(*) AS total_punches
FROM Punches
GROUP BY
    emp_code,
    emp_id,
    employee_name,
    work_date;
