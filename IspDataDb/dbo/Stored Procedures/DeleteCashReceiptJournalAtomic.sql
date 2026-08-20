CREATE OR ALTER PROCEDURE dbo.DeleteCashReceiptJournalAtomic @JournalIdNo int
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 -- Deletion is idempotent: the UI may retry after a successful delete while
 -- its current record is still displayed.  Treat an already-removed row as
 -- complete rather than reporting a false failure.
 IF NOT EXISTS(SELECT 1 FROM dbo.CashReceiptJournal WHERE IdNo=@JournalIdNo) RETURN 1;
 IF EXISTS(SELECT 1 FROM dbo.CashReceiptJournal WHERE IdNo=@JournalIdNo AND Posted=1) THROW 51131,'Posted cash receipts cannot be deleted.',1;
 IF EXISTS(SELECT 1 FROM dbo.CashReceiptJournalItem i JOIN dbo.Reconciled r ON r.JournalCode='CR' AND r.JournalItemIdNo=i.IdNo WHERE i.JournalIdNo=@JournalIdNo) THROW 51132,'Reconciled cash receipts cannot be deleted.',1;
 BEGIN TRAN; BEGIN TRY DELETE FROM dbo.CsrOiItem WHERE CsrIdNo=@JournalIdNo; DELETE FROM dbo.CashReceiptJournalItem WHERE JournalIdNo=@JournalIdNo; DELETE FROM dbo.CashReceiptJournal WHERE IdNo=@JournalIdNo; COMMIT; END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK; THROW; END CATCH END;
GO
