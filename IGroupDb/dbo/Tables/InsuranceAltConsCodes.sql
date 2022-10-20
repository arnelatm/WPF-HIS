CREATE TABLE [dbo].[InsuranceAltConsCodes] (
    [BranchID]        VARCHAR (15) NOT NULL,
    [InsuranceID]     VARCHAR (15) NOT NULL,
    [ConServiceID]    VARCHAR (15) NOT NULL,
    [AltConServiceID] VARCHAR (15) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_InsuranceAltConsCodes]
    ON [dbo].[InsuranceAltConsCodes]([BranchID] ASC, [InsuranceID] ASC, [ConServiceID] ASC);

