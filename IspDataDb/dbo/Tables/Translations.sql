CREATE TABLE [dbo].[Translations] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [OriginalString]  NVARCHAR (MAX) NOT NULL,
    [ModuleName]      NVARCHAR (255) NULL,
    [UIIdentifier]    NVARCHAR (255) NULL,
    [LanguageCode]    NVARCHAR (10)  NOT NULL,
    [LocalizedString] NVARCHAR (MAX) NULL,
    [CreationDate]    DATETIME       CONSTRAINT [DF_Translations_CreationDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO

CREATE NONCLUSTERED INDEX [IX_Translations_Lookups]
    ON [dbo].[Translations]([LanguageCode] ASC, [UIIdentifier] ASC)
    INCLUDE([ModuleName]);


GO

