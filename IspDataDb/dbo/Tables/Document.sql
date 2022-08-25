CREATE TABLE [dbo].[Document] (
    [IdNo]            SMALLINT      IDENTITY (1, 1) NOT NULL,
    [DocumentCode]    VARCHAR (5)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [DocumentName]    VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [DocumentNameAra] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DocumentType]    CHAR (1)      COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [NeedsExpiryDate] BIT           NULL,
    [NeedsIssueDate]  BIT           NULL,
    [NeedsNumber]     BIT           NULL,
    [ImageType]       CHAR (1)      COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]           VARCHAR (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]   ROWVERSION    NULL,
    [CreateDate]      DATETIME2 (7) NULL,
    CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





