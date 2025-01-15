CREATE TABLE [dbo].[DocumentsType] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [SourceType] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_DocumentsType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

