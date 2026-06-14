
CREATE PROCEDURE dbo.custom_att_GetMonthlyAttendanceSummary_Fast
    @DateFrom date = NULL,
    @DateTo   date = NULL,
    @EmpID    int  = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        f.year_no,
        f.month_no,
        f.emp_id,
        f.emp_code,
        LTRIM(RTRIM(
            ISNULL(pe.first_name, '') +
            CASE
                WHEN ISNULL(pe.last_name, '') = '' THEN ''
                ELSE ' ' + pe.last_name
            END
        )) AS employee_name,
        d.dept_name AS department_name,

        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN 1 ELSE 0 END) AS need_present_days,
        SUM(CASE WHEN f.date_type = 1 THEN 1 ELSE 0 END) AS holiday_days,
        SUM(CASE WHEN f.date_type = 2 THEN 1 ELSE 0 END) AS rest_days,

        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.attendance_status IN ('Present','Partial') THEN 1 ELSE 0 END) AS actual_present_days,
        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.attendance_status = 'Absent' THEN 1 ELSE 0 END) AS actual_absence_days,
        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.attendance_status IN ('Present','Partial') THEN 1 ELSE 0 END) AS computed_present_days,
        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.attendance_status = 'Absent' THEN 1 ELSE 0 END) AS computed_absence_days,

        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.attendance_status = 'Present' THEN 1 ELSE 0 END) AS present_days,
        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.attendance_status = 'Partial' THEN 1 ELSE 0 END) AS partial_days,
        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.attendance_status = 'Absent' THEN 1 ELSE 0 END) AS absent_days,

        CAST(100.0 *
            SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.attendance_status IN ('Present','Partial') THEN 1 ELSE 0 END)
            / NULLIF(SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN 1 ELSE 0 END), 0)
        AS decimal(6,2)) AS presence_percentage,

        CAST(100.0 *
            SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.attendance_status = 'Absent' THEN 1 ELSE 0 END)
            / NULLIF(SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN 1 ELSE 0 END), 0)
        AS decimal(6,2)) AS absence_percentage,

        CAST(SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN ISNULL(f.regular_worked_hours, 0) ELSE 0 END) AS decimal(10,2)) AS regular_worked_hours,
        CAST(SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN ISNULL(f.required_scheduled_hours, 0) ELSE 0 END) AS decimal(10,2)) AS regular_required_hours,
        CAST(SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN ISNULL(f.ot_hours, 0) ELSE 0 END) AS decimal(10,2)) AS normal_ot_hours,
        CAST(SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) = 0 AND ISNULL(f.ot_hours, 0) > 0 THEN ISNULL(f.ot_hours, 0) ELSE 0 END) AS decimal(10,2)) AS pure_ot_hours,
        CAST(SUM(ISNULL(f.ot_hours, 0)) AS decimal(10,2)) AS total_ot_hours,

        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN ISNULL(f.late_minutes, 0) ELSE 0 END) AS late_minutes,
        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN ISNULL(f.early_out_minutes, 0) ELSE 0 END) AS early_out_minutes,
        CAST(SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN ISNULL(f.late_minutes, 0) ELSE 0 END) / 60.0 AS decimal(10,2)) AS late_hours,
        CAST(SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN ISNULL(f.early_out_minutes, 0) ELSE 0 END) / 60.0 AS decimal(10,2)) AS early_out_hours,
        CAST(SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN ISNULL(f.recomputed_absence_hours, 0) ELSE 0 END) AS decimal(10,2)) AS absence_hours,

        CAST(SUM(ISNULL(f.worked_hours, 0)) AS decimal(10,2)) AS total_worked_hours,
        CAST(SUM(CASE WHEN f.date_type = 1 THEN ISNULL(f.worked_hours, 0) ELSE 0 END) AS decimal(10,2)) AS holiday_worked_hours,
        CAST(SUM(CASE WHEN f.date_type = 2 THEN ISNULL(f.worked_hours, 0) ELSE 0 END) AS decimal(10,2)) AS restday_worked_hours,
        CAST(SUM(CASE WHEN f.date_type IN (1,2) THEN ISNULL(f.ot_hours, 0) ELSE 0 END) AS decimal(10,2)) AS special_day_ot_hours,

        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND ISNULL(f.ot_hours, 0) > 0 THEN 1 ELSE 0 END) AS Regular_Days_with_OT,
        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) = 0 AND ISNULL(f.ot_hours, 0) > 0 THEN 1 ELSE 0 END) AS Pure_Ot_Days,
        SUM(CASE WHEN f.date_type = 1 AND ISNULL(f.ot_hours, 0) > 0 THEN 1 ELSE 0 END) AS Holiday_OT_Days,
        SUM(CASE WHEN f.date_type = 2 AND ISNULL(f.ot_hours, 0) > 0 THEN 1 ELSE 0 END) AS RestDay_OT_Days,

        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.punch_status = 'NoPunch' THEN 1 ELSE 0 END) AS no_punch_days,
        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.punch_status = 'MissingOut' THEN 1 ELSE 0 END) AS missing_out_days,
        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.punch_status = 'MissingIn' THEN 1 ELSE 0 END) AS missing_in_days,
        SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 AND f.punch_status NOT IN ('OK','NoPunch','MissingOut','MissingIn') THEN 1 ELSE 0 END) AS invalid_punch_days,

        SUM(CASE WHEN f.date_type = 1 AND ISNULL(f.worked_hours, 0) > 0 THEN 1 ELSE 0 END) AS holiday_work_days,
        SUM(CASE WHEN f.date_type = 2 AND ISNULL(f.worked_hours, 0) > 0 THEN 1 ELSE 0 END) AS restday_work_days,

        SUM(CASE WHEN f.schedule_label = 'Holiday Work (Unscheduled)' THEN 1 ELSE 0 END) AS holiday_unscheduled_work_days,
        SUM(CASE WHEN f.schedule_label = 'Unscheduled Work' THEN 1 ELSE 0 END) AS unscheduled_work_days,
        SUM(CASE WHEN f.schedule_label = 'Assigned Off Day' AND ISNULL(f.worked_hours, 0) > 0 THEN 1 ELSE 0 END) AS worked_on_assigned_off_day_days,
        SUM(CASE WHEN f.schedule_label = 'Temporary Schedule Pure OT' THEN 1 ELSE 0 END) AS temporary_pure_ot_days,

        SUM(CASE WHEN f.anomaly_flag = 'HolidayWorkedUnscheduled' THEN 1 ELSE 0 END) AS holiday_worked_unscheduled_days,
        SUM(CASE WHEN f.anomaly_flag = 'WorkedOnAssignedOffDay' THEN 1 ELSE 0 END) AS worked_on_assigned_off_day_anomaly_days,
        SUM(CASE WHEN f.anomaly_flag = 'WorkedOnTrueUnscheduledDay' THEN 1 ELSE 0 END) AS worked_on_true_unscheduled_day_days,
        SUM(CASE WHEN f.anomaly_flag = 'ExcessWorkNoOT' THEN 1 ELSE 0 END) AS excess_work_no_ot_days,
        SUM(CASE WHEN f.anomaly_flag = 'NoPunch' THEN 1 ELSE 0 END) AS anomaly_no_punch_days,
        SUM(CASE WHEN f.anomaly_flag = 'MissingOut' THEN 1 ELSE 0 END) AS anomaly_missing_out_days,
        SUM(CASE WHEN f.anomaly_flag = 'MissingIn' THEN 1 ELSE 0 END) AS anomaly_missing_in_days,
        SUM(CASE WHEN f.anomaly_flag = 'ExcessiveWorkHours' THEN 1 ELSE 0 END) AS excessive_work_hours_days,
        SUM(CASE WHEN f.anomaly_flag = 'MissingSchedule' THEN 1 ELSE 0 END) AS missing_schedule_days,

        SUM(CASE WHEN ISNULL(f.comp_leave_eligible_flag, 0) = 1 THEN 1 ELSE 0 END) AS comp_leave_eligible_days,
        SUM(ISNULL(f.comp_leave_minutes, 0)) AS comp_leave_minutes,
        CAST(SUM(ISNULL(f.comp_leave_hours, 0)) AS decimal(10,2)) AS comp_leave_hours,

        SUM(CASE WHEN ISNULL(f.anomaly_flag, 'Normal') <> 'Normal' THEN 1 ELSE 0 END) AS anomaly_days,
        SUM(CASE WHEN ISNULL(f.needs_payroll_review, 0) = 1 THEN 1 ELSE 0 END) AS review_days,

        CAST(AVG(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN f.work_completion_pct END) AS decimal(6,2)) AS avg_work_completion_pct

    FROM dbo.custom_att_fact_DailyAttendance f
    LEFT JOIN dbo.personnel_employee pe
        ON f.emp_id = pe.id
    LEFT JOIN dbo.personnel_department d
        ON pe.department_id = d.id
    WHERE (@DateFrom IS NULL OR f.att_date >= @DateFrom)
      AND (@DateTo IS NULL OR f.att_date <= @DateTo)
      AND (@EmpID IS NULL OR f.emp_id = @EmpID)
    GROUP BY
        f.year_no,
        f.month_no,
        f.emp_id,
        f.emp_code,
        pe.first_name,
        pe.last_name,
        d.dept_name
    ORDER BY
        f.year_no,
        f.month_no,
        employee_name;
END
