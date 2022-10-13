CREATE TABLE [dbo].[Messages] (
    [Idno]        SMALLINT       IDENTITY (1, 1) NOT NULL,
    [MessageCode] VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [MessageText] NVARCHAR (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([Idno] ASC)
);



