CREATE TABLE [dbo].[InsuranceApprovals] (
    [BranchID]           VARCHAR (15)   NOT NULL,
    [Trans_Key]          INT            IDENTITY (1, 1) NOT NULL,
    [ApprovalType]       VARCHAR (2)    NOT NULL,
    [ApprovalNo]         NUMERIC (12)   NOT NULL,
    [ApprovalDate]       VARCHAR (10)   NULL,
    [ApprovalStatus]     VARCHAR (20)   DEFAULT ('Approved') NULL,
    [PatientType]        VARCHAR (15)   DEFAULT ('Insurance') NULL,
    [RegistrationNo]     NUMERIC (12)   NOT NULL,
    [RegistrationDate]   VARCHAR (10)   NULL,
    [PatientNameEnglish] VARCHAR (75)   NULL,
    [InsuranceID]        VARCHAR (15)   NOT NULL,
    [DoctorID]           VARCHAR (15)   NULL,
    [InsCardNo]          VARCHAR (50)   NULL,
    [InsCardExpiry]      VARCHAR (10)   NULL,
    [Remarks]            VARCHAR (1500) NULL,
    [Counter]            INT            DEFAULT (0) NULL,
    [UserID]             VARCHAR (15)   NULL,
    [Create_Date]        DATETIME       DEFAULT (getdate()) NULL,
    [MachineID]          VARCHAR (20)   DEFAULT (host_name()) NULL,
    PRIMARY KEY CLUSTERED ([Trans_Key] ASC)
);

