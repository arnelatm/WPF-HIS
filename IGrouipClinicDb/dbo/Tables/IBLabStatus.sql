CREATE TABLE [dbo].[IBLabStatus] (
    [Trans_Key]           NUMERIC (10)  NOT NULL,
    [TransType]           VARCHAR (15)  NOT NULL,
    [TransNBR]            NUMERIC (10)  NOT NULL,
    [RegistrationNo]      NUMERIC (12)  NOT NULL,
    [PatientType]         VARCHAR (15)  NOT NULL,
    [DiagnosisType]       VARCHAR (4)   NOT NULL,
    [LABTestStatus]       INT           NULL,
    [LabTestUnfitReason]  VARCHAR (30)  NULL,
    [RadiologyTestStatus] VARCHAR (50)  NULL,
    [CardStatus]          INT           NULL,
    [CardStatusDate]      VARCHAR (10)  NULL,
    [CardIssue]           INT           NULL,
    [CardIssueDate]       VARCHAR (10)  NULL,
    [Remarks]             VARCHAR (300) NULL,
    [UserID]              VARCHAR (15)  DEFAULT ('Admin') NULL,
    [Create_Date]         DATETIME      DEFAULT (getdate()) NULL,
    [MachineID]           VARCHAR (20)  DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_IBLabStatus]
    ON [dbo].[IBLabStatus]([RegistrationNo] ASC, [TransType] ASC, [TransNBR] ASC);

