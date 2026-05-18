
CREATE VIEW [dbo].[custom_att_NormalizedPunchesOrig]
AS
SELECT
    t.id,
    t.company_code,
    t.emp_code,
    t.emp_id,
    ISNULL(e.first_name, '') AS first_name,
    ISNULL(e.last_name, '') AS last_name,
    LTRIM(RTRIM(ISNULL(e.first_name, '') + ' ' + ISNULL(e.last_name, ''))) AS employee_name,
    t.punch_time,
    t.punch_state,
    t.verify_type,
    t.work_code,
    t.terminal_sn,
    t.terminal_alias,
    t.area_alias,
    t.source,
    t.purpose,
    t.is_attendance,
    CASE
        WHEN CAST(t.punch_time AS time) < '03:00:00'
            THEN CAST(DATEADD(day, -1, t.punch_time) AS date)
        ELSE CAST(t.punch_time AS date)
    END AS work_date
FROM dbo.iclock_transaction t
LEFT JOIN dbo.personnel_employee e
    ON t.emp_code = e.emp_code;