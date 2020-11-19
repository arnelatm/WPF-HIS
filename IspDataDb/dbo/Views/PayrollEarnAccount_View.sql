CREATE VIEW dbo.PayrollEarnAccount_View
AS
SELECT        dbo.PayrollEarnAccount.IdNo, dbo.PayrollEarnAccount.EarningIdNo, dbo.PayrollEarnAccount.PayGroupIdNo, dbo.PayrollEarnAccount.EmployeeIdNo, dbo.PayrollEarnAccount.AccountIdNo, dbo.Account.AccountCode, 
                         dbo.Account.AccountName, dbo.PayGroup.PayGroupCode, dbo.PayGroup.PayGroupName, dbo.PayGroup.PayGroupNameAra, dbo.Account.AccountNameAra, dbo.PayrollEarnAccount.Sequence
FROM            dbo.PayrollEarnAccount INNER JOIN
                         dbo.Account ON dbo.PayrollEarnAccount.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.PayGroup ON dbo.PayrollEarnAccount.PayGroupIdNo = dbo.PayGroup.IdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'PayrollEarnAccount_View';


GO




