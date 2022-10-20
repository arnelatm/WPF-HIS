CREATE TABLE [dbo].[InsuranceDeductibleLimitDepartmentWise] (
    [BranchID]            VARCHAR (15)   NOT NULL,
    [InsuranceID]         VARCHAR (15)   NOT NULL,
    [GroupInsuranceID]    VARCHAR (15)   NOT NULL,
    [DepartmentID]        VARCHAR (15)   NOT NULL,
    [CategoryID]          VARCHAR (15)   NOT NULL,
    [ReconsulntationDays] NUMERIC (2)    DEFAULT (10) NULL,
    [DeductiblePercent]   NUMERIC (7, 2) NULL,
    [DeductibleFlatAmt]   NUMERIC (10)   NULL,
    [UpperLimit]          NUMERIC (10)   DEFAULT (100) NULL,
    [Active]              INT            DEFAULT (1) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_InsuranceDeductibleLimitDepartmentWise]
    ON [dbo].[InsuranceDeductibleLimitDepartmentWise]([BranchID] ASC, [InsuranceID] ASC, [DepartmentID] ASC, [CategoryID] ASC);

