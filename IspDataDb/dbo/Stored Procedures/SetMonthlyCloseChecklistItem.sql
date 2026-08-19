CREATE OR ALTER PROCEDURE [dbo].[SetMonthlyCloseChecklistItem]
    @FiscalYear int,
    @FiscalMonth int,
    @ChecklistCode varchar(40),
    @Completed bit,
    @Notes nvarchar(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @FiscalYear NOT BETWEEN 2000 AND 2099 THROW 52311, 'FiscalYear must be between 2000 and 2099.', 1;
    IF @FiscalMonth NOT BETWEEN 1 AND 12 THROW 52312, 'FiscalMonth must be between 1 and 12.', 1;
    EXEC dbo.InitializeMonthlyCloseChecklist @FiscalYear, @FiscalMonth;
    IF EXISTS (SELECT 1 FROM dbo.MonthlyClosePeriod WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth AND Status <> 'Open')
        THROW 52313, 'The monthly close is already approved or closed.', 1;
    IF @FiscalMonth > 1 AND NOT EXISTS (
        SELECT 1
        FROM dbo.MonthlyCloseChecklist
        WHERE FiscalYear = @FiscalYear
          AND FiscalMonth = @FiscalMonth - 1
          AND ChecklistCode = @ChecklistCode
          AND Completed = 1
    )
        THROW 52315, 'The corresponding checklist item in the previous month must be completed first.', 1;
    UPDATE dbo.MonthlyCloseChecklist SET Completed = @Completed, CompletedBy = CASE WHEN @Completed = 1 THEN ORIGINAL_LOGIN() ELSE NULL END, CompletedAt = CASE WHEN @Completed = 1 THEN SYSDATETIME() ELSE NULL END, Notes = @Notes
    WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth AND ChecklistCode = @ChecklistCode;
    IF @@ROWCOUNT = 0 THROW 52314, 'Unknown monthly close checklist code.', 1;
    SELECT * FROM dbo.MonthlyCloseChecklist WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth ORDER BY ChecklistCode;
END;
