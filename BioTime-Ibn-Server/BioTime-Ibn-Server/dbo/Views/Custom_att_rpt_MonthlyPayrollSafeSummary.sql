

CREATE VIEW [dbo].[Custom_att_rpt_MonthlyPayrollSafeSummary]
AS
SELECT
    emp_id,
    year_no,
    month_no,

    COUNT(*) AS calendar_days,

    SUM(CASE WHEN (attendance_status = 'Present' or attendance_status = 'Partial') THEN 1 ELSE 0 END) AS present_days,
    SUM(CASE WHEN attendance_status = 'Absent' THEN 1 ELSE 0 END) AS absent_days,

    SUM(CASE
        WHEN ISNULL(recomputed_absence_hours, 0) > 0
         AND ISNULL(recomputed_worked_minutes, 0) > 0
        THEN 1 ELSE 0
    END) AS partial_days,

    CAST(SUM(ISNULL(recomputed_worked_minutes, 0)) / 60.0 AS decimal(10,2)) AS worked_hours,
    CAST(SUM(ISNULL(ot_minutes, 0)) / 60.0 AS decimal(10,2)) AS ot_hours,

    CAST(
        (SUM(ISNULL(recomputed_worked_minutes, 0)) - SUM(ISNULL(ot_minutes, 0))) / 60.0
        AS decimal(10,2)
    ) AS regular_worked_hours,

    CAST(SUM(ISNULL(recomputed_absence_hours, 0)) AS decimal(10,2)) AS absence_hours,

    SUM(ISNULL(late_minutes, 0)) AS late_minutes,
    SUM(ISNULL(early_out_minutes, 0)) AS early_out_minutes,
	
    SUM(CASE WHEN needs_payroll_review = 1 THEN 1 ELSE 0 END) AS payroll_review_days,
	  
    SUM(CASE WHEN anomaly_flag = 'IncompletePunchPair' THEN 1 ELSE 0 END) AS incomplete_punch_pair_days

FROM dbo.Custom_att_fact_DailyAttendance where year_no=2026 and month_no = 4 and day(att_date) > 0 and day(att_date)<30
GROUP BY
    emp_id,
    year_no,
    month_no;
	
