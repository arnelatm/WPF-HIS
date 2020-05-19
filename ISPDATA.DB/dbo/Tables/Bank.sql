CREATE TABLE [dbo].[Bank] (
    [IdNo]          INT            IDENTITY (1, 1) NOT NULL,
    [BankCode]      VARCHAR (10)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [BankName]      VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [BankNameAra]   NCHAR (50)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]         NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp] ROWVERSION     NULL
);

