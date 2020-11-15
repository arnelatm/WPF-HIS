
CREATE VIEW [dbo].[ApJournalItem_View]
AS
SELECT			dbo.ApJournalItem.IdNo, dbo.ApJournalItem.Sequence, dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.AccountIdNo, dbo.ApJournalItem.Debit, dbo.ApJournalItem.Credit, dbo.ApJournalItem.RevCostCenterIdNo, 
				dbo.ApJournalItem.Notes, dbo.ApJournalItem.Posted, dbo.ApJournalItem.DateTimeStamp, dbo.Account.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, 
				dbo.ApJournalItem.Credit - dbo.ApJournalItem.Debit AS OriginalAmount, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.Account.SpecialAccount, dbo.Account.AccountNameAra, dbo.Account.PayeeType
FROM			dbo.ApJournalItem 
				LEFT OUTER JOIN dbo.Account 
				ON dbo.ApJournalItem.AccountIdNo = dbo.Account.IDNo 
				LEFT OUTER JOIN dbo.ApOpenInvoice 
				ON dbo.ApJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo AND DBO.ApOpenInvoice.[JournalCode] = 'AP'
