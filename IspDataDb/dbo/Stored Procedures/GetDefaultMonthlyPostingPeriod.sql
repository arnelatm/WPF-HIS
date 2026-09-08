CREATE PROCEDURE [dbo].[GetDefaultMonthlyPostingPeriod]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ClosedThrough date = (
        SELECT LastPostingDate
        FROM dbo.LastPosting
        WHERE TransactionName = 'Closed Period'
    );
    DECLARE @ClosedPeriodStart date;
    DECLARE @DefaultPeriodStart date;
    DECLARE @DefaultReason varchar(40);

    IF @ClosedThrough IS NULL
    BEGIN
        SET @DefaultPeriodStart = DATEFROMPARTS(YEAR(DATEADD(month, -1, GETDATE())), MONTH(DATEADD(month, -1, GETDATE())), 1);
        SET @DefaultReason = 'Previous calendar month';
    END
    ELSE
    BEGIN
        SET @ClosedPeriodStart = DATEFROMPARTS(YEAR(@ClosedThrough), MONTH(@ClosedThrough), 1);

        IF EXISTS (SELECT 1 FROM dbo.ApJournal WHERE TransactionDate >= @ClosedPeriodStart AND TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND ISNULL(Posted, 0) = 0)
           OR EXISTS (SELECT 1 FROM dbo.ArJournal WHERE TransactionDate >= @ClosedPeriodStart AND TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND ISNULL(Posted, 0) = 0)
           OR EXISTS (SELECT 1 FROM dbo.CdJournal WHERE TransactionDate >= @ClosedPeriodStart AND TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND ISNULL(Posted, 0) = 0)
           OR EXISTS (SELECT 1 FROM dbo.CkJournal WHERE TransactionDate >= @ClosedPeriodStart AND TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND ISNULL(Posted, 0) = 0)
           OR EXISTS (SELECT 1 FROM dbo.CashReceiptJournal WHERE TransactionDate >= @ClosedPeriodStart AND TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND ISNULL(Posted, 0) = 0)
           OR EXISTS (SELECT 1 FROM dbo.ErJournal WHERE TransactionDate >= @ClosedPeriodStart AND TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND ISNULL(Posted, 0) = 0)
           OR EXISTS (SELECT 1 FROM dbo.GeneralJournal WHERE TransactionDate >= @ClosedPeriodStart AND TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND ISNULL(Posted, 0) = 0)
           OR EXISTS (SELECT 1 FROM dbo.PcJournal WHERE TransactionDate >= @ClosedPeriodStart AND TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND ISNULL(Posted, 0) = 0)
           OR EXISTS (SELECT 1 FROM dbo.SalesJournal WHERE TransactionDate >= @ClosedPeriodStart AND TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND ISNULL(Posted, 0) = 0)
           OR EXISTS (SELECT 1 FROM dbo.ApJournalItem i INNER JOIN dbo.ApJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @ClosedPeriodStart AND h.TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND i.Posted = 0)
           OR EXISTS (SELECT 1 FROM dbo.ArJournalItem i INNER JOIN dbo.ArJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @ClosedPeriodStart AND h.TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND i.Posted = 0)
           OR EXISTS (SELECT 1 FROM dbo.CdJournalItem i INNER JOIN dbo.CdJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @ClosedPeriodStart AND h.TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND i.Posted = 0)
           OR EXISTS (SELECT 1 FROM dbo.CkJournalItem i INNER JOIN dbo.CkJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @ClosedPeriodStart AND h.TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND i.Posted = 0)
           OR EXISTS (SELECT 1 FROM dbo.CashReceiptJournalItem i INNER JOIN dbo.CashReceiptJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @ClosedPeriodStart AND h.TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND i.Posted = 0)
           OR EXISTS (SELECT 1 FROM dbo.ErJournalItem i INNER JOIN dbo.ErJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @ClosedPeriodStart AND h.TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND i.Posted = 0)
           OR EXISTS (SELECT 1 FROM dbo.GeneralJournalItem i INNER JOIN dbo.GeneralJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @ClosedPeriodStart AND h.TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND i.Posted = 0)
           OR EXISTS (SELECT 1 FROM dbo.PcJournalItem i INNER JOIN dbo.PcJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @ClosedPeriodStart AND h.TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND i.Posted = 0)
           OR EXISTS (SELECT 1 FROM dbo.SalesJournalItem i INNER JOIN dbo.SalesJournal h ON h.IdNo = i.JournalIdNo WHERE h.TransactionDate >= @ClosedPeriodStart AND h.TransactionDate < DATEADD(month, 1, @ClosedPeriodStart) AND i.Posted = 0)
        BEGIN
            SET @DefaultPeriodStart = @ClosedPeriodStart;
            SET @DefaultReason = 'Latest closed month needs posting';
        END
        ELSE
        BEGIN
            SET @DefaultPeriodStart = DATEADD(month, 1, @ClosedPeriodStart);
            SET @DefaultReason = 'Next month after closed period';
        END;
    END;

    SELECT YEAR(@DefaultPeriodStart) AS FiscalYear,
        MONTH(@DefaultPeriodStart) AS FiscalMonth,
        @DefaultPeriodStart AS PeriodStart,
        @DefaultReason AS DefaultReason,
        @ClosedThrough AS PeriodLockedThrough;
END;
