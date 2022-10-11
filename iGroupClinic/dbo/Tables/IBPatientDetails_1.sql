CREATE TABLE [dbo].[IBPatientDetails] (
    [BranchID]            VARCHAR (15)    NOT NULL,
    [Series]              VARCHAR (3)     NOT NULL,
    [RegistrationNo]      NUMERIC (12)    NOT NULL,
    [RegistrationDate]    VARCHAR (10)    NULL,
    [PatientType]         VARCHAR (15)    NOT NULL,
    [BillType]            VARCHAR (2)     NOT NULL,
    [Courtesy]            VARCHAR (10)    NULL,
    [PatientNameEnglish]  NVARCHAR (50)   NOT NULL,
    [PatientNameArabic]   NVARCHAR (50)   NULL,
    [CompanyID]           VARCHAR (15)    NULL,
    [IqamaNo]             NVARCHAR (50)   NULL,
    [PassportNo]          NVARCHAR (50)   NULL,
    [SponsorID]           VARCHAR (50)    NULL,
    [SponsorName]         NVARCHAR (75)   NULL,
    [ProfessionID]        VARCHAR (15)    NULL,
    [Mobile]              VARCHAR (30)    NULL,
    [SponsorPhone]        VARCHAR (30)    NULL,
    [eMail]               VARCHAR (30)    NULL,
    [Alert]               CHAR (1)        NULL,
    [DOB]                 VARCHAR (10)    NULL,
    [DOBHijri]            VARCHAR (10)    NULL,
    [Age]                 NUMERIC (3)     NULL,
    [AgeYMD]              CHAR (1)        NULL,
    [Sex]                 CHAR (1)        NULL,
    [CountryIOTA]         VARCHAR (15)    NOT NULL,
    [LastConsDate]        VARCHAR (10)    NULL,
    [SalesmanID]          VARCHAR (15)    NULL,
    [Limit]               NUMERIC (12, 2) NULL,
    [BalanceAmt]          NUMERIC (12, 2) DEFAULT ((0)) NULL,
    [BaladiyaExpiry]      VARCHAR (10)    NULL,
    [BaladiyaExpiryHijri] VARCHAR (10)    NULL,
    [Restricted]          VARCHAR (1)     DEFAULT ('N') NULL,
    [DoctorID]            VARCHAR (10)    NULL,
    [Remarks]             VARCHAR (300)   NULL,
    [UserID]              VARCHAR (15)    DEFAULT ('Admin') NULL,
    [Create_Date]         DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]           VARCHAR (20)    DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_IBPatientDetails]
    ON [dbo].[IBPatientDetails]([BranchID] ASC, [Series] ASC, [RegistrationNo] ASC, [PatientType] ASC);

