CREATE TYPE [dbo].[EmployeeEarningInsert] AS TABLE (
    [Amount]       MONEY    NULL,
    [EarningIdNo]  SMALLINT NOT NULL,
    [EmployeeIdNo] INT      NOT NULL,
    [Rate]         SMALLMONEY NOT NULL,
    [Sequence]     INT      NOT NULL);

