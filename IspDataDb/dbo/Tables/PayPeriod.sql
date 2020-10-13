CREATE TABLE [dbo].[PayPeriod] (
    [IdNo]          SMALLINT      IDENTITY (1, 1) NOT NULL,
    [PayCycleIdNo]  SMALLINT      NOT NULL,
    [StartDate]     DATE          NOT NULL,
    [EndDate]       DATE          NOT NULL,
    [Notes]         VARCHAR (255) NULL,
    [DateTimeStamp] ROWVERSION    NULL,
    CONSTRAINT [PK__PayPeriodID] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

