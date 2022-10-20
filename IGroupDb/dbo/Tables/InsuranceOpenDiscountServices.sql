CREATE TABLE [dbo].[InsuranceOpenDiscountServices] (
    [BranchID]      VARCHAR (15) NOT NULL,
    [InsuranceID]   VARCHAR (15) NOT NULL,
    [InsuranceType] VARCHAR (10) NOT NULL,
    [ServiceID]     VARCHAR (15) NOT NULL,
    [Status]        INT          DEFAULT ((0)) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_InsuranceOpenDiscountServices]
    ON [dbo].[InsuranceOpenDiscountServices]([BranchID] ASC, [InsuranceType] ASC, [InsuranceID] ASC, [ServiceID] ASC);

