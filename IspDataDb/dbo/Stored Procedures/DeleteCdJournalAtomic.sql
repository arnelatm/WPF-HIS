CREATE PROCEDURE dbo.DeleteCdJournalAtomic @JournalIdNo int
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.CdJournal WHERE IdNo=@JournalIdNo) RETURN 1;
 IF EXISTS(SELECT 1 FROM dbo.CdJournal WHERE IdNo=@JournalIdNo AND (Posted=1 OR PcClosed=1)) THROW 51231,'Posted or closed cash disbursements cannot be deleted.',1;
 IF EXISTS(SELECT 1 FROM dbo.CdJournalItem i JOIN dbo.Reconciled r ON r.JournalCode='CD' AND r.JournalItemIdNo=i.IdNo WHERE i.JournalIdNo=@JournalIdNo) THROW 51232,'Reconciled cash disbursements cannot be deleted.',1;
 IF EXISTS(SELECT 1 FROM dbo.ArOpenInvoice o JOIN dbo.CsrOiItem c ON c.ArOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='CD' AND o.JournalIdNo=@JournalIdNo) OR EXISTS(SELECT 1 FROM dbo.ApOpenInvoice o JOIN dbo.CdOiItem c ON c.ApOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='CD' AND o.JournalIdNo=@JournalIdNo) OR EXISTS(SELECT 1 FROM dbo.ApOpenInvoice o JOIN dbo.PcOiItem p ON p.ApOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='CD' AND o.JournalIdNo=@JournalIdNo) OR EXISTS(SELECT 1 FROM dbo.ApOpenInvoice o JOIN dbo.CkOiItem k ON k.ApOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='CD' AND o.JournalIdNo=@JournalIdNo) THROW 51236,'Cash disbursement open invoices with allocations cannot be deleted.',1;
 EXEC dbo.AssertJournalNotReconciliationLocked @JournalCode='CD', @JournalIdNo=@JournalIdNo;
 BEGIN TRAN; BEGIN TRY DELETE FROM dbo.CdOiItem WHERE DjIdNo=@JournalIdNo;DELETE FROM dbo.ArOpenInvoice WHERE JournalCode='CD' AND JournalIdNo=@JournalIdNo;DELETE FROM dbo.ApOpenInvoice WHERE JournalCode='CD' AND JournalIdNo=@JournalIdNo;DELETE FROM dbo.CdJournalItem WHERE JournalIdNo=@JournalIdNo;DELETE FROM dbo.CdJournal WHERE IdNo=@JournalIdNo;COMMIT;END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;THROW;END CATCH END;
GO
