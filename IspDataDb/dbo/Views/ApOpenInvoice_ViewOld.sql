


CREATE VIEW [dbo].[ApOpenInvoice_ViewOld]
AS
SELECT			dbo.ApOpenInvoice.IdNo,
				dbo.ApOpenInvoice.JournalCode, 
				dbo.ApOpenInvoice.JournalItemIdNo, 
				dbo.APDetails_View.Credit - dbo.APDetails_View.Debit AS Amount, 
				dbo.ApOpenInvoice.PaidAmount, 
                dbo.ApOpenInvoice.DiscountTaken, 
				dbo.APDetails_View.Credit - dbo.APDetails_View.Debit - dbo.ApOpenInvoice.PaidAmount - dbo.ApOpenInvoice.DiscountTaken AS Balance, 
                dbo.APDetails_View.Credit - dbo.APDetails_View.Debit AS InvoiceAmount, 
				dbo.ApOpenInvoice.JournalIdNo, 
				dbo.APDetails_View.AccountIdNo, 
				dbo.APDetails_View.SupplierIdNo, 
				dbo.APDetails_View.ReferenceNo, 
                dbo.APDetails_View.TransactionType, 
				dbo.APDetails_View.TransactionDate, 
				dbo.APDetails_View.InvoiceNo, 
				dbo.APDetails_View.Notes, 
				dbo.Account.AccountCode, 
				dbo.Account.AccountName, 
				dbo.Account.AccountNameAra, 
                dbo.Account.SpecialAccount
FROM            dbo.ApOpenInvoice 
				LEFT OUTER JOIN dbo.APDetails_View 
				ON dbo.ApOpenInvoice.JournalItemIdNo = dbo.APDetails_View.IdNo AND dbo.ApOpenInvoice.JournalCode = dbo.APDetails_View.JournalCode Collate SQL_Latin1_General_CP1_CI_AS
				LEFT OUTER JOIN dbo.Account 
				ON dbo.APDetails_View.AccountIdNo = dbo.Account.IDNo