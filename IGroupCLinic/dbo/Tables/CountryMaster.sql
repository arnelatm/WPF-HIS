CREATE TABLE [dbo].[CountryMaster] (
    [Primary_Key]       INT            NOT NULL,
    [CountryIOTA]       VARCHAR (3)    COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [CountryNameEng]    VARCHAR (35)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [CountryNameArabic] NVARCHAR (35)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Currency]          VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Rate]              NUMERIC (6, 2) NOT NULL,
    [Flag]              IMAGE          NULL,
    [UserID]            VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Create_Date]       DATETIME       CONSTRAINT [DF_Date] DEFAULT (getdate()) NOT NULL,
    [MachineID]         VARCHAR (20)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    CONSTRAINT [PK__CountryM__CE44E733DF9CCA21] PRIMARY KEY CLUSTERED ([Primary_Key] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Country Name (English)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CountryMaster', @level2type = N'COLUMN', @level2name = N'CountryNameEng';

