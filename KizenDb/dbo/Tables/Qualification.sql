CREATE TABLE [dbo].[Qualification] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (255) NULL,
    CONSTRAINT [PK_Qualification] PRIMARY KEY CLUSTERED ([ID] ASC)
);

