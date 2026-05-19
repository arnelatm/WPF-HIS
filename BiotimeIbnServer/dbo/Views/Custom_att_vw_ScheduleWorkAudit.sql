
CREATE VIEW [dbo].[Custom_att_vw_ScheduleWorkAudit]
AS
SELECT
    f.emp_id,
    p.first_name,
    f.att_date,
    f.year_no,
    f.month_no,

    f.daily_status,
    f.schedule_label,
    es.effective_schedule_source,
    es.resolved_is_off_day,

    ti.alias AS timetable_name,
    ti.work_type,
    ti.use_mode,
    ti.work_time_duration,
    es.effective_required_work_minutes,
    es.effective_scheduled_in_datetime,
    es.effective_scheduled_out_datetime,

    f.first_clock_in,
    f.last_clock_out,
    f.required_scheduled_hours,
    f.worked_hours,
    f.ot_hours,
    f.excess_hours,
    f.shortfall_hours,
    f.attendance_status,
    f.anomaly_flag,
    f.reconciliation_status,
    f.needs_payroll_review,

    CASE
        WHEN f.daily_status IN ('RestDay', 'Holiday')
             AND ISNULL(f.worked_hours, 0) > 0
             AND NOT (
                    f.attendance_status = 'OT Day'
                AND f.reconciliation_status = 'OT Work'
                AND ISNULL(f.needs_payroll_review, 0) = 0
             )
        THEN 'Worked on non-working day'

        WHEN ISNULL(f.required_scheduled_hours, 0) = 0
             AND ISNULL(f.worked_hours, 0) > 0
             AND ISNULL(es.effective_schedule_source, '') <> 'Temporary'
             AND NOT (
                    f.attendance_status = 'OT Day'
                AND f.reconciliation_status = 'OT Work'
                AND ISNULL(f.needs_payroll_review, 0) = 0
             )
        THEN 'Worked without required schedule'

        WHEN f.daily_status = 'RegularDay'
             AND ISNULL(f.required_scheduled_hours, 0) = 0
        THEN 'RegularDay but zero required hours'

        WHEN f.daily_status <> 'RegularDay'
             AND ISNULL(f.required_scheduled_hours, 0) > 0
        THEN 'Non-RegularDay but has required hours'

        WHEN f.daily_status = 'RegularDay'
             AND ISNULL(f.required_scheduled_hours, 0) > 0
             AND ISNULL(f.worked_hours, 0) = 0
             AND f.first_clock_in IS NULL
             AND f.last_clock_out IS NULL
        THEN 'Absent without punches'

        WHEN ISNULL(f.worked_hours, 0) >= ISNULL(f.required_scheduled_hours, 0) + 4
             AND NOT (
                    f.attendance_status = 'OT Day'
                AND f.reconciliation_status = 'OT Work'
                AND ISNULL(f.needs_payroll_review, 0) = 0
             )
        THEN 'Worked much longer than schedule'

        WHEN ISNULL(f.required_scheduled_hours, 0) >= 6
             AND ISNULL(f.worked_hours, 0) <= 3
             AND ISNULL(f.worked_hours, 0) > 0
        THEN 'Worked much shorter than schedule'

        WHEN f.first_clock_in IS NOT NULL
             AND es.effective_scheduled_in_datetime IS NOT NULL
             AND ISNULL(ti.use_mode, 0) <> 1
             AND ABS(DATEDIFF(MINUTE, es.effective_scheduled_in_datetime, f.first_clock_in)) >= 180
        THEN 'Clock-in far from scheduled IN'

        WHEN f.anomaly_flag IN ('MissingIn', 'MissingOut')
        THEN 'Missing punch'

        WHEN f.anomaly_flag = 'IncompletePunchPair'
             AND ISNULL(f.worked_hours, 0) = 0
        THEN 'Absent without punches'

        WHEN f.anomaly_flag IN ('IncompletePunchPair', 'ExcessiveWorkHours')
        THEN 'Punch/schedule anomaly'

        ELSE 'Review'
    END AS audit_reason

FROM dbo.custom_att_fact_DailyAttendance f
LEFT JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
    ON es.emp_id = f.emp_id
   AND es.att_date = f.att_date
LEFT JOIN dbo.att_timeinterval ti
    ON ti.id = es.effective_time_interval_id
LEFT JOIN dbo.personnel_employee p
    ON f.emp_id = p.id
WHERE
    (
        f.daily_status IN ('RestDay', 'Holiday')
        AND ISNULL(f.worked_hours, 0) > 0
        AND NOT (
               f.attendance_status = 'OT Day'
           AND f.reconciliation_status = 'OT Work'
           AND ISNULL(f.needs_payroll_review, 0) = 0
        )
    )
    OR (
        ISNULL(f.required_scheduled_hours, 0) = 0
        AND ISNULL(f.worked_hours, 0) > 0
        AND ISNULL(es.effective_schedule_source, '') <> 'Temporary'
        AND NOT (
               f.attendance_status = 'OT Day'
           AND f.reconciliation_status = 'OT Work'
           AND ISNULL(f.needs_payroll_review, 0) = 0
        )
    )
    OR (
        f.daily_status = 'RegularDay'
        AND ISNULL(f.required_scheduled_hours, 0) > 0
        AND ISNULL(f.worked_hours, 0) = 0
        AND f.first_clock_in IS NULL
        AND f.last_clock_out IS NULL
    )
    OR (
        ISNULL(f.worked_hours, 0) >= ISNULL(f.required_scheduled_hours, 0) + 4
        AND NOT (
               f.attendance_status = 'OT Day'
           AND f.reconciliation_status = 'OT Work'
           AND ISNULL(f.needs_payroll_review, 0) = 0
        )
    )
    OR (
        ISNULL(f.required_scheduled_hours, 0) >= 6
        AND ISNULL(f.worked_hours, 0) <= 3
        AND ISNULL(f.worked_hours, 0) > 0
    )
    OR (
        f.daily_status = 'RegularDay'
        AND ISNULL(f.required_scheduled_hours, 0) = 0
    )
    OR (
        f.daily_status <> 'RegularDay'
        AND ISNULL(f.required_scheduled_hours, 0) > 0
    )
    OR f.anomaly_flag IN ('IncompletePunchPair', 'MissingIn', 'MissingOut', 'ExcessiveWorkHours')
    OR (
        f.first_clock_in IS NOT NULL
        AND es.effective_scheduled_in_datetime IS NOT NULL
        AND ISNULL(ti.use_mode, 0) <> 1
        AND ABS(DATEDIFF(MINUTE, es.effective_scheduled_in_datetime, f.first_clock_in)) >= 180
    );
