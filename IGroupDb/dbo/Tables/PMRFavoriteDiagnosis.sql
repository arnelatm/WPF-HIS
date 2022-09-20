CREATE TABLE [dbo].[PMRFavoriteDiagnosis] (
    [DiagnosisID]          VARCHAR (15)  NOT NULL,
    [DiagnosisNameEnglish] VARCHAR (300) NULL,
    [DiagnosisNameArabic]  VARCHAR (300) NULL,
    [DoctorID]             VARCHAR (15)  NOT NULL,
    [UserID]               VARCHAR (15)  NULL,
    [Create_Date]          DATETIME      NULL,
    [MachineID]            VARCHAR (20)  NULL
);

