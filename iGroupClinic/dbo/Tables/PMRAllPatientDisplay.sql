CREATE TABLE [dbo].[PMRAllPatientDisplay] (
    [Token]            VARCHAR (3)   NULL,
    [Status]           VARCHAR (1)   NULL,
    [File No]          VARCHAR (7)   NULL,
    [Name]             VARCHAR (50)  NULL,
    [Type]             VARCHAR (3)   NULL,
    [Inv Type]         VARCHAR (6)   NULL,
    [Appointment]      VARCHAR (7)   NULL,
    [TokenNo]          NUMERIC (5)   NULL,
    [Trans_Key]        INT           NOT NULL,
    [RegistrationDate] VARCHAR (10)  NULL,
    [TransDateEnglish] VARCHAR (10)  NULL,
    [DoctorID]         VARCHAR (15)  NULL,
    [MachineID]        NVARCHAR (20) NULL
);

