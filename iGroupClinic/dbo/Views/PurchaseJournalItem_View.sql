
CREATE VIEW [dbo].[PurchaseJournalItem_View]
AS
SELECT        dbo.PurchaseJournalItem.IdNo, dbo.PurchaseJournalItem.Sequence, dbo.PurchaseJournalItem.JournalIdNo, dbo.PurchaseJournalItem.AccountIdNo, dbo.PurchaseJournalItem.Debit, dbo.PurchaseJournalItem.Credit, dbo.PurchaseJournalItem.RevCostCenterIdNo, 
                         dbo.PurchaseJournalItem.Notes, dbo.PurchaseJournalItem.Posted, dbo.PurchaseJournalItem.DateTimeStamp, dbo.Account.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                         dbo.PurchaseJournalItem.Credit - dbo.PurchaseJournalItem.Debit AS OriginalAmount, dbo.ApOpenInvoice.PaidAmount, dbo.Account.SpecialAccount, dbo.Account.AccountNameAra, dbo.Account.PayeeType
FROM            dbo.PurchaseJournalItem LEFT OUTER JOIN
                         dbo.Account ON dbo.PurchaseJournalItem.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.PurchaseJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
