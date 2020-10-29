CREATE TYPE [dbo].[PensionRateInsert] AS TABLE (
    [EmployeeShare]     DECIMAL (8, 2) NOT NULL,
    [EmployerShare]     DECIMAL (8, 2) NOT NULL,
    [HighRange]         MONEY          NOT NULL,
    [LowRange]          MONEY          NOT NULL,
    [MaxAmount]         MONEY          NOT NULL,
    [PensionSchemeIdNo] SMALLINT       NOT NULL,
    [Sequence]          SMALLINT       NOT NULL);

