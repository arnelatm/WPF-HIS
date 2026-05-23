CREATE VIEW [dbo].[Custom_att_vw_ScheduleMismatchEmployees]
AS
SELECT
    f.emp_id,
    e.emp_code,
    e.first_name,
    f.att_date,
    ti.alias AS effective_schedule_alias,
    es.effective_scheduled_in_datetime,
    es.effective_scheduled_out_datetime,
    raw_punches.raw_punches,
    corrected_punches.corrected_punches,
    f.first_clock_in,
    f.last_clock_out,
    DATEDIFF(MINUTE, es.effective_scheduled_in_datetime, f.first_clock_in) AS in_offset_minutes,
    DATEDIFF(MINUTE, es.effective_scheduled_out_datetime, f.last_clock_out) AS out_offset_minutes,
    f.required_scheduled_hours,
    f.worked_hours,
    f.recomputed_worked_minutes,
    f.attendance_status,
    f.anomaly_flag,
    f.reconciliation_status
FROM dbo.custom_att_fact_DailyAttendance f
INNER JOIN dbo.personnel_employee e
    ON e.id = f.emp_id
INNER JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
    ON es.emp_id = f.emp_id
   AND es.att_date = f.att_date
INNER JOIN dbo.att_timeinterval ti
    ON ti.id = es.effective_time_interval_id
OUTER APPLY
(
    SELECT
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(8), CAST(np.punch_time AS time), 108)
                    + '(' +
                    CASE
                        WHEN np.punch_state IN (0, 4) THEN 'IN'
                        WHEN np.punch_state IN (1, 5) THEN 'OUT'
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
        ) AS raw_punches
) raw_punches
OUTER APPLY
(
    SELECT
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(8), CAST(cp.punch_time AS time), 108)
                    + '(' +
                    CASE
                        WHEN cp.corrected_punch_state = 0 THEN 'IN'
                        WHEN cp.corrected_punch_state = 1 THEN 'OUT'
                        ELSE CONVERT(varchar(10), cp.corrected_punch_state)
                    END
                    + CASE WHEN ISNULL(cp.corrected_punch_flag, 0) = 1 THEN '*' ELSE '' END
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
        ) AS corrected_punches
) corrected_punches
WHERE ISNULL(ti.use_mode, 0) <> 1
  AND ISNULL(f.required_scheduled_hours, 0) > 0
  AND es.effective_scheduled_in_datetime IS NOT NULL
  AND es.effective_scheduled_out_datetime IS NOT NULL
  AND NOT EXISTS
  (
      SELECT 1
      FROM dbo.personnel_resign r
      WHERE r.employee_id = f.emp_id
        AND f.att_date > r.resign_date
  )
  AND
  (
      (
          f.first_clock_in IS NOT NULL
      AND f.last_clock_out IS NOT NULL
      AND ISNULL(f.recomputed_worked_minutes, 0) >= (ISNULL(f.required_scheduled_hours, 0) * 60.0) - 30
      AND
          (
              (
                  DATEDIFF(MINUTE, f.first_clock_in, es.effective_scheduled_in_datetime) >= 60
              AND DATEDIFF(MINUTE, f.last_clock_out, es.effective_scheduled_out_datetime) >= 60
              )
              OR
              (
                  DATEDIFF(MINUTE, es.effective_scheduled_in_datetime, f.first_clock_in) >= 60
              AND DATEDIFF(MINUTE, es.effective_scheduled_out_datetime, f.last_clock_out) >= 60
              )
          )
      )
      OR
      (
          f.first_clock_in IS NOT NULL
      AND f.last_clock_out IS NULL
      AND ABS(DATEDIFF(MINUTE, es.effective_scheduled_in_datetime, f.first_clock_in)) >= 60
      )
      OR
      (
          f.first_clock_in IS NULL
      AND f.last_clock_out IS NOT NULL
      AND ABS(DATEDIFF(MINUTE, es.effective_scheduled_out_datetime, f.last_clock_out)) >= 60
      )
  );
