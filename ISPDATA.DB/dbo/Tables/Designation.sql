CREATE TABLE [dbo].[Designation] (
    [IdNo]               INT            IDENTITY (1, 1) NOT NULL,
    [DesignationCode]    VARCHAR (5)    COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [DesignationName]    VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [DesignationNameAra] NVARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]              NVARCHAR (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]      ROWVERSION     NULL,
    CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

