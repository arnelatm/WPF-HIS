CREATE TYPE [dbo].[EmployeePayElementInsert] AS TABLE (
    [Amount]         MONEY      NULL,
    [PayElementIdNo] SMALLINT   NOT NULL,
    [EmployeeIdNo]   INT        NOT NULL,
    [Rate]           SMALLMONEY NOT NULL,
    [Sequence]       INT        NOT NULL);

