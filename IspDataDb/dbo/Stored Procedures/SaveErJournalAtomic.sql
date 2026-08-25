CREATE PROCEDURE dbo.SaveErJournalAtomic
 @EmployeeIdNo int,@TransactionDate date,@ReferenceNo varchar(15)=NULL,@TransactionType char(1)=NULL,@Amount money,@AccountIdNo smallint,@Notes nvarchar(255),@Approved bit=0,@Posted bit=0,@Cancelled bit=0,@Items dbo.JournalItemInsert READONLY,@JournalIdNo int OUTPUT
AS BEGIN SET NOCOUNT ON;SET XACT_ABORT ON;
 IF @TransactionDate>='20260101' AND EXISTS(SELECT 1 FROM @Items WHERE Debit<0 OR Credit<0 OR (Debit<>0 AND Credit<>0)) THROW 51311,'Employee reimbursement detail lines contain invalid debit/credit values.',1;
 IF @TransactionDate>='20260101' AND EXISTS(SELECT 1 FROM @Items WHERE AccountIdNo=0 AND (Debit<>0 OR Credit<>0)) THROW 51312,'Employee reimbursement detail lines require an account.',1;
 IF @TransactionDate>='20260101' AND (NOT EXISTS(SELECT 1 FROM @Items) OR ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items))>.01) THROW 51310,'Employee reimbursement details are not balanced.',1;
 BEGIN TRAN;BEGIN TRY
  INSERT dbo.ErJournal(EmployeeIdNo,TransactionDate,ReferenceNo,TransactionType,Amount,AccountIdNo,Notes,Approved,Posted,Cancelled) VALUES(@EmployeeIdNo,@TransactionDate,@ReferenceNo,@TransactionType,@Amount,@AccountIdNo,@Notes,@Approved,@Posted,@Cancelled);SET @JournalIdNo=CONVERT(int,SCOPE_IDENTITY());
  INSERT dbo.ErJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence) SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
  IF NULLIF(LTRIM(RTRIM(@ReferenceNo)), '') IS NULL BEGIN DECLARE @s varchar(20)='GL'+CONVERT(varchar(4),YEAR(@TransactionDate))+RIGHT('0'+CONVERT(varchar(2),MONTH(@TransactionDate)),2),@p varchar(10),@m int,@v int;SELECT @v=Value,@p=Prefix,@m=MaxLength FROM dbo.Series WITH(UPDLOCK,HOLDLOCK) WHERE SeriesName=@s;IF @p IS NULL BEGIN SET @p=RIGHT('0'+CONVERT(varchar(2),MONTH(@TransactionDate)),2)+'-';SET @m=3;SET @v=0;INSERT dbo.Series(SeriesName,Value,MaxLength,Prefix,Description) VALUES(@s,0,@m,@p,'GL Series for '+@s);END;SET @v=@v+1;UPDATE dbo.Series SET Value=@v WHERE SeriesName=@s;UPDATE dbo.ErJournal SET ReferenceNo=@p+RIGHT(REPLICATE('0',@m)+CONVERT(varchar(20),@v),@m) WHERE IdNo=@JournalIdNo;END;COMMIT;
 END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;SET @JournalIdNo=0;THROW;END CATCH END;
GO
