CREATE VIEW dbo.CkdOiItem_View
AS
SELECT        dbo.CkdOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, dbo.ApOpenInvoice_View.Balance + dbo.CkdOiItem.Amount + dbo.CkdOiItem.DiscountTaken AS PreviousBalance, 
                         dbo.CkdOiItem.Amount, dbo.CkdOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.CkdOiItem.ApOpenInvoiceIdNo, dbo.ApOpenInvoice_View.JournalCode, 
                         dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.CkdOiItem.IdNo, dbo.ApOpenInvoice_View.SupplierIdNo, 
                         dbo.ApOpenInvoice_View.IdNo AS OpenInvoiceIdNo, dbo.CkdOiItem.CkdIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo
FROM            dbo.CkdOiItem INNER JOIN
                         dbo.ApOpenInvoice_View ON dbo.CkdOiItem.ApOpenInvoiceIdNo = dbo.ApOpenInvoice_View.IdNo

GO



GO


