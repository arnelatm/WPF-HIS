CREATE PROCEDURE [dbo].[UncloseMonthlyPeriod]
    @FiscalYear int,
    @FiscalMonth int,
    @ApplicationUser sysname
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @FiscalYear NOT BETWEEN 2000 AND 2099
        THROW 52370, 'FiscalYear must be between 2000 and 2099.', 1;
    IF @FiscalMonth NOT BETWEEN 1 AND 12
        THROW 52371, 'FiscalMonth must be between 1 and 12.', 1;
    IF NULLIF(LTRIM(RTRIM(@ApplicationUser)), '') IS NULL
        THROW 52372, 'ApplicationUser is required.', 1;

    DECLARE @PeriodStart date = DATEFROMPARTS(@FiscalYear, @FiscalMonth, 1);
    DECLARE @PeriodEndExclusive date = DATEADD(month, 1, @PeriodStart);
    DECLARE @PeriodEnd date = DATEADD(day, -1, @PeriodEndExclusive);
    DECLARE @ClosedThrough date;
    DECLARE @LastFiscalYearEnd date;
    DECLARE @ClosedThroughOld date;
    DECLARE @NewClosedThrough date;
    DECLARE @NewClosedThroughOld date;
    DECLARE @PostedHeaders int;
    DECLARE @PostedItems int;
    DECLARE @LockResult int;
    DECLARE @MonthlyLockResult int;
    DECLARE @MonthlyLockResource nvarchar(255) = N'ISPDATA:MonthlyJournalPosting:' + CONVERT(nvarchar(4), @FiscalYear) + N'-' + RIGHT(N'0' + CONVERT(nvarchar(2), @FiscalMonth), 2);

    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
        BEGIN TRANSACTION;

        EXEC @LockResult = sys.sp_getapplock
            @Resource = N'ISPDATA:MonthlyClose',
            @LockMode = 'Exclusive',
            @LockOwner = 'Transaction',
            @LockTimeout = 30000;
        IF @LockResult < 0
            THROW 52373, 'Could not acquire the monthly close lock.', 1;

        EXEC @MonthlyLockResult = sys.sp_getapplock
            @Resource = @MonthlyLockResource,
            @LockMode = 'Exclusive',
            @LockOwner = 'Transaction',
            @LockTimeout = 30000;
        IF @MonthlyLockResult < 0
            THROW 52374, 'Could not acquire the monthly journal posting lock.', 1;

        SELECT @ClosedThrough = LastPostingDate,
            @ClosedThroughOld = LastPostingDateOld
        FROM dbo.LastPosting WITH (UPDLOCK, HOLDLOCK)
        WHERE TransactionName = 'Closed Period';

        SELECT @LastFiscalYearEnd = LastPostingDate
        FROM dbo.LastPosting WITH (UPDLOCK, HOLDLOCK)
        WHERE TransactionName = 'LastFiscalYearEnd';

        IF @LastFiscalYearEnd IS NOT NULL AND @PeriodEnd <= @LastFiscalYearEnd
            THROW 52461, 'A finalized fiscal year cannot be unclosed.', 1;

        IF @ClosedThrough <> @PeriodEnd
            THROW 52375, 'Only the latest closed month can be unclosed.', 1;

        IF NOT EXISTS (
            SELECT 1
            FROM dbo.MonthlyClosePeriod WITH (UPDLOCK, HOLDLOCK)
            WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth AND Status = 'Closed'
        )
            THROW 52376, 'The selected month is not closed.', 1;

        SELECT @PostedHeaders =
            (SELECT COUNT(*) FROM dbo.ApJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive AND ISNULL(Posted, 0) = 1) +
            (SELECT COUNT(*) FROM dbo.ArJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive AND ISNULL(Posted, 0) = 1) +
            (SELECT COUNT(*) FROM dbo.CdJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive AND ISNULL(Posted, 0) = 1) +
            (SELECT COUNT(*) FROM dbo.CkJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive AND ISNULL(Posted, 0) = 1) +
            (SELECT COUNT(*) FROM dbo.CashReceiptJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive AND ISNULL(Posted, 0) = 1) +
            (SELECT COUNT(*) FROM dbo.ErJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive AND ISNULL(Posted, 0) = 1) +
            (SELECT COUNT(*) FROM dbo.GeneralJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive AND ISNULL(Posted, 0) = 1) +
            (SELECT COUNT(*) FROM dbo.PcJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive AND ISNULL(Posted, 0) = 1) +
            (SELECT COUNT(*) FROM dbo.SalesJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive AND ISNULL(Posted, 0) = 1),
            @PostedItems =
            (SELECT COUNT(*) FROM dbo.ApJournalItem i INNER JOIN dbo.ApJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive AND i.Posted = 1) +
            (SELECT COUNT(*) FROM dbo.ArJournalItem i INNER JOIN dbo.ArJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive AND i.Posted = 1) +
            (SELECT COUNT(*) FROM dbo.CdJournalItem i INNER JOIN dbo.CdJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive AND i.Posted = 1) +
            (SELECT COUNT(*) FROM dbo.CkJournalItem i INNER JOIN dbo.CkJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive AND i.Posted = 1) +
            (SELECT COUNT(*) FROM dbo.CashReceiptJournalItem i INNER JOIN dbo.CashReceiptJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive AND i.Posted = 1) +
            (SELECT COUNT(*) FROM dbo.ErJournalItem i INNER JOIN dbo.ErJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive AND i.Posted = 1) +
            (SELECT COUNT(*) FROM dbo.GeneralJournalItem i INNER JOIN dbo.GeneralJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive AND i.Posted = 1) +
            (SELECT COUNT(*) FROM dbo.PcJournalItem i INNER JOIN dbo.PcJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive AND i.Posted = 1) +
            (SELECT COUNT(*) FROM dbo.SalesJournalItem i INNER JOIN dbo.SalesJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive AND i.Posted = 1);

        IF @PostedHeaders > 0 OR @PostedItems > 0
            THROW 52377, 'Unpost the latest month before unclosing it.', 1;

        SET @NewClosedThrough = @ClosedThroughOld;
        IF @NewClosedThrough IS NULL OR @NewClosedThrough >= @PeriodEnd
            THROW 52378, 'The previous closed-period date could not be determined safely.', 1;
        SET @NewClosedThroughOld = DATEADD(day, -DAY(@NewClosedThrough), @NewClosedThrough);

        UPDATE dbo.MonthlyClosePeriod
        SET Status = 'Approved',
            ClosedBy = NULL,
            ClosedAt = NULL
        WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth;

        UPDATE dbo.LastPosting
        SET LastPostingDate = @NewClosedThrough,
            LastPostingDateOld = @NewClosedThroughOld
        WHERE TransactionName = 'Closed Period';

        INSERT INTO dbo.MonthlyClosePeriodReversal (
            FiscalYear, FiscalMonth, PreviousClosedThrough, NewClosedThrough, ReopenedBy, ReopenedAt
        )
        VALUES (
            @FiscalYear, @FiscalMonth, @ClosedThrough, @NewClosedThrough, @ApplicationUser, SYSDATETIME()
        );

        COMMIT TRANSACTION;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

        SELECT N'MONTH UNCLOSED' AS ReversalStatus,
            @FiscalYear AS FiscalYear,
            @FiscalMonth AS FiscalMonth,
            @ClosedThrough AS PreviousPeriodLockedThrough,
            @NewClosedThrough AS PeriodLockedThrough,
            @ApplicationUser AS ReopenedBy;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        THROW;
    END CATCH;
END;
