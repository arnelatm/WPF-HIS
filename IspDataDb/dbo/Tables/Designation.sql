CREATE TABLE [dbo].[Designation] (
    [IdNo]                     SMALLINT       IDENTITY (1, 1) NOT NULL,
    [DesignationCode]          VARCHAR (5)    COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DesignationName]          VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [DesignationNameFemale]    NVARCHAR (50)  NULL,
    [DesignationNameAra]       NVARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DesignationNameFemaleAra] NVARCHAR (50)  NULL,
    [Notes]                    NVARCHAR (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]            ROWVERSION     NULL,
    CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_DesignationCode]
    ON [dbo].[Designation]([DesignationCode] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_DesignationName]
    ON [dbo].[Designation]([IdNo] ASC);


GO

