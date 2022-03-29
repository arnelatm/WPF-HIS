

CREATE VIEW [dbo].[PayrollSummary_View]
as
SELECT empid, dbo.HRPayrollDetails.PeriodMonth, dbo.HRPayrollDetails.PeriodYear, 'E' as PayType, 'Basic Pay' as PayName, Salary as Amount  FROM dbo.HRPayrollDetails 
union 
SELECT empid, dbo.HRPayrollDetails.PeriodMonth, dbo.HRPayrollDetails.PeriodYear, 'E' as PayType, 'Housing' as PayName, HRA as Amount  FROM dbo.HRPayrollDetails 
union 
SELECT empid, dbo.HRPayrollDetails.PeriodMonth, dbo.HRPayrollDetails.PeriodYear, 'E' as PayType, 'Food' as PayName, Food as Amount  FROM dbo.HRPayrollDetails 
union 
SELECT empid, dbo.HRPayrollDetails.PeriodMonth, dbo.HRPayrollDetails.PeriodYear, 'E' as PayType, 'Transport' as PayName, Transport as Amount  FROM dbo.HRPayrollDetails 
union 
SELECT empid, dbo.HRPayrollDetails.PeriodMonth, dbo.HRPayrollDetails.PeriodYear, 'E' as PayType, 'Other Earning' as PayName, Others as Amount  FROM dbo.HRPayrollDetails 
union 
SELECT empid, dbo.HRPayrollDetails.PeriodMonth, dbo.HRPayrollDetails.PeriodYear, 'D' as PayType, 'Loan Amount' as PayName, LoanAmt*-1 as Amount FROM dbo.HRPayrollDetails 
union 
SELECT empid, dbo.HRPayrollDetails.PeriodMonth, dbo.HRPayrollDetails.PeriodYear, 'D' as PayType, 'Other Deduction' as PayName, OthersLess*-1 as Amount  FROM dbo.HRPayrollDetails 
