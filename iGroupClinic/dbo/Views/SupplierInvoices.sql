
CREATE VIEW [dbo].[SupplierInvoices]
AS
SELECT        dbo.ApOpenInvoice.IdNo, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.JournalItemIdNo, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.ApJournalItem.Debit, 
                         dbo.ApJournalItem.Credit, dbo.ApJournalItem.RevCostCenterIdNo, dbo.ApJournalItem.Notes, dbo.ApJournalItem.Posted, dbo.ApJournalItem.AccountIdNo, dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.Sequence, 
                         dbo.ApJournal.SupplierIdNo, dbo.ApJournal.InvoiceNo, dbo.ApJournal.InvoiceDate, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra
FROM            dbo.Account INNER JOIN
                         dbo.ApJournalItem ON dbo.Account.IDNo = dbo.ApJournalItem.AccountIdNo INNER JOIN
                         dbo.ApJournal ON dbo.ApJournalItem.JournalIdNo = dbo.ApJournal.IDNo INNER JOIN
                         dbo.Supplier ON dbo.ApJournal.SupplierIdNo = dbo.Supplier.IDNo RIGHT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.ApJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
