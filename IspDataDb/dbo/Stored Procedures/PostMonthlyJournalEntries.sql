CREATE PROCEDURE [dbo].[PostMonthlyJournalEntries]
    @FiscalYear int,
    @Month int,
    @ExecutePosting bit = 0
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @FiscalYear NOT BETWEEN 2000 AND 2099
        THROW 52201, 'FiscalYear must be between 2000 and 2099.', 1;
    IF @Month NOT BETWEEN 1 AND 12
        THROW 52202, 'Month must be between 1 and 12.', 1;
    IF @ExecutePosting NOT IN (0, 1)
        THROW 52203, 'ExecutePosting must be 0 (validation only) or 1 (execute).', 1;

    DECLARE @PeriodStart date = DATEFROMPARTS(@FiscalYear, @Month, 1);
    DECLARE @PeriodEndExclusive date = DATEADD(month, 1, @PeriodStart);
    DECLARE @PeriodEnd date = DATEADD(day, -1, @PeriodEndExclusive);
    DECLARE @ClosedThrough date = (SELECT LastPostingDate FROM dbo.LastPosting WHERE TransactionName = 'Closed Period');
    DECLARE @RunId uniqueidentifier = NEWID();
    DECLARE @HeadersToChange int;
    DECLARE @ItemsToChange int;
    DECLARE @BlockingErrorCount int;
    DECLARE @HeadersChanged int = 0;
    DECLARE @ItemsChanged int = 0;
    DECLARE @PreviousMonthUnpostedHeaders int = 0;
    DECLARE @PreviousMonthUnpostedItems int = 0;
    DECLARE @MonthlyCloseStatus varchar(20) = NULL;
    DECLARE @LockResult int;
    DECLARE @LockResource nvarchar(255) = N'ISPDATA:MonthlyJournalPosting:' + CONVERT(nvarchar(4), @FiscalYear) + N'-' + RIGHT(N'0' + CONVERT(nvarchar(2), @Month), 2);

    CREATE TABLE #Headers (
        JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        JournalIdNo int NOT NULL,
        TransactionDate date NOT NULL,
        HeaderPosted bit NULL,
        Cancelled bit NULL,
        PRIMARY KEY (JournalCode, JournalIdNo)
    );

    INSERT INTO #Headers (JournalCode, JournalIdNo, TransactionDate, HeaderPosted, Cancelled)
    SELECT 'AP', IdNo, TransactionDate, Posted, Cancelled FROM dbo.ApJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive
    UNION ALL SELECT 'AR', IdNo, TransactionDate, Posted, Cancelled FROM dbo.ArJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive
    UNION ALL SELECT 'CD', IdNo, TransactionDate, Posted, Cancelled FROM dbo.CdJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive
    UNION ALL SELECT 'CK', IdNo, TransactionDate, Posted, Cancelled FROM dbo.CkJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive
    UNION ALL SELECT 'CR', IdNo, TransactionDate, Posted, Cancelled FROM dbo.CashReceiptJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive
    UNION ALL SELECT 'ER', IdNo, TransactionDate, Posted, Cancelled FROM dbo.ErJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive
    UNION ALL SELECT 'GJ', IdNo, TransactionDate, Posted, Cancelled FROM dbo.GeneralJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive
    UNION ALL SELECT 'PC', IdNo, TransactionDate, Posted, Cancelled FROM dbo.PcJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive
    UNION ALL SELECT 'SJ', IdNo, TransactionDate, Posted, Cancelled FROM dbo.SalesJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEndExclusive;

    CREATE TABLE #Items (
        JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        ItemIdNo int NOT NULL,
        JournalIdNo int NOT NULL,
        AccountIdNo int NOT NULL,
        ItemPosted bit NOT NULL,
        Debit money NOT NULL,
        Credit money NOT NULL,
        Cancelled bit NULL,
        PRIMARY KEY (JournalCode, ItemIdNo)
    );

    INSERT INTO #Items (JournalCode, ItemIdNo, JournalIdNo, AccountIdNo, ItemPosted, Debit, Credit, Cancelled)
    SELECT 'AP', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled FROM dbo.ApJournalItem i INNER JOIN #Headers h ON h.JournalCode = 'AP' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL SELECT 'AR', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled FROM dbo.ArJournalItem i INNER JOIN #Headers h ON h.JournalCode = 'AR' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL SELECT 'CD', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled FROM dbo.CdJournalItem i INNER JOIN #Headers h ON h.JournalCode = 'CD' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL SELECT 'CK', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled FROM dbo.CkJournalItem i INNER JOIN #Headers h ON h.JournalCode = 'CK' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL SELECT 'CR', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled FROM dbo.CashReceiptJournalItem i INNER JOIN #Headers h ON h.JournalCode = 'CR' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL SELECT 'ER', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled FROM dbo.ErJournalItem i INNER JOIN #Headers h ON h.JournalCode = 'ER' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL SELECT 'GJ', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled FROM dbo.GeneralJournalItem i INNER JOIN #Headers h ON h.JournalCode = 'GJ' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL SELECT 'PC', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled FROM dbo.PcJournalItem i INNER JOIN #Headers h ON h.JournalCode = 'PC' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL SELECT 'SJ', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled FROM dbo.SalesJournalItem i INNER JOIN #Headers h ON h.JournalCode = 'SJ' AND h.JournalIdNo = i.JournalIdNo;

    IF @Month > 1
    BEGIN
        DECLARE @PreviousPeriodStart date = DATEADD(month, -1, @PeriodStart);
        SELECT @PreviousMonthUnpostedHeaders =
            (SELECT COUNT(*) FROM dbo.ApJournal WHERE TransactionDate >= @PreviousPeriodStart AND TransactionDate < @PeriodStart AND ISNULL(Posted, 0) = 0) +
            (SELECT COUNT(*) FROM dbo.ArJournal WHERE TransactionDate >= @PreviousPeriodStart AND TransactionDate < @PeriodStart AND ISNULL(Posted, 0) = 0) +
            (SELECT COUNT(*) FROM dbo.CdJournal WHERE TransactionDate >= @PreviousPeriodStart AND TransactionDate < @PeriodStart AND ISNULL(Posted, 0) = 0) +
            (SELECT COUNT(*) FROM dbo.CkJournal WHERE TransactionDate >= @PreviousPeriodStart AND TransactionDate < @PeriodStart AND ISNULL(Posted, 0) = 0) +
            (SELECT COUNT(*) FROM dbo.CashReceiptJournal WHERE TransactionDate >= @PreviousPeriodStart AND TransactionDate < @PeriodStart AND ISNULL(Posted, 0) = 0) +
            (SELECT COUNT(*) FROM dbo.ErJournal WHERE TransactionDate >= @PreviousPeriodStart AND TransactionDate < @PeriodStart AND ISNULL(Posted, 0) = 0) +
            (SELECT COUNT(*) FROM dbo.GeneralJournal WHERE TransactionDate >= @PreviousPeriodStart AND TransactionDate < @PeriodStart AND ISNULL(Posted, 0) = 0) +
            (SELECT COUNT(*) FROM dbo.PcJournal WHERE TransactionDate >= @PreviousPeriodStart AND TransactionDate < @PeriodStart AND ISNULL(Posted, 0) = 0) +
            (SELECT COUNT(*) FROM dbo.SalesJournal WHERE TransactionDate >= @PreviousPeriodStart AND TransactionDate < @PeriodStart AND ISNULL(Posted, 0) = 0),
            @PreviousMonthUnpostedItems =
            (SELECT COUNT(*) FROM dbo.ApJournalItem i INNER JOIN dbo.ApJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PreviousPeriodStart AND h.TransactionDate < @PeriodStart AND i.Posted = 0) +
            (SELECT COUNT(*) FROM dbo.ArJournalItem i INNER JOIN dbo.ArJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PreviousPeriodStart AND h.TransactionDate < @PeriodStart AND i.Posted = 0) +
            (SELECT COUNT(*) FROM dbo.CdJournalItem i INNER JOIN dbo.CdJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PreviousPeriodStart AND h.TransactionDate < @PeriodStart AND i.Posted = 0) +
            (SELECT COUNT(*) FROM dbo.CkJournalItem i INNER JOIN dbo.CkJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PreviousPeriodStart AND h.TransactionDate < @PeriodStart AND i.Posted = 0) +
            (SELECT COUNT(*) FROM dbo.CashReceiptJournalItem i INNER JOIN dbo.CashReceiptJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PreviousPeriodStart AND h.TransactionDate < @PeriodStart AND i.Posted = 0) +
            (SELECT COUNT(*) FROM dbo.ErJournalItem i INNER JOIN dbo.ErJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PreviousPeriodStart AND h.TransactionDate < @PeriodStart AND i.Posted = 0) +
            (SELECT COUNT(*) FROM dbo.GeneralJournalItem i INNER JOIN dbo.GeneralJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PreviousPeriodStart AND h.TransactionDate < @PeriodStart AND i.Posted = 0) +
            (SELECT COUNT(*) FROM dbo.PcJournalItem i INNER JOIN dbo.PcJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PreviousPeriodStart AND h.TransactionDate < @PeriodStart AND i.Posted = 0) +
            (SELECT COUNT(*) FROM dbo.SalesJournalItem i INNER JOIN dbo.SalesJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @PreviousPeriodStart AND h.TransactionDate < @PeriodStart AND i.Posted = 0);
    END;

    CREATE TABLE #Unbalanced (JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, JournalIdNo int NOT NULL, Debit decimal(19,4) NOT NULL, Credit decimal(19,4) NOT NULL, PRIMARY KEY (JournalCode, JournalIdNo));
    INSERT INTO #Unbalanced (JournalCode, JournalIdNo, Debit, Credit)
    SELECT JournalCode, JournalIdNo, SUM(CONVERT(decimal(19,4), Debit)), SUM(CONVERT(decimal(19,4), Credit))
    FROM #Items WHERE ISNULL(Cancelled, 0) = 0 GROUP BY JournalCode, JournalIdNo
    HAVING ABS(SUM(CONVERT(decimal(19,4), Debit)) - SUM(CONVERT(decimal(19,4), Credit))) > 0.005;

    SET @BlockingErrorCount = (SELECT COUNT(*) FROM #Unbalanced) +
        (SELECT COUNT(*) FROM #Items WHERE ISNULL(Cancelled, 0) = 0 AND (AccountIdNo = 0 OR Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0)));
    SET @HeadersToChange = (SELECT COUNT(*) FROM #Headers WHERE ISNULL(HeaderPosted, 0) = 0);
    SET @ItemsToChange = (SELECT COUNT(*) FROM #Items WHERE ItemPosted = 0);

    SELECT @FiscalYear AS FiscalYear, @Month AS FiscalMonth, @PeriodStart AS PeriodStart, @PeriodEnd AS PeriodEnd,
        @ClosedThrough AS PeriodLockedThrough, @BlockingErrorCount AS BlockingErrors,
        @HeadersToChange AS HeadersToPost, @ItemsToChange AS ItemsToPost,
        CASE WHEN @ExecutePosting = 1 THEN N'EXECUTION VALIDATION' ELSE N'VALIDATION ONLY - NO DATA CHANGED' END AS PostingMode;

    IF @BlockingErrorCount > 0
        THROW 52204, 'Monthly journal posting validation failed. Review the journal data before execution.', 1;

    IF @ExecutePosting = 0
        RETURN;

    SELECT @MonthlyCloseStatus = Status
    FROM dbo.MonthlyClosePeriod
    WHERE FiscalYear = @FiscalYear AND FiscalMonth = @Month;
    IF ISNULL(@MonthlyCloseStatus, 'Open') <> 'Approved'
        THROW 52330, 'The month must be approved through the monthly close checklist before posting can execute.', 1;

    IF @Month > 1 AND (@PreviousMonthUnpostedHeaders > 0 OR @PreviousMonthUnpostedItems > 0)
        THROW 52207, 'The previous month must be fully posted before this month can be executed.', 1;

    IF @ClosedThrough IS NULL OR @ClosedThrough < @PeriodEnd
        THROW 52205, 'The month must be period-locked through its last day before posting can execute.', 1;

    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
        BEGIN TRANSACTION;

        EXEC @LockResult = sys.sp_getapplock @Resource = @LockResource, @LockMode = 'Exclusive', @LockOwner = 'Transaction', @LockTimeout = 30000;
        IF @LockResult < 0 THROW 52206, 'Could not acquire the monthly journal posting lock.', 1;

        CREATE TABLE #PostedChanges (RunId uniqueidentifier NOT NULL, JournalCode char(2) NOT NULL, RecordType char(1) NOT NULL, RecordIdNo int NOT NULL, JournalIdNo int NOT NULL, PreviousPosted bit NULL, NewPosted bit NOT NULL);
        INSERT INTO dbo.FiscalYearJournalPostingRun (RunId, FiscalYear, FiscalYearStart, FiscalYearEnd, Status, StartedAt, ExecutedBy, ServerName, DatabaseName, HeadersChanged, ItemsChanged)
        VALUES (@RunId, @FiscalYear, @PeriodStart, @PeriodEnd, 'Completed', SYSDATETIME(), ORIGINAL_LOGIN(), CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')), DB_NAME(), 0, 0);

        DECLARE @JournalCode char(2), @HeaderTable sysname, @ItemTable sysname, @Sql nvarchar(max);
        DECLARE journal_cursor CURSOR LOCAL FAST_FORWARD FOR
            SELECT JournalCode, HeaderTable, ItemTable FROM (VALUES
                ('AP','ApJournal','ApJournalItem'), ('AR','ArJournal','ArJournalItem'), ('CD','CdJournal','CdJournalItem'),
                ('CK','CkJournal','CkJournalItem'), ('CR','CashReceiptJournal','CashReceiptJournalItem'), ('ER','ErJournal','ErJournalItem'),
                ('GJ','GeneralJournal','GeneralJournalItem'), ('PC','PcJournal','PcJournalItem'), ('SJ','SalesJournal','SalesJournalItem')
            ) v(JournalCode, HeaderTable, ItemTable);
        OPEN journal_cursor;
        FETCH NEXT FROM journal_cursor INTO @JournalCode, @HeaderTable, @ItemTable;
        WHILE @@FETCH_STATUS = 0
        BEGIN
            SET @Sql = N'UPDATE h SET Posted = 1 OUTPUT @RunId, @Code, ''H'', inserted.IdNo, inserted.IdNo, deleted.Posted, inserted.Posted INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted) FROM dbo.' + QUOTENAME(@HeaderTable) + N' h WHERE h.TransactionDate >= @StartDate AND h.TransactionDate < @EndDate AND ISNULL(h.Posted, 0) = 0;';
            EXEC sys.sp_executesql @Sql, N'@RunId uniqueidentifier, @Code char(2), @StartDate date, @EndDate date', @RunId, @JournalCode, @PeriodStart, @PeriodEndExclusive;
            SET @Sql = N'UPDATE i SET Posted = 1 OUTPUT @RunId, @Code, ''I'', inserted.IdNo, inserted.JournalIdNo, deleted.Posted, inserted.Posted INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted) FROM dbo.' + QUOTENAME(@ItemTable) + N' i INNER JOIN dbo.' + QUOTENAME(@HeaderTable) + N' h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @StartDate AND h.TransactionDate < @EndDate AND i.Posted = 0;';
            EXEC sys.sp_executesql @Sql, N'@RunId uniqueidentifier, @Code char(2), @StartDate date, @EndDate date', @RunId, @JournalCode, @PeriodStart, @PeriodEndExclusive;
            FETCH NEXT FROM journal_cursor INTO @JournalCode, @HeaderTable, @ItemTable;
        END;
        CLOSE journal_cursor;
        DEALLOCATE journal_cursor;

        SET @HeadersChanged = (SELECT COUNT(*) FROM #PostedChanges WHERE RecordType = 'H');
        SET @ItemsChanged = (SELECT COUNT(*) FROM #PostedChanges WHERE RecordType = 'I');
        INSERT INTO dbo.FiscalYearJournalPostingChange (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        SELECT RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted FROM #PostedChanges;
        UPDATE dbo.FiscalYearJournalPostingRun SET CompletedAt = SYSDATETIME(), HeadersChanged = @HeadersChanged, ItemsChanged = @ItemsChanged WHERE RunId = @RunId;

        COMMIT TRANSACTION;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        SELECT N'MONTHLY JOURNALS POSTED' AS PostingStatus, @RunId AS RunId, @FiscalYear AS FiscalYear, @Month AS FiscalMonth, @HeadersChanged AS HeadersChanged, @ItemsChanged AS ItemsChanged;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        IF @ExecutePosting = 1 SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        THROW;
    END CATCH;
END;
