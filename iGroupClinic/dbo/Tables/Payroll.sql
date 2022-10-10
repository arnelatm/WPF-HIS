CREATE TABLE [dbo].[Payroll] (
    [IdNo]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [PayCycleIdNo]   SMALLINT      NOT NULL,
    [StartDate]      DATE          NOT NULL,
    [EndDate]        DATE          NOT NULL,
    [PayrollName]    VARCHAR (50)  NULL,
    [PayrollNameAra] NVARCHAR (50) NULL,
    [PayrollCode]    VARCHAR (6)   NULL,
    [DateTimeStamp]  ROWVERSION    NULL,
    CONSTRAINT [PK__PayrollID] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

