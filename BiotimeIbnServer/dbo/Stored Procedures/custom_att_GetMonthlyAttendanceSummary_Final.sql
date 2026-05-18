CREATE PROCEDURE dbo.custom_att_GetMonthlyAttendanceSummary_Final
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL,
    @SortBy   varchar(50) = 'emp_id',
    @SortDir  varchar(4)  = 'ASC'
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH r AS
    (
        SELECT
            d.emp_id,
            e.emp_code AS employee_code,
            CONCAT(e.first_name, ' ', e.last_name) AS employee_name,
            dept.dept_name AS department_name,

            SUM(d.is_regular_required_day) AS need_present_days,
            SUM(d.is_holiday_day)          AS holiday_days,
            SUM(d.is_rest_day)             AS rest_days,
            SUM(d.is_pure_ot_day)          AS pure_ot_days,
            SUM(d.is_present_regular_day)  AS actual_present_days,
            SUM(d.is_absent_day)           AS absent_days,

            SUM(CASE WHEN d.is_regular_required_day = 1 
                     THEN d.recomputed_worked_minutes ELSE 0 END) / 60.0 AS total_work_hours,

            SUM(CASE WHEN d.is_pure_ot_day = 1 
                     THEN d.recomputed_worked_minutes ELSE 0 END) / 60.0 AS total_ot_hours
        FROM dbo.custom_att_calc_DailyDayClassification d
        LEFT JOIN dbo.personnel_employee e
            ON d.emp_id = e.id
        LEFT JOIN dbo.personnel_department dept
            ON e.department_id = dept.id
        WHERE d.att_date BETWEEN @DateFrom AND @DateTo
          AND (@EmpID IS NULL OR d.emp_id = @EmpID)
        GROUP BY
            d.emp_id,
            e.emp_code,
            e.first_name,
            e.last_name,
            dept.dept_name
    )
    SELECT *
    FROM r
    ORDER BY
        CASE WHEN @SortBy = 'emp_id' AND @SortDir = 'ASC' THEN emp_id END ASC,
        CASE WHEN @SortBy = 'emp_id' AND @SortDir = 'DESC' THEN emp_id END DESC,

        CASE WHEN @SortBy = 'absent_days' AND @SortDir = 'ASC' THEN absent_days END ASC,
        CASE WHEN @SortBy = 'absent_days' AND @SortDir = 'DESC' THEN absent_days END DESC,

        CASE WHEN @SortBy = 'actual_present_days' AND @SortDir = 'ASC' THEN actual_present_days END ASC,
        CASE WHEN @SortBy = 'actual_present_days' AND @SortDir = 'DESC' THEN actual_present_days END DESC,

        CASE WHEN @SortBy = 'need_present_days' AND @SortDir = 'ASC' THEN need_present_days END ASC,
        CASE WHEN @SortBy = 'need_present_days' AND @SortDir = 'DESC' THEN need_present_days END DESC,

        CASE WHEN @SortBy = 'total_work_hours' AND @SortDir = 'ASC' THEN total_work_hours END ASC,
        CASE WHEN @SortBy = 'total_work_hours' AND @SortDir = 'DESC' THEN total_work_hours END DESC,

        emp_id ASC;
END;