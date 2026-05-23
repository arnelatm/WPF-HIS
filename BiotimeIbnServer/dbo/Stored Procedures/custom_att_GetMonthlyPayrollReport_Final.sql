

CREATE PROCEDURE [dbo].[custom_att_GetMonthlyPayrollReport_Final]
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ScheduleWindowToleranceMinutes int = 60;
    DECLARE @ScheduleWorkedToleranceMinutes int = 30;

    ;WITH FactWithSchedule AS
    (
        SELECT
            f.*,
            es.effective_scheduled_in_datetime,
            es.effective_scheduled_out_datetime
        FROM dbo.custom_att_fact_DailyAttendance f
        LEFT JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
            ON es.emp_id = f.emp_id
           AND es.att_date = f.att_date
        WHERE f.att_date BETWEEN @DateFrom AND @DateTo
          AND (@EmpID IS NULL OR f.emp_id = @EmpID)
          AND NOT EXISTS
          (
              SELECT 1
              FROM dbo.personnel_resign r
              WHERE r.employee_id = f.emp_id
                AND f.att_date > r.resign_date
          )
    ),
    Monthly AS
    (
        SELECT
            f.emp_id,
            YEAR(@DateFrom) AS year_no,
            MONTH(@DateFrom) AS month_no,
            e.emp_code,
            e.first_name,
            d.dept_name AS department_name,
            COUNT(*) AS calendar_days,

            SUM(CASE WHEN f.daily_status = 'RegularDay' THEN 1 ELSE 0 END) AS regular_days,
            SUM(CASE WHEN f.daily_status = 'Holiday' THEN 1 ELSE 0 END) AS holiday_days,
            SUM(CASE WHEN f.daily_status = 'RestDay' THEN 1 ELSE 0 END) AS rest_days,

            SUM(CASE 
                WHEN f.required_scheduled_hours > 0 THEN 1 
                ELSE 0 
            END) AS required_work_days,

            SUM(CASE 
                WHEN f.attendance_status IN ('Present', 'Partial')
                THEN 1 ELSE 0 
            END) AS actual_reg_present_days,

            SUM(CASE 
                WHEN f.attendance_status IN ('Present', 'Partial')
                  OR ISNULL(f.worked_hours, 0) > 0
                THEN 1 ELSE 0 
            END) AS actual_present_days,

            SUM(CASE 
                WHEN f.attendance_status = 'Absent'
                THEN 1 ELSE 0 
            END) AS absent_days,

            SUM(CASE 
                WHEN f.attendance_status = 'Partial'
                THEN 1 ELSE 0 
            END) AS partial_days,

            CAST(SUM(ISNULL(f.required_scheduled_hours, 0)) AS decimal(10,2)) AS total_required_hours,
            CAST(SUM(ISNULL(f.worked_hours, 0)) AS decimal(10,2)) AS total_worked_hours,
            CAST(SUM(ISNULL(f.ot_hours, 0)) AS decimal(10,2)) AS total_ot_hours,
            CAST(SUM(ISNULL(f.excess_hours, 0)) AS decimal(10,2)) AS total_excess_hours,
            SUM(ISNULL(f.actual_excess_minutes, 0)) AS total_actual_excess_minutes,
            CAST(SUM(ISNULL(f.shortfall_hours, 0)) AS decimal(10,2)) AS total_shortfall_hours,
            CAST(SUM(ISNULL(f.recomputed_absence_hours, 0)) AS decimal(10,2)) AS total_absence_hours,

            SUM(ISNULL(f.late_minutes, 0)) AS total_late_minutes,
            CAST(SUM(ISNULL(f.late_minutes, 0)) / 60.0 AS decimal(10,2)) AS total_late_hours,

            SUM(ISNULL(f.actual_late_minutes, 0)) AS total_actual_late_minutes,
            CAST(SUM(ISNULL(f.actual_late_minutes, 0)) / 60.0 AS decimal(10,2)) AS total_actual_late_hours,

            SUM(ISNULL(f.early_out_minutes, 0)) AS total_early_out_minutes,
            CAST(SUM(ISNULL(f.early_out_minutes, 0)) / 60.0 AS decimal(10,2)) AS total_early_out_hours,

            SUM(ISNULL(f.actual_early_out_minutes, 0)) AS total_actual_early_out_minutes,
            CAST(SUM(ISNULL(f.actual_early_out_minutes, 0)) / 60.0 AS decimal(10,2)) AS total_actual_early_out_hours,

            SUM(CASE 
                WHEN f.reconciliation_status = 'Balanced' THEN 1 
                ELSE 0 
            END) AS balanced_days,

            SUM(CASE 
                WHEN f.reconciliation_status = 'ExcessNonOT' THEN 1 
                ELSE 0 
            END) AS excess_non_ot_days,

            SUM(CASE 
                WHEN f.reconciliation_status = 'Shortfall' THEN 1 
                ELSE 0 
            END) AS shortfall_days,

            SUM(CASE 
                WHEN ISNULL(f.needs_payroll_review, 0) = 1 THEN 1 
                ELSE 0 
            END) AS review_days,

            SUM(CASE 
                WHEN f.anomaly_flag IN ('MissingIn', 'MissingOut', 'NoPunch', 'IncompletePunchPair')
                THEN 1 ELSE 0
            END) AS no_punch_in_or_out_days,

            SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                 AND f.anomaly_flag IN ('MissingIn', 'MissingOut', 'IncompletePunchPair')
                THEN 1 ELSE 0
            END) AS incomplete_punch_days,

            SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                 AND f.effective_scheduled_in_datetime IS NOT NULL
                 AND
                 (
                     (
                         f.first_clock_in IS NOT NULL
                     AND f.last_clock_out IS NOT NULL
                     AND f.effective_scheduled_out_datetime IS NOT NULL
                     AND ISNULL(f.recomputed_worked_minutes, 0) >= (ISNULL(f.required_scheduled_hours, 0) * 60.0) - @ScheduleWorkedToleranceMinutes
                     AND
                         (
                             (
                                 DATEDIFF(MINUTE, f.first_clock_in, f.effective_scheduled_in_datetime) >= @ScheduleWindowToleranceMinutes
                             AND DATEDIFF(MINUTE, f.last_clock_out, f.effective_scheduled_out_datetime) >= @ScheduleWindowToleranceMinutes
                             )
                          OR (
                                 DATEDIFF(MINUTE, f.effective_scheduled_in_datetime, f.first_clock_in) >= @ScheduleWindowToleranceMinutes
                             AND DATEDIFF(MINUTE, f.effective_scheduled_out_datetime, f.last_clock_out) >= @ScheduleWindowToleranceMinutes
                             )
                         )
                     )
                  OR (
                         f.first_clock_in IS NOT NULL
                     AND f.last_clock_out IS NULL
                     AND ABS(DATEDIFF(MINUTE, f.effective_scheduled_in_datetime, f.first_clock_in)) >= @ScheduleWindowToleranceMinutes
                     )
                  )
                THEN 1 ELSE 0
            END) AS schedule_in_mismatch_days,

            SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                 AND f.effective_scheduled_out_datetime IS NOT NULL
                 AND
                 (
                     (
                         f.first_clock_in IS NOT NULL
                     AND f.last_clock_out IS NOT NULL
                     AND f.effective_scheduled_in_datetime IS NOT NULL
                     AND ISNULL(f.recomputed_worked_minutes, 0) >= (ISNULL(f.required_scheduled_hours, 0) * 60.0) - @ScheduleWorkedToleranceMinutes
                     AND
                         (
                             (
                                 DATEDIFF(MINUTE, f.first_clock_in, f.effective_scheduled_in_datetime) >= @ScheduleWindowToleranceMinutes
                             AND DATEDIFF(MINUTE, f.last_clock_out, f.effective_scheduled_out_datetime) >= @ScheduleWindowToleranceMinutes
                             )
                          OR (
                                 DATEDIFF(MINUTE, f.effective_scheduled_in_datetime, f.first_clock_in) >= @ScheduleWindowToleranceMinutes
                             AND DATEDIFF(MINUTE, f.effective_scheduled_out_datetime, f.last_clock_out) >= @ScheduleWindowToleranceMinutes
                             )
                         )
                     )
                  OR (
                         f.first_clock_in IS NULL
                     AND f.last_clock_out IS NOT NULL
                     AND ABS(DATEDIFF(MINUTE, f.effective_scheduled_out_datetime, f.last_clock_out)) >= @ScheduleWindowToleranceMinutes
                     )
                  )
                THEN 1 ELSE 0
            END) AS schedule_out_mismatch_days,

            SUM(CASE
                WHEN ISNULL(f.required_scheduled_hours, 0) > 0
                 AND f.effective_scheduled_in_datetime IS NOT NULL
                 AND f.effective_scheduled_out_datetime IS NOT NULL
                 AND
                 (
                     (
                         f.first_clock_in IS NOT NULL
                     AND f.last_clock_out IS NOT NULL
                     AND ISNULL(f.recomputed_worked_minutes, 0) >= (ISNULL(f.required_scheduled_hours, 0) * 60.0) - @ScheduleWorkedToleranceMinutes
                     AND
                         (
                             (
                                 DATEDIFF(MINUTE, f.first_clock_in, f.effective_scheduled_in_datetime) >= @ScheduleWindowToleranceMinutes
                             AND DATEDIFF(MINUTE, f.last_clock_out, f.effective_scheduled_out_datetime) >= @ScheduleWindowToleranceMinutes
                             )
                          OR (
                                 DATEDIFF(MINUTE, f.effective_scheduled_in_datetime, f.first_clock_in) >= @ScheduleWindowToleranceMinutes
                             AND DATEDIFF(MINUTE, f.effective_scheduled_out_datetime, f.last_clock_out) >= @ScheduleWindowToleranceMinutes
                             )
                         )
                     )
                  OR (
                         f.first_clock_in IS NOT NULL
                     AND f.last_clock_out IS NULL
                     AND ABS(DATEDIFF(MINUTE, f.effective_scheduled_in_datetime, f.first_clock_in)) >= @ScheduleWindowToleranceMinutes
                     )
                  OR (
                         f.first_clock_in IS NULL
                     AND f.last_clock_out IS NOT NULL
                     AND ABS(DATEDIFF(MINUTE, f.effective_scheduled_out_datetime, f.last_clock_out)) >= @ScheduleWindowToleranceMinutes
                     )
                  )
                THEN 1 ELSE 0
            END) AS schedule_window_mismatch_days,

            CAST(SUM(ISNULL(f.reconciliation_variance_minutes, 0)) / 60.0 AS decimal(10,2)) 
                AS reconciliation_variance_hours,

            CAST(SUM(ISNULL(f.work_gap_minutes, 0)) AS decimal(10,2)) 
                AS total_work_gap_minutes

        FROM FactWithSchedule f
        LEFT JOIN dbo.personnel_employee e
            ON f.emp_id = e.id
        LEFT JOIN dbo.personnel_department d
            ON e.department_id = d.id
        GROUP BY
            f.emp_id,
            e.emp_code,
            e.first_name,
            d.dept_name
    )
    SELECT
        m.emp_id,
        m.year_no,
        m.month_no,
        m.emp_code,
        m.first_name,
        m.department_name,
		CASE
            WHEN m.review_days > 0
            THEN 'Needs Review'

            WHEN m.no_punch_in_or_out_days > 0
            THEN 'Missing Punches'

            WHEN m.schedule_window_mismatch_days > 0
            THEN 'Schedule Mismatch'

            WHEN m.shortfall_days > 0
            THEN 'Shortfall Detected'

            WHEN m.excess_non_ot_days > 0
                 AND m.review_days = 0
                 AND m.shortfall_days = 0
            THEN 'Excess Non-OT Work'

            WHEN m.review_days = 0
			 AND m.no_punch_in_or_out_days = 0
			 AND m.schedule_window_mismatch_days = 0
			 AND m.shortfall_days = 0
		THEN 'Payroll Ready'

		ELSE 'Reconciliation Issue'

        END AS payroll_audit_status,
        m.calendar_days,
        m.regular_days,
        m.holiday_days,
        m.rest_days,
        m.required_work_days,
        m.actual_reg_present_days,
        m.actual_present_days,
        m.absent_days,
        m.partial_days,
        m.total_required_hours,
        m.total_worked_hours,
        m.total_ot_hours,
        m.total_excess_hours,
        m.total_actual_excess_minutes,
        m.total_shortfall_hours,
        m.total_absence_hours,
        m.total_late_minutes,
        m.total_late_hours,
        m.total_actual_late_minutes,
        m.total_actual_late_hours,
        m.total_early_out_minutes,
        m.total_early_out_hours,
        m.total_actual_early_out_minutes,
        m.total_actual_early_out_hours,
        m.balanced_days,
        m.excess_non_ot_days,
        m.shortfall_days,
        m.review_days,
        m.no_punch_in_or_out_days,
        m.incomplete_punch_days,
        m.schedule_in_mismatch_days,
        m.schedule_out_mismatch_days,
        m.schedule_window_mismatch_days,
        m.reconciliation_variance_hours,
        m.total_work_gap_minutes

    FROM Monthly m
    ORDER BY m.department_name,m.first_name;
END;
