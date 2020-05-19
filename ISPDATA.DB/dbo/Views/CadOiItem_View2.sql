
CREATE VIEW [dbo].[CadOiItem_View2]
AS
SELECT        dbo.CadOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, 
                         dbo.ApOpenInvoice_View.Balance + dbo.CadOiItem.Amount + dbo.CadOiItem.DiscountTaken AS PreviousBalance, dbo.CadOiItem.Amount, dbo.CadOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, 
                         dbo.CadOiItem.JournalItemIdNo, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.ApOpenInvoice_View.JournalCode, dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, 
                         dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.CadOiItem.IdNo, dbo.ApOpenInvoice_View.SupplierIdNo, dbo.ApOpenInvoice_View.IdNo AS OpenInvoiceIdNo, 
                         dbo.CadOiItem.CadIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo
FROM            dbo.CadOiItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.CadOiItem.JournalItemIdNo = dbo.ApOpenInvoice_View.JournalItemIdNo
