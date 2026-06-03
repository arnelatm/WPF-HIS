CREATE VIEW [dbo].[custom_att_rpt_DailyPunchCorrectionReport]
AS
/*
Report: Daily punch correction report

Purpose:
- One row per employee attendance date
- Exposes the first two worked punch pairs as report columns
- Shows all raw, effective, corrected, and adjusted punch times used for audit
- Carries the resolved effective schedule alias and daily exception minutes
*/
WITH paired_punches AS
(
    SELECT
        wi.emp_id,
        wi.work_date,
        wi.in_time,
        wi.out_time,
        ROW_NUMBER() OVER
        (
            PARTITION BY wi.emp_id, wi.work_date
            ORDER BY wi.in_time, wi.out_time, wi.in_segment_no, wi.out_segment_no
        ) AS pair_no
    FROM dbo.custom_att_fnd_WorkedIntervals wi
),
punch_slots AS
(
    SELECT
        pp.emp_id,
        pp.work_date,
        MAX(CASE WHEN pp.pair_no = 1 THEN pp.in_time END) AS PunchIn1,
        MAX(CASE WHEN pp.pair_no = 1 THEN pp.out_time END) AS PunchOut1,
        MAX(CASE WHEN pp.pair_no = 2 THEN pp.in_time END) AS PunchIn2,
        MAX(CASE WHEN pp.pair_no = 2 THEN pp.out_time END) AS PunchOut2
    FROM paired_punches pp
    WHERE pp.pair_no <= 2
    GROUP BY
        pp.emp_id,
        pp.work_date
)
SELECT
    f.att_date AS [Date],
    f.emp_id AS EmployeeId,
    e.emp_code AS EmployeeCode,
    LTRIM(RTRIM(ISNULL(e.first_name, '') + ' ' + ISNULL(e.last_name, ''))) AS EmployeeName,

    ps.PunchIn1,
    ps.PunchOut1,
    ps.PunchIn2,
    ps.PunchOut2,

    raw_punches.AllRawPunches,
    effective_punches.AllEffectivePunches,
    corrected_punches.AllCorrectedPunches,
    adjusted_pairs.AllAdjustedPunchPairs,

    ti.alias AS EffectiveScheduleAlias,
    es.effective_schedule_source AS EffectiveScheduleSource,
    es.effective_scheduled_in_datetime AS EffectiveScheduledIn,
    es.effective_scheduled_out_datetime AS EffectiveScheduledOut,

    f.late_minutes AS LateMinutes,
    f.early_out_minutes AS EarlyOutMinutes,
    f.excess_minutes AS ExcessMinutes,

    f.actual_late_minutes AS ActualLateMinutes,
    f.actual_early_out_minutes AS ActualEarlyOutMinutes,
    f.actual_excess_minutes AS ActualExcessMinutes,
    f.recomputed_worked_minutes AS WorkedMinutes,
    f.regular_worked_minutes AS RegularWorkedMinutes,
    f.ot_minutes AS OvertimeMinutes,
    f.punch_status AS PunchStatus,
    f.attendance_status AS AttendanceStatus,
    f.anomaly_flag AS AnomalyFlag,
    f.reconciliation_status AS ReconciliationStatus
FROM dbo.custom_att_fact_DailyAttendance f
LEFT JOIN dbo.personnel_employee e
    ON e.id = f.emp_id
LEFT JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
    ON es.emp_id = f.emp_id
   AND es.att_date = f.att_date
LEFT JOIN dbo.att_timeinterval ti
    ON ti.id = es.effective_time_interval_id
LEFT JOIN punch_slots ps
    ON ps.emp_id = f.emp_id
   AND ps.work_date = f.att_date
OUTER APPLY
(
    SELECT
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(8), CAST(np.punch_time AS time), 108)
                    + '('
                    + CASE
                        WHEN np.punch_state IN ('0', '4') THEN 'IN'
                        WHEN np.punch_state IN ('1', '5') THEN 'OUT'
                        ELSE CONVERT(varchar(10), np.punch_state)
                      END
                    + ')'
                FROM dbo.custom_att_fnd_NormalizedPunches np
                WHERE np.emp_id = f.emp_id
                  AND np.work_date = f.att_date
                ORDER BY
                    np.punch_time,
                    np.id
                FOR XML PATH('')
            ),
            1,
            1,
            ''
        ) AS AllRawPunches
) raw_punches
OUTER APPLY
(
    SELECT
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(8), CAST(ep.punch_datetime AS time), 108)
                    + '('
                    + CASE
                        WHEN ep.punch_state IN ('0', '4') THEN 'IN'
                        WHEN ep.punch_state IN ('1', '5') THEN 'OUT'
                        ELSE CONVERT(varchar(10), ep.punch_state)
                      END
                    + CASE
                        WHEN ISNULL(ep.adjust_state, '') <> ''
                            THEN '/ADJ:' + CONVERT(varchar(10), ep.adjust_state)
                        ELSE ''
                      END
                    + ')'
                FROM dbo.att_payloadeffectpunch ep
                WHERE ep.emp_id = f.emp_id
                  AND ep.att_date = f.att_date
                ORDER BY
                    ep.punch_datetime,
                    ep.id
                FOR XML PATH('')
            ),
            1,
            1,
            ''
        ) AS AllEffectivePunches
) effective_punches
OUTER APPLY
(
    SELECT
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(8), CAST(cp.punch_time AS time), 108)
                    + '('
                    + CASE
                        WHEN cp.corrected_punch_state = 0 THEN 'IN'
                        WHEN cp.corrected_punch_state = 1 THEN 'OUT'
                        ELSE CONVERT(varchar(10), cp.corrected_punch_state)
                      END
                    + CASE
                        WHEN ISNULL(cp.corrected_punch_flag, 0) = 1 THEN '*'
                        ELSE ''
                      END
                    + ')'
                FROM dbo.custom_att_fnd_CorrectedPunches cp
                WHERE cp.emp_id = f.emp_id
                  AND cp.work_date = f.att_date
                ORDER BY
                    cp.punch_time,
                    cp.id
                FOR XML PATH('')
            ),
            1,
            1,
            ''
        ) AS AllCorrectedPunches
) corrected_punches
OUTER APPLY
(
    SELECT
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(8), CAST(wi.in_time AS time), 108)
                    + '-'
                    + CONVERT(varchar(8), CAST(wi.out_time AS time), 108)
                    + '(' + CONVERT(varchar(20), wi.worked_minutes) + 'm)'
                FROM dbo.custom_att_fnd_WorkedIntervals wi
                WHERE wi.emp_id = f.emp_id
                  AND wi.work_date = f.att_date
                ORDER BY
                    wi.in_time,
                    wi.out_time,
                    wi.in_segment_no,
                    wi.out_segment_no
                FOR XML PATH('')
            ),
            1,
            1,
            ''
        ) AS AllAdjustedPunchPairs
) adjusted_pairs;

GO
