CREATE PROCEDURE dbo.custom_att_GetEmployeeMonthlyAttendanceAudit
    @EmpID            int,
    @AttendanceYear   int,
    @AttendanceMonth  int
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DateFrom date = DATEFROMPARTS(@AttendanceYear, @AttendanceMonth, 1);
    DECLARE @DateToExclusive date = DATEADD(MONTH, 1, @DateFrom);

    SELECT
        f.att_date AS [Date of Attendance],
        f.year_no AS AttendanceYear,
        f.month_no AS AttendanceMonth,
        f.emp_id,
        f.emp_code,
        dsa.emp_code_name,

        dsa.EffectiveScheduleAlias,
        dpa.EffectiveShiftAlias,
        dpa.EffectiveTimeTableAlias,
        dpa.ScheduleType,
        dsa.EffectiveScheduleSource,
        dsa.ScheduledIn,
        dsa.ScheduledOut,

        dpa.FirstClockInUsed AS FirstPunchIn,
        dpa.LastClockOutUsed AS LastPunchOut,
        dpa.PunchIn1 AS EffectivePunchIn1,
        dpa.PunchOut1 AS EffectivePunchOut1,
        dpa.PunchIn2 AS EffectivePunchIn2,
        dpa.PunchOut2 AS EffectivePunchOut2,
        dpa.AllRawPunches,
        dpa.AllEffectivePunches,
        dpa.TotalPunches,
        dpa.RawPunch1,
        dpa.RawPunch2,
        dpa.RawPunch3,
        dpa.RawPunch4,
        dpa.RawPunch5,
        dpa.RawPunch6,
        dpa.PunchExceptionType,
        dpa.DerivedPunchStatus,

        dsa.InOffsetMinutes,
        dsa.OutOffsetMinutes,
        dsa.SchedulePunchCheck,

        f.late_minutes AS LateMinutes,
        f.early_out_minutes AS EarlyOutMinutes,
        f.actual_late_minutes AS ActualLateMinutes,
        f.actual_early_out_minutes AS ActualEarlyOutMinutes,
        f.excess_minutes AS ExcessMinutes,
        f.actual_excess_minutes AS ActualExcessMinutes,
        f.shortfall_minutes AS ShortfallMinutes,
        f.work_gap_minutes AS WorkGapMinutes,

        f.recomputed_worked_minutes AS WorkedMinutes,
        f.regular_worked_minutes AS RegularWorkedMinutes,
        f.ot_minutes AS OvertimeMinutes,
        f.worked_hours AS WorkedHours,
        f.regular_worked_hours AS RegularWorkedHours,
        f.ot_hours AS OvertimeHours,
        f.required_scheduled_hours AS RequiredScheduledHours,
        f.work_completion_pct AS WorkCompletionPct,

        f.daily_status AS DailyStatus,
        f.business_day_type AS BusinessDayType,
        f.attendance_status AS AttendanceStatus,
        f.punch_status AS PunchStatus,
        f.anomaly_flag AS AnomalyFlag,
        f.anomaly_group AS AnomalyGroup,
        f.needs_payroll_review AS NeedsPayrollReview,
        f.reconciliation_status AS ReconciliationStatus,
        f.reconciliation_variance_minutes AS ReconciliationVarianceMinutes,
        f.corrected AS Corrected,
        f.[Leaves]
    FROM dbo.custom_att_fact_DailyAttendance f
    LEFT JOIN dbo.custom_att_audit_DailyPunchAudit dpa
        ON dpa.emp_id = f.emp_id
       AND dpa.[Date] = f.att_date
    LEFT JOIN dbo.custom_att_audit_DailySchedulePunchAudit dsa
        ON dsa.emp_id = f.emp_id
       AND dsa.[Date] = f.att_date
    WHERE f.emp_id = @EmpID
      AND f.att_date >= @DateFrom
      AND f.att_date < @DateToExclusive
    ORDER BY
        f.att_date
    OPTION (RECOMPILE);
END;

GO
