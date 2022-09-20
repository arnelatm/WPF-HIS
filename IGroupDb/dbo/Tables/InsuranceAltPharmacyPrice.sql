CREATE TABLE [dbo].[InsuranceAltPharmacyPrice] (
    [BranchID]           VARCHAR (15)    NOT NULL,
    [InsuranceID]        VARCHAR (15)    NOT NULL,
    [GroupInsuranceID]   VARCHAR (15)    NOT NULL,
    [CategoryID]         VARCHAR (15)    NULL,
    [Item_Code]          VARCHAR (15)    NOT NULL,
    [AltItem_Code]       VARCHAR (15)    NULL,
    [AltItemNameEnglish] VARCHAR (50)    NULL,
    [AltItemNameArabic]  NVARCHAR (50)   NULL,
    [Price]              NUMERIC (10, 2) NULL,
    [DiscountPercent]    NUMERIC (7, 2)  NULL,
    [Active]             INT             NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_InsuranceAltPharmacyPrice]
    ON [dbo].[InsuranceAltPharmacyPrice]([BranchID] ASC, [InsuranceID] ASC, [Item_Code] ASC);

