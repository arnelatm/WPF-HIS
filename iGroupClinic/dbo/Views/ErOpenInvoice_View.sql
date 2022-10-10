
CREATE VIEW [dbo].[ErOpenInvoice_View]
AS
SELECT        dbo.ErOpenInvoice.IdNo, dbo.ErOpenInvoice.JournalCode, dbo.ErOpenInvoice.JournalItemIdNo, dbo.ErDetails_View.Debit - dbo.ErDetails_View.Credit AS Amount, dbo.ErOpenInvoice.PaidAmount, 
                         dbo.ErOpenInvoice.DiscountTaken, dbo.ErDetails_View.Debit - dbo.ErDetails_View.Credit - dbo.ErOpenInvoice.PaidAmount - dbo.ErOpenInvoice.DiscountTaken AS Balance, 
                         dbo.ErDetails_View.Debit - dbo.ErDetails_View.Credit AS InvoiceAmount, dbo.ErOpenInvoice.JournalIdNo, dbo.ErDetails_View.AccountIdNo, dbo.ErDetails_View.EmployeeIdNo, 
                         dbo.ErDetails_View.ReferenceNo, dbo.ErDetails_View.TransactionType, dbo.ErDetails_View.TransactionDate, dbo.ErDetails_View.InvoiceNo, dbo.ErDetails_View.Notes, dbo.Account.AccountCode, 
                         dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.Account.SpecialAccount, dbo.Customer.CustomerCode
FROM            dbo.Customer RIGHT OUTER JOIN
                         dbo.ErDetails_View ON dbo.Customer.IdNo = dbo.ErDetails_View.EmployeeIdNo RIGHT OUTER JOIN
                         dbo.ErOpenInvoice ON dbo.ErDetails_View.IdNo = dbo.ErOpenInvoice.JournalItemIdNo AND 
                         dbo.ErDetails_View.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS = dbo.ErOpenInvoice.JournalCode LEFT OUTER JOIN
                         dbo.Account ON dbo.ErDetails_View.AccountIdNo = dbo.Account.IDNo
