CREATE VIEW [dbo].[Custom_att_vw_ScheduleMismatchEmployees]
AS
WITH ScheduleRows AS
(
    SELECT
        f.emp_id,
        e.emp_code,
        e.first_name,
        LTRIM(RTRIM(ISNULL(e.first_name, '') + ' ' + ISNULL(e.last_name, ''))) AS employee_name,
        e.department_id,
        d.dept_code,
        d.dept_name,
        ae.group_id,
        ag.code AS group_code,
        ag.name AS group_name,
        f.att_date,
        es.effective_schedule_source,
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
        f.actual_late_minutes,
        f.actual_early_out_minutes,
        f.attendance_status,
        f.anomaly_flag,
        f.reconciliation_status
    FROM dbo.custom_att_fact_DailyAttendance f
    INNER JOIN dbo.personnel_employee e
        ON e.id = f.emp_id
    LEFT JOIN dbo.personnel_department d
        ON d.id = e.department_id
    LEFT JOIN dbo.att_attemployee ae
        ON ae.emp_id = e.id
    LEFT JOIN dbo.att_attgroup ag
        ON ag.id = ae.group_id
    INNER JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
        ON es.emp_id = f.emp_id
       AND es.att_date = f.att_date
    INNER JOIN dbo.att_timeinterval ti
        ON ti.id = es.effective_time_interval_id
    OUTER APPLY
    (
        SELECT COUNT_BIG(*) AS punch_count
        FROM dbo.custom_att_fnd_NormalizedPunches np
        WHERE np.emp_id = f.emp_id
          AND np.work_date = f.att_date
    ) workday_punches
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
      AND workday_punches.punch_count > 0
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
      )
)
SELECT
    sr.emp_id,
    sr.emp_code,
    sr.first_name,
    sr.employee_name,
    sr.department_id,
    sr.dept_code,
    sr.dept_name,
    sr.group_id,
    sr.group_code,
    sr.group_name,
    sr.att_date,
    sr.effective_schedule_source,
    sr.effective_schedule_alias,
    sr.effective_scheduled_in_datetime,
    sr.effective_scheduled_out_datetime,
    sr.raw_punches,
    sr.corrected_punches,
    sr.first_clock_in,
    sr.last_clock_out,
    sr.in_offset_minutes,
    sr.out_offset_minutes,
    CASE
        WHEN sr.first_clock_in IS NOT NULL
         AND sr.last_clock_out IS NULL
        THEN 'MissingClockOutAgainstSchedule'

        WHEN sr.first_clock_in IS NULL
         AND sr.last_clock_out IS NOT NULL
        THEN 'MissingClockInAgainstSchedule'

        WHEN sr.in_offset_minutes <= -60
         AND sr.out_offset_minutes <= -60
        THEN 'ShiftedEarly'

        WHEN sr.in_offset_minutes >= 60
         AND sr.out_offset_minutes >= 60
        THEN 'ShiftedLate'

        WHEN ABS(sr.in_offset_minutes) >= 60
        THEN 'ClockInFarFromSchedule'

        WHEN ABS(sr.out_offset_minutes) >= 60
        THEN 'ClockOutFarFromSchedule'

        ELSE 'ScheduleWindowMismatch'
    END AS mismatch_type,
    CASE
        WHEN sr.first_clock_in IS NULL
          OR sr.last_clock_out IS NULL
        THEN 'High'

        WHEN ABS(ISNULL(sr.in_offset_minutes, 0)) >= 180
          OR ABS(ISNULL(sr.out_offset_minutes, 0)) >= 180
        THEN 'High'

        ELSE 'Medium'
    END AS severity,
    sr.required_scheduled_hours,
    sr.worked_hours,
    sr.recomputed_worked_minutes,
    sr.actual_late_minutes,
    sr.actual_early_out_minutes,
    sr.attendance_status,
    sr.anomaly_flag,
    sr.reconciliation_status
FROM ScheduleRows sr;
