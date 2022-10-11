CREATE TABLE [dbo].[PMRFurtherMedication] (
    [Trans_Key]          BIGINT       NOT NULL,
    [TransDateEnglish]   VARCHAR (10) NOT NULL,
    [PatientType]        VARCHAR (15) NOT NULL,
    [Series]             VARCHAR (2)  NOT NULL,
    [RegistrationNo]     NUMERIC (10) NOT NULL,
    [DoctorID]           VARCHAR (15) NULL,
    [RowNBR]             INT          NOT NULL,
    [FMC_SlNo]           INT          NOT NULL,
    [Further_MedCode]    VARCHAR (15) NULL,
    [Further_MedName]    TEXT         NULL,
    [Further_MedDossage] TEXT         NULL,
    [UserID]             VARCHAR (15) NULL,
    [Create_Date]        DATETIME     DEFAULT (getdate()) NULL,
    [MachineID]          VARCHAR (20) DEFAULT (host_name()) NULL
);

