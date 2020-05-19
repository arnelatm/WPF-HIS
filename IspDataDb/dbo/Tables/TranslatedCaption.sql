CREATE TABLE [dbo].[TranslatedCaption] (
    [idno]              INT            IDENTITY (1, 1) NOT NULL,
    [CaptionIdNo]       INT            NOT NULL,
    [LanguageIdNo]      SMALLINT       NOT NULL,
    [TranslatedCaption] NVARCHAR (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]     ROWVERSION     NULL,
    CONSTRAINT [PK_TranslatedIdNo] PRIMARY KEY CLUSTERED ([idno] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_TranslatedCultureInfoCode]
    ON [dbo].[TranslatedCaption]([LanguageIdNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TranslatedOriginalIdNo]
    ON [dbo].[TranslatedCaption]([idno] ASC);

