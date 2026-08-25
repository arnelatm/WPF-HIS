CREATE PROCEDURE dbo.DeleteGjJournalAtomic @JournalIdNo int
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.GeneralJournal WHERE IdNo=@JournalIdNo) RETURN 1;
 IF EXISTS(SELECT 1 FROM dbo.GeneralJournal WHERE IdNo=@JournalIdNo AND Posted=1) THROW 51331,'Posted general journal entries cannot be deleted.',1;
 IF EXISTS(SELECT 1 FROM dbo.GeneralJournalItem i JOIN dbo.Reconciled r ON r.JournalCode='GJ' AND r.JournalItemIdNo=i.IdNo WHERE i.JournalIdNo=@JournalIdNo) THROW 51332,'Reconciled general journal entries cannot be deleted.',1;
 EXEC dbo.AssertJournalNotReconciliationLocked @JournalCode='GJ', @JournalIdNo=@JournalIdNo;
 BEGIN TRAN; BEGIN TRY DELETE FROM dbo.GeneralJournalItem WHERE JournalIdNo=@JournalIdNo;DELETE FROM dbo.GeneralJournal WHERE IdNo=@JournalIdNo;COMMIT;END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;THROW;END CATCH END;
GO
