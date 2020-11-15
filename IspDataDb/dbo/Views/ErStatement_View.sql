




CREATE VIEW [dbo].[ErStatement_View]
AS
SELECT        dbo.ErDetails_View.JournalCode, dbo.ErDetails_View.IdNo, dbo.ErDetails_View.Sequence, dbo.ErDetails_View.JournalIdNo, dbo.ErDetails_View.AccountIdNo, dbo.ErDetails_View.Debit, dbo.ErDetails_View.Credit, 
                         dbo.ErDetails_View.RevCostCenterIdNo, dbo.ErDetails_View.Notes, dbo.ErDetails_View.Posted, dbo.ErDetails_View.EmployeeIdNo, dbo.ErDetails_View.InvoiceNo, dbo.ErDetails_View.TransactionDate, dbo.ErDetails_View.ReferenceNo, 
                         dbo.ErDetails_View.TransactionType, dbo.Account.SpecialAccount, dbo.ErDetails_View.MainNote
FROM            dbo.ErDetails_View INNER JOIN
                         dbo.Account ON dbo.ErDetails_View.AccountIdNo = dbo.Account.IDNo
WHERE        (dbo.Account.SpecialAccount = 'EL')