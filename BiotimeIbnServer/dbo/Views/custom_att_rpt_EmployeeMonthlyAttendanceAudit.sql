CREATE VIEW [dbo].[custom_att_rpt_EmployeeMonthlyAttendanceAudit]
AS
/*
Report: Employee monthly attendance audit log

Purpose:
- One row per employee attendance date
- Uses Custom_att_fact_dailyAttendance_View as the main source
- Shows effective schedule, daily punches, late minutes, and early-out minutes
*/
SELECT
    dav.att_date AS [Date of Attendance],
    dav.att_date AS [Date],
    dav.year_no AS AttendanceYear,
    dav.month_no AS AttendanceMonth,
    dav.emp_id AS emp_id,
    dav.emp_code,
    dav.emp_code_name,

    dav.effective_timetable_name AS EffectiveScheduleAlias,
    dav.effective_scheduled_in_datetime AS EffectiveScheduledIn,
    dav.effective_scheduled_out_datetime AS EffectiveScheduledOut,

    dav.first_clock_in AS FirstPunchIn,
    dav.last_clock_out AS LastPunchOut,
    punch_lists.PunchIns,
    punch_lists.PunchOuts,
    dav.corrected AS Corrected,
    dav.effective_punch_in1 AS EffectivePunchIn1,
    dav.effective_punch_out1 AS EffectivePunchOut1,
    dav.effective_punch_in2 AS EffectivePunchIn2,
    dav.effective_punch_out2 AS EffectivePunchOut2,
    punch_lists.AllPunches,

    dav.late_minutes AS LateMinutes,
    dav.early_out_minutes AS EarlyOutMinutes,
    dav.actual_late_minutes AS ActualLateMinutes,
    dav.actual_early_out_minutes AS ActualEarlyOutMinutes,

    dav.recomputed_worked_minutes AS WorkedMinutes,
    dav.regular_worked_minutes AS RegularWorkedMinutes,
    dav.ot_minutes AS OvertimeMinutes,
    dav.worked_hours AS WorkedHours,
    dav.regular_worked_hours AS RegularWorkedHours,
    dav.ot_hours AS OvertimeHours,

    dav.daily_status AS DailyStatus,
    dav.business_day_type AS BusinessDayType,
    dav.attendance_status AS AttendanceStatus,
    dav.punch_status AS PunchStatus,
    dav.anomaly_flag AS AnomalyFlag,
    dav.reconciliation_status AS ReconciliationStatus
FROM dbo.Custom_att_fact_dailyAttendance_View dav
OUTER APPLY
(
    SELECT
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(8), CAST(t.punch_time AS time), 108)
                FROM dbo.iclock_transaction t
                WHERE t.emp_id = dav.emp_id
                  AND t.punch_state IN ('0', '4')
                  AND t.punch_time >= DATEADD(HOUR, 3, CAST(dav.att_date AS datetime2(0)))
                  AND t.punch_time < DATEADD(HOUR, 3, DATEADD(DAY, 1, CAST(dav.att_date AS datetime2(0))))
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
                WHERE t.emp_id = dav.emp_id
                  AND t.punch_state IN ('1', '5')
                  AND t.punch_time >= DATEADD(HOUR, 3, CAST(dav.att_date AS datetime2(0)))
                  AND t.punch_time < DATEADD(HOUR, 3, DATEADD(DAY, 1, CAST(dav.att_date AS datetime2(0))))
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
                WHERE t.emp_id = dav.emp_id
                  AND t.punch_time >= DATEADD(HOUR, 3, CAST(dav.att_date AS datetime2(0)))
                  AND t.punch_time < DATEADD(HOUR, 3, DATEADD(DAY, 1, CAST(dav.att_date AS datetime2(0))))
                ORDER BY
                    t.punch_time,
                    t.id
                FOR XML PATH('')
            ),
            1,
            1,
            ''
        ) AS AllPunches
) punch_lists;

GO
