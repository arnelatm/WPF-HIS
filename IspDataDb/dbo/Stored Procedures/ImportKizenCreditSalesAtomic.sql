CREATE PROCEDURE [dbo].[ImportKizenCreditSalesAtomic]
    @SourcePeriodStart DATE,
    @SourcePeriodEnd DATE,
    @SourceInvoiceCount INT,
    @SourceDetailCount INT,
    @SourceAmount MONEY,
    @Headers [dbo].[KizenArJournalHeaderInsert] READONLY,
    @Items [dbo].[KizenArJournalItemInsert] READONLY,
    @CreatedBy NVARCHAR (128) = NULL,
    @ReferenceNo VARCHAR (15) OUTPUT,
    @JournalCount INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @SourcePeriodStart IS NULL OR @SourcePeriodEnd IS NULL OR @SourcePeriodStart > @SourcePeriodEnd
        THROW 51200, 'A valid Kizen source period is required.', 1;
    IF DAY(@SourcePeriodStart) <> 1 OR @SourcePeriodEnd <> EOMONTH(@SourcePeriodStart)
        THROW 51201, 'Kizen credit sales imports must cover one complete calendar month.', 1;
    IF @SourceInvoiceCount < 0 OR @SourceDetailCount < 0 OR @SourceAmount < 0
        THROW 51202, 'Kizen source totals cannot be negative.', 1;
    IF NOT EXISTS (SELECT 1 FROM @Headers)
        THROW 51203, 'The Kizen batch contains no customer journals.', 1;
    IF NOT EXISTS (SELECT 1 FROM @Items)
        THROW 51204, 'The Kizen batch contains no journal detail.', 1;
    IF EXISTS (SELECT 1 FROM @Headers WHERE BatchSequence <= 0 OR InsuranceInvoiceID <= 0 OR Amount < 0 OR VatAmount < 0)
        THROW 51205, 'Kizen journal headers contain invalid values.', 1;
    IF EXISTS (SELECT InsuranceInvoiceID FROM @Headers GROUP BY InsuranceInvoiceID HAVING COUNT(*) <> 1)
        THROW 51217, 'Each Kizen InsuranceInvoice must be posted at most once in a batch.', 1;
    IF EXISTS (SELECT 1 FROM @Headers h LEFT JOIN [dbo].[Customer] c ON c.IdNo = h.CustomerIdNo WHERE c.IdNo IS NULL)
        THROW 51213, 'A Kizen insurance company is not mapped to an ISPData customer.', 1;
    IF EXISTS (SELECT 1 FROM @Headers h LEFT JOIN [dbo].[Account] a ON a.IdNo = h.AccountIdNo WHERE a.IdNo IS NULL)
        THROW 51214, 'The Kizen AR account mapping is missing.', 1;
    IF EXISTS (SELECT 1 FROM @Items i LEFT JOIN [dbo].[Account] a ON a.IdNo = i.AccountIdNo WHERE a.IdNo IS NULL)
        THROW 51215, 'A Kizen revenue or VAT account mapping is missing.', 1;
    IF EXISTS (SELECT 1 FROM @Items i LEFT JOIN [dbo].[RevCostCenter] r ON r.IDNo = i.RevCostCenterIdNo WHERE r.IDNo IS NULL)
        THROW 51216, 'A Kizen revenue cost-center mapping is missing.', 1;
    IF EXISTS (SELECT 1 FROM @Items WHERE BatchSequence <= 0 OR Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0))
        THROW 51206, 'Kizen journal detail contains invalid debit/credit values.', 1;
    IF EXISTS (SELECT BatchSequence FROM @Headers GROUP BY BatchSequence HAVING COUNT(*) <> 1)
        THROW 51207, 'Kizen journal header sequence numbers must be unique.', 1;
    IF EXISTS (SELECT 1 FROM @Items i LEFT JOIN @Headers h ON h.BatchSequence = i.BatchSequence WHERE h.BatchSequence IS NULL)
        THROW 51208, 'Kizen journal detail references an unknown header.', 1;
    IF EXISTS
    (
        SELECT h.BatchSequence
        FROM @Headers h
        LEFT JOIN @Items i ON i.BatchSequence = h.BatchSequence
        GROUP BY h.BatchSequence
        HAVING ABS(COALESCE(SUM(i.Debit), 0) - COALESCE(SUM(i.Credit), 0)) > 0.00005
    )
        THROW 51209, 'One or more Kizen customer journals are not balanced.', 1;
    IF ABS((SELECT COALESCE(SUM(Amount), 0) FROM @Headers) - @SourceAmount) > 0.00005
        THROW 51210, 'Kizen source total does not match the customer journal totals.', 1;

    DECLARE @seriesName VARCHAR (20) = 'GL' + CONVERT(VARCHAR (4), YEAR(@SourcePeriodStart)) + RIGHT('0' + CONVERT(VARCHAR (2), MONTH(@SourcePeriodStart)), 2);
    DECLARE @prefix VARCHAR (10), @maxLength INT, @seriesValue INT;
    DECLARE @journalMap TABLE (BatchSequence INT NOT NULL PRIMARY KEY, JournalIdNo INT NOT NULL);

    BEGIN TRANSACTION;
    BEGIN TRY
        IF EXISTS
        (
            SELECT 1
            FROM @Headers h
            INNER JOIN [dbo].[KizenArImportInvoice] i WITH (UPDLOCK, HOLDLOCK)
                ON i.InsuranceInvoiceID = h.InsuranceInvoiceID
        )
            THROW 51211, 'One or more Kizen InsuranceInvoice records have already been imported. Refresh the preview before retrying.', 1;

        SELECT @seriesValue = Value, @prefix = Prefix, @maxLength = MaxLength
        FROM [dbo].[Series] WITH (UPDLOCK, HOLDLOCK)
        WHERE SeriesName = @seriesName;

        IF @prefix IS NULL
        BEGIN
            SET @prefix = RIGHT('0' + CONVERT(VARCHAR (2), MONTH(@SourcePeriodStart)), 2) + '-';
            SET @maxLength = 3;
            SET @seriesValue = 0;
            INSERT [dbo].[Series] (SeriesName, Value, MaxLength, Prefix, Description)
            VALUES (@seriesName, 0, @maxLength, @prefix, 'GL Series for ' + @seriesName);
        END;

        IF @maxLength IS NULL OR @maxLength <= 0 OR @seriesValue IS NULL
            THROW 51212, 'The GL series configuration is incomplete.', 1;

        SET @seriesValue = @seriesValue + 1;
        UPDATE [dbo].[Series] SET Value = @seriesValue WHERE SeriesName = @seriesName;
        SET @ReferenceNo = @prefix + RIGHT(REPLICATE('0', @maxLength) + CONVERT(VARCHAR (20), @seriesValue), @maxLength);

        DECLARE @batchSequence INT, @customerIdNo INT, @accountIdNo INT, @dueDate DATE, @amount MONEY, @vatAmount MONEY,
                @invoiceNo VARCHAR (15), @invoiceDate DATE, @notes NVARCHAR (300), @journalIdNo INT,
                @insuranceInvoiceID INT, @companyCode NVARCHAR (100), @supplyPeriodStart DATE, @supplyPeriodEnd DATE,
                @headerSourceInvoiceCount INT, @headerSourceDetailCount INT, @transactionDate DATE;
        DECLARE headerCursor CURSOR LOCAL FAST_FORWARD FOR
            SELECT BatchSequence, CustomerIdNo, AccountIdNo, DueDate, Amount, VatAmount, InvoiceNo, InvoiceDate, Notes,
                   InsuranceInvoiceID, CompanyCode, SupplyPeriodStart, SupplyPeriodEnd, SourceInvoiceCount, SourceDetailCount, TransactionDate
            FROM @Headers ORDER BY BatchSequence;

        OPEN headerCursor;
        FETCH NEXT FROM headerCursor INTO @batchSequence, @customerIdNo, @accountIdNo, @dueDate, @amount, @vatAmount, @invoiceNo, @invoiceDate, @notes,
                                          @insuranceInvoiceID, @companyCode, @supplyPeriodStart, @supplyPeriodEnd, @headerSourceInvoiceCount, @headerSourceDetailCount, @transactionDate;
        WHILE @@FETCH_STATUS = 0
        BEGIN
            INSERT [dbo].[ArJournal]
            (
                CustomerIdNo, TransactionDate, ReferenceNo, TransactionType, Amount, AccountIdNo,
                DueDate, SettlementDueDate, SettlementDiscount, InvoiceNo, InvoiceDate, Notes,
                VatAmount, Approved, Posted, Cancelled
            )
            VALUES
            (
                @customerIdNo, @transactionDate, @ReferenceNo, 'I', @amount, @accountIdNo,
                @dueDate, NULL, NULL, @invoiceNo, @invoiceDate, @notes, @vatAmount, 0, 0, 0
            );
            SET @journalIdNo = CONVERT(INT, SCOPE_IDENTITY());
            INSERT [dbo].[ArJournalItem] (AccountIdNo, Credit, Debit, JournalIdNo, Notes, PayIdNo, RevCostCenterIdNo, Sequence)
            SELECT AccountIdNo, Credit, Debit, @journalIdNo, Notes, NULL, RevCostCenterIdNo, Sequence
            FROM @Items WHERE BatchSequence = @batchSequence;
            INSERT @journalMap (BatchSequence, JournalIdNo) VALUES (@batchSequence, @journalIdNo);
            INSERT [dbo].[ArOpenInvoice] (JournalCode, JournalIdNo, JournalItemIdNo, PaidAmount, DiscountTaken)
            SELECT 'AR', @journalIdNo, i.IdNo, 0, 0
            FROM [dbo].[ArJournalItem] i
            INNER JOIN [dbo].[Account] a ON a.IdNo = i.AccountIdNo
            WHERE i.JournalIdNo = @journalIdNo AND a.SpecialAccount = 'AR';
            INSERT [dbo].[KizenArImportInvoice]
            (
                InsuranceInvoiceID, JournalIdNo, ReferenceNo, CompanyCode, ZatcaNumber,
                SupplyPeriodStart, SupplyPeriodEnd, SourceInvoiceCount, SourceDetailCount,
                SourceAmount, SourceVatAmount, CreatedBy
            )
            VALUES
            (
                @insuranceInvoiceID, @journalIdNo, @ReferenceNo, @companyCode, @invoiceNo,
                @supplyPeriodStart, @supplyPeriodEnd, @headerSourceInvoiceCount, @headerSourceDetailCount,
                @amount, @vatAmount, @CreatedBy
            );
            FETCH NEXT FROM headerCursor INTO @batchSequence, @customerIdNo, @accountIdNo, @dueDate, @amount, @vatAmount, @invoiceNo, @invoiceDate, @notes,
                                              @insuranceInvoiceID, @companyCode, @supplyPeriodStart, @supplyPeriodEnd, @headerSourceInvoiceCount, @headerSourceDetailCount, @transactionDate;
        END;
        CLOSE headerCursor;
        DEALLOCATE headerCursor;

        INSERT [dbo].[KizenArImportRun]
        (
            SourcePeriodStart, SourcePeriodEnd, SeriesName, ReferenceNo,
            SourceInvoiceCount, SourceDetailCount, SourceAmount, CreatedBy
        )
        VALUES
        (
            @SourcePeriodStart, @SourcePeriodEnd, @seriesName, @ReferenceNo,
            @SourceInvoiceCount, @SourceDetailCount, @SourceAmount, @CreatedBy
        );
        SET @JournalCount = (SELECT COUNT(*) FROM @journalMap);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF CURSOR_STATUS('local', 'headerCursor') >= 0 CLOSE headerCursor;
        IF CURSOR_STATUS('local', 'headerCursor') > -3 DEALLOCATE headerCursor;
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
