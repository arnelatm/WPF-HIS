
CREATE VIEW [dbo].[CkJournalItem_View]
AS
SELECT        dbo.CkJournalItem.AccountIdNo, dbo.CkJournalItem.Credit, dbo.CkJournalItem.Debit, dbo.CkJournalItem.IdNo, 
                         dbo.CkJournalItem.JournalIdNo, dbo.CkJournalItem.Notes, dbo.CkJournalItem.RevCostCenterIdNo, dbo.CkJournalItem.Sequence, 
                         dbo.Account.AccountName, dbo.CkJournalItem.Debit - dbo.CkJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CkJournal LEFT OUTER JOIN
                         dbo.CkJournalItem ON dbo.CkJournal.IdNo = dbo.CkJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.CkJournalItem.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CkJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CkJournalItem_View';

