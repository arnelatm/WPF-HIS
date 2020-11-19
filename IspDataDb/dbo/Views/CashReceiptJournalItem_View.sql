CREATE VIEW dbo.CashReceiptJournalItem_View
AS
SELECT        dbo.CashReceiptJournalItem.IdNo, dbo.CashReceiptJournalItem.Sequence, dbo.CashReceiptJournalItem.JournalIdNo, dbo.CashReceiptJournalItem.AccountIdNo, dbo.CashReceiptJournalItem.Debit, 
                         dbo.CashReceiptJournalItem.Credit, dbo.CashReceiptJournalItem.RevCostCenterIdNo, dbo.CashReceiptJournalItem.Notes, dbo.CashReceiptJournalItem.Posted, dbo.CashReceiptJournalItem.DateTimeStamp, 
                         dbo.Account.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, dbo.CashReceiptJournalItem.Credit - dbo.CashReceiptJournalItem.Debit AS OriginalAmount, 
                         dbo.ApOpenInvoice.PaidAmount, dbo.Account.SpecialAccount, dbo.Account.AccountNameAra, dbo.Account.PayeeType, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CashReceiptJournalItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CashReceiptJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo AND dbo.ApOpenInvoice.JournalCode = 'AP' LEFT OUTER JOIN
                         dbo.Account ON dbo.CashReceiptJournalItem.AccountIdNo = dbo.Account.IDNo

GO



GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CashReceiptJournalItem_View';

