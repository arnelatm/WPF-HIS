CREATE VIEW dbo.PcsOiItem_View
AS
SELECT        dbo.PcsOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, dbo.ApOpenInvoice_View.Balance + dbo.PcsOiItem.Amount + dbo.PcsOiItem.DiscountTaken AS PreviousBalance, 
                         dbo.PcsOiItem.Amount, dbo.PcsOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.PcsOiItem.ApOpenInvoiceIdNo, dbo.ApOpenInvoice_View.JournalCode, 
                         dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.PcsOiItem.IdNo, dbo.ApOpenInvoice_View.SupplierIdNo, 
                         dbo.PcsOiItem.PcsIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo
FROM            dbo.PcsOiItem INNER JOIN
                         dbo.ApOpenInvoice_View ON dbo.PcsOiItem.ApOpenInvoiceIdNo = dbo.ApOpenInvoice_View.IdNo
