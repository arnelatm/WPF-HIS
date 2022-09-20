CREATE TABLE [dbo].[CountryMaster] (
    [Primary_Key]       INT            NOT NULL,
    [CountryIOTA]       VARCHAR (3)    NOT NULL,
    [CountryNameEng]    VARCHAR (35)   NOT NULL,
    [CountryNameArabic] NVARCHAR (35)  NULL,
    [Currency]          VARCHAR (15)   NULL,
    [Rate]              NUMERIC (6, 2) NULL,
    [Flag]              IMAGE          NULL,
    [UserID]            VARCHAR (15)   NULL,
    [Create_Date]       DATETIME       NULL,
    [MachineID]         VARCHAR (20)   NULL
);

