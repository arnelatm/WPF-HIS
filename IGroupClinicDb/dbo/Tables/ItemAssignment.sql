CREATE TABLE [dbo].[ItemAssignment] (
    [IdNo]      INT          IDENTITY (1, 1) NOT NULL,
    [BranchID]  VARCHAR (15) NULL,
    [Item_Code] VARCHAR (15) NULL,
    [ServiceID] VARCHAR (15) NULL,
    CONSTRAINT [PK_ItemAssignment] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_ItemAssignment]
    ON [dbo].[ItemAssignment]([BranchID] ASC, [ServiceID] ASC);

