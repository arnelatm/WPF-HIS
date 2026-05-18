


CREATE VIEW [dbo].[custom_att_rpt_MonthlyAttendanceSummary]
AS
/*
Layer: Reporting View
Role: Detailed monthly attendance summary by employee and month

Primary Source:
- dbo.custom_att_calc_DailyAttendanceSummary

Purpose:
- Produces a richer monthly summary including attendance, OT, lateness, early out, anomaly, and compensatory leave metrics
- Serves as a reusable reporting surface for detailed monthly review

Key Outputs:
- need_present_days
- actual_present_days / actual_absence_days
- present / partial / absent day counts
- regular_worked_hours / regular_required_hours
- total_ot_hours / pure_ot_hours / special_day_ot_hours
- anomaly and review metrics
- compensatory leave metrics
- average work completion percentage

Used by:
- Reporting consumers
- Optional monthly summary reporting procedures

Notes:
- Reporting-only layer
- Should remain derived from canonical daily attendance data
- Should not become the primary location for daily business-rule logic
*/
WITH base AS
(
    SELECT
        YEAR(d.att_date) AS year_no,
        MONTH(d.att_date) AS month_no,
        d.emp_id,
        d.att_date,

        e.emp_code AS employee_code,
        LTRIM(RTRIM(
            ISNULL(e.first_name, '') +
            CASE
                WHEN ISNULL(e.last_name, '') = '' THEN ''
                ELSE ' ' + e.last_name
            END
        )) AS employee_name,
        dept.dept_name AS department_name,

        d.date_type,
        d.attendance_status,
        d.punch_status,
        d.schedule_label,
        d.anomaly_flag,
        d.needs_payroll_review,

        ISNULL(d.required_scheduled_hours, 0) AS required_scheduled_hours,
        ISNULL(d.worked_hours, 0) AS worked_hours,
        ISNULL(d.ot_hours, 0) AS ot_hours,
        ISNULL(d.late_minutes, 0) AS late_minutes,
        ISNULL(d.early_out_minutes, 0) AS early_out_minutes,
        ISNULL(d.recomputed_absence_hours, 0) AS recomputed_absence_hours,
        ISNULL(d.comp_leave_eligible_flag, 0) AS comp_leave_eligible_flag,
        ISNULL(d.comp_leave_minutes, 0) AS comp_leave_minutes,
        ISNULL(d.comp_leave_hours, 0) AS comp_leave_hours,
        ISNULL(d.work_completion_pct, 0) AS work_completion_pct,

        CASE WHEN ISNULL(d.required_scheduled_hours, 0) > 0 THEN 1 ELSE 0 END AS is_required_day,
        CASE WHEN ISNULL(d.required_scheduled_hours, 0) > 0 AND d.attendance_status IN ('Present','Partial') THEN 1 ELSE 0 END AS is_actual_present,
        CASE WHEN ISNULL(d.required_scheduled_hours, 0) > 0 AND d.attendance_status = 'Absent' THEN 1 ELSE 0 END AS is_actual_absent,
        CASE WHEN ISNULL(d.required_scheduled_hours, 0) > 0 AND d.attendance_status = 'Present' THEN 1 ELSE 0 END AS is_present_day,
        CASE WHEN ISNULL(d.required_scheduled_hours, 0) > 0 AND d.attendance_status = 'Partial' THEN 1 ELSE 0 END AS is_partial_day,
        CASE WHEN ISNULL(d.required_scheduled_hours, 0) > 0 AND d.attendance_status = 'Absent' THEN 1 ELSE 0 END AS is_absent_day,

        CASE WHEN ISNULL(d.required_scheduled_hours, 0) > 0 AND ISNULL(d.ot_hours, 0) > 0 THEN 1 ELSE 0 END AS is_regular_day_with_ot,
        CASE WHEN ISNULL(d.required_scheduled_hours, 0) = 0 AND ISNULL(d.ot_hours, 0) > 0 THEN 1 ELSE 0 END AS is_pure_ot_day,

        CASE WHEN ISNULL(d.required_scheduled_hours, 0) > 0 AND d.punch_status = 'NoPunch' THEN 1 ELSE 0 END AS is_no_punch_day,
        CASE WHEN ISNULL(d.required_scheduled_hours, 0) > 0 AND d.punch_status = 'MissingOut' THEN 1 ELSE 0 END AS is_missing_out_day,
        CASE WHEN ISNULL(d.required_scheduled_hours, 0) > 0 AND d.punch_status = 'MissingIn' THEN 1 ELSE 0 END AS is_missing_in_day,
        CASE WHEN ISNULL(d.required_scheduled_hours, 0) > 0 AND d.punch_status NOT IN ('OK','NoPunch','MissingOut','MissingIn') THEN 1 ELSE 0 END AS is_invalid_punch_day,

        CASE WHEN ISNULL(d.anomaly_flag, 'Normal') <> 'Normal' THEN 1 ELSE 0 END AS is_anomaly_day
    FROM dbo.custom_att_calc_DailyAttendanceSummary d
    LEFT JOIN dbo.personnel_employee e
        ON d.emp_id = e.id
    LEFT JOIN dbo.personnel_department dept
        ON e.department_id = dept.id
)
SELECT
    year_no,
    month_no,
    emp_id,
    employee_code,
    employee_name,
    department_name,

    SUM(is_required_day) AS need_present_days,
    SUM(CASE WHEN date_type = 2 THEN 1 ELSE 0 END) AS holiday_days,
	SUM(CASE WHEN date_type = 3 THEN 1 ELSE 0 END) AS rest_days,

    SUM(is_actual_present) AS actual_present_days,
    SUM(is_actual_absent) AS actual_absence_days,
    SUM(is_actual_present) AS computed_present_days,
    SUM(is_actual_absent) AS computed_absence_days,

    SUM(is_present_day) AS present_days,
    SUM(is_partial_day) AS partial_days,
    SUM(is_absent_day) AS absent_days,

    CAST(100.0 * SUM(is_actual_present) / NULLIF(SUM(is_required_day), 0) AS decimal(6,2)) AS presence_percentage,
    CAST(100.0 * SUM(is_actual_absent) / NULLIF(SUM(is_required_day), 0) AS decimal(6,2)) AS absence_percentage,

    CAST(SUM(CASE WHEN is_required_day = 1 THEN worked_hours ELSE 0 END) AS decimal(10,2)) AS regular_worked_hours,
    CAST(SUM(CASE WHEN is_required_day = 1 THEN required_scheduled_hours ELSE 0 END) AS decimal(10,2)) AS regular_required_hours,
    CAST(SUM(CASE WHEN is_required_day = 1 THEN ot_hours ELSE 0 END) AS decimal(10,2)) AS normal_ot_hours,
    CAST(SUM(CASE WHEN is_pure_ot_day = 1 THEN ot_hours ELSE 0 END) AS decimal(10,2)) AS pure_ot_hours,
    CAST(SUM(ot_hours) AS decimal(10,2)) AS total_ot_hours,

    CAST(SUM(CASE WHEN is_required_day = 1 THEN late_minutes ELSE 0 END) AS int) AS late_minutes,
    CAST(SUM(CASE WHEN is_required_day = 1 THEN early_out_minutes ELSE 0 END) AS int) AS early_out_minutes,
    CAST(SUM(CASE WHEN is_required_day = 1 THEN late_minutes ELSE 0 END) / 60.0 AS decimal(10,2)) AS late_hours,
    CAST(SUM(CASE WHEN is_required_day = 1 THEN early_out_minutes ELSE 0 END) / 60.0 AS decimal(10,2)) AS early_out_hours,
    CAST(SUM(CASE WHEN is_required_day = 1 THEN recomputed_absence_hours ELSE 0 END) AS decimal(10,2)) AS absence_hours,

    CAST(SUM(worked_hours) AS decimal(10,2)) AS total_worked_hours,
    CAST(SUM(CASE WHEN date_type = 2 THEN worked_hours ELSE 0 END) AS decimal(10,2)) AS holiday_worked_hours,
    CAST(SUM(CASE WHEN date_type = 3 THEN worked_hours ELSE 0 END) AS decimal(10,2)) AS restday_worked_hours,
    CAST(SUM(CASE WHEN date_type IN (2,3) THEN ot_hours ELSE 0 END) AS decimal(10,2)) AS special_day_ot_hours,

    SUM(is_regular_day_with_ot) AS Regular_Days_with_OT,
    SUM(is_pure_ot_day) AS Pure_Ot_Days,
    SUM(CASE WHEN date_type = 2 AND ot_hours > 0 THEN 1 ELSE 0 END) AS Holiday_OT_Days,
    SUM(CASE WHEN date_type = 3 AND ot_hours > 0 THEN 1 ELSE 0 END) AS RestDay_OT_Days,

    SUM(is_no_punch_day) AS no_punch_days,
    SUM(is_missing_out_day) AS missing_out_days,
    SUM(is_missing_in_day) AS missing_in_days,
    SUM(is_invalid_punch_day) AS invalid_punch_days,

    SUM(CASE WHEN date_type = 2 AND worked_hours > 0 THEN 1 ELSE 0 END) AS holiday_work_days,
    SUM(CASE WHEN date_type = 3 AND worked_hours > 0 THEN 1 ELSE 0 END) AS restday_work_days,

    SUM(CASE WHEN schedule_label = 'Holiday Work (Unscheduled)' THEN 1 ELSE 0 END) AS holiday_unscheduled_work_days,
    SUM(CASE WHEN schedule_label = 'Unscheduled Work' THEN 1 ELSE 0 END) AS unscheduled_work_days,
    SUM(CASE WHEN schedule_label = 'Assigned Off Day' AND worked_hours > 0 THEN 1 ELSE 0 END) AS worked_on_assigned_off_day_days,
    SUM(CASE WHEN schedule_label = 'Temporary Schedule Pure OT' THEN 1 ELSE 0 END) AS temporary_pure_ot_days,

    SUM(CASE WHEN anomaly_flag = 'HolidayWorkedUnscheduled' THEN 1 ELSE 0 END) AS holiday_worked_unscheduled_days,
    SUM(CASE WHEN anomaly_flag = 'WorkedOnAssignedOffDay' THEN 1 ELSE 0 END) AS worked_on_assigned_off_day_anomaly_days,
    SUM(CASE WHEN anomaly_flag = 'WorkedOnTrueUnscheduledDay' THEN 1 ELSE 0 END) AS worked_on_true_unscheduled_day_days,
    SUM(CASE WHEN anomaly_flag = 'ExcessWorkNoOT' THEN 1 ELSE 0 END) AS excess_work_no_ot_days,
    SUM(CASE WHEN anomaly_flag = 'NoPunch' THEN 1 ELSE 0 END) AS anomaly_no_punch_days,
    SUM(CASE WHEN anomaly_flag = 'MissingOut' THEN 1 ELSE 0 END) AS anomaly_missing_out_days,
    SUM(CASE WHEN anomaly_flag = 'MissingIn' THEN 1 ELSE 0 END) AS anomaly_missing_in_days,
    SUM(CASE WHEN anomaly_flag = 'ExcessiveWorkHours' THEN 1 ELSE 0 END) AS excessive_work_hours_days,
    SUM(CASE WHEN anomaly_flag = 'MissingSchedule' THEN 1 ELSE 0 END) AS missing_schedule_days,

    SUM(CASE WHEN comp_leave_eligible_flag = 1 THEN 1 ELSE 0 END) AS comp_leave_eligible_days,
    SUM(comp_leave_minutes) AS comp_leave_minutes,
    CAST(SUM(comp_leave_hours) AS decimal(10,2)) AS comp_leave_hours,

    SUM(is_anomaly_day) AS anomaly_days,
    SUM(CASE WHEN needs_payroll_review = 1 THEN 1 ELSE 0 END) AS review_days,

    CAST(AVG(CASE WHEN is_required_day = 1 THEN work_completion_pct END) AS decimal(6,2)) AS avg_work_completion_pct
FROM base
GROUP BY
    year_no,
    month_no,
    emp_id,
    employee_code,
    employee_name,
    department_name;
