CREATE TABLE [dbo].[AppWorkTimeType] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NULL,
    [AppTypeColor] INT           NULL,
    [IsFreeTime]   BIT           NULL,
    CONSTRAINT [PK_AppWorkTimeType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

