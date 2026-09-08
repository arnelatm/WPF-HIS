CREATE PROCEDURE [dbo].[UncompleteMonthlyCloseChecklistItem]
    @FiscalYear int,
    @FiscalMonth int,
    @ChecklistCode varchar(40),
    @Reason nvarchar(500),
    @ApplicationUser sysname
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @FiscalYear NOT BETWEEN 2000 AND 2099
        THROW 52380, 'FiscalYear must be between 2000 and 2099.', 1;
    IF @FiscalMonth NOT BETWEEN 1 AND 12
        THROW 52381, 'FiscalMonth must be between 1 and 12.', 1;
    IF NULLIF(LTRIM(RTRIM(@ChecklistCode)), '') IS NULL
        THROW 52382, 'ChecklistCode is required.', 1;
    IF NULLIF(LTRIM(RTRIM(@Reason)), '') IS NULL
        THROW 52383, 'A correction reason is required when uncompleting a checklist item.', 1;
    IF NULLIF(LTRIM(RTRIM(@ApplicationUser)), '') IS NULL
        THROW 52384, 'ApplicationUser is required.', 1;

    DECLARE @PeriodStart date = DATEFROMPARTS(@FiscalYear, @FiscalMonth, 1);
    DECLARE @NextPeriodStart date = DATEADD(month, 1, @PeriodStart);
    DECLARE @PeriodEnd date = DATEADD(day, -1, @NextPeriodStart);
    DECLARE @LastFiscalYearEnd date;
    DECLARE @PeriodStatus varchar(20);
    DECLARE @PreviousCompletedBy sysname;
    DECLARE @PreviousCompletedAt datetime2(0);
    DECLARE @PreviousNotes nvarchar(1000);
    DECLARE @PreviousApprovedBy sysname;
    DECLARE @PreviousApprovedAt datetime2(0);
    DECLARE @PreviousApprovalNotes nvarchar(1000);
    DECLARE @CompletedItemFound bit = 0;
    DECLARE @LockResult int;

    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
        BEGIN TRANSACTION;

        EXEC @LockResult = sys.sp_getapplock
            @Resource = N'ISPDATA:MonthlyClose',
            @LockMode = 'Exclusive',
            @LockOwner = 'Transaction',
            @LockTimeout = 30000;
        IF @LockResult < 0
            THROW 52385, 'Could not acquire the monthly close lock.', 1;

        SELECT @LastFiscalYearEnd = LastPostingDate
        FROM dbo.LastPosting WITH (UPDLOCK, HOLDLOCK)
        WHERE TransactionName = 'LastFiscalYearEnd';

        IF @LastFiscalYearEnd IS NOT NULL AND @PeriodEnd <= @LastFiscalYearEnd
            THROW 52462, 'A finalized fiscal year checklist cannot be uncompleted.', 1;

        SELECT @PeriodStatus = Status,
            @PreviousApprovedBy = ApprovedBy,
            @PreviousApprovedAt = ApprovedAt,
            @PreviousApprovalNotes = ApprovalNotes
        FROM dbo.MonthlyClosePeriod WITH (UPDLOCK, HOLDLOCK)
        WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth;

        IF @PeriodStatus IS NULL
            THROW 52386, 'Load the monthly close checklist before uncompleting an item.', 1;
        IF @PeriodStatus = 'Closed'
            THROW 52387, 'Unpost and unclose the month before uncompleting a checklist item.', 1;

        SELECT @PreviousCompletedBy = CompletedBy,
            @PreviousCompletedAt = CompletedAt,
            @PreviousNotes = Notes,
            @CompletedItemFound = 1
        FROM dbo.MonthlyCloseChecklist WITH (UPDLOCK, HOLDLOCK)
        WHERE FiscalYear = @FiscalYear
          AND FiscalMonth = @FiscalMonth
          AND ChecklistCode = @ChecklistCode
          AND Completed = 1;

        IF @CompletedItemFound = 0
            THROW 52388, 'The selected checklist item is not completed.', 1;

        IF EXISTS (
            SELECT 1
            FROM dbo.MonthlyCloseChecklist WITH (UPDLOCK, HOLDLOCK)
            WHERE FiscalYear = YEAR(@NextPeriodStart)
              AND FiscalMonth = MONTH(@NextPeriodStart)
              AND ChecklistCode = @ChecklistCode
              AND Completed = 1
        )
            THROW 52389, 'Uncomplete the corresponding checklist item in the later month first.', 1;

        INSERT INTO dbo.MonthlyCloseChecklistReversal (
            FiscalYear, FiscalMonth, ChecklistCode,
            PreviousCompletedBy, PreviousCompletedAt, PreviousNotes,
            PreviousPeriodStatus, PreviousApprovedBy, PreviousApprovedAt, PreviousApprovalNotes,
            ReversalReason, ReversedBy, ReversedAt
        )
        VALUES (
            @FiscalYear, @FiscalMonth, @ChecklistCode,
            @PreviousCompletedBy, @PreviousCompletedAt, @PreviousNotes,
            @PeriodStatus, @PreviousApprovedBy, @PreviousApprovedAt, @PreviousApprovalNotes,
            @Reason, @ApplicationUser, SYSDATETIME()
        );

        UPDATE dbo.MonthlyCloseChecklist
        SET Completed = 0,
            CompletedBy = NULL,
            CompletedAt = NULL,
            Notes = NULL
        WHERE FiscalYear = @FiscalYear
          AND FiscalMonth = @FiscalMonth
          AND ChecklistCode = @ChecklistCode;

        IF @PeriodStatus = 'Approved'
        BEGIN
            UPDATE dbo.MonthlyClosePeriod
            SET Status = 'Open',
                ApprovedBy = NULL,
                ApprovedAt = NULL,
                ApprovalNotes = NULL
            WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth;
        END;

        COMMIT TRANSACTION;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

        SELECT p.FiscalYear,
            p.FiscalMonth,
            p.Status,
            c.ChecklistCode,
            c.Completed,
            c.CompletedBy,
            c.CompletedAt,
            c.Notes
        FROM dbo.MonthlyClosePeriod p
        INNER JOIN dbo.MonthlyCloseChecklist c
            ON c.FiscalYear = p.FiscalYear AND c.FiscalMonth = p.FiscalMonth
        WHERE p.FiscalYear = @FiscalYear AND p.FiscalMonth = @FiscalMonth
        ORDER BY c.ChecklistCode;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        THROW;
    END CATCH;
END;
