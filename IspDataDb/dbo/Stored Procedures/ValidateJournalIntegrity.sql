CREATE OR ALTER PROCEDURE dbo.ValidateJournalIntegrity
    @JournalCode varchar(2),
    @JournalIdNo int,
    @EffectiveDate date = '20260101'
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @HeaderTable sysname;
    DECLARE @ItemTable sysname;
    DECLARE @TransactionDate date;
    DECLARE @Cancelled bit = 0;

    SELECT @HeaderTable = CASE @JournalCode
        WHEN 'AP' THEN 'ApJournal'
        WHEN 'AR' THEN 'ArJournal'
        WHEN 'CD' THEN 'CdJournal'
        WHEN 'CK' THEN 'CkJournal'
        WHEN 'CR' THEN 'CashReceiptJournal'
        WHEN 'ER' THEN 'ErJournal'
        WHEN 'SJ' THEN 'SalesJournal'
        WHEN 'GJ' THEN 'GeneralJournal'
        ELSE NULL END,
        @ItemTable = CASE @JournalCode
        WHEN 'AP' THEN 'ApJournalItem'
        WHEN 'AR' THEN 'ArJournalItem'
        WHEN 'CD' THEN 'CdJournalItem'
        WHEN 'CK' THEN 'CkJournalItem'
        WHEN 'CR' THEN 'CashReceiptJournalItem'
        WHEN 'ER' THEN 'ErJournalItem'
        WHEN 'SJ' THEN 'SalesJournalItem'
        WHEN 'GJ' THEN 'GeneralJournalItem'
        ELSE NULL END;

    IF @HeaderTable IS NULL OR @ItemTable IS NULL
        THROW 51000, 'Unsupported journal code.', 1;

    DECLARE @sql nvarchar(max) = N'
        SELECT @TransactionDateOut = TransactionDate,
               @CancelledOut = ISNULL(Cancelled, 0)
        FROM dbo.' + QUOTENAME(@HeaderTable) + N'
        WHERE IdNo = @JournalIdNo;';

    EXEC sys.sp_executesql @sql,
        N'@JournalIdNo int, @TransactionDateOut date OUTPUT, @CancelledOut bit OUTPUT',
        @JournalIdNo, @TransactionDate OUTPUT, @Cancelled OUTPUT;

    IF @TransactionDate IS NULL
        THROW 51001, 'Journal header was not found or has no transaction date.', 1;

    -- Legacy records are reported but not enforced.
    IF @TransactionDate < @EffectiveDate
    BEGIN
        SELECT CAST(1 AS bit) AS IsValid, CAST(1 AS bit) AS IsLegacy,
               @JournalCode AS JournalCode, @JournalIdNo AS JournalIdNo,
               @TransactionDate AS TransactionDate, CAST(NULL AS decimal(19,4)) AS TotalDebits,
               CAST(NULL AS decimal(19,4)) AS TotalCredits,
               'Legacy journal: validation not enforced.' AS ValidationMessage;
        RETURN;
    END;

    DECLARE @debit money = 0, @credit money = 0, @lineCount int = 0;
    SET @sql = N'
        SELECT @debitOut = COALESCE(SUM(Debit), 0),
               @creditOut = COALESCE(SUM(Credit), 0),
               @lineCountOut = COUNT(*)
        FROM dbo.' + QUOTENAME(@ItemTable) + N'
        WHERE JournalIdNo = @JournalIdNo;';

    EXEC sys.sp_executesql @sql,
        N'@JournalIdNo int, @debitOut money OUTPUT, @creditOut money OUTPUT, @lineCountOut int OUTPUT',
        @JournalIdNo, @debit OUTPUT, @credit OUTPUT, @lineCount OUTPUT;

    DECLARE @isValid bit = CASE WHEN @Cancelled = 1 OR
                                      (@lineCount > 0 AND ABS(@debit - @credit) <= 0.01)
                                THEN 1 ELSE 0 END;
    SELECT @isValid AS IsValid, CAST(0 AS bit) AS IsLegacy,
           @JournalCode AS JournalCode, @JournalIdNo AS JournalIdNo,
           @TransactionDate AS TransactionDate, @debit AS TotalDebits,
           @credit AS TotalCredits,
           CASE WHEN @Cancelled = 1 THEN 'Cancelled journal.'
                WHEN @lineCount = 0 THEN 'Journal must contain at least one detail line.'
                WHEN ABS(@debit - @credit) > 0.01 THEN 'Total debits and credits are not balanced.'
                ELSE 'Valid.' END AS ValidationMessage;
END;
GO
