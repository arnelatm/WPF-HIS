CREATE TABLE [dbo].[AdditionalUserRights] (
    [BranchID]    VARCHAR (15) NOT NULL,
    [RightID]     VARCHAR (15) NOT NULL,
    [Description] VARCHAR (50) NULL,
    [Selected]    NUMERIC (1)  DEFAULT (0) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_AdditionalUserRights]
    ON [dbo].[AdditionalUserRights]([BranchID] ASC, [RightID] ASC);

