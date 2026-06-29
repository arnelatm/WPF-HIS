CREATE PROCEDURE [dbo].[custom_att_DailyEmployeePunchAudit_Crystal]
    @BeginningDate varchar(30),
    @EndingDate    varchar(30),
    @EmpCode       nvarchar(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DateFrom date;
    DECLARE @DateTo date;

    SET @EmpCode = NULLIF(LTRIM(RTRIM(@EmpCode)), '');

    SET @DateFrom = COALESCE(
        TRY_CONVERT(date, @BeginningDate, 120),
        TRY_CONVERT(date, @BeginningDate, 23),
        TRY_CONVERT(date, @BeginningDate, 103),
        TRY_CONVERT(date, @BeginningDate, 101),
        TRY_CONVERT(date, @BeginningDate)
    );
    SET @DateTo = COALESCE(
        TRY_CONVERT(date, @EndingDate, 120),
        TRY_CONVERT(date, @EndingDate, 23),
        TRY_CONVERT(date, @EndingDate, 103),
        TRY_CONVERT(date, @EndingDate, 101),
        TRY_CONVERT(date, @EndingDate)
    );

    IF @DateFrom IS NULL OR @DateTo IS NULL
    BEGIN
        RAISERROR('Invalid Daily Employee Punch Audit Report date parameter.', 16, 1);
        RETURN;
    END;

    EXEC dbo.custom_att_GetDailySchedulePunchAudit
        @BeginningDate = @DateFrom,
        @EndDate = @DateTo,
        @EmpID = NULL,
        @IssuesOnly = 0,
        @EmpCode = @EmpCode;
END;
