CREATE TYPE [dbo].[PayrollDeductionInsert] AS TABLE (
    [Amount]        MONEY    NULL,
    [DeductionIdNo] SMALLINT NOT NULL,
    [EmployeeIdNo]  INT      NOT NULL,
    [PayrollIdNo]   SMALLINT NOT NULL);

