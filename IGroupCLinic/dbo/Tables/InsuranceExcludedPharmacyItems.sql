CREATE TABLE [dbo].[InsuranceExcludedPharmacyItems] (
    [BranchID]         VARCHAR (15) NOT NULL,
    [InsuranceID]      VARCHAR (15) NOT NULL,
    [GroupInsuranceID] VARCHAR (15) NOT NULL,
    [CategoryID]       VARCHAR (15) NULL,
    [DepartmentID]     VARCHAR (15) NULL,
    [Item_Code]        VARCHAR (15) NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_InsuranceExcludedPharmacyItems]
    ON [dbo].[InsuranceExcludedPharmacyItems]([BranchID] ASC, [InsuranceID] ASC, [Item_Code] ASC);

