CREATE TABLE [dbo].[PMRDentalTreatment] (
    [TreatmentID]          VARCHAR (15)   NOT NULL,
    [Trans_key]            NUMERIC (10)   NULL,
    [TreatmentNameEnglish] VARCHAR (100)  NOT NULL,
    [TreatmentNameArabic]  NVARCHAR (100) NULL,
    [UserID]               VARCHAR (15)   NULL,
    [Create_Date]          DATETIME       NULL,
    [machineid]            VARCHAR (20)   NULL
);

