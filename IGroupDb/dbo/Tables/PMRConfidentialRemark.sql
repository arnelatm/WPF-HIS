CREATE TABLE [dbo].[PMRConfidentialRemark] (
    [RegistrationNo] NUMERIC (10)  NULL,
    [PatientType]    VARCHAR (15)  NULL,
    [DoctorID]       VARCHAR (15)  NULL,
    [RemarkDate]     VARCHAR (10)  NULL,
    [Remark]         VARCHAR (7)   NULL,
    [Create_Date]    DATETIME      DEFAULT (getdate()) NULL,
    [MachineID]      NVARCHAR (20) DEFAULT (host_name()) NULL
);

