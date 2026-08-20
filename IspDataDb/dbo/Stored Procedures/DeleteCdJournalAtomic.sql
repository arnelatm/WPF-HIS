CREATE PROCEDURE dbo.DeleteCdJournalAtomic @JournalIdNo int
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.CdJournal WHERE IdNo=@JournalIdNo) RETURN 1;
 IF EXISTS(SELECT 1 FROM dbo.CdJournal WHERE IdNo=@JournalIdNo AND (Posted=1 OR PcClosed=1)) THROW 51231,'Posted or closed cash disbursements cannot be deleted.',1;
 IF EXISTS(SELECT 1 FROM dbo.CdJournalItem i JOIN dbo.Reconciled r ON r.JournalCode='CD' AND r.JournalItemIdNo=i.IdNo WHERE i.JournalIdNo=@JournalIdNo) THROW 51232,'Reconciled cash disbursements cannot be deleted.',1;
 BEGIN TRAN; BEGIN TRY DELETE FROM dbo.CdOiItem WHERE DjIdNo=@JournalIdNo;DELETE FROM dbo.CdJournalItem WHERE JournalIdNo=@JournalIdNo;DELETE FROM dbo.CdJournal WHERE IdNo=@JournalIdNo;COMMIT;END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;THROW;END CATCH END;
GO
