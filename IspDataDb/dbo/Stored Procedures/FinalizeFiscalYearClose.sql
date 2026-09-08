CREATE PROCEDURE [dbo].[FinalizeFiscalYearClose]
    @FiscalYear int,
    @IncomeSummaryAccountIdNo smallint = NULL,
    @RetainedEarningsAccountIdNo smallint = NULL,
    @ApplicationUser sysname,
    @ApprovalNotes nvarchar(1000),
    @WarningsAcknowledged bit,
    @ExpectedFiscalResult varchar(10),
    @ExpectedFiscalResultAmount decimal(19, 4),
    @ExpectedOpeningDebit decimal(19, 4),
    @ExpectedOpeningCredit decimal(19, 4),
    @ExpectedJanuaryBeginningInventory decimal(19, 4),
    @ExpectedDecemberEndingInventory decimal(19, 4)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @FiscalYear NOT BETWEEN 2000 AND 2099
        THROW 52400, 'FiscalYear must be between 2000 and 2099.', 1;
    IF NULLIF(LTRIM(RTRIM(@ApplicationUser)), '') IS NULL
        THROW 52401, 'ApplicationUser is required.', 1;
    IF NULLIF(LTRIM(RTRIM(@ApprovalNotes)), '') IS NULL
        THROW 52402, 'Accountant approval notes are required.', 1;
    IF ISNULL(@WarningsAcknowledged, 0) <> 1
        THROW 52403, 'All year-end review warnings must be acknowledged.', 1;
    IF @ExpectedFiscalResult NOT IN ('PROFIT', 'LOSS', 'BREAK EVEN')
        THROW 52439, 'Run and review the fiscal-year preview before finalization.', 1;

    DECLARE @Tolerance decimal(19, 4) = 0.00005;
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
    DECLARE @BeginningInventoryAccountIdNo smallint;
    DECLARE @EndingInventoryAccountIdNo smallint;
    DECLARE @BeginningInventoryMatches int;
    DECLARE @EndingInventoryMatches int;
    DECLARE @LegacyMonthsNormalized int = 0;
    DECLARE @IncomeClosingJournalIdNo int;
    DECLARE @RetainedEarningsJournalIdNo int;
    DECLARE @ProfitLossNet decimal(19, 4);
    DECLARE @OpeningDebit decimal(19, 4);
    DECLARE @OpeningCredit decimal(19, 4);
    DECLARE @OpeningRows int;
    DECLARE @JanuaryBeginningInventory decimal(19, 4);
    DECLARE @DecemberEndingInventory decimal(19, 4);
    DECLARE @InventoryNetEffect decimal(19, 4);
    DECLARE @AccumulatedInventoryNet decimal(19, 4);
    DECLARE @RunId uniqueidentifier = NEWID();
    DECLARE @LockResult int;

    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
        BEGIN TRANSACTION;

        EXEC @LockResult = sys.sp_getapplock
            @Resource = N'ISPDATA:FiscalYearClose',
            @LockMode = 'Exclusive',
            @LockOwner = 'Transaction',
            @LockTimeout = 30000;
        IF @LockResult < 0
            THROW 52404, 'Could not acquire the fiscal-year close lock.', 1;

        EXEC @LockResult = sys.sp_getapplock
            @Resource = N'ISPDATA:MonthlyClose',
            @LockMode = 'Exclusive',
            @LockOwner = 'Transaction',
            @LockTimeout = 30000;
        IF @LockResult < 0
            THROW 52405, 'Could not acquire the monthly close lock.', 1;

        IF EXISTS (SELECT 1 FROM dbo.FiscalYearCloseRun WITH (UPDLOCK, HOLDLOCK) WHERE FiscalYear = @FiscalYear)
            THROW 52406, 'This fiscal year is already finalized.', 1;

        SELECT @ClosedPeriodRows = COUNT(*), @ClosedThrough = MAX(LastPostingDate)
        FROM dbo.LastPosting WITH (UPDLOCK, HOLDLOCK)
        WHERE TransactionName = 'Closed Period';
        IF @ClosedPeriodRows <> 1 OR @ClosedThrough IS NULL OR @ClosedThrough < @FiscalYearEnd
            THROW 52407, 'The fiscal year must be period-locked through its final date.', 1;

        SELECT @LastFiscalYearEndRows = COUNT(*), @LastFiscalYearEnd = MAX(LastPostingDate)
        FROM dbo.LastPosting WITH (UPDLOCK, HOLDLOCK)
        WHERE TransactionName = 'LastFiscalYearEnd';
        IF @LastFiscalYearEndRows <> 1 OR @LastFiscalYearEnd <> @ExpectedPreviousClose
            THROW 52408, 'The requested year must immediately follow the last finalized fiscal year.', 1;

        IF (SELECT COUNT(*) FROM dbo.MonthlyClosePeriod WHERE FiscalYear = @FiscalYear) <> 12
            THROW 52409, 'All twelve monthly close periods must exist before fiscal finalization.', 1;
        IF EXISTS (SELECT 1 FROM dbo.MonthlyClosePeriod WHERE FiscalYear = @FiscalYear AND Status = 'Open')
            THROW 52410, 'All monthly periods must be approved and locked before fiscal finalization.', 1;
        IF @FiscalYear <> 2025 AND EXISTS (SELECT 1 FROM dbo.MonthlyClosePeriod WHERE FiscalYear = @FiscalYear AND Status <> 'Closed')
            THROW 52411, 'All twelve monthly periods must have Closed status before fiscal finalization.', 1;
        IF @FiscalYear = 2025 AND EXISTS (SELECT 1 FROM dbo.MonthlyClosePeriod WHERE FiscalYear = @FiscalYear AND Status NOT IN ('Approved', 'Closed'))
            THROW 52412, 'The 2025 legacy monthly periods must be Approved or Closed.', 1;
        IF EXISTS (
            SELECT 1
            FROM (VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10),(11),(12)) AS months(FiscalMonth)
            OUTER APPLY (
                SELECT COUNT(*) AS ItemCount, SUM(CASE WHEN Completed = 1 THEN 1 ELSE 0 END) AS CompletedCount
                FROM dbo.MonthlyCloseChecklist
                WHERE FiscalYear = @FiscalYear AND FiscalMonth = months.FiscalMonth
            ) AS checklist
            WHERE checklist.ItemCount <> 8 OR checklist.CompletedCount <> 8
        )
            THROW 52413, 'Every monthly close checklist must contain eight completed items.', 1;

        IF @IncomeSummaryAccountIdNo IS NULL
        BEGIN
            SELECT @IncomeSummaryMatches = COUNT(*), @IncomeSummaryAccountIdNo = MIN(IdNo)
            FROM dbo.Account WHERE AccountCode = '599';
            IF @IncomeSummaryMatches <> 1
                THROW 52414, 'Income Summary account code 599 was not uniquely resolved.', 1;
        END;
        IF NOT EXISTS (
            SELECT 1 FROM dbo.Account
            WHERE IdNo = @IncomeSummaryAccountIdNo AND DetailAccount = 1
              AND AccountGroup IN ('R', 'X') AND Active = 1
        )
            THROW 52415, 'Income Summary must be an active detail revenue or expense account.', 1;

        IF @RetainedEarningsAccountIdNo IS NULL
        BEGIN
            SELECT @RetainedEarningsMatches = COUNT(*), @RetainedEarningsAccountIdNo = MIN(IdNo)
            FROM dbo.Account WHERE SpecialAccount = 'RE';
            IF @RetainedEarningsMatches <> 1
                THROW 52416, 'Retained Earnings was not uniquely resolved.', 1;
        END;
        IF NOT EXISTS (
            SELECT 1 FROM dbo.Account
            WHERE IdNo = @RetainedEarningsAccountIdNo AND DetailAccount = 1
              AND AccountGroup = 'E' AND SpecialAccount = 'RE' AND Active = 1
        )
            THROW 52417, 'Retained Earnings must be the active detail equity account marked RE.', 1;

        SELECT @BeginningInventoryMatches = COUNT(*), @BeginningInventoryAccountIdNo = MIN(IdNo)
        FROM dbo.Account WHERE SpecialAccount = 'BI' AND DetailAccount = 1 AND Active = 1;
        SELECT @EndingInventoryMatches = COUNT(*), @EndingInventoryAccountIdNo = MIN(IdNo)
        FROM dbo.Account WHERE SpecialAccount = 'EI' AND DetailAccount = 1 AND Active = 1;
        IF @BeginningInventoryMatches <> 1 OR @EndingInventoryMatches <> 1
            THROW 52418, 'Beginning and ending inventory accounts must each resolve to one active detail account.', 1;

        CREATE TABLE #Headers (
            JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
            JournalIdNo int NOT NULL,
            TransactionDate date NOT NULL,
            HeaderPosted bit NULL,
            Cancelled bit NULL,
            ClosingJournal bit NULL,
            PRIMARY KEY (JournalCode, JournalIdNo)
        );

        INSERT INTO #Headers (JournalCode, JournalIdNo, TransactionDate, HeaderPosted, Cancelled, ClosingJournal)
        SELECT 'AP', IdNo, TransactionDate, Posted, Cancelled, 0 FROM dbo.ApJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL SELECT 'AR', IdNo, TransactionDate, Posted, Cancelled, 0 FROM dbo.ArJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL SELECT 'CD', IdNo, TransactionDate, Posted, Cancelled, 0 FROM dbo.CdJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL SELECT 'CK', IdNo, TransactionDate, Posted, Cancelled, 0 FROM dbo.CkJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL SELECT 'CR', IdNo, TransactionDate, Posted, Cancelled, 0 FROM dbo.CashReceiptJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL SELECT 'ER', IdNo, TransactionDate, Posted, Cancelled, 0 FROM dbo.ErJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL SELECT 'GJ', IdNo, TransactionDate, Posted, Cancelled, ClosingJournal FROM dbo.GeneralJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL SELECT 'PC', IdNo, TransactionDate, Posted, Cancelled, 0 FROM dbo.PcJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart
        UNION ALL SELECT 'SJ', IdNo, TransactionDate, Posted, Cancelled, 0 FROM dbo.SalesJournal WHERE TransactionDate >= @FiscalYearStart AND TransactionDate < @NextFiscalYearStart;

        CREATE TABLE #Items (
            JournalCode char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
            ItemIdNo int NOT NULL,
            JournalIdNo int NOT NULL,
            AccountIdNo int NOT NULL,
            ItemPosted bit NOT NULL,
            Debit decimal(19, 4) NOT NULL,
            Credit decimal(19, 4) NOT NULL,
            PRIMARY KEY (JournalCode, ItemIdNo)
        );

        INSERT INTO #Items (JournalCode, ItemIdNo, JournalIdNo, AccountIdNo, ItemPosted, Debit, Credit)
        SELECT 'AP', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit FROM dbo.ApJournalItem i INNER JOIN #Headers h ON h.JournalCode='AP' AND h.JournalIdNo=i.JournalIdNo
        UNION ALL SELECT 'AR', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit FROM dbo.ArJournalItem i INNER JOIN #Headers h ON h.JournalCode='AR' AND h.JournalIdNo=i.JournalIdNo
        UNION ALL SELECT 'CD', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit FROM dbo.CdJournalItem i INNER JOIN #Headers h ON h.JournalCode='CD' AND h.JournalIdNo=i.JournalIdNo
        UNION ALL SELECT 'CK', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit FROM dbo.CkJournalItem i INNER JOIN #Headers h ON h.JournalCode='CK' AND h.JournalIdNo=i.JournalIdNo
        UNION ALL SELECT 'CR', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit FROM dbo.CashReceiptJournalItem i INNER JOIN #Headers h ON h.JournalCode='CR' AND h.JournalIdNo=i.JournalIdNo
        UNION ALL SELECT 'ER', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit FROM dbo.ErJournalItem i INNER JOIN #Headers h ON h.JournalCode='ER' AND h.JournalIdNo=i.JournalIdNo
        UNION ALL SELECT 'GJ', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit FROM dbo.GeneralJournalItem i INNER JOIN #Headers h ON h.JournalCode='GJ' AND h.JournalIdNo=i.JournalIdNo
        UNION ALL SELECT 'PC', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit FROM dbo.PcJournalItem i INNER JOIN #Headers h ON h.JournalCode='PC' AND h.JournalIdNo=i.JournalIdNo
        UNION ALL SELECT 'SJ', i.IdNo, i.JournalIdNo, i.AccountIdNo, i.Posted, i.Debit, i.Credit FROM dbo.SalesJournalItem i INNER JOIN #Headers h ON h.JournalCode='SJ' AND h.JournalIdNo=i.JournalIdNo;

        IF EXISTS (SELECT 1 FROM #Headers WHERE ISNULL(HeaderPosted, 0) = 0)
            THROW 52419, 'All fiscal-year journal headers must be posted before finalization.', 1;
        IF EXISTS (SELECT 1 FROM #Items WHERE ItemPosted = 0)
            THROW 52420, 'All fiscal-year journal items must be posted before finalization.', 1;
        IF EXISTS (
            SELECT 1 FROM #Items i
            INNER JOIN #Headers h ON h.JournalCode=i.JournalCode AND h.JournalIdNo=i.JournalIdNo
            LEFT JOIN dbo.Account a ON a.IdNo=i.AccountIdNo
            WHERE ISNULL(h.Cancelled,0)=0 AND (a.IdNo IS NULL OR ISNULL(a.DetailAccount,0)=0 OR i.Debit<0 OR i.Credit<0 OR (i.Debit<>0 AND i.Credit<>0))
        )
            THROW 52422, 'Invalid journal items exist in the fiscal year.', 1;
        IF EXISTS (
            SELECT 1 FROM #Items i
            INNER JOIN #Headers h ON h.JournalCode=i.JournalCode AND h.JournalIdNo=i.JournalIdNo
            WHERE ISNULL(h.Cancelled,0)=0
            GROUP BY i.JournalCode,i.JournalIdNo
            HAVING ABS(SUM(i.Debit)-SUM(i.Credit))>@Tolerance
        )
            THROW 52423, 'Every fiscal-year journal must balance before finalization.', 1;

        CREATE TABLE #AccountMovement (
            AccountIdNo int NOT NULL PRIMARY KEY,
            Net decimal(19, 4) NOT NULL
        );
        INSERT INTO #AccountMovement (AccountIdNo, Net)
        SELECT i.AccountIdNo, SUM(i.Debit-i.Credit)
        FROM #Items i
        INNER JOIN #Headers h ON h.JournalCode=i.JournalCode AND h.JournalIdNo=i.JournalIdNo
        WHERE ISNULL(h.Cancelled,0)=0
        GROUP BY i.AccountIdNo;

        IF EXISTS (
            SELECT 1 FROM #AccountMovement m
            INNER JOIN dbo.Account a ON a.IdNo=m.AccountIdNo
            WHERE a.AccountGroup NOT IN ('A','L','E','R','X') AND ABS(m.Net)>@Tolerance
        )
            THROW 52424, 'Fiscal-year activity exists outside supported account groups.', 1;
        IF ABS(ISNULL((SELECT Net FROM #AccountMovement WHERE AccountIdNo=@IncomeSummaryAccountIdNo),0))>@Tolerance
            THROW 52425, 'Income Summary must be zero before fiscal finalization.', 1;

        IF NOT EXISTS (SELECT 1 FROM dbo.AccountBalance WHERE [Year]=@FiscalYear)
            THROW 52426, 'The fiscal year opening AccountBalance snapshot is missing.', 1;
        IF ABS((SELECT ISNULL(SUM(CONVERT(decimal(19,4),ISNULL(Debit,0)-ISNULL(Credit,0))),0) FROM dbo.AccountBalance WHERE [Year]=@FiscalYear))>@Tolerance
            THROW 52427, 'The fiscal year opening AccountBalance snapshot is unbalanced.', 1;
        IF EXISTS (
            SELECT 1 FROM dbo.AccountBalance ab LEFT JOIN dbo.Account a ON a.IdNo=ab.AccountIdNo
            WHERE ab.[Year]=@FiscalYear AND (a.IdNo IS NULL OR ISNULL(a.DetailAccount,0)=0 OR a.AccountGroup NOT IN ('A','L','E') OR ISNULL(ab.Debit,0)<0 OR ISNULL(ab.Credit,0)<0 OR (ISNULL(ab.Debit,0)<>0 AND ISNULL(ab.Credit,0)<>0))
        )
            THROW 52428, 'The fiscal year opening snapshot contains invalid rows.', 1;
        IF EXISTS (SELECT 1 FROM dbo.AccountBalance WITH (UPDLOCK,HOLDLOCK) WHERE [Year]=@FiscalYear+1)
            THROW 52429, 'The next fiscal year already has AccountBalance rows.', 1;

        CREATE TABLE #InventoryMonth (
            FiscalMonth int NOT NULL PRIMARY KEY,
            BeginningInventory decimal(19,4) NOT NULL,
            EndingInventory decimal(19,4) NOT NULL
        );
        INSERT INTO #InventoryMonth (FiscalMonth,BeginningInventory,EndingInventory)
        SELECT months.FiscalMonth,
            ISNULL(SUM(CASE WHEN i.AccountIdNo=@BeginningInventoryAccountIdNo THEN i.Debit-i.Credit ELSE 0 END),0),
            ISNULL(SUM(CASE WHEN i.AccountIdNo=@EndingInventoryAccountIdNo THEN i.Credit-i.Debit ELSE 0 END),0)
        FROM (VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10),(11),(12)) months(FiscalMonth)
        LEFT JOIN #Headers h ON MONTH(h.TransactionDate)=months.FiscalMonth AND ISNULL(h.Cancelled,0)=0
        LEFT JOIN #Items i ON i.JournalCode=h.JournalCode AND i.JournalIdNo=h.JournalIdNo AND i.AccountIdNo IN (@BeginningInventoryAccountIdNo,@EndingInventoryAccountIdNo)
        GROUP BY months.FiscalMonth;

        IF EXISTS (SELECT 1 FROM #InventoryMonth WHERE BeginningInventory<0 OR EndingInventory<0)
            THROW 52430, 'Monthly beginning and ending inventory balances must be non-negative.', 1;
        IF EXISTS (
            SELECT 1 FROM #InventoryMonth currentMonth
            INNER JOIN #InventoryMonth nextMonth ON nextMonth.FiscalMonth=currentMonth.FiscalMonth+1
            WHERE ABS(currentMonth.EndingInventory-nextMonth.BeginningInventory)>@Tolerance
        )
            THROW 52431, 'Monthly inventory roll-forward failed: each ending inventory must equal the next month beginning inventory.', 1;

        SELECT @JanuaryBeginningInventory=BeginningInventory FROM #InventoryMonth WHERE FiscalMonth=1;
        SELECT @DecemberEndingInventory=EndingInventory FROM #InventoryMonth WHERE FiscalMonth=12;
        SET @InventoryNetEffect=@JanuaryBeginningInventory-@DecemberEndingInventory;
        SET @AccumulatedInventoryNet=ISNULL((SELECT SUM(Net) FROM #AccountMovement WHERE AccountIdNo IN (@BeginningInventoryAccountIdNo,@EndingInventoryAccountIdNo)),0);
        IF ABS(@InventoryNetEffect-@AccumulatedInventoryNet)>@Tolerance
            THROW 52432, 'Accumulated inventory postings do not reconcile to January beginning less December ending inventory.', 1;

        CREATE TABLE #TemporaryBalance (
            AccountIdNo int NOT NULL PRIMARY KEY,
            Net decimal(19,4) NOT NULL
        );
        INSERT INTO #TemporaryBalance (AccountIdNo,Net)
        SELECT m.AccountIdNo,m.Net FROM #AccountMovement m
        INNER JOIN dbo.Account a ON a.IdNo=m.AccountIdNo
        WHERE a.DetailAccount=1 AND a.AccountGroup IN ('R','X')
          AND a.IdNo<>@IncomeSummaryAccountIdNo AND ABS(m.Net)>@Tolerance;
        SET @ProfitLossNet=ISNULL((SELECT SUM(Net) FROM #TemporaryBalance),0);

        CREATE TABLE #ProposedOpening (
            AccountIdNo int NOT NULL PRIMARY KEY,
            Net decimal(19,4) NOT NULL,
            Debit decimal(19,4) NOT NULL,
            Credit decimal(19,4) NOT NULL
        );
        INSERT INTO #ProposedOpening (AccountIdNo,Net,Debit,Credit)
        SELECT a.IdNo,valueset.Net,
            CASE WHEN valueset.Net>0 THEN valueset.Net ELSE 0 END,
            CASE WHEN valueset.Net<0 THEN -valueset.Net ELSE 0 END
        FROM dbo.Account a
        OUTER APPLY (
            SELECT CONVERT(decimal(19,4),ISNULL(ab.Debit,0)-ISNULL(ab.Credit,0)+ISNULL(m.Net,0)+CASE WHEN a.IdNo=@RetainedEarningsAccountIdNo THEN @ProfitLossNet ELSE 0 END) AS Net
            FROM (SELECT 1 AS Anchor) anchor
            LEFT JOIN dbo.AccountBalance ab ON ab.[Year]=@FiscalYear AND ab.AccountIdNo=a.IdNo
            LEFT JOIN #AccountMovement m ON m.AccountIdNo=a.IdNo
        ) valueset
        WHERE a.DetailAccount=1 AND a.AccountGroup IN ('A','L','E') AND ABS(valueset.Net)>@Tolerance;

        SELECT @OpeningRows=COUNT(*),@OpeningDebit=ISNULL(SUM(Debit),0),@OpeningCredit=ISNULL(SUM(Credit),0) FROM #ProposedOpening;
        IF @OpeningRows=0 OR ABS(@OpeningDebit-@OpeningCredit)>@Tolerance
            THROW 52433, 'The proposed next-year opening snapshot is missing or unbalanced.', 1;
        IF @ExpectedFiscalResult <> CASE WHEN @ProfitLossNet>@Tolerance THEN 'LOSS' WHEN @ProfitLossNet < -@Tolerance THEN 'PROFIT' ELSE 'BREAK EVEN' END
           OR ABS(@ExpectedFiscalResultAmount-ABS(@ProfitLossNet))>@Tolerance
           OR ABS(@ExpectedOpeningDebit-@OpeningDebit)>@Tolerance
           OR ABS(@ExpectedOpeningCredit-@OpeningCredit)>@Tolerance
           OR ABS(@ExpectedJanuaryBeginningInventory-@JanuaryBeginningInventory)>@Tolerance
           OR ABS(@ExpectedDecemberEndingInventory-@DecemberEndingInventory)>@Tolerance
            THROW 52440, 'Year-end data changed after Preview. Run Preview and review the results again.', 1;

        INSERT INTO dbo.GeneralJournal (TransactionDate,ReferenceNo,Notes,Approved,Posted,ClosingJournal,Cancelled)
        VALUES (@FiscalYearEnd,N'FYE'+RIGHT(CONVERT(nvarchar(4),@FiscalYear),2)+N'-IS',N'Fiscal year '+CONVERT(nvarchar(4),@FiscalYear)+N' revenue and expense close to Income Summary',1,1,1,0);
        SET @IncomeClosingJournalIdNo=CONVERT(int,SCOPE_IDENTITY());

        INSERT INTO dbo.GeneralJournalItem (Sequence,JournalIdNo,AccountIdNo,Debit,Credit,RevCostCenterIdNo,Notes,Posted)
        SELECT CONVERT(smallint,ROW_NUMBER() OVER (ORDER BY a.AccountCode,a.IdNo)),@IncomeClosingJournalIdNo,t.AccountIdNo,
            CASE WHEN t.Net<0 THEN -t.Net ELSE 0 END,
            CASE WHEN t.Net>0 THEN t.Net ELSE 0 END,
            0,N'Fiscal year '+CONVERT(nvarchar(4),@FiscalYear)+N' temporary account close',1
        FROM #TemporaryBalance t INNER JOIN dbo.Account a ON a.IdNo=t.AccountIdNo;

        IF ABS(@ProfitLossNet)>@Tolerance
            INSERT INTO dbo.GeneralJournalItem (Sequence,JournalIdNo,AccountIdNo,Debit,Credit,RevCostCenterIdNo,Notes,Posted)
            VALUES (CONVERT(smallint,(SELECT COUNT(*)+1 FROM #TemporaryBalance)),@IncomeClosingJournalIdNo,@IncomeSummaryAccountIdNo,
                CASE WHEN @ProfitLossNet>0 THEN @ProfitLossNet ELSE 0 END,
                CASE WHEN @ProfitLossNet<0 THEN -@ProfitLossNet ELSE 0 END,
                0,N'Fiscal year '+CONVERT(nvarchar(4),@FiscalYear)+N' Income Summary offset',1);

        IF ABS((SELECT SUM(CONVERT(decimal(19,4),Debit-Credit)) FROM dbo.GeneralJournalItem WHERE JournalIdNo=@IncomeClosingJournalIdNo))>@Tolerance
            THROW 52434, 'The generated Income Summary closing journal is unbalanced.', 1;

        IF ABS(@ProfitLossNet)>@Tolerance
        BEGIN
            INSERT INTO dbo.GeneralJournal (TransactionDate,ReferenceNo,Notes,Approved,Posted,ClosingJournal,Cancelled)
            VALUES (@FiscalYearEnd,N'FYE'+RIGHT(CONVERT(nvarchar(4),@FiscalYear),2)+N'-RE',N'Fiscal year '+CONVERT(nvarchar(4),@FiscalYear)+N' Income Summary transfer to Retained Earnings',1,1,1,0);
            SET @RetainedEarningsJournalIdNo=CONVERT(int,SCOPE_IDENTITY());

            INSERT INTO dbo.GeneralJournalItem (Sequence,JournalIdNo,AccountIdNo,Debit,Credit,RevCostCenterIdNo,Notes,Posted)
            VALUES
                (1,@RetainedEarningsJournalIdNo,@IncomeSummaryAccountIdNo,CASE WHEN @ProfitLossNet<0 THEN -@ProfitLossNet ELSE 0 END,CASE WHEN @ProfitLossNet>0 THEN @ProfitLossNet ELSE 0 END,0,N'Clear Income Summary',1),
                (2,@RetainedEarningsJournalIdNo,@RetainedEarningsAccountIdNo,CASE WHEN @ProfitLossNet>0 THEN @ProfitLossNet ELSE 0 END,CASE WHEN @ProfitLossNet<0 THEN -@ProfitLossNet ELSE 0 END,0,N'Transfer fiscal result to Retained Earnings',1);
        END;

        IF EXISTS (
            SELECT 1 FROM dbo.GlLedgers_View gl INNER JOIN dbo.Account a ON a.IdNo=gl.AccountIdNo
            WHERE gl.TransactionDate>=@FiscalYearStart AND gl.TransactionDate<@NextFiscalYearStart AND gl.Posted=1 AND a.AccountGroup IN ('R','X')
            GROUP BY gl.AccountIdNo HAVING ABS(SUM(CONVERT(decimal(19,4),gl.Debit-gl.Credit)))>@Tolerance
        )
            THROW 52435, 'Revenue, expense, or Income Summary balances did not clear to zero.', 1;

        INSERT INTO dbo.AccountBalance ([Year],AccountIdNo,Debit,Credit)
        SELECT @FiscalYear+1,AccountIdNo,Debit,Credit FROM #ProposedOpening;
        IF @@ROWCOUNT<>@OpeningRows
            THROW 52436, 'The next-year opening snapshot row count did not match the preview calculation.', 1;
        IF ABS((SELECT SUM(CONVERT(decimal(19,4),ISNULL(Debit,0)-ISNULL(Credit,0))) FROM dbo.AccountBalance WHERE [Year]=@FiscalYear+1))>@Tolerance
            THROW 52437, 'The inserted next-year opening snapshot is unbalanced.', 1;

        IF @FiscalYear=2025
        BEGIN
            UPDATE dbo.MonthlyClosePeriod
            SET Status='Closed',ClosedBy=@ApplicationUser,ClosedAt=SYSDATETIME()
            WHERE FiscalYear=@FiscalYear AND Status='Approved';
            SET @LegacyMonthsNormalized=@@ROWCOUNT;
        END;

        UPDATE dbo.LastPosting
        SET LastPostingDateOld=LastPostingDate,LastPostingDate=@FiscalYearEnd
        WHERE TransactionName='LastFiscalYearEnd';
        IF @@ROWCOUNT<>1
            THROW 52438, 'LastFiscalYearEnd could not be updated safely.', 1;

        INSERT INTO dbo.FiscalYearCloseRun (
            RunId,FiscalYear,FiscalYearStart,FiscalYearEnd,OpeningYear,Status,
            IncomeSummaryAccountIdNo,RetainedEarningsAccountIdNo,FiscalResult,FiscalResultAmount,
            IncomeClosingJournalIdNo,RetainedEarningsJournalIdNo,OpeningRows,OpeningDebit,OpeningCredit,
            JanuaryBeginningInventory,DecemberEndingInventory,InventoryNetEffect,LegacyMonthsNormalized,
            WarningsAcknowledged,ApprovalNotes,ApplicationUser,SqlLogin,FinalizedAt,ServerName,DatabaseName
        )
        VALUES (
            @RunId,@FiscalYear,@FiscalYearStart,@FiscalYearEnd,@FiscalYear+1,'Finalized',
            @IncomeSummaryAccountIdNo,@RetainedEarningsAccountIdNo,
            CASE WHEN @ProfitLossNet>@Tolerance THEN 'LOSS' WHEN @ProfitLossNet<-@Tolerance THEN 'PROFIT' ELSE 'BREAK EVEN' END,
            ABS(@ProfitLossNet),@IncomeClosingJournalIdNo,@RetainedEarningsJournalIdNo,@OpeningRows,@OpeningDebit,@OpeningCredit,
            @JanuaryBeginningInventory,@DecemberEndingInventory,@InventoryNetEffect,@LegacyMonthsNormalized,
            1,@ApprovalNotes,@ApplicationUser,ORIGINAL_LOGIN(),SYSDATETIME(),CONVERT(nvarchar(128),SERVERPROPERTY('ServerName')),DB_NAME()
        );

        COMMIT TRANSACTION;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

        SELECT N'FISCAL YEAR FINALIZED' AS FinalizationStatus,@RunId AS RunId,@FiscalYear AS FiscalYear,@FiscalYearEnd AS FiscalYearEnd,
            @IncomeClosingJournalIdNo AS IncomeClosingJournalIdNo,@RetainedEarningsJournalIdNo AS RetainedEarningsJournalIdNo,
            CASE WHEN @ProfitLossNet>@Tolerance THEN N'LOSS' WHEN @ProfitLossNet<-@Tolerance THEN N'PROFIT' ELSE N'BREAK EVEN' END AS FiscalResult,
            ABS(@ProfitLossNet) AS FiscalResultAmount,@OpeningRows AS OpeningRows,@OpeningDebit AS OpeningDebit,@OpeningCredit AS OpeningCredit,
            @LegacyMonthsNormalized AS LegacyMonthsNormalized,@ApplicationUser AS FinalizedBy;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT>0 ROLLBACK TRANSACTION;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        THROW;
    END CATCH;
END;
