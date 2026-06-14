CREATE VIEW [dbo].[custom_att_rpt_DailyPunchAudit]
AS
/*
Report: Daily punch audit report

Purpose:
- One row per employee attendance date
- Exposes the first two punch pairs stored on custom_att_fact_DailyAttendance
- Shows raw transaction punches and the fact row's effective punches
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

    raw_punches.AllRawPunches,
    effective_punches.AllEffectivePunches,
    schedule_info.EffectiveShiftAlias,
    schedule_info.EffectiveTimeTableAlias,
    schedule_info.ScheduleType,

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
OUTER APPLY
(
    SELECT TOP (1)
        sh.alias AS EffectiveShiftAlias,
        ti.alias AS EffectiveTimeTableAlias,
        schedule_candidates.schedule_type AS ScheduleType
    FROM
    (
        SELECT
            1 AS source_priority,
            ts.id AS source_row_id,
            CAST('Temporary' AS varchar(30)) AS schedule_type,
            CAST(NULL AS int) AS shift_id,
            ts.time_interval_id,
            ts.att_date AS schedule_anchor_date
        FROM dbo.att_temporaryschedule ts
        WHERE ISNULL(ts.status, 0) = 0
          AND ts.employee_id = f.emp_id
          AND ts.att_date = f.att_date

        UNION ALL

        SELECT
            2 AS source_priority,
            s.id AS source_row_id,
            CAST('Employee' AS varchar(30)) AS schedule_type,
            s.shift_id,
            CAST(NULL AS int) AS time_interval_id,
            s.start_date AS schedule_anchor_date
        FROM dbo.att_attschedule s
        WHERE s.employee_id = f.emp_id
          AND f.att_date >= s.start_date
          AND f.att_date <= s.end_date

        UNION ALL

        SELECT
            3 AS source_priority,
            gs.id AS source_row_id,
            CAST('Group' AS varchar(30)) AS schedule_type,
            gs.shift_id,
            CAST(NULL AS int) AS time_interval_id,
            gs.start_date AS schedule_anchor_date
        FROM dbo.att_groupschedule gs
        INNER JOIN dbo.att_attemployee ae
            ON ae.group_id = gs.group_id
        WHERE ISNULL(gs.status, 0) = 0
          AND ae.emp_id = f.emp_id
          AND gs.shift_id IS NOT NULL
          AND f.att_date >= gs.start_date
          AND f.att_date <= gs.end_date

        UNION ALL

        SELECT
            4 AS source_priority,
            ds.id AS source_row_id,
            CAST('Department' AS varchar(30)) AS schedule_type,
            ds.shift_id,
            CAST(NULL AS int) AS time_interval_id,
            ds.start_date AS schedule_anchor_date
        FROM dbo.att_departmentschedule ds
        WHERE ISNULL(ds.status, 0) = 0
          AND ds.department_id = e.department_id
          AND f.att_date >= ds.start_date
          AND f.att_date <= ds.end_date
    ) schedule_candidates
    LEFT JOIN dbo.att_attshift sh
        ON sh.id = schedule_candidates.shift_id
    OUTER APPLY
    (
        SELECT TOP (1)
            sd.time_interval_id
        FROM dbo.att_shiftdetail sd
        WHERE sd.shift_id = schedule_candidates.shift_id
          AND sd.day_index =
              CASE
                  WHEN ISNULL(sh.shift_cycle, 1) > 1
                  THEN
                      (
                          (
                              (
                                  DATEDIFF(
                                      DAY,
                                      DATEADD(
                                          DAY,
                                          -((DATEDIFF(DAY, '19000101', schedule_candidates.schedule_anchor_date) % 7 + 7) % 7),
                                          schedule_candidates.schedule_anchor_date
                                      ),
                                      f.att_date
                                  ) / 7
                              )
                              % ISNULL(sh.shift_cycle, 1)
                          ) * 7
                          + ((DATEDIFF(DAY, '19000101', f.att_date) % 7 + 7) % 7)
                          + 1
                      )
                      % (ISNULL(sh.shift_cycle, 1) * 7)
                  ELSE
                      (DATEDIFF(DAY, '19000107', f.att_date) % 7 + 7) % 7
              END
    ) shift_detail
    LEFT JOIN dbo.att_timeinterval ti
        ON ti.id = COALESCE(schedule_candidates.time_interval_id, shift_detail.time_interval_id)
    ORDER BY
        schedule_candidates.source_priority,
        schedule_candidates.source_row_id DESC
) schedule_info
OUTER APPLY
(
    SELECT
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
