
CREATE VIEW [dbo].[ArJournalItem_View]
AS
SELECT        dbo.ArJournalItem.IdNo, dbo.ArOpenInvoice.JournalCode, dbo.ArJournalItem.JournalIdNo, dbo.ArJournalItem.AccountIdNo, dbo.ArJournalItem.Debit, dbo.ArJournalItem.Credit, dbo.ArJournalItem.RevCostCenterIdNo, 
                dbo.ArJournalItem.Notes, dbo.ArJournalItem.Posted, dbo.ArJournalItem.DateTimeStamp, dbo.Chart.AccountName, dbo.ArOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                dbo.ArJournalItem.Credit - dbo.ArJournalItem.Debit AS OriginalAmount, dbo.ArOpenInvoice.PaidAmount, dbo.ArOpenInvoice.DiscountTaken, dbo.Chart.SpecialAccount, dbo.Chart.AccountNameAra, dbo.Chart.PayeeType, 
                dbo.ArJournalItem.Sequence
FROM            dbo.ArJournalItem 
				LEFT OUTER JOIN dbo.Chart 
				ON dbo.ArJournalItem.AccountIdNo = dbo.Chart.IDNo 
				LEFT OUTER JOIN dbo.ArOpenInvoice 
				ON dbo.ArJournalItem.IdNo = dbo.ArOpenInvoice.JournalItemIdNo AND dbo.ArOpenInvoice.JournalCode = 'AR'
