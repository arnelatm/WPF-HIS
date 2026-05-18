
CREATE VIEW [dbo].[custom_att_DailyBaseVer2]
AS
WITH tc AS
(
    SELECT
        t.emp_id,
        t.att_date,
        MAX(t.date_type) AS date_type,
        MAX(t.present) AS present_flag,
        MAX(t.full_attendance) AS full_attendance_flag,

        MIN(t.check_in) AS scheduled_in,
        MAX(t.check_out) AS scheduled_out,

        SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'total_ot')) AS ot_minutes,
        SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'remaining')) AS absence_minutes,

        SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'worked_hrs'))
        + SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'remaining')) AS required_work_minutes
    FROM dbo.att_payloadtimecard t
    GROUP BY
        t.emp_id,
        t.att_date
),
dwm AS
(
    SELECT
        d.emp_id,
        d.work_date AS att_date,
        d.first_clock_in,
        d.last_clock_out,
        CAST(d.total_worked_minutes AS decimal(10,2)) AS worked_minutes,
        CAST(d.total_worked_minutes AS decimal(10,2)) AS recomputed_worked_minutes,
        CAST(d.total_worked_minutes / 60.0 AS decimal(10,2)) AS recomputed_worked_hours
    FROM dbo.custom_att_DailyWorkedMinutes d
),
ti_break AS
(
    SELECT
        tib.timeinterval_id,
        SUM(ISNULL(bt.duration, 0)) AS break_minutes
    FROM dbo.att_timeinterval_break_time tib
    INNER JOIN dbo.att_breaktime bt
        ON tib.breaktime_id = bt.id
    GROUP BY
        tib.timeinterval_id
),

/* Temporary schedule: per-day override */
ts AS
(
    SELECT
        ats.employee_id AS emp_id,
        ats.att_date,
        ti.use_mode,
        ti.duration,
        ti.work_time_duration,
        ti.enable_overtime,
        ISNULL(tb.break_minutes, 0) AS break_minutes,

        DATEADD(
            SECOND,
            DATEDIFF(SECOND, CAST('00:00:00' AS time), ti.in_time),
            CAST(ats.att_date AS datetime2(0))
        ) AS temp_scheduled_in,

        DATEADD(
            MINUTE,
            ti.duration,
            DATEADD(
                SECOND,
                DATEDIFF(SECOND, CAST('00:00:00' AS time), ti.in_time),
                CAST(ats.att_date AS datetime2(0))
            )
        ) AS temp_scheduled_out,

        CASE
            WHEN ti.use_mode = 1 AND ISNULL(ti.work_time_duration, 0) > 0
                THEN ti.work_time_duration
            ELSE
                CASE
                    WHEN ti.duration - ISNULL(tb.break_minutes, 0) < 0 THEN 0
                    ELSE ti.duration - ISNULL(tb.break_minutes, 0)
                END
        END AS temp_required_work_minutes
    FROM dbo.att_temporaryschedule ats
    INNER JOIN dbo.att_timeinterval ti
        ON ats.time_interval_id = ti.id
    LEFT JOIN ti_break tb
        ON ti.id = tb.timeinterval_id
    WHERE ats.status = 0
),

/* Employee schedule: date-range based */
es AS
(
    SELECT
        a.employee_id AS emp_id,
        c.att_date,
        ti.use_mode,
        ti.duration,
        ti.work_time_duration,
        ti.enable_overtime,
        ISNULL(tb.break_minutes, 0) AS break_minutes,

        DATEADD(
            SECOND,
            DATEDIFF(SECOND, CAST('00:00:00' AS time), ti.in_time),
            CAST(c.att_date AS datetime2(0))
        ) AS emp_scheduled_in,

        DATEADD(
            MINUTE,
            ti.duration,
            DATEADD(
                SECOND,
                DATEDIFF(SECOND, CAST('00:00:00' AS time), ti.in_time),
                CAST(c.att_date AS datetime2(0))
            )
        ) AS emp_scheduled_out,

        CASE
            WHEN ti.use_mode = 1 AND ISNULL(ti.work_time_duration, 0) > 0
                THEN ti.work_time_duration
            ELSE
                CASE
                    WHEN ti.duration - ISNULL(tb.break_minutes, 0) < 0 THEN 0
                    ELSE ti.duration - ISNULL(tb.break_minutes, 0)
                END
        END AS emp_required_work_minutes
    FROM tc c
    INNER JOIN dbo.att_attschedule a
        ON c.emp_id = a.employee_id
       AND c.att_date >= a.start_date
       AND c.att_date <= a.end_date
    INNER JOIN dbo.att_shiftdetail sd
        ON a.shift_id = sd.shift_id
       AND sd.day_index =
            CASE DATENAME(WEEKDAY, c.att_date)
                WHEN 'Sunday' THEN 0
                WHEN 'Monday' THEN 1
                WHEN 'Tuesday' THEN 2
                WHEN 'Wednesday' THEN 3
                WHEN 'Thursday' THEN 4
                WHEN 'Friday' THEN 5
                WHEN 'Saturday' THEN 6
            END
    INNER JOIN dbo.att_timeinterval ti
        ON sd.time_interval_id = ti.id
    LEFT JOIN ti_break tb
        ON ti.id = tb.timeinterval_id
)

SELECT
    tc.emp_id,
    tc.att_date,
    tc.date_type,
    tc.present_flag,
    tc.full_attendance_flag,

    tc.scheduled_in,
    tc.scheduled_out,

    dwm.first_clock_in,
    dwm.last_clock_out,

    ISNULL(dwm.worked_minutes, 0) AS worked_minutes,
    ISNULL(tc.ot_minutes, 0) AS ot_minutes,
    ISNULL(tc.absence_minutes, 0) AS absence_minutes,
    ISNULL(tc.required_work_minutes, 0) AS required_work_minutes,

    ISNULL(dwm.recomputed_worked_minutes, 0) AS recomputed_worked_minutes,
    ISNULL(dwm.recomputed_worked_hours, 0) AS recomputed_worked_hours,

    COALESCE(ts.use_mode, es.use_mode) AS use_mode,
    COALESCE(ts.duration, es.duration) AS temp_duration_minutes,
    COALESCE(ts.work_time_duration, es.work_time_duration) AS temp_work_time_duration,
    COALESCE(ts.break_minutes, es.break_minutes) AS temp_break_minutes,
    COALESCE(ts.enable_overtime, es.enable_overtime, 0) AS ot_eligible_flag,

    COALESCE(ts.temp_scheduled_in, es.emp_scheduled_in, tc.scheduled_in) AS effective_scheduled_in,
    COALESCE(ts.temp_scheduled_out, es.emp_scheduled_out, tc.scheduled_out) AS effective_scheduled_out,

    COALESCE(
        ts.temp_required_work_minutes,
        es.emp_required_work_minutes,
        CASE
            WHEN ISNULL(tc.required_work_minutes, 0) < 0 THEN 0
            ELSE ISNULL(tc.required_work_minutes, 0)
        END
    ) AS effective_required_work_minutes
FROM tc
LEFT JOIN dwm
    ON tc.emp_id = dwm.emp_id
   AND tc.att_date = dwm.att_date
LEFT JOIN ts
    ON tc.emp_id = ts.emp_id
   AND tc.att_date = ts.att_date
LEFT JOIN es
    ON tc.emp_id = es.emp_id
   AND tc.att_date = es.att_date;