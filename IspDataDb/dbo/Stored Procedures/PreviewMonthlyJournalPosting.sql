CREATE OR ALTER PROCEDURE [dbo].[PreviewMonthlyJournalPosting]
    @FiscalYear int,
    @Month int
AS
BEGIN
    SET NOCOUNT ON;

    IF @FiscalYear NOT BETWEEN 2000 AND 2099
        THROW 52101, 'FiscalYear must be between 2000 and 2099.', 1;

    IF @Month NOT BETWEEN 1 AND 12
        THROW 52102, 'Month must be between 1 and 12.', 1;

    DECLARE @PeriodStart date = DATEFROMPARTS(@FiscalYear, @Month, 1);
    DECLARE @PeriodEnd date = DATEADD(month, 1, @PeriodStart);
    DECLARE @ClosedThrough date = (
        SELECT LastPostingDate
        FROM dbo.LastPosting
        WHERE TransactionName = 'Closed Period'
    );
    DECLARE @MonthlyCloseStatus varchar(20) = ISNULL((SELECT Status FROM dbo.MonthlyClosePeriod WHERE FiscalYear = @FiscalYear AND FiscalMonth = @Month), 'Open');

    CREATE TABLE #Headers (
        JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        JournalIdNo int NOT NULL,
        TransactionDate date NOT NULL,
        HeaderPosted bit NULL,
        Cancelled bit NULL,
        PRIMARY KEY (JournalCode, JournalIdNo)
    );

    INSERT INTO #Headers (JournalCode, JournalIdNo, TransactionDate, HeaderPosted, Cancelled)
    SELECT 'AP', IdNo, TransactionDate, Posted, Cancelled FROM dbo.ApJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEnd
    UNION ALL SELECT 'AR', IdNo, TransactionDate, Posted, Cancelled FROM dbo.ArJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEnd
    UNION ALL SELECT 'CD', IdNo, TransactionDate, Posted, Cancelled FROM dbo.CdJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEnd
    UNION ALL SELECT 'CK', IdNo, TransactionDate, Posted, Cancelled FROM dbo.CkJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEnd
    UNION ALL SELECT 'CR', IdNo, TransactionDate, Posted, Cancelled FROM dbo.CashReceiptJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEnd
    UNION ALL SELECT 'ER', IdNo, TransactionDate, Posted, Cancelled FROM dbo.ErJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEnd
    UNION ALL SELECT 'GJ', IdNo, TransactionDate, Posted, Cancelled FROM dbo.GeneralJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEnd
    UNION ALL SELECT 'PC', IdNo, TransactionDate, Posted, Cancelled FROM dbo.PcJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEnd
    UNION ALL SELECT 'SJ', IdNo, TransactionDate, Posted, Cancelled FROM dbo.SalesJournal WHERE TransactionDate >= @PeriodStart AND TransactionDate < @PeriodEnd;

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

    DECLARE @BlockingErrorCount int =
        (SELECT COUNT(*) FROM #Unbalanced) +
        (SELECT COUNT(*) FROM #Items WHERE ISNULL(Cancelled, 0) = 0 AND (AccountIdNo = 0 OR Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0)));

    SELECT
        CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')) AS ServerName,
        DB_NAME() AS DatabaseName,
        @FiscalYear AS FiscalYear,
        @Month AS FiscalMonth,
        @PeriodStart AS PeriodStart,
        DATEADD(day, -1, @PeriodEnd) AS PeriodEnd,
        @ClosedThrough AS PeriodLockedThrough,
        @MonthlyCloseStatus AS MonthlyCloseStatus,
        @BlockingErrorCount AS BlockingErrors,
        (SELECT COUNT(*) FROM #Headers WHERE ISNULL(HeaderPosted, 0) = 0) AS HeadersToPost,
        (SELECT COUNT(*) FROM #Items WHERE ItemPosted = 0) AS ItemsToPost;

    ;WITH ItemHeaders AS (
        SELECT JournalCode, JournalIdNo FROM #Items GROUP BY JournalCode, JournalIdNo
    ), HeaderSummary AS (
        SELECT h.JournalCode, COUNT(*) AS Headers,
            SUM(CASE WHEN ISNULL(h.HeaderPosted, 0) = 0 THEN 1 ELSE 0 END) AS HeadersToPost,
            SUM(CASE WHEN ih.JournalIdNo IS NULL THEN 1 ELSE 0 END) AS EmptyHeaders,
            SUM(CASE WHEN ISNULL(h.Cancelled, 0) = 1 THEN 1 ELSE 0 END) AS CancelledHeaders
        FROM #Headers h LEFT JOIN ItemHeaders ih ON ih.JournalCode = h.JournalCode AND ih.JournalIdNo = h.JournalIdNo
        GROUP BY h.JournalCode
    ), ItemSummary AS (
        SELECT JournalCode, COUNT(*) AS Items,
            SUM(CASE WHEN ItemPosted = 0 THEN 1 ELSE 0 END) AS ItemsToPost,
            SUM(CASE WHEN Debit = 0 AND Credit = 0 THEN 1 ELSE 0 END) AS ZeroAmountItems,
            SUM(Debit) AS Debit, SUM(Credit) AS Credit
        FROM #Items GROUP BY JournalCode
    )
    SELECT h.JournalCode, h.Headers, h.HeadersToPost, h.EmptyHeaders,
        ISNULL(i.Items, 0) AS Items, ISNULL(i.ItemsToPost, 0) AS ItemsToPost,
        ISNULL(i.ZeroAmountItems, 0) AS ZeroAmountItems, h.CancelledHeaders,
        ISNULL(i.Debit, 0) AS Debit, ISNULL(i.Credit, 0) AS Credit
    FROM HeaderSummary h LEFT JOIN ItemSummary i ON i.JournalCode = h.JournalCode
    ORDER BY h.JournalCode;

    SELECT JournalCode, JournalIdNo, Debit, Credit, Debit - Credit AS Difference
    FROM #Unbalanced ORDER BY JournalCode, JournalIdNo;

    SELECT JournalCode, ItemIdNo, JournalIdNo, AccountIdNo, Debit, Credit
    FROM #Items
    WHERE ISNULL(Cancelled, 0) = 0 AND (AccountIdNo = 0 OR Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0))
    ORDER BY JournalCode, JournalIdNo, ItemIdNo;
END;
