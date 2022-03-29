CREATE TABLE [dbo].[PatientFileMerging] (
    [RegistrationNo]       NUMERIC (10) NULL,
    [PatientType]          VARCHAR (10) NULL,
    [MergedRegistrationNo] NUMERIC (10) NULL,
    [RegistrationDate]     VARCHAR (10) NULL,
    [MergedPatientType]    VARCHAR (10) NULL,
    [MergingDate]          VARCHAR (10) NULL,
    [UserID]               VARCHAR (15) NULL,
    [Create_Date]          DATETIME     DEFAULT (getdate()) NULL,
    [MachineID]            VARCHAR (20) DEFAULT (host_name()) NULL
);

