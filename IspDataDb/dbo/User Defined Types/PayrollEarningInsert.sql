CREATE TYPE [dbo].[PayrollEarningInsert] AS TABLE (
    [Amount]       MONEY    NULL,
    [EarningIdNo]  SMALLINT NOT NULL,
    [EmployeeIdNo] INT      NOT NULL,
    [PayrollIdNo]  SMALLINT NOT NULL);

