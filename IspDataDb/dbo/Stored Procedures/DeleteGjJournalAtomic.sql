CREATE PROCEDURE dbo.DeleteGjJournalAtomic @JournalIdNo int
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.GeneralJournal WHERE IdNo=@JournalIdNo) RETURN 1;
 IF EXISTS(SELECT 1 FROM dbo.GeneralJournal WHERE IdNo=@JournalIdNo AND Posted=1) THROW 51331,'Posted general journal entries cannot be deleted.',1;
 IF EXISTS(SELECT 1 FROM dbo.GeneralJournalItem i JOIN dbo.Reconciled r ON r.JournalCode='GJ' AND r.JournalItemIdNo=i.IdNo WHERE i.JournalIdNo=@JournalIdNo) THROW 51332,'Reconciled general journal entries cannot be deleted.',1;
 IF EXISTS(SELECT 1 FROM dbo.ArOpenInvoice o JOIN dbo.CsrOiItem c ON c.ArOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='GJ' AND o.JournalIdNo=@JournalIdNo) OR EXISTS(SELECT 1 FROM dbo.ApOpenInvoice o JOIN dbo.CdOiItem c ON c.ApOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='GJ' AND o.JournalIdNo=@JournalIdNo) OR EXISTS(SELECT 1 FROM dbo.ApOpenInvoice o JOIN dbo.PcOiItem p ON p.ApOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='GJ' AND o.JournalIdNo=@JournalIdNo) OR EXISTS(SELECT 1 FROM dbo.ApOpenInvoice o JOIN dbo.CkOiItem k ON k.ApOpenInvoiceIdNo=o.IdNo WHERE o.JournalCode='GJ' AND o.JournalIdNo=@JournalIdNo) THROW 51334,'General journal open invoices with allocations cannot be deleted.',1;
 EXEC dbo.AssertJournalNotReconciliationLocked @JournalCode='GJ', @JournalIdNo=@JournalIdNo;
 BEGIN TRAN; BEGIN TRY DELETE FROM dbo.ArOpenInvoice WHERE JournalCode='GJ' AND JournalIdNo=@JournalIdNo;DELETE FROM dbo.ApOpenInvoice WHERE JournalCode='GJ' AND JournalIdNo=@JournalIdNo;DELETE FROM dbo.GeneralJournalItem WHERE JournalIdNo=@JournalIdNo;DELETE FROM dbo.GeneralJournal WHERE IdNo=@JournalIdNo;COMMIT;END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;THROW;END CATCH END;
GO
