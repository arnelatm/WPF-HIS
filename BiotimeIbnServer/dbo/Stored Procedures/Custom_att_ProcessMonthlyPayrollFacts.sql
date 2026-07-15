CREATE PROCEDURE [dbo].[Custom_att_ProcessMonthlyPayrollFacts]
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    EXEC dbo.custom_att_processPayrollFacts
        @DateFrom = @DateFrom,
        @DateTo = @DateTo,
        @EmpID = @EmpID;
END;
