




CREATE VIEW [dbo].[ApStatement_View]
AS
SELECT        dbo.ApDetails_View.JournalCode, dbo.ApDetails_View.IdNo, dbo.ApDetails_View.Sequence, dbo.ApDetails_View.JournalIdNo, dbo.ApDetails_View.AccountIdNo, dbo.ApDetails_View.Debit, dbo.ApDetails_View.Credit, 
                         dbo.ApDetails_View.RevCostCenterIdNo, dbo.ApDetails_View.Notes, dbo.ApDetails_View.Posted, dbo.ApDetails_View.SupplierIdNo, dbo.ApDetails_View.InvoiceNo, dbo.ApDetails_View.TransactionDate, dbo.ApDetails_View.ReferenceNo, 
                         dbo.ApDetails_View.TransactionType, dbo.Account.SpecialAccount, dbo.APDetails_View.MainNote, 
						 Iif(dbo.Account.SpecialAccount='PD',1,0) as 'PurchaseDiscount'
FROM            dbo.ApDetails_View INNER JOIN
                         dbo.Account ON dbo.ApDetails_View.AccountIdNo = dbo.Account.IDNo
WHERE        (dbo.Account.SpecialAccount = 'AP' or dbo.Account.SpecialAccount='PD')
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ApStatement_View';

