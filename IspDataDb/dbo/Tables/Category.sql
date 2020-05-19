CREATE TABLE [dbo].[Category] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [CategoryCode]    VARCHAR (10)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [CategoryName]    VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [CategoryNameAra] NVARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Notes]           NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]   ROWVERSION     NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

