CREATE TABLE [dbo].[InsuranceDiscountOnDeductibleClass] (
    [BranchID]        VARCHAR (15)    NOT NULL,
    [TPAID]           VARCHAR (15)    NOT NULL,
    [InsuranceID]     VARCHAR (15)    NOT NULL,
    [CategoryID]      VARCHAR (15)    NULL,
    [DepartmentID]    VARCHAR (15)    NULL,
    [DiscountAmt]     NUMERIC (10, 2) NULL,
    [DiscountPercent] INT             NULL,
    [UserID]          VARCHAR (15)    NULL,
    [Create_Date]     DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]       VARCHAR (20)    DEFAULT (host_name()) NULL
);

