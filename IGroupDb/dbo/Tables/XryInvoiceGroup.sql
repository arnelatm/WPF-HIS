CREATE TABLE [dbo].[XryInvoiceGroup] (
    [BranchID]                 VARCHAR (15)   NOT NULL,
    [Trans_Key]                BIGINT         NOT NULL,
    [TransType]                VARCHAR (2)    NOT NULL,
    [TransNBR]                 NUMERIC (12)   NOT NULL,
    [TransDateEnglish]         VARCHAR (10)   NULL,
    [InvoiceType]              VARCHAR (2)    NOT NULL,
    [InvoiceNBR]               NUMERIC (12)   NOT NULL,
    [InvoiceDateEnglish]       VARCHAR (10)   NULL,
    [RegistrationType]         VARCHAR (15)   NOT NULL,
    [RegistrationNo]           NUMERIC (12)   NOT NULL,
    [RegistrationDate]         VARCHAR (10)   NULL,
    [DoctorID]                 VARCHAR (15)   NULL,
    [PatientName]              VARCHAR (50)   NULL,
    [PatientNameArabic]        NVARCHAR (50)  NULL,
    [CountryID]                VARCHAR (15)   NULL,
    [Age]                      NUMERIC (3)    NULL,
    [YMD]                      CHAR (1)       NULL,
    [DOB]                      VARCHAR (10)   NULL,
    [PatientID]                VARCHAR (50)   NULL,
    [PhoneNo]                  VARCHAR (30)   NULL,
    [InsuranceID]              VARCHAR (15)   NULL,
    [InsuranceNameEnglish]     VARCHAR (75)   NULL,
    [DeductionCategoryID]      VARCHAR (15)   NULL,
    [InsuranceGroupID]         VARCHAR (15)   NULL,
    [InvestigationID]          VARCHAR (15)   NULL,
    [InvestigationName]        VARCHAR (50)   NULL,
    [InvestigationDescription] NVARCHAR (MAX) NULL,
    [Reject]                   INT            NULL,
    [RejectDate]               VARCHAR (10)   NULL,
    [UserID]                   VARCHAR (15)   NULL,
    [Create_Date]              DATETIME       DEFAULT (getdate()) NULL,
    [MachineID]                VARCHAR (20)   DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_XryInvoiceGroup]
    ON [dbo].[XryInvoiceGroup]([BranchID] ASC, [InvoiceType] ASC, [InvoiceNBR] ASC);

