CREATE TABLE [dbo].[PMRFurtherTreatment] (
    [Trans_key]        BIGINT       NOT NULL,
    [TransDateEnglish] VARCHAR (10) NOT NULL,
    [PatientType]      VARCHAR (15) NOT NULL,
    [Series]           VARCHAR (2)  NOT NULL,
    [RegistrationNO]   NUMERIC (10) NOT NULL,
    [DoctorID]         VARCHAR (15) NULL,
    [RowNBR]           INT          NOT NULL,
    [note]             TEXT         NULL,
    [UserID]           VARCHAR (15) NULL,
    [Create_Date]      DATETIME     DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (20) DEFAULT (host_name()) NULL
);

