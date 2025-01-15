CREATE TABLE [dbo].[RepSty] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (255) NULL,
    [Data] VARCHAR (MAX)  NULL,
    CONSTRAINT [PK_RepSty] PRIMARY KEY CLUSTERED ([ID] ASC)
);

