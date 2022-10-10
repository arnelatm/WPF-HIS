CREATE TABLE [dbo].[Religion] (
    [IdNo]            TINYINT        IDENTITY (1, 1) NOT NULL,
    [ReligionCode]    VARCHAR (5)    COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ReligionName]    VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ReligionNameAra] NVARCHAR (30)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]           NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]   ROWVERSION     NULL,
    CONSTRAINT [PK_Religion] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

