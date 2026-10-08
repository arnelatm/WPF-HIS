CREATE PROCEDURE dbo.DeletePcJournalAtomic @JournalIdNo int
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.PcJournal WHERE IdNo=@JournalIdNo) RETURN 1;
 IF EXISTS(SELECT 1 FROM dbo.PcJournal WHERE IdNo=@JournalIdNo AND (Posted=1 OR PcClosed=1)) THROW 51261,'Posted or closed petty cash entries cannot be deleted.',1;
 IF EXISTS(SELECT 1 FROM dbo.PcJournalItem i JOIN dbo.Reconciled r ON r.JournalCode='PC' AND r.JournalItemIdNo=i.IdNo WHERE i.JournalIdNo=@JournalIdNo) THROW 51262,'Reconciled petty cash entries cannot be deleted.',1;
 IF EXISTS(SELECT 1 FROM dbo.ArOpenInvoice o JOIN dbo.CsrOiItem c ON c.ArOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='PC' AND o.JournalIdNo=@JournalIdNo) OR EXISTS(SELECT 1 FROM dbo.ApOpenInvoice o JOIN dbo.CdOiItem c ON c.ApOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='PC' AND o.JournalIdNo=@JournalIdNo) OR EXISTS(SELECT 1 FROM dbo.ApOpenInvoice o JOIN dbo.PcOiItem p ON p.ApOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='PC' AND o.JournalIdNo=@JournalIdNo) OR EXISTS(SELECT 1 FROM dbo.ApOpenInvoice o JOIN dbo.CkOiItem k ON k.ApOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='PC' AND o.JournalIdNo=@JournalIdNo) THROW 51263,'Petty cash open invoices with allocations cannot be deleted.',1;
 EXEC dbo.AssertJournalNotReconciliationLocked @JournalCode='PC', @JournalIdNo=@JournalIdNo;
 BEGIN TRAN; BEGIN TRY DELETE FROM dbo.PcOiItem WHERE DjIdNo=@JournalIdNo;DELETE FROM dbo.ArOpenInvoice WHERE JournalCode='PC' AND JournalIdNo=@JournalIdNo;DELETE FROM dbo.ApOpenInvoice WHERE JournalCode='PC' AND JournalIdNo=@JournalIdNo;DELETE FROM dbo.PcJournalItem WHERE JournalIdNo=@JournalIdNo;DELETE FROM dbo.PcJournal WHERE IdNo=@JournalIdNo;COMMIT;END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;THROW;END CATCH END;
GO
