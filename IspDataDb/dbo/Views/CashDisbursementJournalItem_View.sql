CREATE VIEW dbo.CashDisbursementJournalItem_View
AS
SELECT        dbo.CashDisbursementJournalItem.AccountIdNo, dbo.CashDisbursementJournalItem.Credit, dbo.CashDisbursementJournalItem.Debit, dbo.CashDisbursementJournalItem.IdNo, 
                         dbo.CashDisbursementJournalItem.JournalIdNo, dbo.CashDisbursementJournalItem.Notes, dbo.CashDisbursementJournalItem.RevCostCenterIdNo, dbo.CashDisbursementJournalItem.Sequence, 
                         dbo.Account.AccountName, dbo.CashDisbursementJournalItem.Debit - dbo.CashDisbursementJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CashDisbursementJournalItem LEFT OUTER JOIN
                         dbo.Account ON dbo.CashDisbursementJournalItem.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.CashDisbursementJournal ON dbo.CashDisbursementJournalItem.JournalIdNo = dbo.CashDisbursementJournal.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CashDisbursementJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo AND dbo.ApOpenInvoice.JournalCode = 'CD'

GO



GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CashDisbursementJournalItem_View';

