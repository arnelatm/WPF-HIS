CREATE PROCEDURE dbo.DeleteErJournalAtomic @JournalIdNo int
AS BEGIN SET NOCOUNT ON;SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.ErJournal WHERE IdNo=@JournalIdNo) RETURN 1;
 IF EXISTS(SELECT 1 FROM dbo.ErJournal WHERE IdNo=@JournalIdNo AND Posted=1) THROW 51331,'Posted employee reimbursements cannot be deleted.',1;
 IF EXISTS(SELECT 1 FROM dbo.ErJournalItem i JOIN dbo.Reconciled r ON r.JournalCode='ER' AND r.JournalItemIdNo=i.IdNo WHERE i.JournalIdNo=@JournalIdNo) THROW 51332,'Reconciled employee reimbursements cannot be deleted.',1;
 IF EXISTS(SELECT 1 FROM dbo.ErOpenInvoice o WHERE (o.JournalIdNo=@JournalIdNo OR EXISTS(SELECT 1 FROM dbo.ErJournalItem i WHERE i.JournalIdNo=@JournalIdNo AND i.IdNo=o.JournalItemIdNo)) AND (o.PaidAmount<>0 OR o.DiscountTaken<>0)) THROW 51333,'Employee reimbursements with settled open-invoice markers cannot be deleted.',1;
 EXEC dbo.AssertJournalNotReconciliationLocked @JournalCode='ER', @JournalIdNo=@JournalIdNo;
 BEGIN TRAN;BEGIN TRY DELETE o FROM dbo.ErOpenInvoice o WHERE o.JournalIdNo=@JournalIdNo OR EXISTS(SELECT 1 FROM dbo.ErJournalItem i WHERE i.JournalIdNo=@JournalIdNo AND i.IdNo=o.JournalItemIdNo);DELETE FROM dbo.ErJournalItem WHERE JournalIdNo=@JournalIdNo;DELETE FROM dbo.ErJournal WHERE IdNo=@JournalIdNo;COMMIT;END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;THROW;END CATCH END;
GO
