CREATE TABLE [dbo].[SJPrefix] (
    [IdNo]        TINYINT  NOT NULL,
    [AccountIdNo] INT      NULL,
    [Prefix]      CHAR (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_SJPrefix] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

