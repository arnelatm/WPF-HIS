CREATE PROCEDURE [dbo].[UnpostMonthlyJournalEntries]
    @FiscalYear int,
    @FiscalMonth int,
    @ApplicationUser sysname
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @FiscalYear NOT BETWEEN 2000 AND 2099
        THROW 52350, 'FiscalYear must be between 2000 and 2099.', 1;
    IF @FiscalMonth NOT BETWEEN 1 AND 12
        THROW 52351, 'Month must be between 1 and 12.', 1;
    IF NULLIF(LTRIM(RTRIM(@ApplicationUser)), '') IS NULL
        THROW 52352, 'ApplicationUser is required.', 1;

    DECLARE @PeriodStart date = DATEFROMPARTS(@FiscalYear, @FiscalMonth, 1);
    DECLARE @PeriodEndExclusive date = DATEADD(month, 1, @PeriodStart);
    DECLARE @PeriodEnd date = DATEADD(day, -1, @PeriodEndExclusive);
    DECLARE @ClosedThrough date;
    DECLARE @LastFiscalYearEnd date;
    DECLARE @LatestPostedPeriodEnd date;
    DECLARE @RunCount int;
    DECLARE @HeadersChanged int = 0;
    DECLARE @ItemsChanged int = 0;
    DECLARE @Expected int;
    DECLARE @Actual int;
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
            THROW 52353, 'Could not acquire the monthly close lock.', 1;

        EXEC @MonthlyLockResult = sys.sp_getapplock
            @Resource = @MonthlyLockResource,
            @LockMode = 'Exclusive',
            @LockOwner = 'Transaction',
            @LockTimeout = 30000;
        IF @MonthlyLockResult < 0
            THROW 52354, 'Could not acquire the monthly journal posting lock.', 1;

        SELECT @ClosedThrough = LastPostingDate
        FROM dbo.LastPosting WITH (UPDLOCK, HOLDLOCK)
        WHERE TransactionName = 'Closed Period';

        SELECT @LastFiscalYearEnd = LastPostingDate
        FROM dbo.LastPosting WITH (UPDLOCK, HOLDLOCK)
        WHERE TransactionName = 'LastFiscalYearEnd';

        IF @LastFiscalYearEnd IS NOT NULL AND @PeriodEnd <= @LastFiscalYearEnd
            THROW 52460, 'A finalized fiscal year cannot be unposted.', 1;

        IF @ClosedThrough <> @PeriodEnd
            THROW 52355, 'Only the latest closed month can be unposted.', 1;

        IF NOT EXISTS (
            SELECT 1
            FROM dbo.MonthlyClosePeriod WITH (UPDLOCK, HOLDLOCK)
            WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth AND Status = 'Closed'
        )
            THROW 52356, 'The selected month is not closed.', 1;

        SELECT @LatestPostedPeriodEnd = MAX(FiscalYearEnd)
        FROM dbo.FiscalYearJournalPostingRun WITH (UPDLOCK, HOLDLOCK)
        WHERE Status = 'Completed'
          AND FiscalYearStart = DATEFROMPARTS(YEAR(FiscalYearStart), MONTH(FiscalYearStart), 1)
          AND FiscalYearEnd = DATEADD(day, -1, DATEADD(month, 1, FiscalYearStart))
          AND (HeadersChanged > 0 OR ItemsChanged > 0);

        IF @LatestPostedPeriodEnd IS NULL
            THROW 52357, 'There is no completed monthly posting to reverse.', 1;
        IF @LatestPostedPeriodEnd <> @PeriodEnd
            THROW 52358, 'Only the latest posted month can be unposted.', 1;

        CREATE TABLE #Runs (
            RunId uniqueidentifier NOT NULL PRIMARY KEY,
            IdNo bigint NOT NULL
        );

        INSERT INTO #Runs (RunId, IdNo)
        SELECT RunId, IdNo
        FROM dbo.FiscalYearJournalPostingRun
        WHERE Status = 'Completed'
          AND FiscalYearStart = @PeriodStart
          AND FiscalYearEnd = @PeriodEnd
          AND (HeadersChanged > 0 OR ItemsChanged > 0);

        SET @RunCount = @@ROWCOUNT;
        IF @RunCount = 0
            THROW 52359, 'No active posting audit run exists for the selected month.', 1;

        CREATE TABLE #RestoreChanges (
            JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
            RecordType char(1) NOT NULL,
            RecordIdNo int NOT NULL,
            PreviousPosted bit NULL,
            PRIMARY KEY (JournalCode, RecordType, RecordIdNo)
        );

        ;WITH RankedChanges AS (
            SELECT c.JournalCode,
                c.RecordType,
                c.RecordIdNo,
                c.PreviousPosted,
                ROW_NUMBER() OVER (PARTITION BY c.JournalCode, c.RecordType, c.RecordIdNo ORDER BY r.IdNo) AS SequenceNo
            FROM dbo.FiscalYearJournalPostingChange c
            INNER JOIN #Runs r ON r.RunId = c.RunId
        )
        INSERT INTO #RestoreChanges (JournalCode, RecordType, RecordIdNo, PreviousPosted)
        SELECT JournalCode, RecordType, RecordIdNo, PreviousPosted
        FROM RankedChanges
        WHERE SequenceNo = 1;

        IF NOT EXISTS (SELECT 1 FROM #RestoreChanges)
            THROW 52360, 'The posting audit contains no journal changes to reverse.', 1;

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
            SELECT @Expected = COUNT(*) FROM #RestoreChanges WHERE JournalCode = @JournalCode AND RecordType = 'I';
            SET @Sql = N'SELECT @Actual = COUNT(*) FROM dbo.' + QUOTENAME(@ItemTable) + N' i INNER JOIN #RestoreChanges r ON r.JournalCode = @Code AND r.RecordType = ''I'' AND r.RecordIdNo = i.IdNo WHERE i.Posted = 1;';
            EXEC sys.sp_executesql @Sql, N'@Code char(2), @Actual int OUTPUT', @JournalCode, @Actual OUTPUT;
            IF @Actual <> @Expected
                THROW 52361, 'Unpost stopped because posted item data no longer matches its posting audit.', 1;

            SELECT @Expected = COUNT(*) FROM #RestoreChanges WHERE JournalCode = @JournalCode AND RecordType = 'H';
            SET @Sql = N'SELECT @Actual = COUNT(*) FROM dbo.' + QUOTENAME(@HeaderTable) + N' h INNER JOIN #RestoreChanges r ON r.JournalCode = @Code AND r.RecordType = ''H'' AND r.RecordIdNo = h.IdNo WHERE ISNULL(h.Posted, 0) = 1;';
            EXEC sys.sp_executesql @Sql, N'@Code char(2), @Actual int OUTPUT', @JournalCode, @Actual OUTPUT;
            IF @Actual <> @Expected
                THROW 52362, 'Unpost stopped because posted header data no longer matches its posting audit.', 1;

            FETCH NEXT FROM journal_cursor INTO @JournalCode, @HeaderTable, @ItemTable;
        END;
        CLOSE journal_cursor;
        DEALLOCATE journal_cursor;

        DECLARE journal_update_cursor CURSOR LOCAL FAST_FORWARD FOR
            SELECT JournalCode, HeaderTable, ItemTable FROM (VALUES
                ('AP','ApJournal','ApJournalItem'), ('AR','ArJournal','ArJournalItem'), ('CD','CdJournal','CdJournalItem'),
                ('CK','CkJournal','CkJournalItem'), ('CR','CashReceiptJournal','CashReceiptJournalItem'), ('ER','ErJournal','ErJournalItem'),
                ('GJ','GeneralJournal','GeneralJournalItem'), ('PC','PcJournal','PcJournalItem'), ('SJ','SalesJournal','SalesJournalItem')
            ) v(JournalCode, HeaderTable, ItemTable);

        OPEN journal_update_cursor;
        FETCH NEXT FROM journal_update_cursor INTO @JournalCode, @HeaderTable, @ItemTable;
        WHILE @@FETCH_STATUS = 0
        BEGIN
            SET @Sql = N'UPDATE i SET Posted = ISNULL(r.PreviousPosted, 0) FROM dbo.' + QUOTENAME(@ItemTable) + N' i INNER JOIN #RestoreChanges r ON r.JournalCode = @Code AND r.RecordType = ''I'' AND r.RecordIdNo = i.IdNo; SELECT @Changed = @@ROWCOUNT;';
            EXEC sys.sp_executesql @Sql, N'@Code char(2), @Changed int OUTPUT', @JournalCode, @Actual OUTPUT;
            SET @ItemsChanged += @Actual;

            SET @Sql = N'UPDATE h SET Posted = r.PreviousPosted FROM dbo.' + QUOTENAME(@HeaderTable) + N' h INNER JOIN #RestoreChanges r ON r.JournalCode = @Code AND r.RecordType = ''H'' AND r.RecordIdNo = h.IdNo; SELECT @Changed = @@ROWCOUNT;';
            EXEC sys.sp_executesql @Sql, N'@Code char(2), @Changed int OUTPUT', @JournalCode, @Actual OUTPUT;
            SET @HeadersChanged += @Actual;

            FETCH NEXT FROM journal_update_cursor INTO @JournalCode, @HeaderTable, @ItemTable;
        END;
        CLOSE journal_update_cursor;
        DEALLOCATE journal_update_cursor;

        UPDATE r
        SET Status = 'Reversed',
            ReversedAt = SYSDATETIME(),
            ReversedBy = @ApplicationUser
        FROM dbo.FiscalYearJournalPostingRun r
        INNER JOIN #Runs x ON x.RunId = r.RunId;

        COMMIT TRANSACTION;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

        SELECT N'MONTHLY JOURNALS UNPOSTED' AS ReversalStatus,
            @FiscalYear AS FiscalYear,
            @FiscalMonth AS FiscalMonth,
            @RunCount AS PostingRunsReversed,
            @HeadersChanged AS HeadersChanged,
            @ItemsChanged AS ItemsChanged,
            @ApplicationUser AS ReversedBy;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        THROW;
    END CATCH;
END;
