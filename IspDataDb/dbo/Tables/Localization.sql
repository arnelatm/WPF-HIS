CREATE TABLE [dbo].[Localization] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [OriginalString]  NVARCHAR (MAX) NOT NULL,
    [ModuleName]      NVARCHAR (50)  NULL,
    [UIIdentifier]    NVARCHAR (100) NULL,
    [LanguageCode]    NVARCHAR (10)  NULL,
    [LocalizedString] NVARCHAR (MAX) NOT NULL,
    [CreationDate]    DATETIME2 (7)  CONSTRAINT [DF__Localizat__Creat__47726548] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__Localiza__3214EC2753C37541] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO

