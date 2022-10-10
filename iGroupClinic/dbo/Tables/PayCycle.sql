CREATE TABLE [dbo].[PayCycle] (
    [IdNo]            TINYINT       IDENTITY (1, 1) NOT NULL,
    [PayCycleCode]    VARCHAR (5)   NOT NULL,
    [PayCycleName]    VARCHAR (50)  NOT NULL,
    [PayCycleNameAra] NVARCHAR (50) NOT NULL,
    [PayFrequency]    CHAR (1)      NULL,
    [Notes]           VARCHAR (255) NULL,
    [DateTimeStamp]   ROWVERSION    NULL,
    CONSTRAINT [PK__PayCycleID] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

