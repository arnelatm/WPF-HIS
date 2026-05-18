
CREATE VIEW [dbo].[custom_att_DailyAttendanceSummaryVer15]
AS
SELECT
    -- Core identity
    m.emp_id,
    m.att_date,

    -- Resolved effective schedule source
    ISNULL(esr.effective_schedule_source, 'Unscheduled') AS effective_schedule_source,
    esr.effective_shift_id,
    esr.effective_time_interval_id,

    -- Schedule & punches
    CASE
        WHEN ISNULL(esr.effective_schedule_source, 'Unscheduled') = 'Unscheduled' THEN NULL
        ELSE m.scheduled_in
    END AS scheduled_in,

    CASE
        WHEN ISNULL(esr.effective_schedule_source, 'Unscheduled') = 'Unscheduled' THEN NULL
        ELSE m.scheduled_out
    END AS scheduled_out,

    m.first_clock_in,
    m.last_clock_out,

    -- Work metrics
    m.required_scheduled_hours,
    m.required_work_hours,
    m.recomputed_worked_minutes,
    m.recomputed_worked_hours,
    m.worked_hours,

    -- Time deviations
    m.late_minutes,
    m.early_out_minutes,

    -- OT
    m.ot_minutes,
    m.ot_hours,

    -- Work completion / extra work
    m.work_completion_pct,
    m.recomputed_excess_hours,

    -- Compensatory leave
    m.comp_leave_eligible_flag,
    m.comp_leave_minutes,
    m.comp_leave_hours,

    CASE
        WHEN m.comp_leave_eligible_flag = 1 THEN 'For Compensatory Leave Review'
        ELSE NULL
    END AS leave_action_note,

    -- Date classification
    m.date_type,
    m.weekday_name,

    CASE
        WHEN m.date_type = 0 THEN 'RegularDay'
        WHEN m.date_type = 1 THEN 'Holiday'
        WHEN m.date_type = 2 THEN 'DayOff'
        ELSE 'Unclassified'
    END AS daily_status,

    CASE
        WHEN m.date_type IN (1,2) THEN 'NotRequired'
        WHEN ISNULL(m.recomputed_worked_hours,0) = 0 THEN 'Absent'
        WHEN m.recomputed_worked_hours < m.required_work_hours THEN 'Partial'
        ELSE 'Present'
    END AS attendance_status,

    CASE
        WHEN m.ot_hours > 0 THEN 'WithOT'
        ELSE 'NoOT'
    END AS ot_status,

    CASE
        WHEN ISNULL(esr.effective_schedule_source, 'Unscheduled') = 'Unscheduled'
             AND m.date_type = 1
            THEN 'Holiday Work (Unscheduled)'
        WHEN ISNULL(esr.effective_schedule_source, 'Unscheduled') = 'Unscheduled'
            THEN 'Unscheduled Work'
        ELSE ISNULL(esr.effective_schedule_source, m.schedule_type)
    END AS schedule_label,

    CASE
        WHEN m.date_type IN (1,2) THEN 'NotRequired'
        WHEN m.first_clock_in IS NULL THEN 'NoPunch'
        WHEN m.last_clock_out IS NULL THEN 'MissingOut'
        WHEN m.first_clock_in = m.last_clock_out THEN 'InvalidPunch'
        ELSE 'OK'
    END AS punch_status,

    CASE
        WHEN m.date_type = 1
             AND ISNULL(m.recomputed_worked_hours, 0) > 0
             AND ISNULL(esr.effective_schedule_source, 'Unscheduled') = 'Unscheduled'
            THEN 'HolidayWorkedUnscheduled'
        WHEN m.date_type <> 1
             AND ISNULL(m.recomputed_worked_hours, 0) > 0
             AND ISNULL(esr.effective_schedule_source, 'Unscheduled') = 'Unscheduled'
             AND ISNULL(m.ot_hours, 0) = 0
            THEN 'WorkedUnscheduledNoOT'
        WHEN ISNULL(m.recomputed_worked_hours, 0) > ISNULL(m.required_work_hours, 0)
             AND ISNULL(m.required_work_hours, 0) > 0
             AND ISNULL(m.ot_hours, 0) = 0
            THEN 'ExcessWorkNoOT'
        ELSE ISNULL(m.anomaly_flag, 'Normal')
    END AS anomaly_flag,

    CASE
        WHEN ISNULL(m.recomputed_worked_hours,0) > 0 THEN 1
        ELSE 0
    END AS is_present_by_report_rule

FROM dbo.custom_att_DailyMetrics m
LEFT JOIN dbo.custom_att_EffectiveScheduleResolved esr
    ON esr.emp_id = m.emp_id
   AND esr.att_date = m.att_date;