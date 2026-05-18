

CREATE VIEW [dbo].[custom_att_MonthlyAttendanceSummary]
AS
SELECT
    YEAR(d.att_date) AS year_no,
    MONTH(d.att_date) AS month_no,
    d.emp_id,

    e.emp_code AS employee_code,
    LTRIM(RTRIM(
        ISNULL(e.first_name, '') +
        CASE
            WHEN ISNULL(e.last_name, '') = '' THEN ''
            ELSE ' ' + e.last_name
        END
    )) AS employee_name,

    dept.dept_name AS department_name,

    --------------------------------------------------
    -- Core calendar / payroll-required counts
    --------------------------------------------------
    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
        THEN 1 ELSE 0
    END) AS need_present_days,

    SUM(CASE WHEN d.date_type = 1 THEN 1 ELSE 0 END) AS holiday_days,
    SUM(CASE WHEN d.date_type = 2 THEN 1 ELSE 0 END) AS rest_days,

    --------------------------------------------------
    -- Attendance counts on payroll-required days
    --------------------------------------------------
    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
         AND d.attendance_status IN ('Present', 'Partial')
        THEN 1 ELSE 0
    END) AS actual_present_days,

    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
         AND d.attendance_status = 'Absent'
        THEN 1 ELSE 0
    END) AS actual_absence_days,

    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
         AND d.attendance_status IN ('Present', 'Partial')
        THEN 1 ELSE 0
    END) AS computed_present_days,

    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
         AND d.attendance_status = 'Absent'
        THEN 1 ELSE 0
    END) AS computed_absence_days,

    --------------------------------------------------
    -- Required-day buckets
    --------------------------------------------------
    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
         AND d.attendance_status = 'Present'
        THEN 1 ELSE 0
    END) AS present_days,

    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
         AND d.attendance_status = 'Partial'
        THEN 1 ELSE 0
    END) AS partial_days,

    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
         AND d.attendance_status = 'Absent'
        THEN 1 ELSE 0
    END) AS absent_days,

    --------------------------------------------------
    -- Percentages
    --------------------------------------------------
    CAST(
        100.0 *
        SUM(CASE
            WHEN ISNULL(d.required_work_hours, 0) > 0
             AND d.attendance_status IN ('Present', 'Partial')
            THEN 1 ELSE 0
        END)
        / NULLIF(
            SUM(CASE
                WHEN ISNULL(d.required_work_hours, 0) > 0
                THEN 1 ELSE 0
            END),
            0
        )
        AS decimal(6,2)
    ) AS presence_percentage,

    CAST(
        100.0 *
        SUM(CASE
            WHEN ISNULL(d.required_work_hours, 0) > 0
             AND d.attendance_status = 'Absent'
            THEN 1 ELSE 0
        END)
        / NULLIF(
            SUM(CASE
                WHEN ISNULL(d.required_work_hours, 0) > 0
                THEN 1 ELSE 0
            END),
            0
        )
        AS decimal(6,2)
    ) AS absence_percentage,

    --------------------------------------------------
    -- Hours: payroll-required days
    --------------------------------------------------
    CAST(SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
        THEN ISNULL(d.worked_hours, 0)
        ELSE 0
    END) AS decimal(10,2)) AS regular_worked_hours,

    CAST(SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
        THEN ISNULL(d.required_work_hours, 0)
        ELSE 0
    END) AS decimal(10,2)) AS regular_required_hours,

    CAST(SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
        THEN ISNULL(d.ot_hours, 0)
        ELSE 0
    END) AS decimal(10,2)) AS normal_ot_hours,

	CAST(SUM(CASE
		WHEN ISNULL(d.required_work_hours, 0) = 0
		 AND ISNULL(d.ot_hours, 0) > 0
		THEN ISNULL(d.ot_hours, 0)
		ELSE 0
	END) AS decimal(10,2)) AS pure_ot_hours,

	CAST(SUM(ISNULL(d.ot_hours, 0)) AS decimal(10,2)) AS total_ot_hours,

    CAST(SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
        THEN ISNULL(d.late_minutes, 0)
        ELSE 0
    END) AS int) AS late_minutes,

    CAST(SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
        THEN ISNULL(d.early_out_minutes, 0)
        ELSE 0
    END) AS int) AS early_out_minutes,

    CAST(SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
        THEN ISNULL(d.late_minutes, 0)
        ELSE 0
    END) / 60.0 AS decimal(10,2)) AS late_hours,

    CAST(SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
        THEN ISNULL(d.early_out_minutes, 0)
        ELSE 0
    END) / 60.0 AS decimal(10,2)) AS early_out_hours,

	CAST(SUM(CASE
		WHEN ISNULL(d.required_work_hours, 0) > 0
		THEN ISNULL(d.recomputed_absence_hours, 0)
		ELSE 0
	END) AS decimal(10,2)) AS absence_hours,

    --------------------------------------------------
    -- Hours: all days / special days
    --------------------------------------------------
    CAST(SUM(ISNULL(d.worked_hours, 0)) AS decimal(10,2)) AS total_worked_hours,
    CAST(SUM(CASE WHEN d.date_type = 1 THEN ISNULL(d.worked_hours, 0) ELSE 0 END) AS decimal(10,2)) AS holiday_worked_hours,
    CAST(SUM(CASE WHEN d.date_type = 2 THEN ISNULL(d.worked_hours, 0) ELSE 0 END) AS decimal(10,2)) AS restday_worked_hours,
    CAST(SUM(CASE WHEN d.date_type IN (1,2) THEN ISNULL(d.ot_hours, 0) ELSE 0 END) AS decimal(10,2)) AS special_day_ot_hours,

    --------------------------------------------------
    -- OT day counts
    --------------------------------------------------
    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
         AND ISNULL(d.ot_hours, 0) > 0
        THEN 1 ELSE 0
    END) AS Regular_Days_with_OT,

    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) = 0
         AND ISNULL(d.ot_hours, 0) > 0
        THEN 1 ELSE 0
    END) AS Pure_Ot_Days,

    SUM(CASE WHEN d.date_type = 1 AND ISNULL(d.ot_hours, 0) > 0 THEN 1 ELSE 0 END) AS Holiday_OT_Days,
    SUM(CASE WHEN d.date_type = 2 AND ISNULL(d.ot_hours, 0) > 0 THEN 1 ELSE 0 END) AS RestDay_OT_Days,

    --------------------------------------------------
    -- Punch issue counts on payroll-required days
    --------------------------------------------------
    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
         AND d.punch_status = 'NoPunch'
        THEN 1 ELSE 0
    END) AS no_punch_days,

    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
         AND d.punch_status = 'MissingOut'
        THEN 1 ELSE 0
    END) AS missing_out_days,

    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
         AND d.punch_status = 'MissingIn'
        THEN 1 ELSE 0
    END) AS missing_in_days,

    SUM(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
         AND d.punch_status NOT IN ('OK','NoPunch','MissingOut','MissingIn')
        THEN 1 ELSE 0
    END) AS invalid_punch_days,

    --------------------------------------------------
    -- Holiday / rest-day worked counts
    --------------------------------------------------
    SUM(CASE WHEN d.date_type = 1 AND ISNULL(d.worked_hours, 0) > 0 THEN 1 ELSE 0 END) AS holiday_work_days,
    SUM(CASE WHEN d.date_type = 2 AND ISNULL(d.worked_hours, 0) > 0 THEN 1 ELSE 0 END) AS restday_work_days,

    --------------------------------------------------
    -- Schedule label buckets
    --------------------------------------------------
    SUM(CASE WHEN d.schedule_label = 'Holiday Work (Unscheduled)' THEN 1 ELSE 0 END) AS holiday_unscheduled_work_days,
    SUM(CASE WHEN d.schedule_label = 'Unscheduled Work' THEN 1 ELSE 0 END) AS unscheduled_work_days,
    SUM(CASE WHEN d.schedule_label = 'Assigned Off Day' AND ISNULL(d.worked_hours,0) > 0 THEN 1 ELSE 0 END) AS worked_on_assigned_off_day_days,
    SUM(CASE WHEN d.schedule_label = 'Temporary Schedule Pure OT' THEN 1 ELSE 0 END) AS temporary_pure_ot_days,

    --------------------------------------------------
    -- Anomaly buckets
    --------------------------------------------------
    SUM(CASE WHEN d.anomaly_flag = 'HolidayWorkedUnscheduled' THEN 1 ELSE 0 END) AS holiday_worked_unscheduled_days,
    SUM(CASE WHEN d.anomaly_flag = 'WorkedOnAssignedOffDay' THEN 1 ELSE 0 END) AS worked_on_assigned_off_day_anomaly_days,
    SUM(CASE WHEN d.anomaly_flag = 'WorkedOnTrueUnscheduledDay' THEN 1 ELSE 0 END) AS worked_on_true_unscheduled_day_days,
    SUM(CASE WHEN d.anomaly_flag = 'ExcessWorkNoOT' THEN 1 ELSE 0 END) AS excess_work_no_ot_days,
    SUM(CASE WHEN d.anomaly_flag = 'NoPunch' THEN 1 ELSE 0 END) AS anomaly_no_punch_days,
    SUM(CASE WHEN d.anomaly_flag = 'MissingOut' THEN 1 ELSE 0 END) AS anomaly_missing_out_days,
    SUM(CASE WHEN d.anomaly_flag = 'MissingIn' THEN 1 ELSE 0 END) AS anomaly_missing_in_days,
    SUM(CASE WHEN d.anomaly_flag = 'ExcessiveWorkHours' THEN 1 ELSE 0 END) AS excessive_work_hours_days,
    SUM(CASE WHEN d.anomaly_flag = 'MissingSchedule' THEN 1 ELSE 0 END) AS missing_schedule_days,

    --------------------------------------------------
    -- Compensatory leave
    --------------------------------------------------
    SUM(CASE WHEN ISNULL(d.comp_leave_eligible_flag, 0) = 1 THEN 1 ELSE 0 END) AS comp_leave_eligible_days,
    SUM(ISNULL(d.comp_leave_minutes, 0)) AS comp_leave_minutes,
    CAST(SUM(ISNULL(d.comp_leave_hours, 0)) AS decimal(10,2)) AS comp_leave_hours,

    --------------------------------------------------
    -- Review counts
    --------------------------------------------------
    SUM(CASE WHEN ISNULL(d.anomaly_flag, 'Normal') <> 'Normal' THEN 1 ELSE 0 END) AS anomaly_days,
    SUM(CASE WHEN ISNULL(d.needs_payroll_review, 0) = 1 THEN 1 ELSE 0 END) AS review_days,

    --------------------------------------------------
    -- Averages
    --------------------------------------------------
    CAST(AVG(CASE
        WHEN ISNULL(d.required_work_hours, 0) > 0
        THEN ISNULL(d.work_completion_pct, 0)
    END) AS decimal(6,2)) AS avg_work_completion_pct

FROM dbo.custom_att_DailyAttendanceSummary d
LEFT JOIN dbo.personnel_employee e
    ON d.emp_id = e.id
LEFT JOIN dbo.personnel_department dept
    ON e.department_id = dept.id
GROUP BY
    YEAR(d.att_date),
    MONTH(d.att_date),
    d.emp_id,
    e.emp_code,
    e.first_name,
    e.last_name,
    dept.dept_name;