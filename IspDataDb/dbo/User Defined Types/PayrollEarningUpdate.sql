CREATE TYPE [dbo].[PayrollEarningUpdate] AS TABLE (
    [Amount]       MONEY    NULL,
    [EarningIdNo]  SMALLINT NOT NULL,
    [EmployeeIdNo] INT      NOT NULL,
    [IdNo]         INT      NOT NULL,
    [PayrollIdNo]  SMALLINT NOT NULL);

