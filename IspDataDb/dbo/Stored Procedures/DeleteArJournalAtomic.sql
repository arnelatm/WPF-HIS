CREATE OR ALTER PROCEDURE dbo.DeleteArJournalAtomic @JournalIdNo int
AS
BEGIN
 SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.ArJournal WHERE IdNo=@JournalIdNo) THROW 51120,'AR journal was not found.',1;
 IF EXISTS(SELECT 1 FROM dbo.Reconciled r INNER JOIN dbo.ArJournalItem i ON i.IdNo=r.JournalItemIdNo WHERE r.JournalCode='AR' AND i.JournalIdNo=@JournalIdNo) THROW 51121,'AR journal contains reconciled detail lines and cannot be deleted.',1;
 IF EXISTS(SELECT 1 FROM dbo.ArOpenInvoice o WHERE o.JournalCode='AR' AND o.JournalIdNo=@JournalIdNo AND EXISTS(SELECT 1 FROM dbo.CsrOiItem c WHERE c.ArOpenInvoiceIdNo=o.IdNo)) THROW 51122,'AR journal has CR collections and cannot be deleted.',1;
 BEGIN TRANSACTION;
 BEGIN TRY
  DELETE FROM dbo.ArOpenInvoice WHERE JournalCode='AR' AND JournalIdNo=@JournalIdNo;
  DELETE FROM dbo.ArJournalItem WHERE JournalIdNo=@JournalIdNo;
  DELETE FROM dbo.ArJournal WHERE IdNo=@JournalIdNo;
  COMMIT TRANSACTION;
 END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK TRANSACTION; THROW; END CATCH;
END;
GO
