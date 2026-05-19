


/****** Script for SelectTopNRows command from SSMS  ******/
CREATE View [dbo].[Custom_Monthly_Report]
as SELECT f.[emp_id]
      ,e.emp_Code
	  ,e.First_name
      ,f.[year_no]
      ,f.[month_no]
      ,f.[calendar_days]
      ,f.[present_days]
      ,f.[absent_days]
      ,f.[partial_days]
      ,f.[worked_hours]
      ,f.[ot_hours]
      ,f.[regular_worked_hours]
      ,f.[absence_hours]
      ,f.[late_minutes]
      ,f.[early_out_minutes]
      ,f.[payroll_review_days]
	  ,f.[incomplete_punch_pair_days]
  FROM [dbo].[Custom_att_rpt_MonthlyPayrollSafeSummary] f
  left join [dbo].[personnel_employee] e 
  on f.emp_id = e.id
