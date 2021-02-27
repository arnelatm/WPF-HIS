CREATE TYPE [dbo].[EmployeeDeductionInsert] AS TABLE (
    [Amount]        MONEY    NULL,
    [DeductionIdNo] SMALLINT NOT NULL,
    [EmployeeIdNo]  INT      NOT NULL,
    [Rate]          DECIMAL  NOT NULL,
    [Sequence]      INT      NOT NULL);

