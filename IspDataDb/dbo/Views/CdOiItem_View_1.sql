
CREATE VIEW [dbo].[CdOiItem_View]
AS
SELECT        dbo.CdOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, dbo.ApOpenInvoice_View.Balance + dbo.CdOiItem.Amount + dbo.CdOiItem.DiscountTaken AS PreviousBalance, 
                         dbo.CdOiItem.Amount, dbo.CdOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.ApOpenInvoice_View.JournalCode, 
                         dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.CdOiItem.IdNo, dbo.CdOiItem.ApOpenInvoiceIdNo, 
                         dbo.ApOpenInvoice_View.SupplierIdNo, dbo.CdOiItem.CjIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo
FROM            dbo.CdOiItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.CdOiItem.ApOpenInvoiceIdNo = dbo.ApOpenInvoice_View.IdNo