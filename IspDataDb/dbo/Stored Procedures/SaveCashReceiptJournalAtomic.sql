CREATE OR ALTER PROCEDURE dbo.SaveCashReceiptJournalAtomic
    @TransactionDate date, @ReferenceNo varchar(15)=NULL, @Amount money,
    @AccountIdNo smallint, @PayorType char(1)=NULL, @PayorIdNo int=NULL,
    @PayorName nvarchar(50)=NULL, @CheckNumber varchar(10)=NULL, @CheckDate date=NULL,
    @ORNumber varchar(15)=NULL, @DiscountTaken money=NULL, @DiscountAccountIdNo smallint=NULL,
    @Applied money=NULL, @UnApplied money=NULL, @VatAmount money=NULL, @VatNumber varchar(15)=NULL,
    @Notes nvarchar(300)=NULL, @Posted bit=0, @Approved bit=0, @Cancelled bit=0,
    @Items dbo.JournalItemInsert READONLY, @OiItems dbo.CsrOiItemInsert READONLY,
    @JournalIdNo int OUTPUT
AS
BEGIN
 SET NOCOUNT ON; SET XACT_ABORT ON;
 IF @TransactionDate >= '20260101' AND NOT EXISTS (SELECT 1 FROM @Items)
     THROW 51110, 'Cash receipt must contain at least one detail line.', 1;
 IF @TransactionDate >= '20260101' AND EXISTS (SELECT 1 FROM @Items WHERE Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0))
     THROW 51111, 'Cash receipt detail lines contain invalid debit/credit values.', 1;
 IF @TransactionDate >= '20260101' AND ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items)) > .01
     THROW 51112, 'Cash receipt debits and credits are not balanced.', 1;
 BEGIN TRAN;
 BEGIN TRY
  INSERT dbo.CashReceiptJournal(TransactionDate,ReferenceNo,Amount,AccountIdNo,PayorType,PayorIdNo,Payorname,CheckNumber,CheckDate,ORNumber,DiscountTaken,DiscountAccountIdNo,Applied,UnApplied,VatAmount,VatNumber,Notes,Posted,Approved,Cancelled)
  VALUES(@TransactionDate,@ReferenceNo,@Amount,@AccountIdNo,@PayorType,@PayorIdNo,@PayorName,@CheckNumber,@CheckDate,@ORNumber,@DiscountTaken,@DiscountAccountIdNo,@Applied,@UnApplied,@VatAmount,@VatNumber,@Notes,@Posted,@Approved,@Cancelled);
  SET @JournalIdNo=CONVERT(int,SCOPE_IDENTITY());
  INSERT dbo.CashReceiptJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence)
  SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
  INSERT dbo.CsrOiItem(Amount,ArOpenInvoiceIdNo,CsrIdNo,DiscountTaken,Sequence)
  SELECT Amount,ArOpenInvoiceIdNo,@JournalIdNo,DiscountTaken,Sequence FROM @OiItems;
  DECLARE @s varchar(20)='GL'+CONVERT(varchar(4),YEAR(@TransactionDate))+RIGHT('0'+CONVERT(varchar(2),MONTH(@TransactionDate)),2), @p varchar(10), @m int, @v int;
  SELECT @v=Value,@p=Prefix,@m=MaxLength FROM dbo.Series WITH(UPDLOCK,HOLDLOCK) WHERE SeriesName=@s;
  IF @p IS NULL BEGIN SET @p=RIGHT('0'+CONVERT(varchar(2),MONTH(@TransactionDate)),2)+'-'; SET @m=3; SET @v=0; INSERT dbo.Series(SeriesName,Value,MaxLength,Prefix,Description) VALUES(@s,0,@m,@p,'GL Series for '+@s); END;
  SET @v=@v+1; UPDATE dbo.Series SET Value=@v WHERE SeriesName=@s;
  UPDATE dbo.CashReceiptJournal SET ReferenceNo=@p+RIGHT(REPLICATE('0',@m)+CONVERT(varchar(20),@v),@m) WHERE IdNo=@JournalIdNo;
  COMMIT;
 END TRY
 BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK; SET @JournalIdNo=0; THROW; END CATCH
END;
GO
