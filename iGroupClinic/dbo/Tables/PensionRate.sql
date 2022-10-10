CREATE TABLE [dbo].[PensionRate] (
    [IdNo]              SMALLINT       IDENTITY (1, 1) NOT NULL,
    [PensionSchemeIdNo] SMALLINT       NULL,
    [LowRange]          MONEY          NULL,
    [HighRange]         MONEY          NULL,
    [MaxAmount]         MONEY          NULL,
    [EmployeeShare]     DECIMAL (8, 2) NULL,
    [EmployerShare]     DECIMAL (8, 2) NULL,
    [Sequence]          SMALLINT       NULL,
    [DateTimeStamp]     ROWVERSION     NULL,
    CONSTRAINT [PK_PensionRates] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

