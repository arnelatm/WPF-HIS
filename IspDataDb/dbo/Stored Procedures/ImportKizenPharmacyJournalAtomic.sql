CREATE PROCEDURE [dbo].[ImportKizenPharmacyJournalAtomic]
    @SourcePeriodStart DATE,
    @SourcePeriodEnd DATE,
    @ReceiptCount INT,
    @InvoiceCount INT,
    @Taxable MONEY,
    @Vat MONEY,
    @ZeroRated MONEY,
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
            THROW 51921, 'Select a complete calendar month for the Kizen Pharmacy import.', 1;

        IF @SourcePeriodEnd > CONVERT(DATE, GETDATE())
            THROW 51922, 'The Kizen Pharmacy month cannot be in the future.', 1;

        IF EXISTS (SELECT 1 FROM dbo.KizenPharmacyJournalImport WITH (UPDLOCK, HOLDLOCK) WHERE SourcePeriodStart = @SourcePeriodStart)
            THROW 51923, 'This Kizen Pharmacy month has already been imported.', 1;

        IF NOT EXISTS (SELECT 1 FROM @Items)
            THROW 51924, 'The Kizen Pharmacy import has no journal lines.', 1;

        IF ABS(@Taxable + @ZeroRated + @Vat - @WithVat) > 0.1
            THROW 51925, 'Pharmacy taxable, zero-rated and VAT totals must reconcile to receipts.', 1;

        IF EXISTS (SELECT 1 FROM @Items WHERE Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0))
            THROW 51926, 'Kizen Pharmacy journal lines must use non-negative debit or credit amounts.', 1;

        IF (SELECT ISNULL(SUM(Debit),0) - ISNULL(SUM(Credit),0) FROM @Items) <> 0
            THROW 51927, 'Kizen Pharmacy General Journal details are not balanced.', 1;

        IF EXISTS (
            SELECT 1
            FROM @Items AS i
            LEFT JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
            LEFT JOIN dbo.RevCostCenter AS rc ON rc.IdNo = i.RevCostCenterIdNo
            WHERE a.IdNo IS NULL OR ISNULL(a.Active,1) = 0 OR ISNULL(a.DetailAccount,0) = 0
               OR a.AccountCode NOT IN ('402','414','232','419')
               OR (a.AccountCode IN ('419','232') AND i.RevCostCenterIdNo <> 0)
               OR (a.AccountCode IN ('414','402') AND rc.IdNo IS NULL)
        )
            THROW 51928, 'A Pharmacy journal account or revenue cost center is missing, inactive, or invalid.', 1;

        IF ABS((SELECT ISNULL(SUM(i.Credit-i.Debit),0) FROM @Items i JOIN dbo.Account a ON a.IdNo=i.AccountIdNo WHERE a.AccountCode='414') - @ZeroRated) > 0.01
           OR ABS((SELECT ISNULL(SUM(i.Credit-i.Debit),0) FROM @Items i JOIN dbo.Account a ON a.IdNo=i.AccountIdNo WHERE a.AccountCode='402') - @Taxable) > 0.1
           OR ABS((SELECT ISNULL(SUM(i.Credit-i.Debit),0) FROM @Items i JOIN dbo.Account a ON a.IdNo=i.AccountIdNo WHERE a.AccountCode='232') - @Vat) > 0.01
           OR ABS((SELECT ISNULL(SUM(i.Debit-i.Credit),0) FROM @Items i JOIN dbo.Account a ON a.IdNo=i.AccountIdNo WHERE a.AccountCode='419') - @WithVat) > 0.01
            THROW 51929, 'Pharmacy journal lines do not match the classified and clearing totals.', 1;

        DECLARE @LastGeneralJournalDate DATE;
        DECLARE @ClosedPeriodDate DATE;
        SELECT @LastGeneralJournalDate = MAX(LastPostingDate) FROM dbo.LastPosting WHERE TransactionName = 'General Journal';
        SELECT @ClosedPeriodDate = MAX(LastPostingDate) FROM dbo.LastPosting WHERE TransactionName = 'Closed Period';
        IF @LastGeneralJournalDate IS NULL
            THROW 51930, 'The General Journal posting date is not configured.', 1;
        IF @SourcePeriodEnd < @LastGeneralJournalDate
            THROW 51931, 'The selected Pharmacy month is outside the valid General Journal date range.', 1;
        IF @ClosedPeriodDate IS NOT NULL AND @SourcePeriodEnd <= @ClosedPeriodDate
            THROW 51932, 'The selected Pharmacy month is in a closed accounting period.', 1;

        INSERT INTO dbo.GeneralJournal (TransactionDate, ReferenceNo, Notes, Approved, Posted, ClosingJournal, Cancelled)
        VALUES (@SourcePeriodEnd, NULL, N'Kizen Pharmacy cash sales - ' + CONVERT(NVARCHAR(7), @SourcePeriodStart, 126), 0, 0, 0, 0);
        SET @JournalIdNo = CONVERT(INT, SCOPE_IDENTITY());

        INSERT INTO dbo.GeneralJournalItem (Sequence, JournalIdNo, AccountIdNo, Debit, Credit, RevCostCenterIdNo, Notes, Posted)
        SELECT CONVERT(SMALLINT, i.Sequence), @JournalIdNo, CONVERT(SMALLINT, i.AccountIdNo), i.Debit, i.Credit,
               CASE WHEN a.AccountCode IN ('419','232') THEN NULL ELSE CONVERT(SMALLINT, i.RevCostCenterIdNo) END,
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

        INSERT INTO dbo.KizenPharmacyJournalImport (SourcePeriodStart, SourcePeriodEnd, GeneralJournalIdNo, ReceiptCount, InvoiceCount, ZeroRated, WithVat)
        VALUES (@SourcePeriodStart, @SourcePeriodEnd, @JournalIdNo, @ReceiptCount, @InvoiceCount, @ZeroRated, @WithVat);

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
