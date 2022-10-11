CREATE TABLE [dbo].[PMRSignificantSigns] (
    [SSID]          VARCHAR (15)   NOT NULL,
    [Trans_key]     NUMERIC (10)   NULL,
    [SSNameEnglish] VARCHAR (100)  NOT NULL,
    [SSNameArabic]  NVARCHAR (100) NULL,
    [UserID]        VARCHAR (15)   NULL,
    [Create_Date]   DATETIME       NULL,
    [machineid]     VARCHAR (20)   NULL
);

