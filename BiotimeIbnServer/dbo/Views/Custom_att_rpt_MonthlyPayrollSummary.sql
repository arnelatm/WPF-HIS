

CREATE VIEW [dbo].[Custom_att_rpt_MonthlyPayrollSummary]
AS
SELECT
    f.emp_id,
	e.emp_code,
	e.first_name
	year_no,
    month_no,

    COUNT(*) AS calendar_days,

    SUM(CASE WHEN attendance_status = 'Present' THEN 1 ELSE 0 END) AS present_days,
    SUM(CASE WHEN attendance_status = 'Absent' THEN 1 ELSE 0 END) AS absent_days,
    SUM(CASE WHEN attendance_status = 'Partial' THEN 1 ELSE 0 END) AS partial_days,
    SUM(CASE WHEN attendance_status = 'NotRequired' THEN 1 ELSE 0 END) AS not_required_days,
    SUM(CASE WHEN attendance_status = 'WorkedNonRequired' THEN 1 ELSE 0 END) AS worked_non_required_days,

    CAST(SUM(ISNULL(recomputed_worked_minutes, 0)) / 60.0 AS decimal(10,2)) AS worked_hours,
    CAST(SUM(ISNULL(ot_minutes, 0)) / 60.0 AS decimal(10,2)) AS ot_hours,

    CAST(SUM(ISNULL(regular_worked_minutes, 0)) / 60.0 AS decimal(10,2)) AS regular_worked_hours,

    CAST(SUM(ISNULL(recomputed_absence_hours, 0)) AS decimal(10,2)) AS absence_hours,

    SUM(ISNULL(late_minutes, 0)) AS late_minutes,
    SUM(ISNULL(early_out_minutes, 0)) AS early_out_minutes,

    SUM(CASE WHEN needs_payroll_review = 1 THEN 1 ELSE 0 END) AS payroll_review_days

FROM dbo.custom_att_fact_DailyAttendance f
left join personnel_employee e
on f.emp_id = e.id
WHERE DAY(att_date) BETWEEN 1 AND 29 and month_no=4  -- 🔴 Key addition
GROUP BY
    emp_id,
    year_no,
    month_no,
	e.emp_code,
	e.first_name;

