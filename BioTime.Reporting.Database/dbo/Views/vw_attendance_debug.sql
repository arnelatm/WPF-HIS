CREATE VIEW [dbo].[vw_attendance_debug]
AS
SELECT
    emp_id,
    att_date,
    weekday_name,
    scheduled_in,
    scheduled_out,
    first_clock_in,
    last_clock_out,
    required_scheduled_hours,
    required_work_hours,
    recomputed_worked_minutes,
    recomputed_worked_hours,
    late_minutes,
    early_out_minutes,

    -- ✅ ADD HERE
    anomaly_flag,
    work_completion_pct,
    recomputed_excess_hours,

    punch_status,
    attendance_status
FROM dbo.custom_att_DailyAttendanceSummary;