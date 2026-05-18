
CREATE PROCEDURE dbo.Custom_att_ProcessMonthlyPayrollFacts_Batched
    @DateFrom date,
    @DateTo   date
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @EmpID int;

    DECLARE emp_cursor CURSOR LOCAL FAST_FORWARD FOR
    SELECT DISTINCT emp_id
    FROM dbo.custom_att_calc_DailyBase
    WHERE att_date BETWEEN @DateFrom AND @DateTo
    ORDER BY emp_id;

    OPEN emp_cursor;

    FETCH NEXT FROM emp_cursor INTO @EmpID;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        PRINT CONCAT('Processing EmpID: ', @EmpID);

        EXEC dbo.Custom_att_ProcessMonthlyPayrollFacts
            @DateFrom = @DateFrom,
            @DateTo   = @DateTo,
            @EmpID    = @EmpID;

        FETCH NEXT FROM emp_cursor INTO @EmpID;
    END;

    CLOSE emp_cursor;
    DEALLOCATE emp_cursor;

    SELECT
        @DateFrom AS date_from,
        @DateTo AS date_to,
        COUNT(*) AS rows_processed,
        COUNT(DISTINCT emp_id) AS employees_processed,
        MIN(att_date) AS min_date,
        MAX(att_date) AS max_date
    FROM dbo.Custom_att_fact_DailyAttendance
    WHERE att_date BETWEEN @DateFrom AND @DateTo;
END;