CREATE TYPE [dbo].[PensionRateUpdate] AS TABLE (
    [EmployeeShare]     DECIMAL (8, 2) NOT NULL,
    [EmployerShare]     DECIMAL (8, 2) NOT NULL,
    [HighRange]         MONEY          NOT NULL,
    [IdNo]              INT            NOT NULL,
    [LowRange]          MONEY          NOT NULL,
    [MaxAmount]         MONEY          NOT NULL,
    [PensionSchemeIdNo] SMALLINT       NOT NULL,
    [Sequence]          SMALLINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

