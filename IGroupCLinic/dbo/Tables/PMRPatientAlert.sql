CREATE TABLE [dbo].[PMRPatientAlert] (
    [Trans_Key]          INT            NOT NULL,
    [PatientType]        VARCHAR (10)   NOT NULL,
    [RegistrationNo]     NUMERIC (12)   NOT NULL,
    [PatientNameEnglish] NVARCHAR (50)  NULL,
    [AlertMessage]       NVARCHAR (300) NULL,
    [DisplayDateFrom]    VARCHAR (10)   NULL,
    [DisplayDateUpto]    VARCHAR (10)   NULL,
    [Activate]           INT            DEFAULT (1) NULL,
    [UserID]             VARCHAR (15)   NULL,
    [Create_Date]        DATETIME       DEFAULT (getdate()) NULL,
    [MachineID]          VARCHAR (20)   DEFAULT (host_name()) NULL
);

