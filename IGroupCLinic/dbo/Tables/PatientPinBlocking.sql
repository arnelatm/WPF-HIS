CREATE TABLE [dbo].[PatientPinBlocking] (
    [BranchID]       VARCHAR (15)  NOT NULL,
    [PatientType]    VARCHAR (2)   NOT NULL,
    [RegistrationNo] NUMERIC (10)  NOT NULL,
    [NameEnglish]    VARCHAR (50)  NULL,
    [NameArabic]     NVARCHAR (50) NULL,
    [Remarks]        VARCHAR (500) NULL,
    [create_date]    DATETIME      DEFAULT (getdate()) NULL,
    [UuserID]        VARCHAR (15)  NOT NULL,
    [MachineID]      VARCHAR (20)  NOT NULL
);

