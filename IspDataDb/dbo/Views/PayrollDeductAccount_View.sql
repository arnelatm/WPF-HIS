
CREATE VIEW [dbo].[PayrollDeductAccount_View]
AS
SELECT        dbo.PayrollDeductAccount.IdNo, dbo.PayrollDeductAccount.DeductionIdNo, dbo.PayrollDeductAccount.PayGroupIdNo, dbo.PayrollDeductAccount.EmployeeIdNo, dbo.PayrollDeductAccount.AccountIdNo, dbo.Account.AccountCode, 
                         dbo.Account.AccountName, dbo.PayGroup.PayGroupCode, dbo.PayGroup.PayGroupName, dbo.PayGroup.PayGroupNameAra, dbo.Account.AccountNameAra, dbo.PayrollDeductAccount.Sequence
FROM            dbo.PayrollDeductAccount INNER JOIN
                         dbo.Account ON dbo.PayrollDeductAccount.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.PayGroup ON dbo.PayrollDeductAccount.PayGroupIdNo = dbo.PayGroup.IdNo