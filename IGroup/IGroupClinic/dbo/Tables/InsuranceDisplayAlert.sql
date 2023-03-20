CREATE TABLE [dbo].[InsuranceDisplayAlert] (
    [BranchID]         VARCHAR (15) NOT NULL,
    [InsuranceID]      VARCHAR (15) NOT NULL,
    [GroupInsuranceID] VARCHAR (15) NULL,
    [Alert]            TEXT         NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_InsuranceDisplayAlert]
    ON [dbo].[InsuranceDisplayAlert]([BranchID] ASC, [InsuranceID] ASC);

