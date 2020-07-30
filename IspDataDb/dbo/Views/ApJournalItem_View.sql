
CREATE VIEW [dbo].[ApJournalItem_View]
AS
SELECT			dbo.ApJournalItem.IdNo, dbo.ApJournalItem.Sequence, dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.AccountIdNo, dbo.ApJournalItem.Debit, dbo.ApJournalItem.Credit, dbo.ApJournalItem.RevCostCenterIdNo, 
				dbo.ApJournalItem.Notes, dbo.ApJournalItem.Posted, dbo.ApJournalItem.DateTimeStamp, dbo.Chart.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, 
				dbo.ApJournalItem.Credit - dbo.ApJournalItem.Debit AS OriginalAmount, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.Chart.SpecialAccount, dbo.Chart.AccountNameAra, dbo.Chart.PayeeType
FROM			dbo.ApJournalItem 
				LEFT OUTER JOIN dbo.Chart 
				ON dbo.ApJournalItem.AccountIdNo = dbo.Chart.IDNo 
				LEFT OUTER JOIN dbo.ApOpenInvoice 
				ON dbo.ApJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo AND DBO.ApOpenInvoice.[JournalCode] = 'AP'
