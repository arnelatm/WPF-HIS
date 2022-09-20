CREATE TABLE [dbo].[InsuranceCategory] (
    [BranchID]      VARCHAR (15) NOT NULL,
    [InsuranceType] VARCHAR (10) NOT NULL,
    [InsuranceID]   VARCHAR (15) NOT NULL,
    [CategoryID]    VARCHAR (15) NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_InsuranceCategory]
    ON [dbo].[InsuranceCategory]([BranchID] ASC, [InsuranceID] ASC, [CategoryID] ASC);

