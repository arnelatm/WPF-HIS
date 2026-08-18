CREATE PROCEDURE [dbo].[PostFiscalYearJournalEntries]
    @FiscalYear int,
    @ExecutePosting bit = 0
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @FiscalYear NOT BETWEEN 2000 AND 2099
        THROW 52001, 'FiscalYear must be between 2000 and 2099.', 1;

    IF @ExecutePosting NOT IN (0, 1)
        THROW 52002, 'ExecutePosting must be 0 (preview) or 1 (execute).', 1;

    DECLARE @FiscalYearStart date = DATEFROMPARTS(@FiscalYear, 1, 1);
    DECLARE @NextFiscalYearStart date = DATEFROMPARTS(@FiscalYear + 1, 1, 1);
    DECLARE @FiscalYearEnd date = DATEADD(day, -1, @NextFiscalYearStart);
    DECLARE @ClosedThrough date = (
        SELECT LastPostingDate
        FROM dbo.LastPosting
        WHERE TransactionName = 'Closed Period'
    );
    DECLARE @RunId uniqueidentifier = NEWID();
    DECLARE @LockResult int;
    DECLARE @HeadersToChange int;
    DECLARE @ItemsToChange int;
    DECLARE @BlockingErrorCount int;
    DECLARE @HeadersChanged int = 0;
    DECLARE @ItemsChanged int = 0;
    DECLARE @LockResource nvarchar(255) =
        N'ISPDATA:FiscalYearJournalPosting:' + CONVERT(nvarchar(4), @FiscalYear);

    BEGIN TRY
        IF @ExecutePosting = 1
        BEGIN
            SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
            BEGIN TRANSACTION;

            EXEC @LockResult = sys.sp_getapplock
                @Resource = @LockResource,
                @LockMode = 'Exclusive',
                @LockOwner = 'Transaction',
                @LockTimeout = 30000;

            IF @LockResult < 0
                THROW 52003, 'Could not acquire the fiscal-year journal posting lock.', 1;

            IF @ClosedThrough IS NULL OR @ClosedThrough < @FiscalYearEnd
                THROW 52004, 'The fiscal year must be period-locked before journal posting can execute.', 1;
        END;

        CREATE TABLE #Headers (
            JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
            JournalIdNo int NOT NULL,
            TransactionDate date NOT NULL,
            HeaderPosted bit NULL,
            Cancelled bit NULL,
            PRIMARY KEY (JournalCode, JournalIdNo)
        );

        INSERT INTO #Headers (JournalCode, JournalIdNo, TransactionDate, HeaderPosted, Cancelled)
        SELECT 'AP', IdNo, TransactionDate, Posted, Cancelled
        FROM dbo.ApJournal
        WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL
        SELECT 'AR', IdNo, TransactionDate, Posted, Cancelled
        FROM dbo.ArJournal
        WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL
        SELECT 'CD', IdNo, TransactionDate, Posted, Cancelled
        FROM dbo.CdJournal
        WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL
        SELECT 'CK', IdNo, TransactionDate, Posted, Cancelled
        FROM dbo.CkJournal
        WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL
        SELECT 'CR', IdNo, TransactionDate, Posted, Cancelled
        FROM dbo.CashReceiptJournal
        WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL
        SELECT 'ER', IdNo, TransactionDate, Posted, Cancelled
        FROM dbo.ErJournal
        WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL
        SELECT 'GJ', IdNo, TransactionDate, Posted, Cancelled
        FROM dbo.GeneralJournal
        WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL
        SELECT 'PC', IdNo, TransactionDate, Posted, Cancelled
        FROM dbo.PcJournal
        WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL
        SELECT 'SJ', IdNo, TransactionDate, Posted, Cancelled
        FROM dbo.SalesJournal
        WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart;

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
        SELECT 'AP', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled
        FROM dbo.ApJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'AP' AND h.JournalIdNo = i.JournalIdNo
        UNION ALL
        SELECT 'AR', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled
        FROM dbo.ArJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'AR' AND h.JournalIdNo = i.JournalIdNo
        UNION ALL
        SELECT 'CD', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled
        FROM dbo.CdJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'CD' AND h.JournalIdNo = i.JournalIdNo
        UNION ALL
        SELECT 'CK', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled
        FROM dbo.CkJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'CK' AND h.JournalIdNo = i.JournalIdNo
        UNION ALL
        SELECT 'CR', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled
        FROM dbo.CashReceiptJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'CR' AND h.JournalIdNo = i.JournalIdNo
        UNION ALL
        SELECT 'ER', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled
        FROM dbo.ErJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'ER' AND h.JournalIdNo = i.JournalIdNo
        UNION ALL
        SELECT 'GJ', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled
        FROM dbo.GeneralJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'GJ' AND h.JournalIdNo = i.JournalIdNo
        UNION ALL
        SELECT 'PC', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled
        FROM dbo.PcJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'PC' AND h.JournalIdNo = i.JournalIdNo
        UNION ALL
        SELECT 'SJ', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit, h.Cancelled
        FROM dbo.SalesJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'SJ' AND h.JournalIdNo = i.JournalIdNo;

        CREATE TABLE #OrphanSummary (
            JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL PRIMARY KEY,
            OrphanItems int NOT NULL
        );

        INSERT INTO #OrphanSummary (JournalCode, OrphanItems)
        SELECT 'AP', COUNT(*) FROM dbo.ApJournalItem AS i WHERE NOT EXISTS (SELECT 1 FROM dbo.ApJournal AS h WHERE h.IdNo = i.JournalIdNo)
        UNION ALL SELECT 'AR', COUNT(*) FROM dbo.ArJournalItem AS i WHERE NOT EXISTS (SELECT 1 FROM dbo.ArJournal AS h WHERE h.IdNo = i.JournalIdNo)
        UNION ALL SELECT 'CD', COUNT(*) FROM dbo.CdJournalItem AS i WHERE NOT EXISTS (SELECT 1 FROM dbo.CdJournal AS h WHERE h.IdNo = i.JournalIdNo)
        UNION ALL SELECT 'CK', COUNT(*) FROM dbo.CkJournalItem AS i WHERE NOT EXISTS (SELECT 1 FROM dbo.CkJournal AS h WHERE h.IdNo = i.JournalIdNo)
        UNION ALL SELECT 'CR', COUNT(*) FROM dbo.CashReceiptJournalItem AS i WHERE NOT EXISTS (SELECT 1 FROM dbo.CashReceiptJournal AS h WHERE h.IdNo = i.JournalIdNo)
        UNION ALL SELECT 'ER', COUNT(*) FROM dbo.ErJournalItem AS i WHERE NOT EXISTS (SELECT 1 FROM dbo.ErJournal AS h WHERE h.IdNo = i.JournalIdNo)
        UNION ALL SELECT 'GJ', COUNT(*) FROM dbo.GeneralJournalItem AS i WHERE NOT EXISTS (SELECT 1 FROM dbo.GeneralJournal AS h WHERE h.IdNo = i.JournalIdNo)
        UNION ALL SELECT 'PC', COUNT(*) FROM dbo.PcJournalItem AS i WHERE NOT EXISTS (SELECT 1 FROM dbo.PcJournal AS h WHERE h.IdNo = i.JournalIdNo)
        UNION ALL SELECT 'SJ', COUNT(*) FROM dbo.SalesJournalItem AS i WHERE NOT EXISTS (SELECT 1 FROM dbo.SalesJournal AS h WHERE h.IdNo = i.JournalIdNo);

        CREATE TABLE #Unbalanced (
            JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
            JournalIdNo int NOT NULL,
            Debit decimal(19, 4) NOT NULL,
            Credit decimal(19, 4) NOT NULL,
            PRIMARY KEY (JournalCode, JournalIdNo)
        );

        INSERT INTO #Unbalanced (JournalCode, JournalIdNo, Debit, Credit)
        SELECT JournalCode, JournalIdNo, SUM(CONVERT(decimal(19, 4), Debit)), SUM(CONVERT(decimal(19, 4), Credit))
        FROM #Items
        WHERE ISNULL(Cancelled, 0) = 0
        GROUP BY JournalCode, JournalIdNo
        HAVING ABS(SUM(CONVERT(decimal(19, 4), Debit)) - SUM(CONVERT(decimal(19, 4), Credit))) > 0.005;

        SET @BlockingErrorCount =
            (SELECT COUNT(*) FROM #Unbalanced) +
            (SELECT COUNT(*)
             FROM #Items
             WHERE ISNULL(Cancelled, 0) = 0
               AND (AccountIdNo = 0 OR Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0)));

        SET @HeadersToChange = (SELECT COUNT(*) FROM #Headers WHERE ISNULL(HeaderPosted, 0) = 0);
        SET @ItemsToChange = (SELECT COUNT(*) FROM #Items WHERE ItemPosted = 0);

        SELECT
            CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')) AS ServerName,
            DB_NAME() AS DatabaseName,
            @FiscalYear AS FiscalYear,
            @FiscalYearStart AS FiscalYearStart,
            @FiscalYearEnd AS FiscalYearEnd,
            @ClosedThrough AS PeriodLockedThrough,
            CASE WHEN @ExecutePosting = 0 THEN N'PREVIEW - NO DATA CHANGED' ELSE N'EXECUTION VALIDATION' END AS PostingMode,
            @BlockingErrorCount AS BlockingErrors,
            @HeadersToChange AS HeadersToPost,
            @ItemsToChange AS ItemsToPost;

        ;WITH ItemHeaders AS (
            SELECT i.JournalCode, i.JournalIdNo
            FROM #Items AS i
            GROUP BY i.JournalCode, i.JournalIdNo
        ),
        HeaderSummary AS (
            SELECT
                h.JournalCode,
                COUNT(*) AS Headers,
                SUM(CASE WHEN ISNULL(h.HeaderPosted, 0) = 0 THEN 1 ELSE 0 END) AS HeadersToPost,
                SUM(CASE WHEN ih.JournalIdNo IS NULL THEN 1 ELSE 0 END) AS EmptyHeaders,
                SUM(CASE WHEN ISNULL(h.Cancelled, 0) = 1 THEN 1 ELSE 0 END) AS CancelledHeaders
            FROM #Headers AS h
            LEFT JOIN ItemHeaders AS ih
                ON ih.JournalCode = h.JournalCode
               AND ih.JournalIdNo = h.JournalIdNo
            GROUP BY h.JournalCode
        ),
        ItemSummary AS (
            SELECT
                i.JournalCode,
                COUNT(*) AS Items,
                SUM(CASE WHEN i.ItemPosted = 0 THEN 1 ELSE 0 END) AS ItemsToPost,
                SUM(CASE WHEN i.Debit = 0 AND i.Credit = 0 THEN 1 ELSE 0 END) AS ZeroAmountItems,
                SUM(i.Debit) AS Debit,
                SUM(i.Credit) AS Credit
            FROM #Items AS i
            GROUP BY i.JournalCode
        )
        SELECT
            h.JournalCode,
            h.Headers,
            h.HeadersToPost,
            h.EmptyHeaders,
            ISNULL(i.Items, 0) AS Items,
            ISNULL(i.ItemsToPost, 0) AS ItemsToPost,
            ISNULL(i.ZeroAmountItems, 0) AS ZeroAmountItems,
            h.CancelledHeaders,
            ISNULL(i.Debit, 0) AS Debit,
            ISNULL(i.Credit, 0) AS Credit
        FROM HeaderSummary AS h
        LEFT JOIN ItemSummary AS i ON i.JournalCode = h.JournalCode
        ORDER BY h.JournalCode;

        SELECT JournalCode, OrphanItems
        FROM #OrphanSummary
        WHERE OrphanItems > 0
        ORDER BY JournalCode;

        SELECT JournalCode, JournalIdNo, Debit, Credit, Debit - Credit AS Difference
        FROM #Unbalanced
        ORDER BY JournalCode, JournalIdNo;

        SELECT JournalCode, ItemIdNo, JournalIdNo, AccountIdNo, Debit, Credit
        FROM #Items
        WHERE ISNULL(Cancelled, 0) = 0
          AND (AccountIdNo = 0 OR Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0))
        ORDER BY JournalCode, JournalIdNo, ItemIdNo;

        IF @BlockingErrorCount > 0
            THROW 52005, 'Fiscal-year journal posting validation failed. Review the blocking result sets.', 1;

        IF @ExecutePosting = 0
            RETURN;

        IF @HeadersToChange = 0 AND @ItemsToChange = 0
        BEGIN
            COMMIT TRANSACTION;
            SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

            SELECT N'ALREADY POSTED - NO DATA CHANGED' AS PostingStatus, @FiscalYear AS FiscalYear;
            RETURN;
        END;

        CREATE TABLE #PostedChanges (
            RunId uniqueidentifier NOT NULL,
            JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
            RecordType char(1) NOT NULL,
            RecordIdNo int NOT NULL,
            JournalIdNo int NOT NULL,
            PreviousPosted bit NULL,
            NewPosted bit NOT NULL
        );

        INSERT INTO dbo.FiscalYearJournalPostingRun (
            RunId, FiscalYear, FiscalYearStart, FiscalYearEnd, Status,
            StartedAt, CompletedAt, ExecutedBy, ServerName, DatabaseName,
            HeadersChanged, ItemsChanged
        )
        VALUES (
            @RunId, @FiscalYear, @FiscalYearStart, @FiscalYearEnd, 'Completed',
            SYSDATETIME(), NULL, ORIGINAL_LOGIN(),
            CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')), DB_NAME(),
            0, 0
        );

        UPDATE h SET Posted = 1
        OUTPUT @RunId, 'AP', 'H', inserted.IdNo, inserted.IdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.ApJournal AS h WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND ISNULL(h.Posted, 0) = 0;
        SET @HeadersChanged += @@ROWCOUNT;
        UPDATE h SET Posted = 1
        OUTPUT @RunId, 'AR', 'H', inserted.IdNo, inserted.IdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.ArJournal AS h WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND ISNULL(h.Posted, 0) = 0;
        SET @HeadersChanged += @@ROWCOUNT;
        UPDATE h SET Posted = 1
        OUTPUT @RunId, 'CD', 'H', inserted.IdNo, inserted.IdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.CdJournal AS h WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND ISNULL(h.Posted, 0) = 0;
        SET @HeadersChanged += @@ROWCOUNT;
        UPDATE h SET Posted = 1
        OUTPUT @RunId, 'CK', 'H', inserted.IdNo, inserted.IdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.CkJournal AS h WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND ISNULL(h.Posted, 0) = 0;
        SET @HeadersChanged += @@ROWCOUNT;
        UPDATE h SET Posted = 1
        OUTPUT @RunId, 'CR', 'H', inserted.IdNo, inserted.IdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.CashReceiptJournal AS h WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND ISNULL(h.Posted, 0) = 0;
        SET @HeadersChanged += @@ROWCOUNT;
        UPDATE h SET Posted = 1
        OUTPUT @RunId, 'ER', 'H', inserted.IdNo, inserted.IdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.ErJournal AS h WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND ISNULL(h.Posted, 0) = 0;
        SET @HeadersChanged += @@ROWCOUNT;
        UPDATE h SET Posted = 1
        OUTPUT @RunId, 'GJ', 'H', inserted.IdNo, inserted.IdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.GeneralJournal AS h WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND ISNULL(h.Posted, 0) = 0;
        SET @HeadersChanged += @@ROWCOUNT;
        UPDATE h SET Posted = 1
        OUTPUT @RunId, 'PC', 'H', inserted.IdNo, inserted.IdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.PcJournal AS h WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND ISNULL(h.Posted, 0) = 0;
        SET @HeadersChanged += @@ROWCOUNT;
        UPDATE h SET Posted = 1
        OUTPUT @RunId, 'SJ', 'H', inserted.IdNo, inserted.IdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.SalesJournal AS h WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND ISNULL(h.Posted, 0) = 0;
        SET @HeadersChanged += @@ROWCOUNT;

        UPDATE i SET Posted = 1
        OUTPUT @RunId, 'AP', 'I', inserted.IdNo, inserted.JournalIdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.ApJournalItem AS i INNER JOIN dbo.ApJournal AS h ON h.IdNo = i.JournalIdNo
        WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0;
        SET @ItemsChanged += @@ROWCOUNT;
        UPDATE i SET Posted = 1
        OUTPUT @RunId, 'AR', 'I', inserted.IdNo, inserted.JournalIdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.ArJournalItem AS i INNER JOIN dbo.ArJournal AS h ON h.IdNo = i.JournalIdNo
        WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0;
        SET @ItemsChanged += @@ROWCOUNT;
        UPDATE i SET Posted = 1
        OUTPUT @RunId, 'CD', 'I', inserted.IdNo, inserted.JournalIdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.CdJournalItem AS i INNER JOIN dbo.CdJournal AS h ON h.IdNo = i.JournalIdNo
        WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0;
        SET @ItemsChanged += @@ROWCOUNT;
        UPDATE i SET Posted = 1
        OUTPUT @RunId, 'CK', 'I', inserted.IdNo, inserted.JournalIdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.CkJournalItem AS i INNER JOIN dbo.CkJournal AS h ON h.IdNo = i.JournalIdNo
        WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0;
        SET @ItemsChanged += @@ROWCOUNT;
        UPDATE i SET Posted = 1
        OUTPUT @RunId, 'CR', 'I', inserted.IdNo, inserted.JournalIdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.CashReceiptJournalItem AS i INNER JOIN dbo.CashReceiptJournal AS h ON h.IdNo = i.JournalIdNo
        WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0;
        SET @ItemsChanged += @@ROWCOUNT;
        UPDATE i SET Posted = 1
        OUTPUT @RunId, 'ER', 'I', inserted.IdNo, inserted.JournalIdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.ErJournalItem AS i INNER JOIN dbo.ErJournal AS h ON h.IdNo = i.JournalIdNo
        WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0;
        SET @ItemsChanged += @@ROWCOUNT;
        UPDATE i SET Posted = 1
        OUTPUT @RunId, 'GJ', 'I', inserted.IdNo, inserted.JournalIdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.GeneralJournalItem AS i INNER JOIN dbo.GeneralJournal AS h ON h.IdNo = i.JournalIdNo
        WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0;
        SET @ItemsChanged += @@ROWCOUNT;
        UPDATE i SET Posted = 1
        OUTPUT @RunId, 'PC', 'I', inserted.IdNo, inserted.JournalIdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.PcJournalItem AS i INNER JOIN dbo.PcJournal AS h ON h.IdNo = i.JournalIdNo
        WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0;
        SET @ItemsChanged += @@ROWCOUNT;
        UPDATE i SET Posted = 1
        OUTPUT @RunId, 'SJ', 'I', inserted.IdNo, inserted.JournalIdNo, deleted.Posted, inserted.Posted
            INTO #PostedChanges (RunId, JournalCode, RecordType, RecordIdNo, JournalIdNo, PreviousPosted, NewPosted)
        FROM dbo.SalesJournalItem AS i INNER JOIN dbo.SalesJournal AS h ON h.IdNo = i.JournalIdNo
        WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0;
        SET @ItemsChanged += @@ROWCOUNT;

        INSERT INTO dbo.FiscalYearJournalPostingChange (
            RunId, JournalCode, RecordType, RecordIdNo,
            JournalIdNo, PreviousPosted, NewPosted
        )
        SELECT
            RunId, JournalCode, RecordType, RecordIdNo,
            JournalIdNo, PreviousPosted, NewPosted
        FROM #PostedChanges;

        IF @HeadersChanged <> @HeadersToChange OR @ItemsChanged <> @ItemsToChange
            THROW 52006, 'Posted row counts changed between validation and execution.', 1;

        IF EXISTS (
            SELECT 1 FROM dbo.ApJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart AND ISNULL(Posted, 0) = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.ArJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart AND ISNULL(Posted, 0) = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.CdJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart AND ISNULL(Posted, 0) = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.CkJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart AND ISNULL(Posted, 0) = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.CashReceiptJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart AND ISNULL(Posted, 0) = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.ErJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart AND ISNULL(Posted, 0) = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.GeneralJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart AND ISNULL(Posted, 0) = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.PcJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart AND ISNULL(Posted, 0) = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.SalesJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart AND ISNULL(Posted, 0) = 0
        )
            THROW 52007, 'Header posting verification failed.', 1;

        IF EXISTS (
            SELECT 1 FROM dbo.ApJournalItem AS i INNER JOIN dbo.ApJournal AS h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.ArJournalItem AS i INNER JOIN dbo.ArJournal AS h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.CdJournalItem AS i INNER JOIN dbo.CdJournal AS h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.CkJournalItem AS i INNER JOIN dbo.CkJournal AS h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.CashReceiptJournalItem AS i INNER JOIN dbo.CashReceiptJournal AS h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.ErJournalItem AS i INNER JOIN dbo.ErJournal AS h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.GeneralJournalItem AS i INNER JOIN dbo.GeneralJournal AS h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.PcJournalItem AS i INNER JOIN dbo.PcJournal AS h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0
        ) OR EXISTS (
            SELECT 1 FROM dbo.SalesJournalItem AS i INNER JOIN dbo.SalesJournal AS h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @FiscalYearStart AND h.TransactionDate < @NextFiscalYearStart AND i.Posted = 0
        )
            THROW 52008, 'Journal item posting verification failed.', 1;

        IF (SELECT COUNT(*) FROM dbo.FiscalYearJournalPostingChange WHERE RunId = @RunId AND RecordType = 'H') <> @HeadersChanged
           OR (SELECT COUNT(*) FROM dbo.FiscalYearJournalPostingChange WHERE RunId = @RunId AND RecordType = 'I') <> @ItemsChanged
            THROW 52009, 'Posting audit row counts do not match the changed row counts.', 1;

        UPDATE dbo.FiscalYearJournalPostingRun
        SET CompletedAt = SYSDATETIME(),
            HeadersChanged = @HeadersChanged,
            ItemsChanged = @ItemsChanged
        WHERE RunId = @RunId;

        COMMIT TRANSACTION;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

        SELECT
            N'FISCAL-YEAR JOURNALS POSTED' AS PostingStatus,
            @RunId AS RunId,
            @FiscalYear AS FiscalYear,
            @HeadersChanged AS HeadersChanged,
            @ItemsChanged AS ItemsChanged;

        SELECT JournalCode, RecordType, COUNT(*) AS RecordsChanged
        FROM dbo.FiscalYearJournalPostingChange
        WHERE RunId = @RunId
        GROUP BY JournalCode, RecordType
        ORDER BY JournalCode, RecordType;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        IF @ExecutePosting = 1
            SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

        THROW;
    END CATCH;
END;
