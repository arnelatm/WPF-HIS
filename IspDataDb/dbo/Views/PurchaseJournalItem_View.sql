
CREATE VIEW [dbo].[PurchaseJournalItem_View]
AS
SELECT        dbo.PurchaseJournalItem.IdNo, dbo.PurchaseJournalItem.Sequence, dbo.PurchaseJournalItem.JournalIdNo, dbo.PurchaseJournalItem.AccountIdNo, dbo.PurchaseJournalItem.Debit, dbo.PurchaseJournalItem.Credit, dbo.PurchaseJournalItem.RevCostCenterIdNo, 
                         dbo.PurchaseJournalItem.Notes, dbo.PurchaseJournalItem.Posted, dbo.PurchaseJournalItem.DateTimeStamp, dbo.Chart.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                         dbo.PurchaseJournalItem.Credit - dbo.PurchaseJournalItem.Debit AS OriginalAmount, dbo.ApOpenInvoice.PaidAmount, dbo.Chart.SpecialAccount, dbo.Chart.AccountNameAra, dbo.Chart.PayeeType
FROM            dbo.PurchaseJournalItem LEFT OUTER JOIN
                         dbo.Chart ON dbo.PurchaseJournalItem.AccountIdNo = dbo.Chart.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.PurchaseJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
