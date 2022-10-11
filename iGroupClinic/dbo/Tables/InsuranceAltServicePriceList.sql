CREATE TABLE [dbo].[InsuranceAltServicePriceList] (
    [BranchID]              VARCHAR (15)    NOT NULL,
    [InsuranceID]           VARCHAR (15)    NOT NULL,
    [GroupInsuranceID]      VARCHAR (15)    NOT NULL,
    [DepartmentID]          VARCHAR (15)    NOT NULL,
    [ServiceID]             VARCHAR (15)    NOT NULL,
    [AltServiceID]          VARCHAR (15)    NULL,
    [AltServiceNameEnglish] VARCHAR (75)    NULL,
    [AltServiceNameArabic]  NVARCHAR (70)   NULL,
    [Price]                 NUMERIC (10, 2) NULL,
    [DiscountPercent]       NUMERIC (7, 2)  NULL,
    [DiscountAmt]           NUMERIC (10, 2) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_InsuranceAltServicePriceList]
    ON [dbo].[InsuranceAltServicePriceList]([BranchID] ASC, [InsuranceID] ASC, [ServiceID] ASC);

