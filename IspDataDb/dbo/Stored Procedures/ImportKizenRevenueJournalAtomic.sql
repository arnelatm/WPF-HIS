CREATE PROCEDURE [dbo].[ImportKizenRevenueJournalAtomic]
    @SourcePeriodStart DATE,
    @SourcePeriodEnd DATE,
    @ReceiptCount INT,
    @InvoiceCount INT,
    @Taxable MONEY,
    @Exempt MONEY,
    @ZeroRated MONEY,
    @Vat MONEY,
    @WithVat MONEY,
    @Items dbo.KizenRevenueJournalItemInsert READONLY,
    @JournalIdNo INT OUTPUT,
    @ReferenceNo NVARCHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    SET @JournalIdNo = 0;
    SET @ReferenceNo = NULL;

    BEGIN TRANSACTION;
    BEGIN TRY
        IF @SourcePeriodStart IS NULL OR DAY(@SourcePeriodStart) <> 1
           OR @SourcePeriodEnd <> EOMONTH(@SourcePeriodStart)
            THROW 51901, 'Select a complete calendar month for the Kizen import.', 1;

        IF @SourcePeriodEnd > CONVERT(DATE, GETDATE())
            THROW 51902, 'The Kizen sales month cannot be in the future.', 1;

        IF EXISTS (SELECT 1 FROM dbo.KizenRevenueJournalImport WITH (UPDLOCK, HOLDLOCK) WHERE SourcePeriodStart = @SourcePeriodStart)
            THROW 51903, 'This Kizen sales month has already been imported.', 1;

        IF NOT EXISTS (SELECT 1 FROM @Items)
            THROW 51904, 'The Kizen import has no journal lines.', 1;

        IF EXISTS (SELECT 1 FROM @Items WHERE Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0))
            THROW 51905, 'Kizen journal lines must use non-negative debit or credit amounts.', 1;

        IF ABS((SELECT ISNULL(SUM(Debit),0) - ISNULL(SUM(Credit),0) FROM @Items)) > 0.01
            THROW 51906, 'Kizen General Journal details are not balanced.', 1;

        IF ABS(@WithVat - @Taxable - @Exempt - @ZeroRated - @Vat) > 0.10
            THROW 51907, 'Kizen summary totals do not reconcile.', 1;

        IF EXISTS (
            SELECT 1
            FROM @Items AS i
            LEFT JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
            LEFT JOIN dbo.RevCostCenter AS rc ON rc.IdNo = i.RevCostCenterIdNo
            WHERE a.IdNo IS NULL OR ISNULL(a.Active,1) = 0 OR ISNULL(a.DetailAccount,0) = 0
               OR a.SpecialAccount IN ('AP','AR','AS','CA','PD','RD')
               OR (a.AccountCode = '401' AND i.RevCostCenterIdNo <> 0)
               OR (a.AccountCode = '232' AND i.RevCostCenterIdNo <> 0)
               OR (a.AccountCode NOT IN ('401','232') AND rc.IdNo IS NULL)
        )
            THROW 51908, 'A Kizen journal account or revenue cost center is missing, inactive, or invalid.', 1;

        IF EXISTS (
            SELECT 1 FROM @Items AS i INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
            WHERE NOT ((a.AccountCode = '401' AND i.Debit > 0)
                    OR (a.AccountCode IN ('426','421','413','232') AND i.Credit > 0)
                    OR (a.AccountCode = '401' AND i.Credit > 0)
                    OR (a.AccountCode IN ('426','421','413','232') AND i.Debit > 0))
        )
            THROW 51909, 'Kizen import lines contain an account outside the approved revenue mapping.', 1;

        DECLARE @LastGeneralJournalDate DATE;
        DECLARE @ClosedPeriodDate DATE;
        SELECT @LastGeneralJournalDate = MAX(LastPostingDate) FROM dbo.LastPosting WHERE TransactionName = 'General Journal';
        SELECT @ClosedPeriodDate = MAX(LastPostingDate) FROM dbo.LastPosting WHERE TransactionName = 'Closed Period';
        IF @LastGeneralJournalDate IS NULL
            THROW 51910, 'The General Journal posting date is not configured.', 1;
        IF @SourcePeriodEnd < @LastGeneralJournalDate
            THROW 51911, 'The selected Kizen month is outside the valid General Journal date range.', 1;
        IF @ClosedPeriodDate IS NOT NULL AND @SourcePeriodEnd <= @ClosedPeriodDate
            THROW 51912, 'The selected Kizen month is in a closed accounting period.', 1;

        INSERT INTO dbo.GeneralJournal (TransactionDate, ReferenceNo, Notes, Approved, Posted, ClosingJournal, Cancelled)
        VALUES (@SourcePeriodEnd, NULL, N'Kizen revenue summary - ' + CONVERT(NVARCHAR(7), @SourcePeriodStart, 126), 0, 0, 0, 0);
        SET @JournalIdNo = CONVERT(INT, SCOPE_IDENTITY());

        INSERT INTO dbo.GeneralJournalItem (Sequence, JournalIdNo, AccountIdNo, Debit, Credit, RevCostCenterIdNo, Notes, Posted)
        SELECT CONVERT(SMALLINT, i.Sequence), @JournalIdNo, CONVERT(SMALLINT, i.AccountIdNo), i.Debit, i.Credit,
               CASE WHEN a.AccountCode IN ('401','232') THEN NULL ELSE CONVERT(SMALLINT, i.RevCostCenterIdNo) END,
               i.Notes, 0
        FROM @Items AS i
        INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
        ORDER BY i.Sequence;

        DECLARE @SeriesName VARCHAR(20) = 'GL' + CONVERT(VARCHAR(4), YEAR(@SourcePeriodEnd)) + RIGHT('0' + CONVERT(VARCHAR(2), MONTH(@SourcePeriodEnd)), 2);
        DECLARE @Prefix VARCHAR(10), @MaxLength INT, @SeriesValue INT;
        SELECT @SeriesValue = Value, @Prefix = Prefix, @MaxLength = MaxLength
        FROM dbo.Series WITH (UPDLOCK, HOLDLOCK) WHERE SeriesName = @SeriesName;
        IF @Prefix IS NULL
        BEGIN
            SET @Prefix = RIGHT('0' + CONVERT(VARCHAR(2), MONTH(@SourcePeriodEnd)), 2) + '-';
            SET @MaxLength = 3;
            SET @SeriesValue = 0;
            INSERT INTO dbo.Series (SeriesName, Value, MaxLength, Prefix, Description)
            VALUES (@SeriesName, 0, @MaxLength, @Prefix, 'GL Series for ' + @SeriesName);
        END;
        SET @SeriesValue = @SeriesValue + 1;
        UPDATE dbo.Series SET Value = @SeriesValue WHERE SeriesName = @SeriesName;
        SET @ReferenceNo = @Prefix + RIGHT(REPLICATE('0', @MaxLength) + CONVERT(VARCHAR(20), @SeriesValue), @MaxLength);
        UPDATE dbo.GeneralJournal SET ReferenceNo = @ReferenceNo WHERE IdNo = @JournalIdNo;

        INSERT INTO dbo.KizenRevenueJournalImport (SourcePeriodStart, SourcePeriodEnd, GeneralJournalIdNo, ReceiptCount, InvoiceCount, Taxable, Exempt, ZeroRated, Vat, WithVat)
        VALUES (@SourcePeriodStart, @SourcePeriodEnd, @JournalIdNo, @ReceiptCount, @InvoiceCount, @Taxable, @Exempt, @ZeroRated, @Vat, @WithVat);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @JournalIdNo = 0;
        SET @ReferenceNo = NULL;
        THROW;
    END CATCH;
END;
GO
