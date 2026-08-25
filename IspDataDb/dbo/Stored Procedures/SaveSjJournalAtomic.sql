CREATE PROCEDURE dbo.SaveSjJournalAtomic
 @TransactionDate date,@AccountIdNo smallint,@ReferenceNo varchar(15)=NULL,@Notes nvarchar(300)=NULL,@Approved bit=0,@Posted bit=0,@Cancelled bit=0,@Items dbo.JournalItemInsert READONLY,@Deposits dbo.SalesDepositInsert READONLY,@JournalIdNo int OUTPUT
AS BEGIN SET NOCOUNT ON;SET XACT_ABORT ON;
 IF @TransactionDate>='20260101' AND EXISTS(SELECT 1 FROM @Items WHERE Debit<0 OR Credit<0 OR (Debit<>0 AND Credit<>0)) THROW 51411,'Sales journal detail lines contain invalid debit/credit values.',1;
 IF @TransactionDate>='20260101' AND EXISTS(SELECT 1 FROM @Items WHERE AccountIdNo=0 AND (Debit<>0 OR Credit<>0)) THROW 51412,'Sales journal detail lines require an account.',1;
 IF @TransactionDate>='20260101' AND (NOT EXISTS(SELECT 1 FROM @Items) OR ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items))>.01) THROW 51410,'Sales journal details are not balanced.',1;
 DECLARE @SeriesName varchar(20)='Sales'+CONVERT(varchar(10),@AccountIdNo),@SeriesPrefix varchar(10),@GeneratedReferenceNo varchar(15);
 SELECT @SeriesPrefix=Prefix FROM dbo.Series WHERE SeriesName=@SeriesName;
 IF NULLIF(LTRIM(RTRIM(@SeriesPrefix)),'') IS NULL THROW 51413,'Sales journal series format was not found for the selected account.',1;
 SET @GeneratedReferenceNo=CONVERT(varchar(15),FORMAT(@TransactionDate,@SeriesPrefix,'en-US'));
 IF NULLIF(LTRIM(RTRIM(@GeneratedReferenceNo)),'') IS NULL THROW 51414,'Sales journal reference number could not be generated.',1;
 BEGIN TRAN;BEGIN TRY INSERT dbo.SalesJournal(TransactionDate,AccountIdNo,ReferenceNo,Notes,Approved,Posted,Cancelled) VALUES(@TransactionDate,@AccountIdNo,@GeneratedReferenceNo,@Notes,@Approved,@Posted,@Cancelled);SET @JournalIdNo=CONVERT(int,SCOPE_IDENTITY());INSERT dbo.SalesJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence) SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;INSERT dbo.SalesDeposit(DepositTypeIdNo,DepositAmount,SaleAmount,SalesJournalIdNo,Sequence,VatAmount) SELECT DepositTypeIdNo,DepositAmount,SaleAmount,@JournalIdNo,Sequence,VatAmount FROM @Deposits;COMMIT;END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;SET @JournalIdNo=0;THROW;END CATCH END;
GO
