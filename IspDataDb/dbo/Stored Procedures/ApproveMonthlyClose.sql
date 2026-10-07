CREATE PROCEDURE [dbo].[ApproveMonthlyClose]
    @FiscalYear int,
    @FiscalMonth int,
    @ApprovalNotes nvarchar(500) = NULL,
    @ApplicationUser sysname = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    IF NULLIF(LTRIM(RTRIM(@ApplicationUser)), '') IS NULL THROW 52323, 'ApplicationUser is required.', 1;
    IF NOT EXISTS (
        SELECT 1
        FROM dbo.[User] u
        INNER JOIN dbo.GroupAccess ga ON ga.SecurityGroupIDNo = u.SecurityGroupIDNo
        INNER JOIN dbo.SecurityObject so ON so.IdNo = ga.SecurityObjectIDNo
        WHERE u.UserName = @ApplicationUser AND u.Active = 1
          AND so.SecurityObjectName = 'ApproveMonthlyPosting'
          AND ga.Visible = 1 AND ga.Editable = 1
    ) THROW 52324, 'The application user is not authorized to approve monthly posting.', 1;
    EXEC dbo.InitializeMonthlyCloseChecklist @FiscalYear, @FiscalMonth;
    IF EXISTS (SELECT 1 FROM dbo.MonthlyClosePeriod WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth AND Status <> 'Open')
        THROW 52321, 'The monthly close is already approved or closed.', 1;
    IF EXISTS (SELECT 1 FROM dbo.MonthlyCloseChecklist WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth AND Completed = 0)
        THROW 52322, 'All monthly close checklist items must be completed before approval.', 1;
    UPDATE dbo.MonthlyClosePeriod SET Status = 'Approved', ApprovedBy = @ApplicationUser, ApprovedAt = SYSDATETIME(), ApprovalNotes = @ApprovalNotes WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth;
    SELECT * FROM dbo.MonthlyClosePeriod WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth;
END;
