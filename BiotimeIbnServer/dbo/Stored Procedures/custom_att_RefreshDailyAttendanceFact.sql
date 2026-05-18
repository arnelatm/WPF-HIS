CREATE PROCEDURE [dbo].[custom_att_RefreshDailyAttendanceFact]
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE   
        @start_time DATETIME = GETDATE(),
        @end_time DATETIME,
        @rows INT = 0,
        @status VARCHAR(20) = 'SKIPPED',
        @remarks VARCHAR(500) = 'Refresh skipped: custom_att_calc_DailyAttendanceSummary causes SQL Server error 8632. Use targeted manual patch or rebuild source logic.';

    SET @end_time = GETDATE();

    INSERT INTO dbo.custom_att_fact_refresh_log
    (
        date_from, date_to, emp_id,
        start_time, end_time, duration_seconds,
        rows_loaded, status, remarks
    )
    VALUES
    (
        @DateFrom, @DateTo, @EmpID,
        @start_time, @end_time,
        DATEDIFF(SECOND, @start_time, @end_time),
        @rows, @status, @remarks
    );

    SELECT 
        @rows AS rows_loaded,
        @status AS status,
        DATEDIFF(SECOND, @start_time, @end_time) AS duration_seconds,
        @remarks AS remarks;
END
