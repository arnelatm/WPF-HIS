
CREATE VIEW [dbo].[PayrollDeductAccount_View]
AS
SELECT        dbo.PayrollDeductAccount.IdNo, dbo.PayrollDeductAccount.DeductionIdNo, dbo.PayrollDeductAccount.PayGroupIdNo, dbo.PayrollDeductAccount.EmployeeIdNo, dbo.PayrollDeductAccount.AccountIdNo, dbo.Chart.AccountCode, 
                         dbo.Chart.AccountName, dbo.PayGroup.PayGroupCode, dbo.PayGroup.PayGroupName, dbo.PayGroup.PayGroupNameAra, dbo.Chart.AccountNameAra, dbo.PayrollDeductAccount.Sequence
FROM            dbo.PayrollDeductAccount INNER JOIN
                         dbo.Chart ON dbo.PayrollDeductAccount.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.PayGroup ON dbo.PayrollDeductAccount.PayGroupIdNo = dbo.PayGroup.IdNo