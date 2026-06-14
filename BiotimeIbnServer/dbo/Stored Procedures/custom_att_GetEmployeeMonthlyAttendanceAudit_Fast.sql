CREATE PROCEDURE dbo.custom_att_GetEmployeeMonthlyAttendanceAudit_Fast
    @EmpID            int,
    @AttendanceYear   int,
    @AttendanceMonth  int
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DateFrom date = DATEFROMPARTS(@AttendanceYear, @AttendanceMonth, 1);
    DECLARE @DateToExclusive date = DATEADD(MONTH, 1, @DateFrom);

    WITH daily AS
    (
        SELECT
            dav.emp_id,
            dav.emp_code,
            dav.emp_code_name,
            dav.att_date,
            dav.year_no,
            dav.month_no,
            dav.effective_timetable_name,
            dav.effective_scheduled_in_datetime,
            dav.effective_scheduled_out_datetime,
            dav.first_clock_in,
            dav.last_clock_out,
            dav.corrected,
            dav.effective_punch_in1,
            dav.effective_punch_out1,
            dav.effective_punch_in2,
            dav.effective_punch_out2,
            dav.late_minutes,
            dav.early_out_minutes,
            dav.actual_late_minutes,
            dav.actual_early_out_minutes,
            dav.recomputed_worked_minutes,
            dav.regular_worked_minutes,
            dav.ot_minutes,
            dav.worked_hours,
            dav.regular_worked_hours,
            dav.ot_hours,
            dav.daily_status,
            dav.business_day_type,
            dav.attendance_status,
            dav.punch_status,
            dav.anomaly_flag,
            dav.reconciliation_status
        FROM dbo.Custom_att_fact_dailyAttendance_View dav
        WHERE dav.emp_id = @EmpID
          AND dav.att_date >= @DateFrom
          AND dav.att_date < @DateToExclusive
    )
    SELECT
        d.att_date AS [Date of Attendance],
        d.year_no AS AttendanceYear,
        d.month_no AS AttendanceMonth,
        d.emp_id AS emp_id,
        d.emp_code,
        d.emp_code_name,

        d.effective_timetable_name AS EffectiveScheduleAlias,
        d.effective_scheduled_in_datetime AS EffectiveScheduledIn,
        d.effective_scheduled_out_datetime AS EffectiveScheduledOut,

        d.first_clock_in AS FirstPunchIn,
        d.last_clock_out AS LastPunchOut,
        punch_lists.PunchIns,
        punch_lists.PunchOuts,
        d.corrected AS Corrected,
        d.effective_punch_in1 AS EffectivePunchIn1,
        d.effective_punch_out1 AS EffectivePunchOut1,
        d.effective_punch_in2 AS EffectivePunchIn2,
        d.effective_punch_out2 AS EffectivePunchOut2,
        punch_lists.AllPunches,

        d.late_minutes AS LateMinutes,
        d.early_out_minutes AS EarlyOutMinutes,
        d.actual_late_minutes AS ActualLateMinutes,
        d.actual_early_out_minutes AS ActualEarlyOutMinutes,

        d.recomputed_worked_minutes AS WorkedMinutes,
        d.regular_worked_minutes AS RegularWorkedMinutes,
        d.ot_minutes AS OvertimeMinutes,
        d.worked_hours AS WorkedHours,
        d.regular_worked_hours AS RegularWorkedHours,
        d.ot_hours AS OvertimeHours,

        d.daily_status AS DailyStatus,
        d.business_day_type AS BusinessDayType,
        d.attendance_status AS AttendanceStatus,
        d.punch_status AS PunchStatus,
        d.anomaly_flag AS AnomalyFlag,
        d.reconciliation_status AS ReconciliationStatus
    FROM daily d
    OUTER APPLY
    (
        SELECT
            STUFF(
                (
                    SELECT
                        ',' + CONVERT(varchar(8), CAST(t.punch_time AS time), 108)
                    FROM dbo.iclock_transaction t
                    WHERE t.emp_id = d.emp_id
                      AND t.punch_state IN ('0', '4')
                      AND t.punch_time >= DATEADD(HOUR, 3, CAST(d.att_date AS datetime2(0)))
                      AND t.punch_time < DATEADD(HOUR, 3, DATEADD(DAY, 1, CAST(d.att_date AS datetime2(0))))
                    ORDER BY
                        t.punch_time,
                        t.id
                    FOR XML PATH('')
                ),
                1,
                1,
                ''
            ) AS PunchIns,
            STUFF(
                (
                    SELECT
                        ',' + CONVERT(varchar(8), CAST(t.punch_time AS time), 108)
                    FROM dbo.iclock_transaction t
                    WHERE t.emp_id = d.emp_id
                      AND t.punch_state IN ('1', '5')
                      AND t.punch_time >= DATEADD(HOUR, 3, CAST(d.att_date AS datetime2(0)))
                      AND t.punch_time < DATEADD(HOUR, 3, DATEADD(DAY, 1, CAST(d.att_date AS datetime2(0))))
                    ORDER BY
                        t.punch_time,
                        t.id
                    FOR XML PATH('')
                ),
                1,
                1,
                ''
            ) AS PunchOuts,
            STUFF(
                (
                    SELECT
                        ',' + CONVERT(varchar(8), CAST(t.punch_time AS time), 108)
                        + '('
                        + CASE
                            WHEN t.punch_state IN ('0', '4') THEN 'IN'
                            WHEN t.punch_state IN ('1', '5') THEN 'OUT'
                            ELSE CONVERT(varchar(10), t.punch_state)
                          END
                        + ')'
                    FROM dbo.iclock_transaction t
                    WHERE t.emp_id = d.emp_id
                      AND t.punch_time >= DATEADD(HOUR, 3, CAST(d.att_date AS datetime2(0)))
                      AND t.punch_time < DATEADD(HOUR, 3, DATEADD(DAY, 1, CAST(d.att_date AS datetime2(0))))
                    ORDER BY
                        t.punch_time,
                        t.id
                    FOR XML PATH('')
                ),
                1,
                1,
                ''
            ) AS AllPunches
    ) punch_lists
    ORDER BY
        d.att_date
    OPTION (RECOMPILE);
END
GO
