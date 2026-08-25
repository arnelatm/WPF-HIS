CREATE PROCEDURE dbo.SavePcJournalAtomic
 @TransactionDate date,@ReferenceNo varchar(15)=NULL,@Amount money,@AccountIdNo smallint,@PaymentType char(1)=NULL,@PayType char(1)=NULL,@PayeeIdNo int=NULL,@PayeeName nvarchar(100)=NULL,@CheckNumber varchar(10)=NULL,@CheckDate date=NULL,@ORNumber varchar(15)=NULL,@DiscountTaken money=NULL,@DiscountAccountIdNo int=NULL,@Applied money=NULL,@UnApplied money=NULL,@VatNumber varchar(15)=NULL,@VatAmount money=NULL,@Notes nvarchar(300)=NULL,@PcClosed bit=0,@Approved bit=0,@Posted bit=0,@Cancelled bit=0,@Items dbo.JournalItemInsert READONLY,@OiItems dbo.PcOiItemInsert READONLY,@JournalIdNo int OUTPUT
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 IF @TransactionDate>='20260101' AND EXISTS(SELECT 1 FROM @Items WHERE Debit<0 OR Credit<0 OR (Debit<>0 AND Credit<>0)) THROW 51241,'Petty cash detail lines contain invalid debit/credit values.',1;
 IF @TransactionDate>='20260101' AND EXISTS(SELECT 1 FROM @Items WHERE AccountIdNo=0 AND (Debit<>0 OR Credit<>0)) THROW 51242,'Petty cash detail lines require an account.',1;
 IF @TransactionDate>='20260101' AND (NOT EXISTS(SELECT 1 FROM @Items) OR ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items))>.01) THROW 51240,'Petty cash details are not balanced.',1;
 BEGIN TRAN; BEGIN TRY
  INSERT dbo.PcJournal(TransactionDate,ReferenceNo,Amount,AccountIdNo,PaymentType,PayType,PayeeIdNo,PayeeName,CheckNumber,CheckDate,ORNumber,DiscountTaken,DiscountAccountIdNo,Applied,UnApplied,VatNumber,VatAmount,Notes,PcClosed,Approved,Posted,Cancelled) VALUES(@TransactionDate,@ReferenceNo,@Amount,@AccountIdNo,@PaymentType,@PayType,@PayeeIdNo,@PayeeName,@CheckNumber,@CheckDate,@ORNumber,@DiscountTaken,@DiscountAccountIdNo,@Applied,@UnApplied,@VatNumber,@VatAmount,@Notes,@PcClosed,@Approved,@Posted,@Cancelled);
  SET @JournalIdNo=CONVERT(int,SCOPE_IDENTITY());
  INSERT dbo.PcJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence) SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
  INSERT dbo.PcOiItem(Amount,ApOpenInvoiceIdNo,DiscountTaken,DjIdNo,Sequence) SELECT Amount,ApOpenInvoiceIdNo,DiscountTaken,@JournalIdNo,Sequence FROM @OiItems;
  IF NULLIF(LTRIM(RTRIM(@ReferenceNo)), '') IS NULL
  BEGIN
   DECLARE @seriesValue int, @seriesPrefix varchar(10), @generatedPrefix varchar(30);
   SELECT @seriesValue = Value, @seriesPrefix = Prefix
   FROM dbo.Series WITH (UPDLOCK, HOLDLOCK)
   WHERE SeriesName = 'PCJOURNAL';
   IF @@ROWCOUNT = 0
       THROW 51243, 'Petty cash journal series PCJOURNAL was not found.', 1;
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
 END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK;SET @JournalIdNo=0;THROW;END CATCH END;
GO
