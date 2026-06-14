
CREATE PROCEDURE dbo.custom_att_GetMonthlyAuditTopIssues
    @DateFrom date,
    @DateTo   date,
    @TopN     int = 10
AS
BEGIN
    SET NOCOUNT ON;

    CREATE TABLE #t
    (
        year_no int,
        month_no int,
        emp_id int,
        emp_code nvarchar(50),
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

    INSERT INTO #t
    EXEC dbo.custom_att_GetMonthlyAttendanceSummary_Fast
        @DateFrom = @DateFrom,
        @DateTo   = @DateTo,
        @EmpID    = NULL;

    SELECT TOP (@TopN)
        emp_id,
        emp_code,
        employee_name,
        department_name,

        review_days,
        anomaly_days,
        no_punch_days,
        missing_out_days,
        missing_in_days,
        excess_work_no_ot_days,
        absence_hours,
        late_hours,
        early_out_hours,

        total_worked_hours,
        total_ot_hours,
        avg_work_completion_pct

    FROM #t
    ORDER BY
        review_days DESC,
        anomaly_days DESC,
        absence_hours DESC,
        late_hours DESC;
END
