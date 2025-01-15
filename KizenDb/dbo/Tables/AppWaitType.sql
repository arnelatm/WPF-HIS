CREATE TABLE [dbo].[AppWaitType] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NULL,
    [Sound]        NVARCHAR (MAX) NULL,
    [Color]        INT            NULL,
    [Color2]       INT            NULL,
    [Type]         NVARCHAR (50)  NULL,
    [SequanceCode] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_AppWaitType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

