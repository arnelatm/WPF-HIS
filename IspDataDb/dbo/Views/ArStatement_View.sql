

CREATE VIEW [dbo].[ArStatement_View]
AS
SELECT        dbo.ARDetails_View.JournalCode, dbo.ARDetails_View.IdNo, dbo.ARDetails_View.Sequence, dbo.ARDetails_View.JournalIdNo, dbo.ARDetails_View.AccountIdNo, dbo.ARDetails_View.Debit, dbo.ARDetails_View.Credit, 
                         dbo.ARDetails_View.RevCostCenterIdNo, dbo.ARDetails_View.Notes, dbo.ARDetails_View.Posted, dbo.ARDetails_View.CustomerIdNo, dbo.ARDetails_View.InvoiceNo, dbo.ARDetails_View.TransactionDate, 
                         dbo.ARDetails_View.ReferenceNo, dbo.ARDetails_View.TransactionType, dbo.Account.SpecialAccount, dbo.ARDetails_View.MainNote, dbo.Customer.CustomerCode, dbo.Customer.CustomerName, 
                         dbo.Customer.CustomerNameAra
FROM            dbo.ARDetails_View INNER JOIN
                         dbo.Account ON dbo.ARDetails_View.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.Customer ON dbo.ARDetails_View.CustomerIdNo = dbo.Customer.IdNo
WHERE        (dbo.Account.SpecialAccount = 'AR' or dbo.Account.SpecialAccount = 'CA')

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ArStatement_View';


GO






