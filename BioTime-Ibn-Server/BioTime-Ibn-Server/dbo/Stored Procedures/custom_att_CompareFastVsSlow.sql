
CREATE PROCEDURE dbo.custom_att_CompareFastVsSlow
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    CREATE TABLE #slow
    (
        year_no int,
        month_no int,
        emp_id int,
        employee_code nvarchar(50),
        employee_name nvarchar(200),
        department_name nvarchar(200),
        need_present_days int,
        holiday_days int,
        rest_days int,
        actual_present_days int,
        actual_absence_days int,
        computed_present_days int,
        computed_absence_days int,
        present_days int,
        partial_days int,
        absent_days int,
        presence_percentage decimal(10,2),
        absence_percentage decimal(10,2),
        regular_worked_hours decimal(10,2),
        regular_required_hours decimal(10,2),
        normal_ot_hours decimal(10,2),
        pure_ot_hours decimal(10,2),
        total_ot_hours decimal(10,2),
        late_minutes decimal(10,2),
        early_out_minutes decimal(10,2),
        late_hours decimal(10,2),
        early_out_hours decimal(10,2),
        absence_hours decimal(10,2),
        total_worked_hours decimal(10,2),
        holiday_worked_hours decimal(10,2),
        restday_worked_hours decimal(10,2),
        special_day_ot_hours decimal(10,2),
        Regular_Days_with_OT int,
        Pure_Ot_Days int,
        Holiday_OT_Days int,
        RestDay_OT_Days int,
        no_punch_days int,
        missing_out_days int,
        missing_in_days int,
        invalid_punch_days int,
        holiday_work_days int,
        restday_work_days int,
        holiday_unscheduled_work_days int,
        unscheduled_work_days int,
        worked_on_assigned_off_day_days int,
        temporary_pure_ot_days int,
        holiday_worked_unscheduled_days int,
        worked_on_assigned_off_day_anomaly_days int,
        worked_on_true_unscheduled_day_days int,
        excess_work_no_ot_days int,
        anomaly_no_punch_days int,
        anomaly_missing_out_days int,
        anomaly_missing_in_days int,
        excessive_work_hours_days int,
        missing_schedule_days int,
        comp_leave_eligible_days int,
        comp_leave_minutes decimal(10,2),
        comp_leave_hours decimal(10,2),
        anomaly_days int,
        review_days int,
        avg_work_completion_pct decimal(10,2)
    );

    CREATE TABLE #fast
    (
        year_no int,
        month_no int,
        emp_id int,
        employee_code nvarchar(50),
        employee_name nvarchar(200),
        department_name nvarchar(200),
        need_present_days int,
        holiday_days int,
        rest_days int,
        actual_present_days int,
        actual_absence_days int,
        computed_present_days int,
        computed_absence_days int,
        present_days int,
        partial_days int,
        absent_days int,
        presence_percentage decimal(10,2),
        absence_percentage decimal(10,2),
        regular_worked_hours decimal(10,2),
        regular_required_hours decimal(10,2),
        normal_ot_hours decimal(10,2),
        pure_ot_hours decimal(10,2),
        total_ot_hours decimal(10,2),
        late_minutes decimal(10,2),
        early_out_minutes decimal(10,2),
        late_hours decimal(10,2),
        early_out_hours decimal(10,2),
        absence_hours decimal(10,2),
        total_worked_hours decimal(10,2),
        holiday_worked_hours decimal(10,2),
        restday_worked_hours decimal(10,2),
        special_day_ot_hours decimal(10,2),
        Regular_Days_with_OT int,
        Pure_Ot_Days int,
        Holiday_OT_Days int,
        RestDay_OT_Days int,
        no_punch_days int,
        missing_out_days int,
        missing_in_days int,
        invalid_punch_days int,
        holiday_work_days int,
        restday_work_days int,
        holiday_unscheduled_work_days int,
        unscheduled_work_days int,
        worked_on_assigned_off_day_days int,
        temporary_pure_ot_days int,
        holiday_worked_unscheduled_days int,
        worked_on_assigned_off_day_anomaly_days int,
        worked_on_true_unscheduled_day_days int,
        excess_work_no_ot_days int,
        anomaly_no_punch_days int,
        anomaly_missing_out_days int,
        anomaly_missing_in_days int,
        excessive_work_hours_days int,
        missing_schedule_days int,
        comp_leave_eligible_days int,
        comp_leave_minutes decimal(10,2),
        comp_leave_hours decimal(10,2),
        anomaly_days int,
        review_days int,
        avg_work_completion_pct decimal(10,2)
    );

    INSERT INTO #slow
    EXEC dbo.custom_att_GetMonthlyAttendanceSummary
        @DateFrom = @DateFrom,
        @DateTo   = @DateTo,
        @EmpID    = @EmpID;

    INSERT INTO #fast
    EXEC dbo.custom_att_GetMonthlyAttendanceSummary_Fast
        @DateFrom = @DateFrom,
        @DateTo   = @DateTo,
        @EmpID    = @EmpID;

    SELECT
        s.emp_id,
        s.employee_code,
        s.employee_name,
        s.department_name,
        s.year_no,
        s.month_no,

        s.total_worked_hours AS slow_total_worked_hours,
        f.total_worked_hours AS fast_total_worked_hours,

        s.total_ot_hours AS slow_total_ot_hours,
        f.total_ot_hours AS fast_total_ot_hours,

        s.absence_hours AS slow_absence_hours,
        f.absence_hours AS fast_absence_hours,

        s.late_minutes AS slow_late_minutes,
        f.late_minutes AS fast_late_minutes,

        s.early_out_minutes AS slow_early_out_minutes,
        f.early_out_minutes AS fast_early_out_minutes,

        s.review_days AS slow_review_days,
        f.review_days AS fast_review_days,

        s.avg_work_completion_pct AS slow_avg_work_completion_pct,
        f.avg_work_completion_pct AS fast_avg_work_completion_pct

    FROM #slow s
    INNER JOIN #fast f
        ON s.emp_id = f.emp_id
       AND s.year_no = f.year_no
       AND s.month_no = f.month_no
    WHERE
        ABS(ISNULL(s.total_worked_hours, 0) - ISNULL(f.total_worked_hours, 0)) > 0.01
        OR ABS(ISNULL(s.total_ot_hours, 0) - ISNULL(f.total_ot_hours, 0)) > 0.01
        OR ABS(ISNULL(s.absence_hours, 0) - ISNULL(f.absence_hours, 0)) > 0.01
        OR ABS(ISNULL(s.late_minutes, 0) - ISNULL(f.late_minutes, 0)) > 0.01
        OR ABS(ISNULL(s.early_out_minutes, 0) - ISNULL(f.early_out_minutes, 0)) > 0.01
        OR ABS(ISNULL(s.review_days, 0) - ISNULL(f.review_days, 0)) > 0.01
        OR ABS(ISNULL(s.avg_work_completion_pct, 0) - ISNULL(f.avg_work_completion_pct, 0)) > 0.01;
END
