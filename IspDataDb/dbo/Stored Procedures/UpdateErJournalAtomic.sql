CREATE PROCEDURE dbo.UpdateErJournalAtomic
 @JournalIdNo int,@EmployeeIdNo int,@TransactionDate date,@ReferenceNo varchar(15)=NULL,@TransactionType char(1)=NULL,@Amount money,@AccountIdNo smallint,@Notes nvarchar(255),@Approved bit=0,@Posted bit=0,@Cancelled bit=0,@Items dbo.JournalItemInsert READONLY
AS BEGIN SET NOCOUNT ON;SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.ErJournal WHERE IdNo=@JournalIdNo) THROW 51320,'Employee reimbursement was not found.',1;
 IF EXISTS(SELECT 1 FROM dbo.ErJournal WHERE IdNo=@JournalIdNo AND Posted=1) THROW 51321,'Posted employee reimbursements cannot be edited.',1;
 IF EXISTS(SELECT 1 FROM dbo.ErJournalItem i JOIN dbo.Reconciled r ON r.JournalCode='ER' AND r.JournalItemIdNo=i.IdNo WHERE i.JournalIdNo=@JournalIdNo) THROW 51322,'Reconciled employee reimbursements cannot be edited.',1;
 IF @TransactionDate>='20260101' AND (NOT EXISTS(SELECT 1 FROM @Items) OR ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items))>.01) THROW 51323,'Employee reimbursement details are not balanced.',1;
 BEGIN TRAN;BEGIN TRY DELETE FROM dbo.ErJournalItem WHERE JournalIdNo=@JournalIdNo;UPDATE dbo.ErJournal SET EmployeeIdNo=@EmployeeIdNo,TransactionDate=@TransactionDate,ReferenceNo=@ReferenceNo,TransactionType=@TransactionType,Amount=@Amount,AccountIdNo=@AccountIdNo,Notes=@Notes,Approved=@Approved,Posted=@Posted,Cancelled=@Cancelled WHERE IdNo=@JournalIdNo;INSERT dbo.ErJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence) SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;COMMIT;END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;THROW;END CATCH END;
GO
