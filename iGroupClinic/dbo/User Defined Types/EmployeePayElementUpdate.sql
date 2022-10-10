CREATE TYPE [dbo].[EmployeePayElementUpdate] AS TABLE (
    [Amount]         SMALLMONEY NULL,
    [EmployeeIdNo]   INT        NOT NULL,
    [IdNo]           INT        NOT NULL,
    [PayElementIdNo] SMALLINT   NOT NULL,
    [Rate]           SMALLMONEY NULL,
    [Sequence]       INT        NOT NULL,
    [Unit]           CHAR (1)   NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

