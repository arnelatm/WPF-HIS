CREATE PROCEDURE dbo.SaveApJournalAtomic
    @SupplierIdNo int,
    @TransactionDate date,
    @ReferenceNo varchar(15) = NULL,
    @TransactionType char(1) = NULL,
    @Amount money,
    @AccountIdNo int,
    @DueDate date = NULL,
    @SettlementDueDate date = NULL,
    @SettlementDiscount decimal(5,2) = NULL,
    @InvoiceNo varchar(15),
    @InvoiceDate date = NULL,
    @VatNumber varchar(15) = NULL,
    @VatAmount money = NULL,
    @Notes nvarchar(600),
    @Approved bit = 0,
    @Posted bit = 0,
    @Items dbo.JournalItemInsert READONLY,
    @JournalIdNo int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @TransactionDate >= '20260101' AND NOT EXISTS (SELECT 1 FROM @Items)
        THROW 51010, 'AP journal must contain at least one detail line.', 1;

    IF @TransactionDate >= '20260101' AND EXISTS (
        SELECT 1 FROM @Items WHERE Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0))
        THROW 51011, 'AP detail lines contain invalid debit/credit values.', 1;

    IF @TransactionDate >= '20260101' AND EXISTS (
        SELECT 1 FROM @Items WHERE AccountIdNo IS NULL OR AccountIdNo = 0)
        THROW 51012, 'AP detail lines require an account.', 1;

    IF @TransactionDate >= '20260101' AND
       ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items) -
           (SELECT COALESCE(SUM(Credit),0) FROM @Items)) > 0.01
        THROW 51013, 'AP journal debits and credits are not balanced.', 1;

    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT dbo.ApJournal
        (SupplierIdNo, TransactionDate, ReferenceNo, TransactionType, Amount, AccountIdNo,
         DueDate, SettlementDueDate, SettlementDiscount, InvoiceNo, InvoiceDate, VatNumber,
         VatAmount, Notes, Approved, Posted, Cancelled)
        VALUES
        (@SupplierIdNo, @TransactionDate, @ReferenceNo, @TransactionType, @Amount, @AccountIdNo,
         @DueDate, @SettlementDueDate, @SettlementDiscount, @InvoiceNo, @InvoiceDate, @VatNumber,
         @VatAmount, @Notes, @Approved, @Posted, 0);

        SET @JournalIdNo = CONVERT(int, SCOPE_IDENTITY());

        INSERT dbo.ApJournalItem
        (AccountIdNo, Credit, Debit, JournalIdNo, Notes, PayIdNo, RevCostCenterIdNo, Sequence)
        SELECT AccountIdNo, Credit, Debit, @JournalIdNo, Notes, PayIdNo, RevCostCenterIdNo, Sequence
        FROM @Items;

        IF @TransactionDate >= '20260101' AND
           (SELECT COUNT(*) FROM dbo.ApJournalItem WHERE JournalIdNo = @JournalIdNo) = 0
            THROW 51014, 'AP journal detail insertion failed.', 1;

        IF @TransactionDate >= '20260101' AND
           ABS((SELECT COALESCE(SUM(Debit),0) FROM dbo.ApJournalItem WHERE JournalIdNo = @JournalIdNo) -
               (SELECT COALESCE(SUM(Credit),0) FROM dbo.ApJournalItem WHERE JournalIdNo = @JournalIdNo)) > 0.01
            THROW 51015, 'AP journal is not balanced after insertion.', 1;

        INSERT dbo.ApOpenInvoice (JournalCode, JournalIdNo, JournalItemIdNo, PaidAmount, DiscountTaken)
        SELECT 'AP', @JournalIdNo, i.IdNo, 0, 0
        FROM dbo.ApJournalItem i
        INNER JOIN dbo.Account a ON a.IdNo = i.AccountIdNo
        WHERE i.JournalIdNo = @JournalIdNo
          AND a.SpecialAccount = 'AP';

        IF @VatNumber IS NOT NULL AND LTRIM(RTRIM(@VatNumber)) <> ''
            UPDATE dbo.Supplier
            SET VatNumber = @VatNumber
            WHERE IdNo = @SupplierIdNo AND (VatNumber IS NULL OR VatNumber = '');

        -- Generate a GL reference only when the user did not supply one.
        IF NULLIF(LTRIM(RTRIM(@ReferenceNo)), '') IS NULL
        BEGIN
            DECLARE @seriesName varchar(20) = 'GL' + CONVERT(varchar(4), YEAR(@TransactionDate)) +
                                              RIGHT('0' + CONVERT(varchar(2), MONTH(@TransactionDate)), 2);
            DECLARE @prefix varchar(10), @maxLength int, @seriesValue int;
            SELECT @seriesValue = Value, @prefix = Prefix, @maxLength = MaxLength
            FROM dbo.Series WITH (UPDLOCK, HOLDLOCK)
            WHERE SeriesName = @seriesName;

            IF @prefix IS NULL
            BEGIN
                SET @prefix = RIGHT('0' + CONVERT(varchar(2), MONTH(@TransactionDate)), 2) + '-';
                SET @maxLength = 3;
                SET @seriesValue = 0;
                INSERT dbo.Series (SeriesName, Value, MaxLength, Prefix, Description)
                VALUES (@seriesName, 0, @maxLength, @prefix, 'GL Series for ' + @seriesName);
            END;

            SET @seriesValue = @seriesValue + 1;
            UPDATE dbo.Series SET Value = @seriesValue WHERE SeriesName = @seriesName;
            UPDATE dbo.ApJournal
            SET ReferenceNo = @prefix + RIGHT(REPLICATE('0', @maxLength) + CONVERT(varchar(20), @seriesValue), @maxLength)
            WHERE IdNo = @JournalIdNo;
        END;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @JournalIdNo = 0;
        THROW;
    END CATCH;
END;
GO
