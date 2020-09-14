CREATE TYPE [dbo].[EmployeeEarningInsert] AS TABLE (
    [Amount]       MONEY    NULL,
    [EarningIdNo]  SMALLINT NOT NULL,
    [EmployeeIdNo] INT      NOT NULL,
    [Sequence]     INT      NOT NULL);

