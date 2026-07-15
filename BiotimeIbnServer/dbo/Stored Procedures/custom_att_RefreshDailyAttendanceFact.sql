CREATE PROCEDURE [dbo].[custom_att_RefreshDailyAttendanceFact]
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @LogID int;
    DECLARE @StartTime datetime = GETDATE();
    DECLARE @RowsLoaded int = 0;

    IF @DateFrom > @DateTo
    BEGIN
        DECLARE @SwapDate date = @DateFrom;
        SET @DateFrom = @DateTo;
        SET @DateTo = @SwapDate;
    END;

    INSERT INTO dbo.custom_att_fact_refresh_log
    (
        date_from,
        date_to,
        emp_id,
        start_time,
        status,
        remarks
    )
    VALUES
    (
        @DateFrom,
        @DateTo,
        @EmpID,
        @StartTime,
        'Running',
        'Started dbo.custom_att_processPayrollFacts.'
    );

    SET @LogID = SCOPE_IDENTITY();

    BEGIN TRY
        EXEC dbo.custom_att_processPayrollFacts
            @DateFrom = @DateFrom,
            @DateTo   = @DateTo,
            @EmpID    = @EmpID;

        SELECT
            @RowsLoaded = COUNT(*)
        FROM dbo.custom_att_fact_DailyAttendance f
        WHERE f.att_date BETWEEN @DateFrom AND @DateTo
          AND (@EmpID IS NULL OR f.emp_id = @EmpID);

        UPDATE dbo.custom_att_fact_refresh_log
        SET
            end_time = GETDATE(),
            duration_seconds = DATEDIFF(SECOND, @StartTime, GETDATE()),
            rows_loaded = @RowsLoaded,
            status = 'Succeeded',
            remarks = 'Completed dbo.custom_att_processPayrollFacts.'
        WHERE id = @LogID;

        SELECT
            @LogID AS refresh_log_id,
            @DateFrom AS date_from,
            @DateTo AS date_to,
            @EmpID AS emp_id,
            @RowsLoaded AS rows_loaded,
            CAST('Succeeded' AS varchar(20)) AS status;
    END TRY
    BEGIN CATCH
        UPDATE dbo.custom_att_fact_refresh_log
        SET
            end_time = GETDATE(),
            duration_seconds = DATEDIFF(SECOND, @StartTime, GETDATE()),
            rows_loaded = @RowsLoaded,
            status = 'Failed',
            remarks = LEFT(
                CONCAT(
                    'Error ',
                    ERROR_NUMBER(),
                    ' at line ',
                    ERROR_LINE(),
                    ': ',
                    ERROR_MESSAGE()
                ),
                500
            )
        WHERE id = @LogID;

        THROW;
    END CATCH;
END;
