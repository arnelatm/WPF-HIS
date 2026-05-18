


/****** Script for SelectTopNRows command from SSMS  ******/
CREATE View [dbo].[Custom_Monthly_Report]
as SELECT f.[emp_id]
      ,e.emp_Code
	  ,e.First_name
      ,[year_no]
      ,[month_no]
      ,[calendar_days]
      ,[present_days]
      ,[absent_days]
      ,[partial_days]
      ,[worked_hours]
      ,[ot_hours]
      ,[regular_worked_hours]
      ,[absence_hours]
      ,[late_minutes]
      ,[early_out_minutes]
      ,[payroll_review_days]
	  ,[incomplete_punch_pair_days]
  FROM [BioTime].[dbo].[Custom_att_rpt_MonthlyPayrollSafeSummary] f
  left join personnel_employee e 
  on f.emp_id = e.id
