
CREATE VIEW [dbo].[SupplierInvoices]
AS
SELECT        dbo.ApOpenInvoice_View.IdNo, dbo.ApOpenInvoice_View.JournalCode, dbo.ApOpenInvoice_View.JournalItemIdNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.ApOpenInvoice_View.DiscountTaken, dbo.ApJournalItem.Debit, 
                         dbo.ApJournalItem.Credit, dbo.ApJournalItem.RevCostCenterIdNo, dbo.ApJournalItem.Notes, dbo.ApJournalItem.Posted, dbo.ApJournalItem.AccountIdNo, dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.Sequence, 
                         dbo.ApJournal.SupplierIdNo, dbo.ApJournal.InvoiceNo, dbo.ApJournal.InvoiceDate, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra
FROM            dbo.Account INNER JOIN
                         dbo.ApJournalItem ON dbo.Account.IDNo = dbo.ApJournalItem.AccountIdNo INNER JOIN
                         dbo.ApJournal ON dbo.ApJournalItem.JournalIdNo = dbo.ApJournal.IDNo INNER JOIN
                         dbo.Supplier ON dbo.ApJournal.SupplierIdNo = dbo.Supplier.IDNo RIGHT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.ApJournalItem.IdNo = dbo.ApOpenInvoice_View.JournalItemIdNo

GO



GO



GO


