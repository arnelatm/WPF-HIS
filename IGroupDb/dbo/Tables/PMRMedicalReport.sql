CREATE TABLE [dbo].[PMRMedicalReport] (
    [Trans_Key]        BIGINT       NOT NULL,
    [Series]           VARCHAR (2)  NOT NULL,
    [RegistrationNo]   NUMERIC (10) NOT NULL,
    [TransNBR]         BIGINT       NOT NULL,
    [TransDateEnglish] VARCHAR (10) NULL,
    [DoctorID]         VARCHAR (15) NULL,
    [InsuranceID]      VARCHAR (15) NULL,
    [InsuranceGroupID] VARCHAR (15) NULL,
    [Salutation]       VARCHAR (10) NULL,
    [Complaining]      NTEXT        NULL,
    [Investigation]    NTEXT        NULL,
    [Diagnosis]        NTEXT        NULL,
    [TreatmentNow]     NTEXT        NULL,
    [TreatmentFurther] NTEXT        NULL,
    [Appointment]      NTEXT        NULL,
    [SickLeaveFrom]    VARCHAR (10) NULL,
    [SickLeaveUpto]    VARCHAR (10) NULL,
    [BackToWork]       VARCHAR (10) NULL,
    [UserID]           VARCHAR (15) NULL,
    [Create_Date]      DATETIME     DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (20) DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRMedicalReport]
    ON [dbo].[PMRMedicalReport]([Trans_Key] ASC);

