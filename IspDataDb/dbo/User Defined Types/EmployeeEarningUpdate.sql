CREATE TYPE [dbo].[EmployeeEarningUpdate] AS TABLE (
    [Amount]       SMALLMONEY NULL,
    [EarningIdNo]  SMALLINT   NOT NULL,
    [EmployeeIdNo] INT        NOT NULL,
    [IdNo]         INT        NOT NULL,
    [Rate]         SMALLMONEY NULL,
    [Sequence]     INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

