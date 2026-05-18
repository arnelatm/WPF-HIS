
CREATE VIEW [dbo].[custom_att_DailyBaseVer3]
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
resolved AS
(
    SELECT
        esr.emp_id,
        esr.att_date,
        esr.effective_schedule_source,
        esr.effective_shift_id,
        esr.effective_time_interval_id,

        ti.use_mode,
        ti.duration,
        ti.work_time_duration,
        ti.enable_overtime,
        ti.in_time,
        ISNULL(tb.break_minutes, 0) AS break_minutes,

        DATEADD(
            SECOND,
            DATEDIFF(SECOND, CAST('00:00:00' AS time), ti.in_time),
            CAST(esr.att_date AS datetime2(0))
        ) AS resolved_scheduled_in,

        DATEADD(
            MINUTE,
            ti.duration,
            DATEADD(
                SECOND,
                DATEDIFF(SECOND, CAST('00:00:00' AS time), ti.in_time),
                CAST(esr.att_date AS datetime2(0))
            )
        ) AS resolved_scheduled_out,

        CASE
            WHEN ti.use_mode = 1 AND ISNULL(ti.work_time_duration, 0) > 0
                THEN ti.work_time_duration
            ELSE
                CASE
                    WHEN ISNULL(ti.duration, 0) - ISNULL(tb.break_minutes, 0) > 0
                        THEN ISNULL(ti.duration, 0) - ISNULL(tb.break_minutes, 0)
                    ELSE 0
                END
        END AS resolved_required_work_minutes
    FROM dbo.custom_att_EffectiveScheduleResolved esr
    LEFT JOIN dbo.att_timeinterval ti
        ON esr.effective_time_interval_id = ti.id
    LEFT JOIN ti_break tb
        ON ti.id = tb.timeinterval_id
)
SELECT
    tc.emp_id,
    tc.att_date,
    tc.date_type,
    tc.present_flag,
    tc.full_attendance_flag,

    -- Original payload/timetable values from BioTime
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

    -- Resolved schedule behavior fields
    r.use_mode,
    ISNULL(r.duration, 0) AS temp_duration_minutes,
    ISNULL(r.work_time_duration, 0) AS temp_work_time_duration,
    ISNULL(r.break_minutes, 0) AS temp_break_minutes,
    ISNULL(r.enable_overtime, 0) AS ot_eligible_flag,

    CASE
        WHEN r.effective_schedule_source = 'Temporary' THEN 1
        ELSE 0
    END AS has_temp_schedule,

    CASE
        WHEN r.effective_schedule_source IN ('Employee', 'Group', 'Department') THEN 1
        ELSE 0
    END AS has_assigned_schedule,

    ISNULL(r.effective_schedule_source, 'Unscheduled') AS schedule_source,

    r.resolved_scheduled_in AS effective_scheduled_in,
    r.resolved_scheduled_out AS effective_scheduled_out,

    ISNULL(r.resolved_required_work_minutes, 0) AS effective_required_work_minutes
FROM tc
LEFT JOIN dwm
    ON tc.emp_id = dwm.emp_id
   AND tc.att_date = dwm.att_date
LEFT JOIN resolved r
    ON tc.emp_id = r.emp_id
   AND tc.att_date = r.att_date;