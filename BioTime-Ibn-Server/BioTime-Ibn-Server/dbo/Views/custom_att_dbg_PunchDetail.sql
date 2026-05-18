
CREATE VIEW [dbo].[custom_att_dbg_PunchDetail]
AS
SELECT
    emp_code,
    emp_id,
    employee_name,
    work_date,
    punch_time,
    punch_state,
    verify_type,
    terminal_sn,
    terminal_alias,
    area_alias,
    source,
    purpose,
    is_attendance
FROM dbo.custom_att_fnd_NormalizedPunches;
