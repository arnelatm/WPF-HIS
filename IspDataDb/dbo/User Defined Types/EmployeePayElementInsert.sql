CREATE TYPE [dbo].[EmployeePayElementInsert] AS TABLE (
    [Amount]         MONEY      NULL,
    [EmployeeIdNo]   INT        NOT NULL,
    [PayElementIdNo] SMALLINT   NOT NULL,
    [Rate]           SMALLMONEY NOT NULL,
    [Sequence]       INT        NOT NULL,
    [Unit]           CHAR (1)   NOT NULL);



