CREATE VIEW [dbo].[Custom_att_fact_dailyAttendance_View]
AS
SELECT
    f.emp_id,
    Concat(e.emp_code,'-',e.first_name) as EmployeeIdCodeName,
    f.att_date,
    ti.alias AS effective_timetable_name,
    raw_punches.raw_punch_times,
    f.daily_status,
    f.attendance_status,
    f.anomaly_flag,
    f.needs_payroll_review,
    f.worked_hours,
    f.ot_hours,
    f.schedule_label,
    f.punch_status,
    f.late_minutes,
    f.early_out_minutes,   
    f.shortfall_hours,
    f.excess_hours,
    f.recomputed_absence_hours,
    f.actual_late_minutes,
    f.actual_early_out_minutes,
    f.first_clock_in,
    f.last_clock_out,
    f.year_no,
    f.month_no,
    es.effective_time_interval_id,
    es.effective_scheduled_in_datetime,
    es.effective_scheduled_out_datetime,
    f.business_day_type,
    f.anomaly_group,      
    f.required_scheduled_hours,
    f.recomputed_worked_minutes,
    f.ot_minutes,
    f.work_completion_pct,
    f.date_type,
    f.comp_leave_eligible_flag,
    f.comp_leave_minutes,
    f.comp_leave_hours,
    f.actual_excess_minutes,
    f.excess_minutes,
    f.shortfall_minutes,
    f.reconciliation_status,
    f.reconciliation_variance_minutes,
    f.work_gap_minutes    
FROM dbo.custom_att_fact_DailyAttendance f
LEFT JOIN dbo.personnel_employee e
    ON e.id = f.emp_id
LEFT JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
    ON es.emp_id = f.emp_id
   AND es.att_date = f.att_date
LEFT JOIN dbo.att_timeinterval ti
    ON ti.id = es.effective_time_interval_id
OUTER APPLY
(
    SELECT
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(8), CAST(np.punch_time AS time), 108)
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
        ) AS raw_punch_times
) raw_punches;

GO
