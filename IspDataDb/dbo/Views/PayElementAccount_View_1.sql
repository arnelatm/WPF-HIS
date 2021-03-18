
CREATE VIEW [dbo].[PayElementAccount_View]
AS
SELECT        dbo.PayElementAccount.IdNo, dbo.PayElementAccount.PayElementIdNo, dbo.PayElementAccount.PayGroupIdNo, dbo.PayElementAccount.EmployeeIdNo, dbo.PayElementAccount.AccountIdNo, dbo.Account.AccountCode, 
                         dbo.Account.AccountName, dbo.PayGroup.PayGroupCode, dbo.PayGroup.PayGroupName, dbo.PayGroup.PayGroupNameAra, dbo.Account.AccountNameAra, dbo.PayElementAccount.Sequence
FROM            dbo.PayElementAccount INNER JOIN
                         dbo.Account ON dbo.PayElementAccount.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.PayGroup ON dbo.PayElementAccount.PayGroupIdNo = dbo.PayGroup.IdNo