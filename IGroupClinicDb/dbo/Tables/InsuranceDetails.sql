CREATE TABLE [dbo].[InsuranceDetails] (
    [BranchID]            VARCHAR (15)    NOT NULL,
    [InsuranceType]       VARCHAR (10)    NOT NULL,
    [RegDate]             VARCHAR (10)    DEFAULT (convert(varchar(10),getdate(),111)) NULL,
    [InsuranceID]         VARCHAR (15)    NOT NULL,
    [NameEnglish]         VARCHAR (75)    NOT NULL,
    [NameArabic]          NVARCHAR (75)   NOT NULL,
    [CurrentStatus]       INT             DEFAULT (1) NULL,
    [ContractStatus]      INT             DEFAULT (1) NULL,
    [ContractFrom]        VARCHAR (10)    NOT NULL,
    [ContractUpto]        VARCHAR (10)    NOT NULL,
    [Address1]            VARCHAR (100)   NULL,
    [Address2]            VARCHAR (100)   NULL,
    [Street]              VARCHAR (100)   NULL,
    [City]                VARCHAR (100)   NULL,
    [CountryID]           VARCHAR (15)    NULL,
    [POBox]               VARCHAR (30)    NULL,
    [ZIP]                 VARCHAR (30)    NULL,
    [Phone1]              VARCHAR (20)    NULL,
    [Phone2]              VARCHAR (20)    NULL,
    [Fax]                 VARCHAR (20)    NULL,
    [FaceBook]            VARCHAR (50)    NULL,
    [EMail]               VARCHAR (50)    NULL,
    [Web]                 VARCHAR (50)    NULL,
    [GroupInsuranceID]    VARCHAR (15)    NOT NULL,
    [UnderInsuranceID]    VARCHAR (15)    NOT NULL,
    [CoInsuranceID]       VARCHAR (15)    NULL,
    [ApplyTermsID]        VARCHAR (15)    NOT NULL,
    [Policy]              VARCHAR (25)    NULL,
    [SOAPCode]            VARCHAR (25)    NULL,
    [SOAPNo]              VARCHAR (25)    NULL,
    [ShowAlert]           INT             DEFAULT (1) NULL,
    [ACLedgerID]          VARCHAR (15)    NOT NULL,
    [ClinicLimit]         NUMERIC (12, 2) NULL,
    [PharmacyLimit]       NUMERIC (12, 2) NULL,
    [PharmacyDiscount]    NUMERIC (7, 2)  NULL,
    [PrintDeductible]     INT             DEFAULT (1) NULL,
    [AltServiceCode]      INT             DEFAULT (0) NULL,
    [AltPharmacyItemCode] INT             DEFAULT (0) NULL,
    [DeductibleOnGross]   INT             DEFAULT (0) NULL,
    [ReconsultationDays]  NUMERIC (2)     DEFAULT (10) NULL,
    [UserID]              VARCHAR (15)    NULL,
    [Create_Date]         DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]           VARCHAR (20)    DEFAULT (host_name()) NULL,
    [PrintSDFACode]       INT             NULL,
    [ProviderCode]        VARCHAR (50)    NULL,
    [DeductibleNotTaken]  INT             NULL,
    [VatNumber]           VARCHAR (15)    NULL
);




GO
CREATE UNIQUE CLUSTERED INDEX [IDX_InsuranceDetails]
    ON [dbo].[InsuranceDetails]([BranchID] ASC, [InsuranceID] ASC);

