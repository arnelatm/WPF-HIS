CREATE TABLE [dbo].[PhoneType] (
    [IdNo]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [PhoneTypeCode]    VARCHAR (5)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [PhoneTypeName]    VARCHAR (15)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [PhoneTypeNameAra] NVARCHAR (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]            VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]    ROWVERSION    NULL,
    CONSTRAINT [PK_PhoneType] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





