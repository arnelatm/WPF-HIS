CREATE TABLE [dbo].[Lab_AttachedService] (
    [BranchID]        VARCHAR (15) NOT NULL,
    [ServiceID]       VARCHAR (15) NULL,
    [InvestigationID] VARCHAR (15) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_AttachedService]
    ON [dbo].[Lab_AttachedService]([BranchID] ASC, [ServiceID] ASC);

