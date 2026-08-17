CREATE TABLE [dbo].[Dosage] (
    [IdNo]            INT             IDENTITY (1, 1) NOT NULL,
    [DosageCode]      NVARCHAR (10)   NULL,
    [DosageUnit]      INT             NULL,
    [Route]           INT             NULL,
    [Direction]       INT             NULL,
    [Frequency]       NVARCHAR (20)   NULL,
    [FrequencyTiming] INT             NULL,
    [Duration]        DECIMAL (10, 2) NULL,
    [DurationUnit]    INT             NULL,
    [DateTimeStamp]   ROWVERSION      NULL,
    CONSTRAINT [PK_DosagePrinting] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO

