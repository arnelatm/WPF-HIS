CREATE VIEW dbo.CheckDisbursementJournalItem_View
AS
SELECT        dbo.CheckDisbursementJournalItem.AccountIdNo, dbo.CheckDisbursementJournalItem.Credit, dbo.CheckDisbursementJournalItem.Debit, dbo.CheckDisbursementJournalItem.IdNo, 
                         dbo.CheckDisbursementJournalItem.JournalIdNo, dbo.CheckDisbursementJournalItem.Notes, dbo.CheckDisbursementJournalItem.RevCostCenterIdNo, dbo.CheckDisbursementJournalItem.Sequence, 
                         dbo.Account.AccountName, dbo.CheckDisbursementJournalItem.Debit - dbo.CheckDisbursementJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CheckDisbursementJournal LEFT OUTER JOIN
                         dbo.CheckDisbursementJournalItem ON dbo.CheckDisbursementJournal.IdNo = dbo.CheckDisbursementJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.CheckDisbursementJournalItem.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CheckDisbursementJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo

GO



GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CheckDisbursementJournalItem_View';

