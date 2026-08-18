CREATE PROCEDURE [dbo].[PreviewFiscalYearClose]
    @FiscalYear int,
    @IncomeSummaryAccountIdNo smallint = NULL,
    @RetainedEarningsAccountIdNo smallint = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @FiscalYear NOT BETWEEN 2000 AND 2099
        THROW 52101, 'FiscalYear must be between 2000 and 2099.', 1;

    DECLARE @Tolerance decimal(19, 4) = 0.005;
    DECLARE @FiscalYearStart date = DATEFROMPARTS(@FiscalYear, 1, 1);
    DECLARE @NextFiscalYearStart date = DATEFROMPARTS(@FiscalYear + 1, 1, 1);
    DECLARE @FiscalYearEnd date = DATEADD(day, -1, @NextFiscalYearStart);
    DECLARE @ExpectedPreviousClose date = DATEADD(day, -1, @FiscalYearStart);
    DECLARE @ClosedThrough date;
    DECLARE @LastFiscalYearEnd date;
    DECLARE @ClosedPeriodRows int;
    DECLARE @LastFiscalYearEndRows int;
    DECLARE @IncomeSummaryMatches int;
    DECLARE @RetainedEarningsMatches int;
    DECLARE @UnpostedHeaders int;
    DECLARE @UnpostedItems int;
    DECLARE @InvalidItems int;
    DECLARE @UnbalancedJournals int;
    DECLARE @ExistingClosingJournals int;
    DECLARE @OpeningRows int;
    DECLARE @TargetOpeningRows int;
    DECLARE @UnexpectedOpeningRows int;
    DECLARE @InvalidOpeningRows int;
    DECLARE @NextYearActivityLines int;
    DECLARE @PeriodDebit decimal(19, 4);
    DECLARE @PeriodCredit decimal(19, 4);
    DECLARE @OpeningDebit decimal(19, 4);
    DECLARE @OpeningCredit decimal(19, 4);
    DECLARE @IncomeSummaryExistingNet decimal(19, 4);
    DECLARE @ProfitLossNet decimal(19, 4);
    DECLARE @BlockingErrors int;
    DECLARE @ReviewWarnings int;

    SELECT
        @ClosedPeriodRows = COUNT(*),
        @ClosedThrough = MAX(LastPostingDate)
    FROM dbo.LastPosting
    WHERE TransactionName = 'Closed Period';

    SELECT
        @LastFiscalYearEndRows = COUNT(*),
        @LastFiscalYearEnd = MAX(LastPostingDate)
    FROM dbo.LastPosting
    WHERE TransactionName = 'LastFiscalYearEnd';

    CREATE TABLE #ValidationIssue (
        Severity varchar(10) NOT NULL,
        IssueCode varchar(50) NOT NULL,
        AffectedRecords int NULL,
        Details nvarchar(500) NOT NULL
    );

    IF @ClosedPeriodRows <> 1
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'CLOSED_PERIOD_CONTROL_INVALID', @ClosedPeriodRows,
             N'LastPosting must contain exactly one Closed Period control row.');
    ELSE IF @ClosedThrough IS NULL OR @ClosedThrough < @FiscalYearEnd
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'FISCAL_PERIOD_NOT_LOCKED', 1,
             N'The fiscal year must be locked through its final date before it can be closed.');

    IF @LastFiscalYearEndRows <> 1
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'LAST_FISCAL_YEAR_CONTROL_INVALID', @LastFiscalYearEndRows,
             N'LastPosting must contain exactly one LastFiscalYearEnd control row.');
    ELSE IF @LastFiscalYearEnd <> @ExpectedPreviousClose
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'FISCAL_YEAR_SEQUENCE_INVALID', 1,
             N'LastFiscalYearEnd must equal the day before the requested fiscal year starts.');

    IF @IncomeSummaryAccountIdNo IS NULL
    BEGIN
        SELECT
            @IncomeSummaryMatches = COUNT(*),
            @IncomeSummaryAccountIdNo = MIN(IdNo)
        FROM dbo.Account
        WHERE AccountCode = '599';

        IF @IncomeSummaryMatches <> 1
            INSERT INTO #ValidationIssue VALUES
                ('BLOCKER', 'INCOME_SUMMARY_NOT_RESOLVED', @IncomeSummaryMatches,
                 N'Pass IncomeSummaryAccountIdNo explicitly; account code 599 was not unique.');
    END;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Account
        WHERE IdNo = @IncomeSummaryAccountIdNo
          AND DetailAccount = 1
          AND AccountGroup IN ('R', 'X')
          AND Active = 1
    )
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'INCOME_SUMMARY_ACCOUNT_INVALID', 1,
             N'Income Summary must be an active detail revenue/expense account.');

    IF @RetainedEarningsAccountIdNo IS NULL
    BEGIN
        SELECT
            @RetainedEarningsMatches = COUNT(*),
            @RetainedEarningsAccountIdNo = MIN(IdNo)
        FROM dbo.Account
        WHERE SpecialAccount = 'RE';

        IF @RetainedEarningsMatches <> 1
            INSERT INTO #ValidationIssue VALUES
                ('BLOCKER', 'RETAINED_EARNINGS_NOT_RESOLVED', @RetainedEarningsMatches,
                 N'Pass RetainedEarningsAccountIdNo explicitly; the RE special account was not unique.');
    END;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Account
        WHERE IdNo = @RetainedEarningsAccountIdNo
          AND DetailAccount = 1
          AND AccountGroup = 'E'
          AND SpecialAccount = 'RE'
          AND Active = 1
    )
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'RETAINED_EARNINGS_ACCOUNT_INVALID', 1,
             N'Retained Earnings must be the active detail equity account marked RE.');

    CREATE TABLE #Headers (
        JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        JournalIdNo int NOT NULL,
        TransactionDate date NOT NULL,
        HeaderPosted bit NULL,
        Cancelled bit NULL,
        ClosingJournal bit NULL,
        PRIMARY KEY (JournalCode, JournalIdNo)
    );

    INSERT INTO #Headers (
        JournalCode, JournalIdNo, TransactionDate,
        HeaderPosted, Cancelled, ClosingJournal
    )
    SELECT 'AP', IdNo, TransactionDate, Posted, Cancelled, 0
    FROM dbo.ApJournal
    WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
    UNION ALL
    SELECT 'AR', IdNo, TransactionDate, Posted, Cancelled, 0
    FROM dbo.ArJournal
    WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
    UNION ALL
    SELECT 'CD', IdNo, TransactionDate, Posted, Cancelled, 0
    FROM dbo.CdJournal
    WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
    UNION ALL
    SELECT 'CK', IdNo, TransactionDate, Posted, Cancelled, 0
    FROM dbo.CkJournal
    WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
    UNION ALL
    SELECT 'CR', IdNo, TransactionDate, Posted, Cancelled, 0
    FROM dbo.CashReceiptJournal
    WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
    UNION ALL
    SELECT 'ER', IdNo, TransactionDate, Posted, Cancelled, 0
    FROM dbo.ErJournal
    WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
    UNION ALL
    SELECT 'GJ', IdNo, TransactionDate, Posted, Cancelled, ClosingJournal
    FROM dbo.GeneralJournal
    WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
    UNION ALL
    SELECT 'PC', IdNo, TransactionDate, Posted, Cancelled, 0
    FROM dbo.PcJournal
    WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
    UNION ALL
    SELECT 'SJ', IdNo, TransactionDate, Posted, Cancelled, 0
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
        PRIMARY KEY (JournalCode, ItemIdNo)
    );

    INSERT INTO #Items (
        JournalCode, ItemIdNo, JournalIdNo,
        AccountIdNo, ItemPosted, Debit, Credit
    )
    SELECT 'AP', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit
    FROM dbo.ApJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'AP' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL
    SELECT 'AR', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit
    FROM dbo.ArJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'AR' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL
    SELECT 'CD', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit
    FROM dbo.CdJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'CD' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL
    SELECT 'CK', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit
    FROM dbo.CkJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'CK' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL
    SELECT 'CR', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit
    FROM dbo.CashReceiptJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'CR' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL
    SELECT 'ER', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit
    FROM dbo.ErJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'ER' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL
    SELECT 'GJ', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit
    FROM dbo.GeneralJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'GJ' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL
    SELECT 'PC', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit
    FROM dbo.PcJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'PC' AND h.JournalIdNo = i.JournalIdNo
    UNION ALL
    SELECT 'SJ', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit
    FROM dbo.SalesJournalItem AS i INNER JOIN #Headers AS h ON h.JournalCode = 'SJ' AND h.JournalIdNo = i.JournalIdNo;

    SELECT @UnpostedHeaders = COUNT(*)
    FROM #Headers
    WHERE ISNULL(HeaderPosted, 0) = 0;

    IF @UnpostedHeaders > 0
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'UNPOSTED_JOURNAL_HEADERS', @UnpostedHeaders,
             N'Run PostFiscalYearJournalEntries successfully before fiscal close.');

    SELECT @UnpostedItems = COUNT(*)
    FROM #Items
    WHERE ItemPosted = 0;

    IF @UnpostedItems > 0
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'UNPOSTED_JOURNAL_ITEMS', @UnpostedItems,
             N'Run PostFiscalYearJournalEntries successfully before fiscal close.');

    SELECT @InvalidItems = COUNT(*)
    FROM #Items AS i
    INNER JOIN #Headers AS h
        ON h.JournalCode = i.JournalCode
       AND h.JournalIdNo = i.JournalIdNo
    LEFT JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
    WHERE ISNULL(h.Cancelled, 0) = 0
      AND (
          a.IdNo IS NULL
          OR ISNULL(a.DetailAccount, 0) = 0
          OR i.Debit < 0
          OR i.Credit < 0
          OR (i.Debit <> 0 AND i.Credit <> 0)
      );

    IF @InvalidItems > 0
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'INVALID_JOURNAL_ITEMS', @InvalidItems,
             N'Non-cancelled items must use valid detail accounts and one non-negative debit or credit amount.');

    ;WITH JournalTotals AS (
        SELECT
            i.JournalCode,
            i.JournalIdNo,
            SUM(CONVERT(decimal(19, 4), i.Debit)) AS Debit,
            SUM(CONVERT(decimal(19, 4), i.Credit)) AS Credit
        FROM #Items AS i
        INNER JOIN #Headers AS h
            ON h.JournalCode = i.JournalCode
           AND h.JournalIdNo = i.JournalIdNo
        WHERE ISNULL(h.Cancelled, 0) = 0
        GROUP BY i.JournalCode, i.JournalIdNo
    )
    SELECT @UnbalancedJournals = COUNT(*)
    FROM JournalTotals
    WHERE ABS(Debit - Credit) > @Tolerance;

    IF @UnbalancedJournals > 0
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'UNBALANCED_JOURNALS', @UnbalancedJournals,
             N'Every non-cancelled journal must balance independently before fiscal close.');

    SELECT @ExistingClosingJournals = COUNT(*)
    FROM #Headers
    WHERE ISNULL(Cancelled, 0) = 0
      AND ISNULL(ClosingJournal, 0) = 1;

    IF @ExistingClosingJournals > 0
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'CLOSING_JOURNAL_ALREADY_EXISTS', @ExistingClosingJournals,
             N'The fiscal year already contains a non-cancelled closing journal.');

    SELECT
        @PeriodDebit = ISNULL(SUM(CONVERT(decimal(19, 4), i.Debit)), 0),
        @PeriodCredit = ISNULL(SUM(CONVERT(decimal(19, 4), i.Credit)), 0)
    FROM #Items AS i
    INNER JOIN #Headers AS h
        ON h.JournalCode = i.JournalCode
       AND h.JournalIdNo = i.JournalIdNo
    WHERE ISNULL(h.Cancelled, 0) = 0;

    IF ABS(@PeriodDebit - @PeriodCredit) > @Tolerance
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'FISCAL_YEAR_LEDGER_UNBALANCED', 1,
             N'Total fiscal-year debits and credits do not balance.');

    SELECT
        @OpeningRows = COUNT(*),
        @OpeningDebit = ISNULL(SUM(CONVERT(decimal(19, 4), Debit)), 0),
        @OpeningCredit = ISNULL(SUM(CONVERT(decimal(19, 4), Credit)), 0)
    FROM dbo.AccountBalance
    WHERE [Year] = @FiscalYear;

    IF @OpeningRows = 0
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'OPENING_BALANCE_MISSING', 0,
             N'The requested fiscal year has no AccountBalance opening snapshot.');

    IF ABS(@OpeningDebit - @OpeningCredit) > @Tolerance
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'OPENING_BALANCE_UNBALANCED', @OpeningRows,
             N'The requested fiscal year opening AccountBalance does not balance.');

    SELECT @UnexpectedOpeningRows = COUNT(*)
    FROM dbo.AccountBalance AS ab
    LEFT JOIN dbo.Account AS a ON a.IdNo = ab.AccountIdNo
    WHERE ab.[Year] = @FiscalYear
      AND (
          a.IdNo IS NULL
          OR ISNULL(a.DetailAccount, 0) = 0
          OR a.AccountGroup NOT IN ('A', 'L', 'E')
      );

    IF @UnexpectedOpeningRows > 0
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'OPENING_BALANCE_ACCOUNT_INVALID', @UnexpectedOpeningRows,
             N'Opening balances may contain only permanent detail accounts.');

    SELECT @InvalidOpeningRows = COUNT(*)
    FROM dbo.AccountBalance
    WHERE [Year] = @FiscalYear
      AND (
          ISNULL(Debit, 0) < 0
          OR ISNULL(Credit, 0) < 0
          OR (ISNULL(Debit, 0) <> 0 AND ISNULL(Credit, 0) <> 0)
      );

    IF @InvalidOpeningRows > 0
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'OPENING_BALANCE_AMOUNT_INVALID', @InvalidOpeningRows,
             N'Each opening-balance row must have one non-negative debit or credit amount.');

    SELECT @TargetOpeningRows = COUNT(*)
    FROM dbo.AccountBalance
    WHERE [Year] = @FiscalYear + 1;

    IF @TargetOpeningRows > 0
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'NEXT_YEAR_OPENING_ALREADY_EXISTS', @TargetOpeningRows,
             N'The next fiscal year already has AccountBalance rows; do not create a duplicate snapshot.');

    IF EXISTS (
        SELECT 1
        FROM #Items AS i
        INNER JOIN #Headers AS h
            ON h.JournalCode = i.JournalCode
           AND h.JournalIdNo = i.JournalIdNo
        INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
        WHERE ISNULL(h.Cancelled, 0) = 0
          AND a.AccountGroup NOT IN ('A', 'L', 'E', 'R', 'X')
    )
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'UNSUPPORTED_ACCOUNT_GROUP_ACTIVITY', 1,
             N'Fiscal-year activity exists outside the supported A/L/E/R/X account groups.');

    CREATE TABLE #AccountMovement (
        AccountIdNo int NOT NULL PRIMARY KEY,
        Debit decimal(19, 4) NOT NULL,
        Credit decimal(19, 4) NOT NULL,
        Net decimal(19, 4) NOT NULL
    );

    INSERT INTO #AccountMovement (AccountIdNo, Debit, Credit, Net)
    SELECT
        i.AccountIdNo,
        SUM(CONVERT(decimal(19, 4), i.Debit)),
        SUM(CONVERT(decimal(19, 4), i.Credit)),
        SUM(CONVERT(decimal(19, 4), i.Debit - i.Credit))
    FROM #Items AS i
    INNER JOIN #Headers AS h
        ON h.JournalCode = i.JournalCode
       AND h.JournalIdNo = i.JournalIdNo
    WHERE ISNULL(h.Cancelled, 0) = 0
      AND ISNULL(h.HeaderPosted, 0) = 1
      AND i.ItemPosted = 1
    GROUP BY i.AccountIdNo;

    SELECT @IncomeSummaryExistingNet = ISNULL(Net, 0)
    FROM #AccountMovement
    WHERE AccountIdNo = @IncomeSummaryAccountIdNo;

    SET @IncomeSummaryExistingNet = ISNULL(@IncomeSummaryExistingNet, 0);

    IF ABS(@IncomeSummaryExistingNet) > @Tolerance
        INSERT INTO #ValidationIssue VALUES
            ('BLOCKER', 'INCOME_SUMMARY_NOT_ZERO', 1,
             N'Income Summary has fiscal-year activity before the proposed closing entry.');

    CREATE TABLE #TemporaryBalance (
        AccountIdNo int NOT NULL PRIMARY KEY,
        AccountCode varchar(5) NOT NULL,
        AccountName varchar(50) NOT NULL,
        AccountGroup char(1) NOT NULL,
        Net decimal(19, 4) NOT NULL
    );

    INSERT INTO #TemporaryBalance (
        AccountIdNo, AccountCode, AccountName, AccountGroup, Net
    )
    SELECT
        a.IdNo,
        a.AccountCode,
        a.AccountName,
        a.AccountGroup,
        m.Net
    FROM #AccountMovement AS m
    INNER JOIN dbo.Account AS a ON a.IdNo = m.AccountIdNo
    WHERE a.DetailAccount = 1
      AND a.AccountGroup IN ('R', 'X')
      AND a.IdNo <> ISNULL(@IncomeSummaryAccountIdNo, -1)
      AND ABS(m.Net) > @Tolerance;

    SELECT @ProfitLossNet = ISNULL(SUM(Net), 0)
    FROM #TemporaryBalance;

    CREATE TABLE #IncomeStatementClose (
        Sequence int NOT NULL,
        AccountIdNo int NOT NULL,
        AccountCode varchar(5) NOT NULL,
        AccountName varchar(50) NOT NULL,
        AccountGroup char(1) NOT NULL,
        LineType varchar(30) NOT NULL,
        Debit decimal(19, 4) NOT NULL,
        Credit decimal(19, 4) NOT NULL
    );

    INSERT INTO #IncomeStatementClose (
        Sequence, AccountIdNo, AccountCode, AccountName,
        AccountGroup, LineType, Debit, Credit
    )
    SELECT
        ROW_NUMBER() OVER (ORDER BY AccountCode, AccountIdNo),
        AccountIdNo,
        AccountCode,
        AccountName,
        AccountGroup,
        'CLOSE_TEMPORARY_ACCOUNT',
        CASE WHEN Net < 0 THEN -Net ELSE 0 END,
        CASE WHEN Net > 0 THEN Net ELSE 0 END
    FROM #TemporaryBalance;

    IF ABS(@ProfitLossNet) > @Tolerance
        INSERT INTO #IncomeStatementClose (
            Sequence, AccountIdNo, AccountCode, AccountName,
            AccountGroup, LineType, Debit, Credit
        )
        SELECT
            ISNULL((SELECT MAX(Sequence) FROM #IncomeStatementClose), 0) + 1,
            a.IdNo,
            a.AccountCode,
            a.AccountName,
            a.AccountGroup,
            'INCOME_SUMMARY_OFFSET',
            CASE WHEN @ProfitLossNet > 0 THEN @ProfitLossNet ELSE 0 END,
            CASE WHEN @ProfitLossNet < 0 THEN -@ProfitLossNet ELSE 0 END
        FROM dbo.Account AS a
        WHERE a.IdNo = @IncomeSummaryAccountIdNo;

    CREATE TABLE #RetainedEarningsTransfer (
        Sequence int NOT NULL,
        AccountIdNo int NOT NULL,
        AccountCode varchar(5) NOT NULL,
        AccountName varchar(50) NOT NULL,
        AccountGroup char(1) NOT NULL,
        LineType varchar(30) NOT NULL,
        Debit decimal(19, 4) NOT NULL,
        Credit decimal(19, 4) NOT NULL
    );

    IF ABS(@ProfitLossNet) > @Tolerance
    BEGIN
        INSERT INTO #RetainedEarningsTransfer (
            Sequence, AccountIdNo, AccountCode, AccountName,
            AccountGroup, LineType, Debit, Credit
        )
        SELECT
            1,
            a.IdNo,
            a.AccountCode,
            a.AccountName,
            a.AccountGroup,
            'CLEAR_INCOME_SUMMARY',
            CASE WHEN @ProfitLossNet < 0 THEN -@ProfitLossNet ELSE 0 END,
            CASE WHEN @ProfitLossNet > 0 THEN @ProfitLossNet ELSE 0 END
        FROM dbo.Account AS a
        WHERE a.IdNo = @IncomeSummaryAccountIdNo;

        INSERT INTO #RetainedEarningsTransfer (
            Sequence, AccountIdNo, AccountCode, AccountName,
            AccountGroup, LineType, Debit, Credit
        )
        SELECT
            2,
            a.IdNo,
            a.AccountCode,
            a.AccountName,
            a.AccountGroup,
            'TRANSFER_TO_RETAINED_EARNINGS',
            CASE WHEN @ProfitLossNet > 0 THEN @ProfitLossNet ELSE 0 END,
            CASE WHEN @ProfitLossNet < 0 THEN -@ProfitLossNet ELSE 0 END
        FROM dbo.Account AS a
        WHERE a.IdNo = @RetainedEarningsAccountIdNo;
    END;

    CREATE TABLE #ProposedOpening (
        AccountIdNo int NOT NULL PRIMARY KEY,
        AccountCode varchar(5) NOT NULL,
        AccountName varchar(50) NOT NULL,
        AccountGroup char(1) NOT NULL,
        ExistingOpeningNet decimal(19, 4) NOT NULL,
        PermanentMovementNet decimal(19, 4) NOT NULL,
        RetainedEarningsTransferNet decimal(19, 4) NOT NULL,
        ProposedOpeningNet decimal(19, 4) NOT NULL,
        Debit decimal(19, 4) NOT NULL,
        Credit decimal(19, 4) NOT NULL
    );

    INSERT INTO #ProposedOpening (
        AccountIdNo, AccountCode, AccountName, AccountGroup,
        ExistingOpeningNet, PermanentMovementNet,
        RetainedEarningsTransferNet, ProposedOpeningNet,
        Debit, Credit
    )
    SELECT
        a.IdNo,
        a.AccountCode,
        a.AccountName,
        a.AccountGroup,
        valueset.ExistingOpeningNet,
        valueset.PermanentMovementNet,
        valueset.RetainedEarningsTransferNet,
        valueset.ProposedOpeningNet,
        CASE WHEN valueset.ProposedOpeningNet > 0 THEN valueset.ProposedOpeningNet ELSE 0 END,
        CASE WHEN valueset.ProposedOpeningNet < 0 THEN -valueset.ProposedOpeningNet ELSE 0 END
    FROM dbo.Account AS a
    OUTER APPLY (
        SELECT
            CONVERT(decimal(19, 4), ISNULL(ab.Debit, 0) - ISNULL(ab.Credit, 0)) AS ExistingOpeningNet,
            CONVERT(decimal(19, 4), ISNULL(m.Net, 0)) AS PermanentMovementNet,
            CONVERT(decimal(19, 4),
                CASE WHEN a.IdNo = @RetainedEarningsAccountIdNo THEN @ProfitLossNet ELSE 0 END
            ) AS RetainedEarningsTransferNet,
            CONVERT(decimal(19, 4),
                ISNULL(ab.Debit, 0) - ISNULL(ab.Credit, 0)
                + ISNULL(m.Net, 0)
                + CASE WHEN a.IdNo = @RetainedEarningsAccountIdNo THEN @ProfitLossNet ELSE 0 END
            ) AS ProposedOpeningNet
        FROM (SELECT 1 AS Anchor) AS anchor
        LEFT JOIN dbo.AccountBalance AS ab
            ON ab.[Year] = @FiscalYear
           AND ab.AccountIdNo = a.IdNo
        LEFT JOIN #AccountMovement AS m ON m.AccountIdNo = a.IdNo
    ) AS valueset
    WHERE a.DetailAccount = 1
      AND a.AccountGroup IN ('A', 'L', 'E');

    IF EXISTS (
        SELECT 1
        FROM dbo.Account AS a
        INNER JOIN #AccountMovement AS m ON m.AccountIdNo = a.IdNo
        WHERE a.SpecialAccount IN ('BI', 'EI')
          AND ABS(m.Net) > @Tolerance
    )
        INSERT INTO #ValidationIssue VALUES
            ('WARNING', 'INVENTORY_VALUATION_REVIEW', NULL,
             N'Beginning and ending inventory are included in the income close; verify the final physical inventory valuation.');

    IF EXISTS (
        SELECT 1
        FROM dbo.Account AS a
        LEFT JOIN dbo.AccountBalance AS ab
            ON ab.[Year] = @FiscalYear
           AND ab.AccountIdNo = a.IdNo
        LEFT JOIN #AccountMovement AS m ON m.AccountIdNo = a.IdNo
        WHERE a.AccountGroup = 'L'
          AND (a.SpecialAccount IN ('VI', 'VO') OR a.AccountName LIKE '%VAT%')
          AND ABS(ISNULL(ab.Debit, 0) - ISNULL(ab.Credit, 0) + ISNULL(m.Net, 0)) > @Tolerance
    )
        INSERT INTO #ValidationIssue VALUES
            ('WARNING', 'VAT_RECLASSIFICATION_REVIEW', NULL,
             N'VAT balances will carry forward unless a separately reviewed VAT reclassification journal is posted first.');

    INSERT INTO #ValidationIssue VALUES
        ('WARNING', 'ZAKAH_PROVISION_REVIEW', NULL,
         N'This preview does not calculate Zakah or tax provisions; post any approved provision before executing fiscal close.');

    SELECT @NextYearActivityLines = COUNT(*)
    FROM dbo.GlLedgers_View
    WHERE TransactionDate >= @NextFiscalYearStart
      AND TransactionDate < DATEADD(year, 1, @NextFiscalYearStart);

    IF @NextYearActivityLines > 0
        INSERT INTO #ValidationIssue VALUES
            ('WARNING', 'NEXT_YEAR_ACTIVITY_EXISTS', @NextYearActivityLines,
             N'Next-year journal activity already exists; the opening snapshot must be installed without changing those journals.');

    SELECT @BlockingErrors = COUNT(*)
    FROM #ValidationIssue
    WHERE Severity = 'BLOCKER';

    SELECT @ReviewWarnings = COUNT(*)
    FROM #ValidationIssue
    WHERE Severity = 'WARNING';

    SELECT
        CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')) AS ServerName,
        DB_NAME() AS DatabaseName,
        N'PREVIEW ONLY - NO DATA CHANGED' AS PreviewMode,
        CASE
            WHEN @BlockingErrors > 0 THEN N'BLOCKED'
            ELSE N'READY FOR ACCOUNTANT REVIEW'
        END AS PreviewStatus,
        @FiscalYear AS FiscalYear,
        @FiscalYearStart AS FiscalYearStart,
        @FiscalYearEnd AS FiscalYearEnd,
        @FiscalYear + 1 AS TargetOpeningYear,
        @ClosedThrough AS PeriodLockedThrough,
        @LastFiscalYearEnd AS LastFiscalYearEnd,
        @IncomeSummaryAccountIdNo AS IncomeSummaryAccountIdNo,
        @RetainedEarningsAccountIdNo AS RetainedEarningsAccountIdNo,
        @BlockingErrors AS BlockingErrors,
        @ReviewWarnings AS ReviewWarnings,
        (SELECT COUNT(*) FROM #Headers) AS JournalHeaders,
        (SELECT COUNT(*) FROM #Items) AS JournalItems,
        @PeriodDebit AS PeriodDebit,
        @PeriodCredit AS PeriodCredit,
        CASE
            WHEN @ProfitLossNet > @Tolerance THEN N'LOSS'
            WHEN @ProfitLossNet < -@Tolerance THEN N'PROFIT'
            ELSE N'BREAK EVEN'
        END AS FiscalResult,
        ABS(@ProfitLossNet) AS FiscalResultAmount,
        (SELECT COUNT(*) FROM #IncomeStatementClose) AS ProposedIncomeCloseLines,
        (SELECT COUNT(*) FROM #RetainedEarningsTransfer) AS ProposedTransferLines,
        (SELECT COUNT(*) FROM #ProposedOpening WHERE ABS(ProposedOpeningNet) > @Tolerance) AS ProposedOpeningRows,
        @NextYearActivityLines AS NextYearActivityLines;

    SELECT Severity, IssueCode, AffectedRecords, Details
    FROM #ValidationIssue
    ORDER BY
        CASE Severity WHEN 'BLOCKER' THEN 1 ELSE 2 END,
        IssueCode;

    SELECT
        Sequence,
        AccountIdNo,
        AccountCode,
        AccountName,
        AccountGroup,
        LineType,
        Debit,
        Credit
    FROM #IncomeStatementClose
    ORDER BY Sequence;

    SELECT
        Sequence,
        AccountIdNo,
        AccountCode,
        AccountName,
        AccountGroup,
        LineType,
        Debit,
        Credit
    FROM #RetainedEarningsTransfer
    ORDER BY Sequence;

    SELECT
        @FiscalYear + 1 AS [Year],
        AccountIdNo,
        AccountCode,
        AccountName,
        AccountGroup,
        ExistingOpeningNet,
        PermanentMovementNet,
        RetainedEarningsTransferNet,
        ProposedOpeningNet,
        Debit,
        Credit
    FROM #ProposedOpening
    WHERE ABS(ProposedOpeningNet) > @Tolerance
    ORDER BY AccountCode, AccountIdNo;

    SELECT
        'INCOME_STATEMENT_CLOSE' AS Reconciliation,
        ISNULL(SUM(Debit), 0) AS Debit,
        ISNULL(SUM(Credit), 0) AS Credit,
        ISNULL(SUM(Debit - Credit), 0) AS Difference
    FROM #IncomeStatementClose
    UNION ALL
    SELECT
        'RETAINED_EARNINGS_TRANSFER',
        ISNULL(SUM(Debit), 0),
        ISNULL(SUM(Credit), 0),
        ISNULL(SUM(Debit - Credit), 0)
    FROM #RetainedEarningsTransfer
    UNION ALL
    SELECT
        'NEXT_YEAR_OPENING',
        ISNULL(SUM(Debit), 0),
        ISNULL(SUM(Credit), 0),
        ISNULL(SUM(Debit - Credit), 0)
    FROM #ProposedOpening;

    SELECT
        CASE
            WHEN a.SpecialAccount IN ('BI', 'EI') THEN 'INVENTORY'
            WHEN a.AccountGroup = 'L'
             AND (a.SpecialAccount IN ('VI', 'VO') OR a.AccountName LIKE '%VAT%') THEN 'VAT'
        END AS ReviewCategory,
        a.IdNo AS AccountIdNo,
        a.AccountCode,
        a.AccountName,
        a.AccountGroup,
        a.SpecialAccount,
        CONVERT(decimal(19, 4), ISNULL(ab.Debit, 0) - ISNULL(ab.Credit, 0)) AS ExistingOpeningNet,
        CONVERT(decimal(19, 4), ISNULL(m.Net, 0)) AS FiscalYearMovementNet,
        CONVERT(decimal(19, 4),
            ISNULL(ab.Debit, 0) - ISNULL(ab.Credit, 0) + ISNULL(m.Net, 0)
        ) AS PreCloseYearEndNet,
        CASE
            WHEN a.SpecialAccount IN ('BI', 'EI')
                THEN N'Closed automatically to Income Summary after inventory valuation is approved.'
            ELSE N'Carried into the next opening unless a reviewed VAT reclassification is posted first.'
        END AS ProposedTreatment
    FROM dbo.Account AS a
    LEFT JOIN dbo.AccountBalance AS ab
        ON ab.[Year] = @FiscalYear
       AND ab.AccountIdNo = a.IdNo
    LEFT JOIN #AccountMovement AS m ON m.AccountIdNo = a.IdNo
    WHERE (
            a.SpecialAccount IN ('BI', 'EI')
            OR (
                a.AccountGroup = 'L'
                AND (a.SpecialAccount IN ('VI', 'VO') OR a.AccountName LIKE '%VAT%')
            )
          )
      AND ABS(ISNULL(ab.Debit, 0) - ISNULL(ab.Credit, 0) + ISNULL(m.Net, 0)) > @Tolerance
    ORDER BY ReviewCategory, a.AccountCode;
END;
