CREATE TABLE [dbo].[PMRDiagnosisHistory] (
    [Trans_Key]            BIGINT       NOT NULL,
    [TransDateEnglish]     VARCHAR (10) NOT NULL,
    [PatientType]          VARCHAR (15) NOT NULL,
    [Series]               VARCHAR (2)  NOT NULL,
    [RegistrationNo]       NUMERIC (10) NOT NULL,
    [DoctorID]             VARCHAR (15) NULL,
    [RowNBR]               INT          NOT NULL,
    [Chief_Complaint]      TEXT         NULL,
    [Duration_of_Illness]  TEXT         NULL,
    [Past_History]         TEXT         NULL,
    [Physical_Examination] TEXT         NULL,
    [Vital_Science_BP]     VARCHAR (10) NULL,
    [Vital_Science_Pulse]  VARCHAR (10) NULL,
    [Vital_Science_Temp]   VARCHAR (10) NULL,
    [Diagnosis]            TEXT         NULL,
    [Treatment_History]    TEXT         NULL,
    [UserID]               VARCHAR (15) NULL,
    [Create_Date]          DATETIME     DEFAULT (getdate()) NULL,
    [MachineID]            VARCHAR (20) DEFAULT (host_name()) NULL
);

