CREATE TYPE [dbo].[EmployeeDeductionUpdate] AS TABLE (
    [Amount]        SMALLMONEY NULL,
    [EmployeeIdNo]  INT        NOT NULL,
    [DeductionIdNo] SMALLINT   NOT NULL,
    [IDNo]          INT        NOT NULL,
    [Sequence]      INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

