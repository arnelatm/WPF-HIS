-- One-time historical close baseline for ISPADMIN2.ISPDATA.
-- The user accepted January-October 2025 as already approved, posted, and closed.
-- Checklist completion and individual approver identities were not recorded.
SET NOCOUNT ON;
SET XACT_ABORT ON;

IF CONVERT(sysname, SERVERPROPERTY('ServerName')) <> N'ISPADMIN2' OR DB_NAME() <> N'ISPDATA'
    THROW 52501, 'This historical baseline script is only for ISPADMIN2.ISPDATA.', 1;
IF COL_LENGTH('dbo.MonthlyClosePeriod', 'HistoricalBaseline') IS NULL
    THROW 52502, 'Deploy the HistoricalBaseline schema column before running this script.', 1;

DECLARE @Start date = '20250101';
DECLARE @Cutoff date = '20251101';
DECLARE @ClosedThrough date;
DECLARE @Unposted int = 0;
DECLARE @HeaderTable sysname;
DECLARE @ItemTable sysname;
DECLARE @Sql nvarchar(max);
DECLARE @Count int;

BEGIN TRY
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRANSACTION;

    IF (SELECT COUNT(*) FROM dbo.LastPosting WITH (UPDLOCK, HOLDLOCK) WHERE TransactionName = 'Closed Period') <> 1
        THROW 52503, 'The Closed Period control row is missing or duplicated.', 1;
    SELECT @ClosedThrough = LastPostingDate FROM dbo.LastPosting WHERE TransactionName = 'Closed Period';
    IF @ClosedThrough IS NULL OR @ClosedThrough > '20251031'
        THROW 52504, 'The existing closed-period date cannot be moved safely to October 31, 2025.', 1;

    DECLARE journal_cursor CURSOR LOCAL FAST_FORWARD FOR
        SELECT HeaderTable, ItemTable FROM (VALUES
            ('ApJournal','ApJournalItem'), ('ArJournal','ArJournalItem'),
            ('CashReceiptJournal','CashReceiptJournalItem'), ('CdJournal','CdJournalItem'),
            ('CkJournal','CkJournalItem'), ('ErJournal','ErJournalItem'),
            ('GeneralJournal','GeneralJournalItem'), ('PcJournal','PcJournalItem'),
            ('SalesJournal','SalesJournalItem')
        ) AS journals(HeaderTable, ItemTable);
    OPEN journal_cursor;
    FETCH NEXT FROM journal_cursor INTO @HeaderTable, @ItemTable;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @Sql = N'SELECT @Count =
            (SELECT COUNT(*) FROM dbo.' + QUOTENAME(@HeaderTable) + N' WHERE TransactionDate >= @Start AND TransactionDate < @Cutoff AND ISNULL(Posted, 0) = 0) +
            (SELECT COUNT(*) FROM dbo.' + QUOTENAME(@ItemTable) + N' i INNER JOIN dbo.' + QUOTENAME(@HeaderTable) + N' h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @Start AND h.TransactionDate < @Cutoff AND i.Posted = 0);';
        EXEC sys.sp_executesql @Sql, N'@Start date, @Cutoff date, @Count int OUTPUT', @Start, @Cutoff, @Count OUTPUT;
        SET @Unposted += @Count;
        FETCH NEXT FROM journal_cursor INTO @HeaderTable, @ItemTable;
    END;
    CLOSE journal_cursor;
    DEALLOCATE journal_cursor;
    IF @Unposted <> 0
        THROW 52505, 'Some January-October 2025 journal headers or items are not posted.', 1;

    INSERT INTO dbo.MonthlyClosePeriod (FiscalYear, FiscalMonth)
    SELECT 2025, months.FiscalMonth
    FROM (VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10)) AS months(FiscalMonth)
    WHERE NOT EXISTS (SELECT 1 FROM dbo.MonthlyClosePeriod p WHERE p.FiscalYear = 2025 AND p.FiscalMonth = months.FiscalMonth);

    UPDATE dbo.MonthlyClosePeriod
    SET Status = 'Closed', HistoricalBaseline = 1,
        ApprovalNotes = N'Historical baseline accepted for periods before 2025-11-01. Journals were already posted; individual checklist completion and approver identities were not recorded.'
    WHERE FiscalYear = 2025 AND FiscalMonth BETWEEN 1 AND 10;
    IF @@ROWCOUNT <> 10
        THROW 52506, 'Expected ten historical monthly close records.', 1;

    UPDATE dbo.LastPosting
    SET LastPostingDateOld = LastPostingDate, LastPostingDate = '20251031'
    WHERE TransactionName = 'Closed Period' AND LastPostingDate < '20251031';

    COMMIT TRANSACTION;
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
    SELECT FiscalYear, FiscalMonth, Status, HistoricalBaseline, ApprovalNotes
    FROM dbo.MonthlyClosePeriod WHERE FiscalYear = 2025 AND FiscalMonth <= 10 ORDER BY FiscalMonth;
    SELECT TransactionName, LastPostingDate FROM dbo.LastPosting WHERE TransactionName = 'Closed Period';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
    THROW;
END CATCH;
