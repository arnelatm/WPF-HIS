CREATE TABLE [dbo].[Languages] (
    [IdNo]            SMALLINT     IDENTITY (0, 1) NOT NULL,
    [CultureInfoCode] VARCHAR (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Country]         VARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Iso2Code]        CHAR (2)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Language]        VARCHAR (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [LanguageCode2]   CHAR (3)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [LanguageCode3]   CHAR (3)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_LanguagesIdNo2] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

