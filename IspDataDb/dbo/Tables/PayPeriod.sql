CREATE TABLE [dbo].[PayPeriod] (
    [IdNo]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [PayCycleIdNo]     SMALLINT      NOT NULL,
    [StartDate]        DATE          NOT NULL,
    [EndDate]          DATE          NOT NULL,
    [PayPeriodName]    VARCHAR (50)  NULL,
    [PayPeriodNameAra] NVARCHAR (50) NULL,
    [PayPeriodCode]    VARCHAR (6)   NULL,
    [DateTimeStamp]    ROWVERSION    NULL,
    CONSTRAINT [PK__PayPeriodID] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



