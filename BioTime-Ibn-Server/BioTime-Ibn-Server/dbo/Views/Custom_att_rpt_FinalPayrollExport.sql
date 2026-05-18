CREATE VIEW dbo.Custom_att_rpt_FinalPayrollExport
AS
SELECT
    p.year_no,
    p.month_no,
    p.emp_id,

    e.emp_code,
    LTRIM(RTRIM(CONCAT(e.first_name, ' ', e.last_name))) AS employee_name,
    e.department_id,

    p.present_days,
    p.absent_days,
    p.partial_days,

    p.worked_hours,
    p.regular_worked_hours,
    p.ot_hours,
    p.absence_hours,

    p.late_minutes,
    p.early_out_minutes,
    p.payroll_review_days

FROM dbo.Custom_att_rpt_MonthlyPayrollSafeSummary p
LEFT JOIN dbo.personnel_employee e
    ON e.id = p.emp_id;
