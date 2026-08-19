CREATE OR ALTER PROCEDURE [dbo].[ApproveMonthlyClose]
    @FiscalYear int,
    @FiscalMonth int,
    @ApprovalNotes nvarchar(500) = NULL,
    @ApplicationUser sysname = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    IF NULLIF(LTRIM(RTRIM(@ApplicationUser)), '') IS NULL THROW 52323, 'ApplicationUser is required.', 1;
    EXEC dbo.InitializeMonthlyCloseChecklist @FiscalYear, @FiscalMonth;
    IF EXISTS (SELECT 1 FROM dbo.MonthlyClosePeriod WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth AND Status <> 'Open')
        THROW 52321, 'The monthly close is already approved or closed.', 1;
    IF EXISTS (SELECT 1 FROM dbo.MonthlyCloseChecklist WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth AND Completed = 0)
        THROW 52322, 'All monthly close checklist items must be completed before approval.', 1;
    UPDATE dbo.MonthlyClosePeriod SET Status = 'Approved', ApprovedBy = @ApplicationUser, ApprovedAt = SYSDATETIME(), ApprovalNotes = @ApprovalNotes WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth;
    SELECT * FROM dbo.MonthlyClosePeriod WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth;
END;
