CREATE TABLE [dbo].[PMRDiagnosisDetails] (
    [DiagnosisID]          VARCHAR (15)   NOT NULL,
    [Trans_key]            NUMERIC (10)   NULL,
    [DiagnosisNameEnglish] VARCHAR (100)  NOT NULL,
    [DiagnosisNameArabic]  NVARCHAR (100) NULL,
    [UserID]               VARCHAR (15)   NULL,
    [Create_Date]          DATETIME       NULL,
    [machineid]            VARCHAR (20)   NULL
);

