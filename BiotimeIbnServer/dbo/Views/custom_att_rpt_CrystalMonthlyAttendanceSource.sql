CREATE VIEW dbo.custom_att_rpt_CrystalMonthlyAttendanceSource
AS
SELECT
    f.emp_id,
    pe.emp_code,
    pe.first_name AS employee_name,
    d.dept_name AS department_name,

    f.att_date,
    f.year_no,
    f.month_no,

    f.daily_status,
    f.business_day_type,
    f.attendance_status,
    f.punch_status,
    f.schedule_label,

    f.recomputed_worked_minutes,
    f.ot_minutes,
    f.required_scheduled_hours,
    f.worked_hours,
    f.ot_hours,
    f.date_type
FROM dbo.custom_att_fact_DailyAttendance f
LEFT JOIN dbo.personnel_employee pe
    ON f.emp_id = pe.id
LEFT JOIN dbo.personnel_department d
    ON pe.department_id = d.id;
