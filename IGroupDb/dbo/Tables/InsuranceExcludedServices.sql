CREATE TABLE [dbo].[InsuranceExcludedServices] (
    [BranchID]         VARCHAR (15) NOT NULL,
    [InsuranceID]      VARCHAR (15) NOT NULL,
    [GroupInsuranceID] VARCHAR (15) NOT NULL,
    [CategoryID]       VARCHAR (15) NOT NULL,
    [DepartmentID]     VARCHAR (15) NOT NULL,
    [ServiceID]        VARCHAR (15) NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_InsuranceExcludedServices]
    ON [dbo].[InsuranceExcludedServices]([BranchID] ASC, [InsuranceID] ASC, [DepartmentID] ASC, [CategoryID] ASC);

