CREATE TABLE [dbo].[SupplierDetails] (
    [BranchID]            VARCHAR (15)    NULL,
    [SupplierID]          VARCHAR (15)    NOT NULL,
    [Courtesy]            VARCHAR (15)    NULL,
    [SupplierNameEnglish] VARCHAR (50)    NOT NULL,
    [SupplierNameArabic]  NVARCHAR (50)   NULL,
    [Contact_Person]      NVARCHAR (50)   NULL,
    [DesignationID]       NVARCHAR (15)   NULL,
    [Address1]            VARCHAR (50)    NULL,
    [Address2]            VARCHAR (50)    NULL,
    [Street]              VARCHAR (50)    NULL,
    [City]                VARCHAR (50)    NULL,
    [Country]             VARCHAR (50)    NULL,
    [POBox]               VARCHAR (10)    NULL,
    [Zip]                 VARCHAR (10)    NULL,
    [Phone1]              VARCHAR (50)    NULL,
    [Phone2]              VARCHAR (50)    NULL,
    [Mobile]              VARCHAR (50)    NULL,
    [fax]                 VARCHAR (50)    NULL,
    [email]               VARCHAR (50)    NULL,
    [web]                 VARCHAR (50)    NULL,
    [CR_no]               VARCHAR (20)    NULL,
    [AC_Code]             VARCHAR (10)    NULL,
    [Blocked]             VARCHAR (3)     NULL,
    [SupplierType]        VARCHAR (20)    NULL,
    [AgentID]             VARCHAR (15)    NULL,
    [PriceCategory]       VARCHAR (20)    NULL,
    [CreditStatus]        VARCHAR (20)    NULL,
    [CreditDays]          NUMERIC (3)     NULL,
    [CreditLimit]         NUMERIC (12, 2) NULL,
    [CreditDiscount]      NUMERIC (12, 2) NULL,
    [Remarks]             VARCHAR (150)   NULL,
    [Create_date]         VARCHAR (10)    NULL,
    [UserId]              VARCHAR (10)    NULL,
    [MachineId]           VARCHAR (20)    NULL,
    [primary_key]         INT             IDENTITY (1, 1) NOT NULL,
    [VATNo]               VARCHAR (50)    NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SupplierDetails]
    ON [dbo].[SupplierDetails]([SupplierID] ASC);

