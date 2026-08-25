CREATE PROCEDURE dbo.UpdatePcJournalAtomic
 @JournalIdNo int,@TransactionDate date,@ReferenceNo varchar(15)=NULL,@Amount money,@AccountIdNo smallint,@PaymentType char(1)=NULL,@PayType char(1)=NULL,@PayeeIdNo int=NULL,@PayeeName nvarchar(100)=NULL,@CheckNumber varchar(10)=NULL,@CheckDate date=NULL,@ORNumber varchar(15)=NULL,@DiscountTaken money=NULL,@DiscountAccountIdNo int=NULL,@Applied money=NULL,@UnApplied money=NULL,@VatNumber varchar(15)=NULL,@VatAmount money=NULL,@Notes nvarchar(300)=NULL,@PcClosed bit=0,@Approved bit=0,@Posted bit=0,@Cancelled bit=0,@Items dbo.JournalItemInsert READONLY,@OiItems dbo.PcOiItemInsert READONLY
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.PcJournal WHERE IdNo=@JournalIdNo) THROW 51250,'Petty cash entry was not found.',1;
 IF EXISTS(SELECT 1 FROM dbo.PcJournal WHERE IdNo=@JournalIdNo AND (Posted=1 OR PcClosed=1)) THROW 51251,'Posted or closed petty cash entries cannot be edited.',1;
 IF EXISTS(SELECT 1 FROM dbo.PcJournalItem i JOIN dbo.Reconciled r ON r.JournalCode='PC' AND r.JournalItemIdNo=i.IdNo WHERE i.JournalIdNo=@JournalIdNo) THROW 51252,'Reconciled petty cash entries cannot be edited.',1;
 EXEC dbo.AssertJournalNotReconciliationLocked @JournalCode='PC', @JournalIdNo=@JournalIdNo;
 IF @TransactionDate>='20260101' AND EXISTS(SELECT 1 FROM @Items WHERE Debit<0 OR Credit<0 OR (Debit<>0 AND Credit<>0)) THROW 51254,'Petty cash detail lines contain invalid debit/credit values.',1;
 IF @TransactionDate>='20260101' AND EXISTS(SELECT 1 FROM @Items WHERE AccountIdNo=0 AND (Debit<>0 OR Credit<>0)) THROW 51255,'Petty cash detail lines require an account.',1;
 IF @TransactionDate>='20260101' AND (NOT EXISTS(SELECT 1 FROM @Items) OR ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items))>.01) THROW 51253,'Petty cash details are not balanced.',1;
 BEGIN TRAN; BEGIN TRY
  DELETE FROM dbo.PcOiItem WHERE DjIdNo=@JournalIdNo; DELETE FROM dbo.PcJournalItem WHERE JournalIdNo=@JournalIdNo;
  UPDATE dbo.PcJournal SET TransactionDate=@TransactionDate,ReferenceNo=@ReferenceNo,Amount=@Amount,AccountIdNo=@AccountIdNo,PaymentType=@PaymentType,PayType=@PayType,PayeeIdNo=@PayeeIdNo,PayeeName=@PayeeName,CheckNumber=@CheckNumber,CheckDate=@CheckDate,ORNumber=@ORNumber,DiscountTaken=@DiscountTaken,DiscountAccountIdNo=@DiscountAccountIdNo,Applied=@Applied,UnApplied=@UnApplied,VatNumber=@VatNumber,VatAmount=@VatAmount,Notes=@Notes,PcClosed=@PcClosed,Approved=@Approved,Posted=@Posted,Cancelled=@Cancelled WHERE IdNo=@JournalIdNo;
  INSERT dbo.PcJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence) SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
  INSERT dbo.PcOiItem(Amount,ApOpenInvoiceIdNo,DiscountTaken,DjIdNo,Sequence) SELECT Amount,ApOpenInvoiceIdNo,DiscountTaken,@JournalIdNo,Sequence FROM @OiItems;
  IF NULLIF(LTRIM(RTRIM(@ReferenceNo)), '') IS NULL
  BEGIN
   DECLARE @seriesValue int, @seriesPrefix varchar(10), @generatedPrefix varchar(30);
   SELECT @seriesValue = Value, @seriesPrefix = Prefix
   FROM dbo.Series WITH (UPDLOCK, HOLDLOCK)
   WHERE SeriesName = 'PCJOURNAL';
   IF @@ROWCOUNT = 0
       THROW 51256, 'Petty cash journal series PCJOURNAL was not found.', 1;
   SET @seriesValue = COALESCE(@seriesValue, 0) + 1;
   SET @generatedPrefix = '';
   IF NULLIF(LTRIM(RTRIM(@seriesPrefix)), '') IS NOT NULL
       SET @generatedPrefix = CONVERT(varchar(30), FORMAT(@TransactionDate, @seriesPrefix, 'en-US'));
   UPDATE dbo.Series SET Value = @seriesValue WHERE SeriesName = 'PCJOURNAL';
   UPDATE dbo.PcJournal
   SET ReferenceNo = @generatedPrefix + CONVERT(varchar(20), @seriesValue)
   WHERE IdNo = @JournalIdNo;
  END;
  COMMIT;
 END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;THROW;END CATCH END;
GO
