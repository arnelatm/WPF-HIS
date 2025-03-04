CREATE TABLE [dbo].[JobSources] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (255) NULL,
    CONSTRAINT [PK_JobSources] PRIMARY KEY CLUSTERED ([ID] ASC)
);

