CREATE PROCEDURE dbo.SaveCashReceiptJournalAtomic
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
 IF @TransactionDate >= '20260101' AND ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items)) > 0.00005
     THROW 51112, 'Cash receipt debits and credits are not balanced.', 1;
 IF @TransactionDate >= '20260101' AND ABS(COALESCE(@Applied,0)+COALESCE(@UnApplied,0)-COALESCE(@Amount,0)) > 0.00005
     THROW 51113, 'Cash receipt applied and unapplied amounts do not equal the receipt amount.', 1;
 IF @TransactionDate >= '20260101' AND @PayorType='A' AND ABS((SELECT COALESCE(SUM(Amount),0) FROM @OiItems)-COALESCE(@Applied,0)) > 0.00005
     THROW 51114, 'Cash receipt allocations do not equal the applied amount.', 1;
 IF @TransactionDate >= '20260101' AND EXISTS (SELECT 1 FROM @OiItems WHERE COALESCE(Amount,0)=0 AND COALESCE(DiscountTaken,0)=0)
     THROW 51115, 'Cash receipt contains a zero-value invoice allocation.', 1;
 IF @TransactionDate >= '20260101' AND @PayorType='A' AND EXISTS (
     SELECT 1 FROM @OiItems i LEFT JOIN dbo.ArOpenInvoice_View v ON v.IdNo=i.ArOpenInvoiceIdNo
     WHERE v.IdNo IS NULL OR v.CustomerIdNo IS NULL OR @PayorIdNo IS NULL OR v.CustomerIdNo<>@PayorIdNo)
     THROW 51116, 'Cash receipt allocation does not belong to the selected customer.', 1;
 IF @TransactionDate >= '20260101' AND NULLIF(LTRIM(RTRIM(@ReferenceNo)), '') IS NOT NULL AND EXISTS (
     SELECT 1 FROM dbo.CashReceiptJournal r
     WHERE r.TransactionDate=@TransactionDate AND ISNULL(r.ReferenceNo,'')=ISNULL(@ReferenceNo,'')
       AND r.PayorType=@PayorType AND ISNULL(r.PayorIdNo,0)=ISNULL(@PayorIdNo,0)
       AND r.Amount=@Amount AND r.Cancelled=0)
     THROW 51117, 'A matching cash receipt already exists.', 1;
 BEGIN TRAN;
 BEGIN TRY
  INSERT dbo.CashReceiptJournal(TransactionDate,ReferenceNo,Amount,AccountIdNo,PayorType,PayorIdNo,Payorname,CheckNumber,CheckDate,ORNumber,DiscountTaken,DiscountAccountIdNo,Applied,UnApplied,VatAmount,VatNumber,Notes,Posted,Approved,Cancelled)
  VALUES(@TransactionDate,@ReferenceNo,@Amount,@AccountIdNo,@PayorType,@PayorIdNo,@PayorName,@CheckNumber,@CheckDate,@ORNumber,@DiscountTaken,@DiscountAccountIdNo,@Applied,@UnApplied,@VatAmount,@VatNumber,@Notes,@Posted,@Approved,@Cancelled);
  SET @JournalIdNo=CONVERT(int,SCOPE_IDENTITY());
  INSERT dbo.CashReceiptJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence)
  SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
  INSERT dbo.CsrOiItem(Amount,ArOpenInvoiceIdNo,CsrIdNo,DiscountTaken,Sequence)
  SELECT Amount,ArOpenInvoiceIdNo,@JournalIdNo,DiscountTaken,Sequence FROM @OiItems;
  IF NULLIF(LTRIM(RTRIM(@ReferenceNo)), '') IS NULL
  BEGIN
   DECLARE @s varchar(20)='GL'+CONVERT(varchar(4),YEAR(@TransactionDate))+RIGHT('0'+CONVERT(varchar(2),MONTH(@TransactionDate)),2), @p varchar(10), @m int, @v int;
   SELECT @v=Value,@p=Prefix,@m=MaxLength FROM dbo.Series WITH(UPDLOCK,HOLDLOCK) WHERE SeriesName=@s;
   IF @p IS NULL BEGIN SET @p=RIGHT('0'+CONVERT(varchar(2),MONTH(@TransactionDate)),2)+'-'; SET @m=3; SET @v=0; INSERT dbo.Series(SeriesName,Value,MaxLength,Prefix,Description) VALUES(@s,0,@m,@p,'GL Series for '+@s); END;
   SET @v=@v+1; UPDATE dbo.Series SET Value=@v WHERE SeriesName=@s;
   UPDATE dbo.CashReceiptJournal SET ReferenceNo=@p+RIGHT(REPLICATE('0',@m)+CONVERT(varchar(20),@v),@m) WHERE IdNo=@JournalIdNo;
  END;
  COMMIT;
 END TRY
 BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK; SET @JournalIdNo=0; THROW; END CATCH
END;
GO
