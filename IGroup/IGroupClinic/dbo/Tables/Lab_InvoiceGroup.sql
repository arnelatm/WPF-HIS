CREATE TABLE [dbo].[Lab_InvoiceGroup] (
    [BranchID]           VARCHAR (15)   NOT NULL,
    [Trans_Key]          NUMERIC (12)   NOT NULL,
    [TransType]          VARCHAR (3)    NULL,
    [TransNo]            NUMERIC (10)   NOT NULL,
    [TransDate]          VARCHAR (10)   NULL,
    [SampleNo]           VARCHAR (15)   NULL,
    [ServiceID]          VARCHAR (15)   NULL,
    [InvestigationID]    VARCHAR (15)   NULL,
    [Remarks]            NVARCHAR (500) NULL,
    [InvoiceType]        VARCHAR (2)    NULL,
    [InvoiceNo]          NUMERIC (10)   NULL,
    [InvoiceDate]        VARCHAR (10)   NULL,
    [PatientType]        VARCHAR (15)   NULL,
    [RegistrationNo]     NUMERIC (10)   NULL,
    [RegistrationSeries] VARCHAR (2)    NULL,
    [PatientNameEnglish] VARCHAR (50)   NULL,
    [PatientNameArabic]  NVARCHAR (50)  NULL,
    [Age]                NUMERIC (3)    NULL,
    [AgeYMD]             CHAR (1)       DEFAULT ('Y') NULL,
    [Sex]                CHAR (1)       DEFAULT ('M') NULL,
    [InsuranceID]        VARCHAR (10)   NULL,
    [DoctorID]           VARCHAR (15)   NULL,
    [IDNo]               VARCHAR (50)   NULL,
    [UserID]             VARCHAR (15)   NULL,
    [Create_Date]        DATETIME       DEFAULT (getdate()) NULL,
    [MachineID]          VARCHAR (20)   DEFAULT (host_name()) NULL,
    [Status]             INT            DEFAULT ((0)) NULL,
    [Remark]             NVARCHAR (300) DEFAULT (NULL) NULL,
    [PreparedBy]         VARCHAR (35)   NULL,
    [CheckedBy]          VARCHAR (35)   NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_InvoiceGroup]
    ON [dbo].[Lab_InvoiceGroup]([BranchID] ASC, [Trans_Key] ASC, [InvoiceType] ASC, [InvoiceNo] ASC);

