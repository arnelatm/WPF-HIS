CREATE PROCEDURE [dbo].[custom_att_GetDailyPunchAudit]
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
        TRY_CONVERT(date, @BeginningDate, 111),
        TRY_CONVERT(date, @BeginningDate, 103),
        TRY_CONVERT(date, @BeginningDate, 101),
        TRY_CONVERT(date, @BeginningDate)
    );

    SET @DateTo = COALESCE(
        TRY_CONVERT(date, @EndingDate, 120),
        TRY_CONVERT(date, @EndingDate, 111),
        TRY_CONVERT(date, @EndingDate, 103),
        TRY_CONVERT(date, @EndingDate, 101),
        TRY_CONVERT(date, @EndingDate)
    );

    IF @DateFrom IS NULL OR @DateTo IS NULL
    BEGIN
        RAISERROR('Invalid BeginningDate or EndingDate.', 16, 1);
        RETURN;
    END;

    IF @DateFrom > @DateTo
    BEGIN
        DECLARE @SwapDate date;
        SET @SwapDate = @DateFrom;
        SET @DateFrom = @DateTo;
        SET @DateTo = @SwapDate;
    END;

    SELECT
        [Date],
        emp_id,
        emp_code,
        EmployeeName,
        PunchIn1,
        PunchOut1,
        PunchIn2,
        PunchOut2,
        FirstClockInUsed,
        LastClockOutUsed,
        LatestRawPunchUsed,
        LatestRawPunchState,
        TotalPunches,
        RawPunch1,
        RawPunch2,
        RawPunch3,
        RawPunch4,
        RawPunch5,
        RawPunch6,
        PunchExceptionType,
        AllRawPunches,
        AllEffectivePunches,
        EffectiveShiftAlias,
        EffectiveTimeTableAlias,
        ScheduleType,
        IsFlexDuty,
        FlexDuty,
        FlexDutyMinutes,
        TimeTableUseMode,
        LateMinutes,
        EarlyOutMinutes,
        ExcessMinutes,
        ActualLateMinutes,
        ActualEarlyOutMinutes,
        ActualExcessMinutes,
        WorkedMinutes,
        RegularWorkedMinutes,
        OvertimeMinutes,
        DerivedPunchStatus,
        AttendanceStatus,
        AnomalyFlag,
        ReconciliationStatus
    FROM dbo.custom_att_audit_DailyPunchAudit
    WHERE [Date] >= @DateFrom
      AND [Date] <= @DateTo
      AND (@EmpCode IS NULL OR emp_code = @EmpCode)
    ORDER BY
        [Date],
        emp_code;
END;

GO
