CREATE TABLE [dbo].[KS_WordTranslation] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [FromWord] NVARCHAR (255) NULL,
    [ToWord]   NVARCHAR (255) NULL,
    CONSTRAINT [PK_KS_WordTranslation] PRIMARY KEY CLUSTERED ([ID] ASC)
);

