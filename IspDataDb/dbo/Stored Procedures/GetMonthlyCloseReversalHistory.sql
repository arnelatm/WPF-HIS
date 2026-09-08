CREATE PROCEDURE [dbo].[GetMonthlyCloseReversalHistory]
    @FiscalYear int,
    @FiscalMonth int
AS
BEGIN
    SET NOCOUNT ON;

    IF @FiscalYear NOT BETWEEN 2000 AND 2099
        THROW 52390, 'FiscalYear must be between 2000 and 2099.', 1;
    IF @FiscalMonth NOT BETWEEN 1 AND 12
        THROW 52391, 'FiscalMonth must be between 1 and 12.', 1;

    DECLARE @PeriodStart date = DATEFROMPARTS(@FiscalYear, @FiscalMonth, 1);
    DECLARE @PeriodEnd date = DATEADD(day, -1, DATEADD(month, 1, @PeriodStart));

    SELECT ActionAt,
        ActionType,
        ActionBy,
        ChecklistCode,
        Details,
        PreviousStatus,
        NewStatus,
        HeadersChanged,
        ItemsChanged,
        PreviousNote,
        Reason
    FROM (
        SELECT r.ReversedAt AS ActionAt,
            CONVERT(varchar(20), 'Unpost') AS ActionType,
            r.ReversedBy AS ActionBy,
            CONVERT(varchar(40), NULL) AS ChecklistCode,
            CONVERT(nvarchar(200), N'Posting run ' + CONVERT(nvarchar(36), r.RunId)) AS Details,
            CONVERT(varchar(20), 'Posted') AS PreviousStatus,
            CONVERT(varchar(20), 'Unposted') AS NewStatus,
            r.HeadersChanged,
            r.ItemsChanged,
            CONVERT(nvarchar(1000), NULL) AS PreviousNote,
            CONVERT(nvarchar(500), NULL) AS Reason,
            r.IdNo AS SortId
        FROM dbo.FiscalYearJournalPostingRun r
        WHERE r.Status = 'Reversed'
          AND r.FiscalYearStart = @PeriodStart
          AND r.FiscalYearEnd = @PeriodEnd

        UNION ALL

        SELECT r.ReopenedAt,
            CONVERT(varchar(20), 'Unclose'),
            r.ReopenedBy,
            CONVERT(varchar(40), NULL),
            CONVERT(nvarchar(200), N'Period lock ' + CONVERT(nvarchar(10), r.PreviousClosedThrough, 120) + N' to ' + CONVERT(nvarchar(10), r.NewClosedThrough, 120)),
            CONVERT(varchar(20), 'Closed'),
            CONVERT(varchar(20), 'Approved'),
            CONVERT(int, NULL),
            CONVERT(int, NULL),
            CONVERT(nvarchar(1000), NULL),
            CONVERT(nvarchar(500), NULL),
            r.IdNo
        FROM dbo.MonthlyClosePeriodReversal r
        WHERE r.FiscalYear = @FiscalYear AND r.FiscalMonth = @FiscalMonth

        UNION ALL

        SELECT r.ReversedAt,
            CONVERT(varchar(20), 'Uncomplete'),
            r.ReversedBy,
            r.ChecklistCode,
            CONVERT(nvarchar(200), N'Checklist item returned for correction'),
            r.PreviousPeriodStatus,
            CONVERT(varchar(20), 'Open'),
            CONVERT(int, NULL),
            CONVERT(int, NULL),
            r.PreviousNotes,
            r.ReversalReason,
            r.IdNo
        FROM dbo.MonthlyCloseChecklistReversal r
        WHERE r.FiscalYear = @FiscalYear AND r.FiscalMonth = @FiscalMonth
    ) history
    ORDER BY ActionAt DESC, SortId DESC;
END;
