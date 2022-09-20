CREATE TABLE [dbo].[PMRPatientMedicalReport] (
    [Trans_Key]        NUMERIC (10) NOT NULL,
    [TransDateEnglish] VARCHAR (10) NULL,
    [PatientType]      VARCHAR (15) NULL,
    [RegistrationNo]   NUMERIC (10) NULL,
    [Diagnosis]        NTEXT        NULL,
    [DoctorID]         VARCHAR (15) NULL,
    [Report]           NTEXT        NULL,
    [UserID]           VARCHAR (15) NULL,
    [Create_date]      DATETIME     DEFAULT (getdate()) NULL,
    [MAchineID]        VARCHAR (20) DEFAULT (host_name()) NULL
);

