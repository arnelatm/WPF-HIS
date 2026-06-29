CREATE VIEW [dbo].[custom_att_audit_DailyPunchAudit]
AS
/*
Report: Daily punch audit report

Purpose:
- One row per employee attendance date
- Exposes the first two punch pairs stored on custom_att_fact_DailyAttendance
- Shows raw transaction punches and the fact row's effective punches
- Exposes normalized punch slots and odd-punch exception classification
- Includes the effective schedule alias and source type for the day
- Keeps the query narrow so employee/date filters can use the fact table key
*/
SELECT
    f.att_date AS [Date],
    f.emp_id AS emp_id,
    f.emp_code,
    LTRIM(RTRIM(ISNULL(e.first_name, '') + ' ' + ISNULL(e.last_name, ''))) AS EmployeeName,

    CONVERT(varchar(8), CAST(f.effective_punch_in1 AS time), 108) AS PunchIn1,
    CONVERT(varchar(8), CAST(f.effective_punch_out1 AS time), 108) AS PunchOut1,
    CONVERT(varchar(8), CAST(f.effective_punch_in2 AS time), 108) AS PunchIn2,
    CONVERT(varchar(8), CAST(f.effective_punch_out2 AS time), 108) AS PunchOut2,
    CONVERT(varchar(8), CAST(f.first_clock_in AS time), 108) AS FirstClockInUsed,
    CONVERT(varchar(8), CAST(f.last_clock_out AS time), 108) AS LastClockOutUsed,
    latest_raw_punch.LatestRawPunchUsed,
    latest_raw_punch.LatestRawPunchState,

    raw_punch_slots.TotalPunches,
    CONVERT(varchar(8), CAST(raw_punch_slots.Punch1 AS time), 108) AS RawPunch1,
    CONVERT(varchar(8), CAST(raw_punch_slots.Punch2 AS time), 108) AS RawPunch2,
    CONVERT(varchar(8), CAST(raw_punch_slots.Punch3 AS time), 108) AS RawPunch3,
    CONVERT(varchar(8), CAST(raw_punch_slots.Punch4 AS time), 108) AS RawPunch4,
    CONVERT(varchar(8), CAST(raw_punch_slots.Punch5 AS time), 108) AS RawPunch5,
    CONVERT(varchar(8), CAST(raw_punch_slots.Punch6 AS time), 108) AS RawPunch6,
    CASE
        WHEN raw_punch_slots.TotalPunches = 1 THEN 'Only One Punch'
        WHEN raw_punch_slots.TotalPunches = 3 THEN 'Three Punches / One Missing'
        WHEN raw_punch_slots.TotalPunches = 5 THEN 'Five Punches / Unpaired'
        WHEN raw_punch_slots.TotalPunches % 2 = 1 THEN 'Odd Number of Punches'
        ELSE 'OK'
    END AS PunchExceptionType,

    raw_punches.AllRawPunches,
    effective_punches.AllEffectivePunches,
    sh.alias AS EffectiveShiftAlias,
    ti.alias AS EffectiveTimeTableAlias,
    es.effective_schedule_source AS ScheduleType,
    ISNULL(
        f.is_flex_duty,
        CASE
            WHEN ISNULL(ti.use_mode, 0) = 1
             AND ISNULL(es.resolved_is_off_day, 0) = 0
             AND ISNULL(es.effective_required_work_minutes, 0) > 0
                THEN CAST(1 AS bit)
            ELSE CAST(0 AS bit)
        END
    ) AS IsFlexDuty,
    CASE
        WHEN ISNULL(
            f.is_flex_duty,
            CASE
                WHEN ISNULL(ti.use_mode, 0) = 1
                 AND ISNULL(es.resolved_is_off_day, 0) = 0
                 AND ISNULL(es.effective_required_work_minutes, 0) > 0
                    THEN CAST(1 AS bit)
                ELSE CAST(0 AS bit)
            END
        ) = 1 THEN 'Yes'
        ELSE 'No'
    END AS FlexDuty,
    ISNULL(f.flex_duty_minutes, 0) AS FlexDutyMinutes,
    ISNULL(ti.use_mode, 0) AS TimeTableUseMode,

    f.late_minutes AS LateMinutes,
    f.early_out_minutes AS EarlyOutMinutes,
    f.excess_minutes AS ExcessMinutes,

    f.actual_late_minutes AS ActualLateMinutes,
    f.actual_early_out_minutes AS ActualEarlyOutMinutes,
    f.actual_excess_minutes AS ActualExcessMinutes,
    f.recomputed_worked_minutes AS WorkedMinutes,
    f.regular_worked_minutes AS RegularWorkedMinutes,
    f.ot_minutes AS OvertimeMinutes,
    CASE
        WHEN ISNULL(f.recomputed_worked_minutes, 0) > 0 THEN 'OK'
        WHEN f.first_clock_in IS NULL AND f.last_clock_out IS NULL THEN 'NoPunch'
        WHEN f.first_clock_in IS NOT NULL AND f.last_clock_out IS NULL THEN 'MissingOut'
        WHEN f.first_clock_in IS NULL AND f.last_clock_out IS NOT NULL THEN 'MissingIn'
        ELSE 'OK'
    END AS DerivedPunchStatus,
    f.attendance_status AS AttendanceStatus,
    f.anomaly_flag AS AnomalyFlag,
    f.reconciliation_status AS ReconciliationStatus
FROM dbo.custom_att_fact_DailyAttendance f
LEFT JOIN dbo.personnel_employee e
    ON e.id = f.emp_id
LEFT JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
    ON es.emp_id = f.emp_id
   AND es.att_date = f.att_date
LEFT JOIN dbo.att_attshift sh
    ON sh.id = es.effective_shift_id
LEFT JOIN dbo.att_timeinterval ti
    ON ti.id = es.effective_time_interval_id
OUTER APPLY
(
    SELECT
        COUNT(*) AS TotalPunches,
        MAX(CASE WHEN numbered_punches.punch_no = 1 THEN numbered_punches.punch_time END) AS Punch1,
        MAX(CASE WHEN numbered_punches.punch_no = 2 THEN numbered_punches.punch_time END) AS Punch2,
        MAX(CASE WHEN numbered_punches.punch_no = 3 THEN numbered_punches.punch_time END) AS Punch3,
        MAX(CASE WHEN numbered_punches.punch_no = 4 THEN numbered_punches.punch_time END) AS Punch4,
        MAX(CASE WHEN numbered_punches.punch_no = 5 THEN numbered_punches.punch_time END) AS Punch5,
        MAX(CASE WHEN numbered_punches.punch_no = 6 THEN numbered_punches.punch_time END) AS Punch6
    FROM
    (
        SELECT
            np.punch_time,
            ROW_NUMBER() OVER
            (
                ORDER BY
                    np.punch_time,
                    np.id
            ) AS punch_no
        FROM dbo.custom_att_fnd_NormalizedPunches np
        WHERE np.emp_id = f.emp_id
          AND np.work_date = f.att_date
    ) numbered_punches
) raw_punch_slots
OUTER APPLY
(
    SELECT
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(5), CAST(t.punch_time AS time), 108)
                    + CASE
                        WHEN t.punch_state IN ('0', '4') THEN 'i'
                        WHEN t.punch_state IN ('1', '5') THEN 'o'
                        ELSE CONVERT(varchar(10), t.punch_state)
                      END
                FROM dbo.iclock_transaction t
                WHERE t.emp_id = f.emp_id
                  AND t.punch_time >= DATEADD(HOUR, 3, CAST(f.att_date AS datetime2(0)))
                  AND t.punch_time < DATEADD(HOUR, 3, DATEADD(DAY, 1, CAST(f.att_date AS datetime2(0))))
                ORDER BY
                    t.punch_time,
                    t.id
                FOR XML PATH('')
            ),
            1,
            1,
            ''
        ) AS AllRawPunches
) raw_punches
OUTER APPLY
(
    SELECT TOP (1)
        CONVERT(varchar(8), CAST(t.punch_time AS time), 108) AS LatestRawPunchUsed,
        CASE
            WHEN t.punch_state IN ('0', '4') THEN 'IN'
            WHEN t.punch_state IN ('1', '5') THEN 'OUT'
            ELSE CONVERT(varchar(10), t.punch_state)
        END AS LatestRawPunchState
    FROM dbo.iclock_transaction t
    WHERE t.emp_id = f.emp_id
      AND t.punch_time >= CAST(f.att_date AS datetime2(0))
      AND t.punch_time < DATEADD(DAY, 1, CAST(f.att_date AS datetime2(0)))
    ORDER BY
        t.punch_time DESC,
        t.id DESC
) latest_raw_punch
OUTER APPLY
(
    SELECT
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(8), CAST(v.punch_datetime AS time), 108)
                    + '(' + v.punch_label + ')'
                FROM
                (
                    VALUES
                        (1, f.effective_punch_in1, 'IN'),
                        (2, f.effective_punch_out1, 'OUT'),
                        (3, f.effective_punch_in2, 'IN'),
                        (4, f.effective_punch_out2, 'OUT')
                ) v(sort_no, punch_datetime, punch_label)
                WHERE v.punch_datetime IS NOT NULL
                ORDER BY
                    v.sort_no
                FOR XML PATH('')
            ),
            1,
            1,
            ''
        ) AS AllEffectivePunches
) effective_punches
;

GO
