CREATE TABLE [dbo].[Localization] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [OriginalString]  NVARCHAR (MAX) NOT NULL,
    [ModuleName]      NVARCHAR (50)  NOT NULL,
    [UIIdentifier]    NVARCHAR (100) NOT NULL,
    [LanguageCode]    NVARCHAR (10)  NOT NULL,
    [LocalizedString] NVARCHAR (MAX) NOT NULL,
    [CreationDate]    DATETIME2 (7)  DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Localization_Unique]
    ON [dbo].[Localization]([ModuleName] ASC, [UIIdentifier] ASC, [LanguageCode] ASC);

