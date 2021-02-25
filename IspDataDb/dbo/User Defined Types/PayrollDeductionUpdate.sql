CREATE TYPE [dbo].[PayrollDeductionUpdate] AS TABLE (
    [Amount]        MONEY    NULL,
    [DeductionIdNo] SMALLINT NOT NULL,
    [EmployeeIdNo]  INT      NOT NULL,
    [IdNo]          INT      NOT NULL,
    [PayrollIdNo]   SMALLINT NOT NULL);

