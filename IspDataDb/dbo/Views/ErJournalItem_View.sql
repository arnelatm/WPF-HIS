

CREATE VIEW [dbo].[ErJournalItem_View]
AS
SELECT        dbo.ErJournalItem.IdNo, dbo.ArOpenInvoice.JournalCode, dbo.ErJournalItem.JournalIdNo, dbo.ErJournalItem.AccountIdNo, dbo.ErJournalItem.Debit, dbo.ErJournalItem.Credit, dbo.ErJournalItem.RevCostCenterIdNo, 
                dbo.ErJournalItem.Notes, dbo.ErJournalItem.Posted, dbo.ErJournalItem.DateTimeStamp, dbo.Account.AccountName, dbo.ArOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                dbo.ErJournalItem.Credit - dbo.ErJournalItem.Debit AS OriginalAmount, dbo.ArOpenInvoice.PaidAmount, dbo.ArOpenInvoice.DiscountTaken, dbo.Account.SpecialAccount, dbo.Account.AccountNameAra, dbo.Account.PayeeType, 
                dbo.ErJournalItem.Sequence
FROM            dbo.ErJournalItem 
				LEFT OUTER JOIN dbo.Account 
				ON dbo.ErJournalItem.AccountIdNo = dbo.Account.IDNo 
				LEFT OUTER JOIN dbo.ArOpenInvoice 
				ON dbo.ErJournalItem.IdNo = dbo.ArOpenInvoice.JournalItemIdNo AND dbo.ArOpenInvoice.JournalCode = 'ER'