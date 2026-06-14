CREATE VIEW [dbo].[custom_att_vw_DailySchedulePunchAuditLean]
AS
SELECT
    f.att_date AS [Date],
    f.emp_id AS emp_id,
    f.emp_code,
    f.emp_code_name,
    f.effective_timetable_name AS EffectiveScheduleAlias,

    CONVERT(varchar(8), CAST(f.effective_scheduled_in_datetime AS time), 108) AS ScheduledIn,
    CONVERT(varchar(8), CAST(f.effective_scheduled_out_datetime AS time), 108) AS ScheduledOut,

    CONVERT(varchar(8), CAST(f.effective_punch_in1 AS time), 108) AS EffectivePunchIn1,
    CONVERT(varchar(8), CAST(f.effective_punch_out1 AS time), 108) AS EffectivePunchOut1,
    CONVERT(varchar(8), CAST(f.effective_punch_in2 AS time), 108) AS EffectivePunchIn2,
    CONVERT(varchar(8), CAST(f.effective_punch_out2 AS time), 108) AS EffectivePunchOut2,

    punch_lists.AllPunches,

    DATEDIFF(MINUTE, f.effective_scheduled_in_datetime, f.effective_punch_in1) AS InOffsetMinutes,
    DATEDIFF(
        MINUTE,
        f.effective_scheduled_out_datetime,
        COALESCE(f.effective_punch_out2, f.effective_punch_out1)
    ) AS OutOffsetMinutes,

    CASE
        WHEN f.effective_time_interval_id IS NULL
        THEN 'MissingSchedule'

        WHEN f.effective_punch_in1 IS NULL
         AND f.effective_punch_out1 IS NULL
        THEN 'NoEffectivePunches'

        WHEN f.effective_punch_in1 IS NULL
        THEN 'MissingEffectiveIn'

        WHEN COALESCE(f.effective_punch_out2, f.effective_punch_out1) IS NULL
        THEN 'MissingEffectiveOut'

        WHEN f.effective_scheduled_in_datetime IS NOT NULL
         AND f.effective_scheduled_out_datetime IS NOT NULL
         AND f.effective_punch_in1 IS NOT NULL
         AND COALESCE(f.effective_punch_out2, f.effective_punch_out1) IS NOT NULL
         AND DATEDIFF(MINUTE, f.effective_scheduled_in_datetime, f.effective_punch_in1) <= -60
         AND DATEDIFF(MINUTE, f.effective_scheduled_out_datetime, COALESCE(f.effective_punch_out2, f.effective_punch_out1)) <= -60
        THEN 'LikelyEarlierSchedule'

        WHEN f.effective_scheduled_in_datetime IS NOT NULL
         AND f.effective_scheduled_out_datetime IS NOT NULL
         AND f.effective_punch_in1 IS NOT NULL
         AND COALESCE(f.effective_punch_out2, f.effective_punch_out1) IS NOT NULL
         AND DATEDIFF(MINUTE, f.effective_scheduled_in_datetime, f.effective_punch_in1) >= 60
         AND DATEDIFF(MINUTE, f.effective_scheduled_out_datetime, COALESCE(f.effective_punch_out2, f.effective_punch_out1)) >= 60
        THEN 'LikelyLaterSchedule'

        WHEN f.effective_scheduled_in_datetime IS NOT NULL
         AND f.effective_punch_in1 IS NOT NULL
         AND ABS(DATEDIFF(MINUTE, f.effective_scheduled_in_datetime, f.effective_punch_in1)) >= 120
        THEN 'PunchInFarFromSchedule'

        WHEN f.effective_scheduled_out_datetime IS NOT NULL
         AND COALESCE(f.effective_punch_out2, f.effective_punch_out1) IS NOT NULL
         AND ABS(DATEDIFF(MINUTE, f.effective_scheduled_out_datetime, COALESCE(f.effective_punch_out2, f.effective_punch_out1))) >= 120
        THEN 'PunchOutFarFromSchedule'

        ELSE 'OK'
    END AS SchedulePunchCheck,

    f.required_scheduled_hours AS RequiredScheduledHours,
    f.worked_hours AS WorkedHours,
    f.attendance_status AS AttendanceStatus,
    f.anomaly_flag AS AnomalyFlag,
    f.needs_payroll_review AS NeedsPayrollReview,
    es.effective_schedule_source AS EffectiveScheduleSource
FROM dbo.Custom_att_fact_dailyAttendance_View f
LEFT JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
    ON es.emp_id = f.emp_id
   AND es.att_date = f.att_date
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
        ) AS AllPunches
) punch_lists;
