CREATE TABLE [dbo].[TranslatedMessages] (
    [idno]              INT            IDENTITY (1, 1) NOT NULL,
    [MessageIdNo]       SMALLINT       NOT NULL,
    [LanguageIdNo]      SMALLINT       NOT NULL,
    [TranslatedMessage] NVARCHAR (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [TranslatedCaption] NVARCHAR (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]     ROWVERSION     NULL,
    CONSTRAINT [PK_TranslatedMessagesIdNo] PRIMARY KEY CLUSTERED ([idno] ASC)
);



