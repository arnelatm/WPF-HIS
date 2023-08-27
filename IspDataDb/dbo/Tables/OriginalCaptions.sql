CREATE TABLE [dbo].[OriginalCaptions] (
    [idno]          INT             IDENTITY (1, 1) NOT NULL,
    [Caption]       NVARCHAR (1024) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp] ROWVERSION      NULL,
    CONSTRAINT [PK_Original] PRIMARY KEY CLUSTERED ([idno] ASC)
);



