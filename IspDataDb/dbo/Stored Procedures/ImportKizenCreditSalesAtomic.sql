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
    @JournalCount INT OUTPUT,
    @CreatedCustomerCount INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    SET @CreatedCustomerCount = 0;

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
    IF EXISTS (SELECT 1 FROM @Headers h LEFT JOIN [dbo].[Customer] c ON c.IdNo = h.CustomerIdNo WHERE h.CustomerIdNo > 0 AND c.IdNo IS NULL)
        THROW 51213, 'A Kizen insurance company is not mapped to an ISPData customer.', 1;

    DECLARE @missingCustomerCode NVARCHAR (100), @missingCustomerName NVARCHAR (100), @contactError NVARCHAR (2048);
    SELECT TOP (1) @missingCustomerCode = c.CustomerCode, @missingCustomerName = c.CustomerName
    FROM @Headers AS h
    INNER JOIN [dbo].[Customer] AS c ON c.IdNo = h.CustomerIdNo
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM [dbo].[Contact] AS contact
        WHERE contact.CSEIdNo = c.IdNo AND contact.CSECode = 'C'
    )
    ORDER BY h.BatchSequence;
    IF @missingCustomerName IS NOT NULL
    BEGIN
        SET @contactError = CONCAT('Kizen customer ', COALESCE(NULLIF(@missingCustomerCode, N''), N'(no code)'), ' - ', @missingCustomerName, ' has no contact entry with party type C.');
        THROW 51218, @contactError, 1;
    END;
    IF EXISTS (SELECT 1 FROM @Headers h LEFT JOIN [dbo].[Account] a ON a.IdNo = h.AccountIdNo WHERE a.IdNo IS NULL)
        THROW 51214, 'The Kizen AR account mapping is missing.', 1;
    IF EXISTS (SELECT 1 FROM @Items i LEFT JOIN [dbo].[Account] a ON a.IdNo = i.AccountIdNo WHERE a.IdNo IS NULL)
        THROW 51215, 'A Kizen revenue or VAT account mapping is missing.', 1;
    IF EXISTS
    (
        SELECT 1 FROM @Items i
        INNER JOIN [dbo].[Account] a ON a.IdNo = i.AccountIdNo
        LEFT JOIN [dbo].[RevCostCenter] r ON r.IDNo = i.RevCostCenterIdNo
        WHERE r.IDNo IS NULL AND NOT (i.RevCostCenterIdNo = 0 AND a.AccountCode IN ('112', '232'))
    )
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
                @insuranceInvoiceID INT, @companyCode NVARCHAR (100), @companyName NVARCHAR (MAX), @companyNameAra NVARCHAR (MAX),
                @companyVatNumber NVARCHAR (MAX), @companyCrNumber NVARCHAR (MAX), @headerCustomerIdNo INT,
                @supplyPeriodStart DATE, @supplyPeriodEnd DATE,
                @headerSourceInvoiceCount INT, @headerSourceDetailCount INT, @transactionDate DATE;
        DECLARE headerCursor CURSOR LOCAL FAST_FORWARD FOR
            SELECT BatchSequence, CustomerIdNo, AccountIdNo, DueDate, Amount, VatAmount, InvoiceNo, InvoiceDate, Notes,
                   InsuranceInvoiceID, CompanyCode, CompanyName, CompanyNameAra, CompanyVatNumber, CompanyCrNumber,
                   SupplyPeriodStart, SupplyPeriodEnd, SourceInvoiceCount, SourceDetailCount, TransactionDate
            FROM @Headers ORDER BY BatchSequence;

        OPEN headerCursor;
        FETCH NEXT FROM headerCursor INTO @batchSequence, @headerCustomerIdNo, @accountIdNo, @dueDate, @amount, @vatAmount, @invoiceNo, @invoiceDate, @notes,
                                          @insuranceInvoiceID, @companyCode, @companyName, @companyNameAra, @companyVatNumber, @companyCrNumber,
                                          @supplyPeriodStart, @supplyPeriodEnd, @headerSourceInvoiceCount, @headerSourceDetailCount, @transactionDate;
        WHILE @@FETCH_STATUS = 0
        BEGIN
            SET @customerIdNo = NULL;
            SELECT TOP (1) @customerIdNo = c.IdNo
            FROM [dbo].[Customer] AS c WITH (UPDLOCK, HOLDLOCK)
            WHERE LTRIM(RTRIM(c.CustomerCode)) = @companyCode;

            IF @headerCustomerIdNo > 0 AND ISNULL(@customerIdNo, 0) <> @headerCustomerIdNo
                THROW 51219, 'The ISPData customer mapping changed after preview. Refresh the Kizen preview and retry.', 1;
            IF @customerIdNo IS NULL
            BEGIN
                IF LEN(@companyCode) = 0 OR LEN(@companyCode) > 50
                    THROW 51220, 'A Kizen company code is blank or exceeds the 50-character ISPData customer-code limit.', 1;
                IF LEN(@companyName) = 0 OR LEN(@companyName) > 50 OR LEN(@companyNameAra) = 0 OR LEN(@companyNameAra) > 50
                    THROW 51221, 'A Kizen company name is blank or exceeds the 50-character ISPData customer-name limit.', 1;
                IF LEN(@companyVatNumber) > 15 OR LEN(@companyCrNumber) > 20
                    THROW 51222, 'A Kizen customer VAT or commercial registration number exceeds the ISPData field limit.', 1;
                IF EXISTS
                (
                    SELECT 1
                    FROM [dbo].[Customer] AS c
                    WHERE (c.CustomerName = @companyName OR c.CustomerNameAra = @companyNameAra)
                      AND ISNULL(LTRIM(RTRIM(c.CustomerCode)), N'') <> @companyCode
                )
                    THROW 51223, 'A Kizen company name is already assigned to a different ISPData customer code. Resolve the duplicate name or map the company manually.', 1;

                INSERT [dbo].[Customer]
                    (CustomerCode, CustomerName, CustomerNameAra, VATNumber, CRNumber, AccountStatus, ARAccountIdNo, PaymentDueDays, Active)
                VALUES
                    (@companyCode, @companyName, @companyNameAra, NULLIF(CONVERT(VARCHAR (15), @companyVatNumber), ''),
                     NULLIF(CONVERT(VARCHAR (20), @companyCrNumber), ''), 'O', CONVERT(SMALLINT, @accountIdNo), 0, 1);
                SET @customerIdNo = CONVERT(INT, SCOPE_IDENTITY());
                SET @CreatedCustomerCount = @CreatedCustomerCount + 1;
            END;

            IF NOT EXISTS (SELECT 1 FROM [dbo].[Contact] WHERE CSEIdNo = @customerIdNo AND CSECode = 'C')
                THROW 51218, 'The ISPData customer has no customer-type contact entry. Add a valid contact before importing.', 1;

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
            SELECT i.AccountIdNo, i.Credit, i.Debit, @journalIdNo, i.Notes,
                   CASE WHEN a.SpecialAccount IN ('AR', 'CA') THEN customerContact.ContactIdNo END,
                   NULLIF(i.RevCostCenterIdNo, 0), i.Sequence
            FROM @Items AS i
            INNER JOIN [dbo].[Account] AS a ON a.IdNo = i.AccountIdNo
            OUTER APPLY
            (
                SELECT MIN(contact.IdNo) AS ContactIdNo
                FROM [dbo].[Contact] AS contact
                WHERE contact.CSEIdNo = @customerIdNo AND contact.CSECode = 'C'
            ) AS customerContact
            WHERE i.BatchSequence = @batchSequence;
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
            FETCH NEXT FROM headerCursor INTO @batchSequence, @headerCustomerIdNo, @accountIdNo, @dueDate, @amount, @vatAmount, @invoiceNo, @invoiceDate, @notes,
                                              @insuranceInvoiceID, @companyCode, @companyName, @companyNameAra, @companyVatNumber, @companyCrNumber,
                                          @supplyPeriodStart, @supplyPeriodEnd, @headerSourceInvoiceCount, @headerSourceDetailCount, @transactionDate;
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
