CREATE PROCEDURE [dbo].[custom_att_EmployeeAbsencesAndLeaveReport_Crystal]
    @BeginningDate varchar(30),
    @EndingDate    varchar(30)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DateFrom date;
    DECLARE @DateTo date;
    DECLARE @DateFromText varchar(10);
    DECLARE @DateToText varchar(10);

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
        RAISERROR('Invalid Employee Absences and Leave Report date parameter.', 16, 1);
        RETURN;
    END;

    SET @DateFromText = CONVERT(varchar(10), @DateFrom, 120);
    SET @DateToText = CONVERT(varchar(10), @DateTo, 120);

    EXEC dbo.custom_att_GetEmployeeAbsencesFromBaseData
        @DateFrom = @DateFromText,
        @DateTo = @DateToText,
        @EmpID = NULL,
        @DepartmentID = NULL,
        @GroupID = NULL,
        @ExcludeApprovedLeaves = 0
    WITH RESULT SETS
    (
        (
            DateAbsentFrom varchar(10),
            DateAbsentTo varchar(10),
            AbsentDays int,
            CalendarDays int,
            DeductibleAbsentDays int,
            EmployeeID int,
            EmployeeCode nvarchar(20),
            EmployeeName nvarchar(250),
            DepartmentID int,
            DepartmentCode nvarchar(50),
            DepartmentName nvarchar(200),
            GroupID int,
            GroupCode nvarchar(50),
            GroupName nvarchar(100),
            LeaveType nvarchar(50),
            EffectiveScheduleSource varchar(30),
            ScheduleAlias nvarchar(50),
            ScheduledInDateTime varchar(19),
            ScheduledOutDateTime varchar(19),
            ScheduledIn varchar(8),
            ScheduledOut varchar(8),
            RequiredHours decimal(10,2),
            RequiredMinutes int,
            RawPunchCount int,
            FirstRawPunchTime varchar(19),
            LastRawPunchTime varchar(19),
            ApprovedLeaveDays decimal(10,2),
            IsHoliday bit,
            IsResolvedOffDay bit
        )
    );
END;
