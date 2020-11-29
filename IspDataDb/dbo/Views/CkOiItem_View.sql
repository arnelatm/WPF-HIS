
CREATE VIEW [dbo].[CkOiItem_View]
AS
SELECT        dbo.CkOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, dbo.ApOpenInvoice_View.Balance + dbo.CkOiItem.Amount + dbo.CkOiItem.DiscountTaken AS PreviousBalance, 
                         dbo.CkOiItem.Amount, dbo.CkOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.ApOpenInvoice_View.JournalCode, 
                         dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.CkOiItem.IdNo, dbo.CkOiItem.ApOpenInvoiceIdNo, 
                         dbo.ApOpenInvoice_View.SupplierIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo, dbo.CkOiItem.DjIdNo
FROM            dbo.CkOiItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.CkOiItem.ApOpenInvoiceIdNo = dbo.ApOpenInvoice_View.IdNo