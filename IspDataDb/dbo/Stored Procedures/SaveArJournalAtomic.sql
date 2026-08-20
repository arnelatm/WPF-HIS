CREATE OR ALTER PROCEDURE dbo.SaveArJournalAtomic
    @CustomerIdNo int, @TransactionDate date, @ReferenceNo varchar(15)=NULL,
    @TransactionType char(1)=NULL, @Amount money, @AccountIdNo int,
    @DueDate date=NULL, @SettlementDueDate date=NULL,
    @SettlementDiscount decimal(5,2)=NULL, @InvoiceNo varchar(15),
    @InvoiceDate date=NULL, @VatAmount money=NULL, @Notes nvarchar(600),
    @Approved bit=0, @Posted bit=0, @Items dbo.JournalItemInsert READONLY,
    @JournalIdNo int OUTPUT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    IF @TransactionDate >= '20260101' AND NOT EXISTS (SELECT 1 FROM @Items)
        THROW 51100, 'AR journal must contain at least one detail line.', 1;
    IF @TransactionDate >= '20260101' AND EXISTS (SELECT 1 FROM @Items WHERE Debit<0 OR Credit<0 OR (Debit<>0 AND Credit<>0))
        THROW 51101, 'AR detail lines contain invalid debit/credit values.', 1;
    IF @TransactionDate >= '20260101' AND ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items))>.01
        THROW 51102, 'AR journal debits and credits are not balanced.', 1;
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT dbo.ArJournal(CustomerIdNo,TransactionDate,ReferenceNo,TransactionType,Amount,AccountIdNo,DueDate,SettlementDueDate,SettlementDiscount,InvoiceNo,InvoiceDate,Notes,VatAmount,Approved,Posted,Cancelled)
        VALUES(@CustomerIdNo,@TransactionDate,@ReferenceNo,@TransactionType,@Amount,@AccountIdNo,@DueDate,@SettlementDueDate,@SettlementDiscount,@InvoiceNo,@InvoiceDate,@Notes,@VatAmount,@Approved,@Posted,0);
        SET @JournalIdNo=CONVERT(int,SCOPE_IDENTITY());
        INSERT dbo.ArJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence)
        SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
        IF @TransactionDate >= '20260101' AND ABS((SELECT COALESCE(SUM(Debit),0) FROM dbo.ArJournalItem WHERE JournalIdNo=@JournalIdNo)-(SELECT COALESCE(SUM(Credit),0) FROM dbo.ArJournalItem WHERE JournalIdNo=@JournalIdNo))>.01
            THROW 51103, 'AR journal is not balanced after insertion.', 1;
        INSERT dbo.ArOpenInvoice(JournalCode,JournalIdNo,JournalItemIdNo,PaidAmount,DiscountTaken)
        SELECT 'AR',@JournalIdNo,i.IdNo,0,0 FROM dbo.ArJournalItem i INNER JOIN dbo.Account a ON a.IdNo=i.AccountIdNo
        WHERE i.JournalIdNo=@JournalIdNo AND a.SpecialAccount='AR';
        DECLARE @seriesName varchar(20)='GL'+CONVERT(varchar(4),YEAR(@TransactionDate))+RIGHT('0'+CONVERT(varchar(2),MONTH(@TransactionDate)),2),@prefix varchar(10),@maxLength int,@seriesValue int;
        SELECT @seriesValue=Value,@prefix=Prefix,@maxLength=MaxLength FROM dbo.Series WITH(UPDLOCK,HOLDLOCK) WHERE SeriesName=@seriesName;
        IF @prefix IS NULL BEGIN SET @prefix=RIGHT('0'+CONVERT(varchar(2),MONTH(@TransactionDate)),2)+'-'; SET @maxLength=3; SET @seriesValue=0; INSERT dbo.Series(SeriesName,Value,MaxLength,Prefix,Description) VALUES(@seriesName,0,@maxLength,@prefix,'GL Series for '+@seriesName); END;
        SET @seriesValue=@seriesValue+1; UPDATE dbo.Series SET Value=@seriesValue WHERE SeriesName=@seriesName;
        UPDATE dbo.ArJournal SET ReferenceNo=@prefix+RIGHT(REPLICATE('0',@maxLength)+CONVERT(varchar(20),@seriesValue),@maxLength) WHERE IdNo=@JournalIdNo;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE()<>0 ROLLBACK TRANSACTION; THROW;
    END CATCH;
END;
GO
