CREATE TABLE [dbo].[Lab_InputOrReport] (
    [BranchID] VARCHAR (15) NOT NULL,
    [Type]     INT          NULL,
    [IRID]     VARCHAR (10) NOT NULL,
    [IRName]   VARCHAR (50) NULL,
    [Picture1] VARCHAR (50) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_InputOrReport]
    ON [dbo].[Lab_InputOrReport]([BranchID] ASC, [Type] ASC, [IRID] ASC);

