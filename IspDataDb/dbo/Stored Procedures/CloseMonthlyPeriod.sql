CREATE PROCEDURE [dbo].[CloseMonthlyPeriod]
    @FiscalYear int,
    @FiscalMonth int,
    @ApplicationUser sysname
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @FiscalYear NOT BETWEEN 2000 AND 2099
        THROW 52340, 'FiscalYear must be between 2000 and 2099.', 1;
    IF @FiscalMonth NOT BETWEEN 1 AND 12
        THROW 52341, 'FiscalMonth must be between 1 and 12.', 1;
    IF NULLIF(LTRIM(RTRIM(@ApplicationUser)), '') IS NULL
        THROW 52342, 'ApplicationUser is required.', 1;

    DECLARE @PeriodStart date = DATEFROMPARTS(@FiscalYear, @FiscalMonth, 1);
    DECLARE @PeriodEndExclusive date = DATEADD(month, 1, @PeriodStart);
    DECLARE @PeriodEnd date = DATEADD(day, -1, @PeriodEndExclusive);
    DECLARE @PreviousPeriodEnd date = DATEADD(day, -1, @PeriodStart);
    DECLARE @ClosedThrough date;
    DECLARE @CloseStatus varchar(20);
    DECLARE @ClosedPeriodRows int;
    DECLARE @LockResult int;

    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
        BEGIN TRANSACTION;

        EXEC @LockResult = sys.sp_getapplock
            @Resource = N'ISPDATA:MonthlyClose',
            @LockMode = 'Exclusive',
            @LockOwner = 'Transaction',
            @LockTimeout = 30000;
        IF @LockResult < 0
            THROW 52343, 'Could not acquire the monthly close lock.', 1;

        SELECT @CloseStatus = Status
        FROM dbo.MonthlyClosePeriod WITH (UPDLOCK, HOLDLOCK)
        WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth;

        IF @CloseStatus IS NULL
            THROW 52344, 'Load and complete the monthly close checklist before closing the month.', 1;
        IF @CloseStatus = 'Open'
            THROW 52345, 'The month must be approved before it can be closed.', 1;

        SELECT
            @ClosedPeriodRows = COUNT(*),
            @ClosedThrough = MAX(LastPostingDate)
        FROM dbo.LastPosting WITH (UPDLOCK, HOLDLOCK)
        WHERE TransactionName = 'Closed Period';

        IF @ClosedPeriodRows <> 1
            THROW 52346, 'LastPosting must contain exactly one Closed Period control row.', 1;
        IF @ClosedThrough IS NULL
            THROW 52347, 'The Closed Period control date is not initialized.', 1;
        IF @ClosedThrough < @PreviousPeriodEnd
            THROW 52348, 'Close the previous accounting period before closing this month.', 1;

        CREATE TABLE #Items (
            JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
            JournalIdNo int NOT NULL,
            AccountIdNo int NOT NULL,
            Debit money NOT NULL,
            Credit money NOT NULL,
            Cancelled bit NULL
        );

        INSERT INTO #Items (JournalCode, JournalIdNo, AccountIdNo, Debit, Credit, Cancelled)
        SELECT 'AP', i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit, h.Cancelled FROM dbo.ApJournalItem i INNER JOIN dbo.ApJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive
        UNION ALL SELECT 'AR', i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit, h.Cancelled FROM dbo.ArJournalItem i INNER JOIN dbo.ArJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive
        UNION ALL SELECT 'CD', i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit, h.Cancelled FROM dbo.CdJournalItem i INNER JOIN dbo.CdJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive
        UNION ALL SELECT 'CK', i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit, h.Cancelled FROM dbo.CkJournalItem i INNER JOIN dbo.CkJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive
        UNION ALL SELECT 'CR', i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit, h.Cancelled FROM dbo.CashReceiptJournalItem i INNER JOIN dbo.CashReceiptJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive
        UNION ALL SELECT 'ER', i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit, h.Cancelled FROM dbo.ErJournalItem i INNER JOIN dbo.ErJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive
        UNION ALL SELECT 'GJ', i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit, h.Cancelled FROM dbo.GeneralJournalItem i INNER JOIN dbo.GeneralJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive
        UNION ALL SELECT 'PC', i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit, h.Cancelled FROM dbo.PcJournalItem i INNER JOIN dbo.PcJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive
        UNION ALL SELECT 'SJ', i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit, h.Cancelled FROM dbo.SalesJournalItem i INNER JOIN dbo.SalesJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive;

        IF EXISTS (
            SELECT 1
            FROM #Items
            WHERE ISNULL(Cancelled, 0) = 0
              AND (AccountIdNo = 0 OR Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0))
        ) OR EXISTS (
            SELECT 1
            FROM #Items
            WHERE ISNULL(Cancelled, 0) = 0
            GROUP BY JournalCode, JournalIdNo
            HAVING ABS(SUM(CONVERT(decimal(19, 4), Debit)) - SUM(CONVERT(decimal(19, 4), Credit))) > 0.00005
        )
            THROW 52349, 'Monthly journal validation failed. Correct the journal data and run Preview again before closing.', 1;

        IF @ClosedThrough < @PeriodEnd
        BEGIN
            UPDATE dbo.LastPosting
            SET LastPostingDateOld = LastPostingDate,
                LastPostingDate = @PeriodEnd
            WHERE TransactionName = 'Closed Period';
            SET @ClosedThrough = @PeriodEnd;
        END;

        IF @CloseStatus <> 'Closed'
        BEGIN
            UPDATE dbo.MonthlyClosePeriod
            SET Status = 'Closed',
                ClosedBy = @ApplicationUser,
                ClosedAt = SYSDATETIME()
            WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth;
        END;

        COMMIT TRANSACTION;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

        SELECT p.FiscalYear,
            p.FiscalMonth,
            @PeriodEnd AS PeriodEnd,
            @ClosedThrough AS PeriodLockedThrough,
            p.Status,
            p.ClosedBy,
            p.ClosedAt
        FROM dbo.MonthlyClosePeriod p
        WHERE p.FiscalYear = @FiscalYear AND p.FiscalMonth = @FiscalMonth;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        THROW;
    END CATCH;
END;
