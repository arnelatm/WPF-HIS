CREATE TABLE [dbo].[Jobs] (
    [JobID]   INT           IDENTITY (1, 1) NOT NULL,
    [JobName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED ([JobID] ASC)
);

