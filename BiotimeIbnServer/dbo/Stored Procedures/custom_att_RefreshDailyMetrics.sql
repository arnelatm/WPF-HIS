CREATE PROCEDURE dbo.custom_att_RefreshDailyMetrics
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF OBJECT_ID('tempdb..#punch_agg') IS NOT NULL
        DROP TABLE #punch_agg;

    SELECT
        t.emp_id,
        CAST(t.punch_time AS date) AS att_date,
        COUNT_BIG(*) AS punch_count,
        MIN(t.punch_time) AS first_any_punch,
        MAX(t.punch_time) AS last_any_punch,
        MIN(CASE WHEN t.punch_state = 0 THEN t.punch_time END) AS first_in,
        MAX(CASE WHEN t.punch_state = 1 THEN t.punch_time END) AS last_out
    INTO #punch_agg
    FROM dbo.iclock_transaction t
    WHERE t.punch_time >= @DateFrom
      AND t.punch_time < DATEADD(DAY, 1, @DateTo)
      AND (@EmpID IS NULL OR t.emp_id = @EmpID)
    GROUP BY
        t.emp_id,
        CAST(t.punch_time AS date);

    CREATE INDEX IX_punch_agg_emp_date
        ON #punch_agg(emp_id, att_date);

    SELECT
        d.emp_id,
        d.emp_code,
        d.att_date,
        d.year_no,
        d.month_no,
        d.daily_status,
        d.business_day_type,
        d.attendance_status,
        d.anomaly_flag,
        d.anomaly_group,
        d.needs_payroll_review,
        d.first_clock_in,
        d.last_clock_out,
        d.recomputed_worked_minutes,
        d.ot_minutes,
        d.required_scheduled_hours,
        d.worked_hours,
        d.ot_hours,
        d.punch_status,
        d.schedule_label,
        d.late_minutes,
        d.early_out_minutes,
        d.recomputed_absence_hours,
        d.work_completion_pct,
        d.date_type,
        d.comp_leave_eligible_flag,
        d.comp_leave_minutes,
        d.comp_leave_hours,

        ISNULL(p.punch_count, 0) AS punch_count,
        p.first_in,
        p.last_out,
        p.first_any_punch,
        p.last_any_punch,

        CASE 
            WHEN ISNULL(p.punch_count, 0) > 0 THEN 1 
            ELSE 0 
        END AS has_any_punch
    FROM dbo.custom_att_fact_DailyAttendance d
    LEFT JOIN #punch_agg p
        ON p.emp_id = d.emp_id
       AND p.att_date = d.att_date
    WHERE d.att_date >= @DateFrom
      AND d.att_date <= @DateTo
      AND (@EmpID IS NULL OR d.emp_id = @EmpID)
    ORDER BY d.emp_id, d.att_date;
END;
