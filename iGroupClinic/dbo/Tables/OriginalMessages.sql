CREATE TABLE [dbo].[OriginalMessages] (
    [idno]          SMALLINT      IDENTITY (1, 1) NOT NULL,
    [MessageKey]    VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Message]       VARCHAR (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Caption]       VARCHAR (128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]         VARCHAR (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp] ROWVERSION    NULL,
    CONSTRAINT [PK_OriginalMessages] PRIMARY KEY CLUSTERED ([idno] ASC)
);

