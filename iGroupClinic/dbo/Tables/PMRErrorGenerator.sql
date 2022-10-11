CREATE TABLE [dbo].[PMRErrorGenerator] (
    [ErrorModule]      VARCHAR (20)  NULL,
    [PatientType]      VARCHAR (15)  NULL,
    [RegistrationNo]   NUMERIC (10)  NULL,
    [TransDateEnglish] VARCHAR (10)  NULL,
    [DoctorID]         VARCHAR (15)  NULL,
    [Module]           VARCHAR (50)  NULL,
    [ErrorMessage]     VARCHAR (500) NULL,
    [UserID]           VARCHAR (15)  NULL,
    [Create_Date]      DATETIME      DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (20)  NULL
);

