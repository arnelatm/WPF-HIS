CREATE TABLE [dbo].[UserRights] (
    [BranchID]        VARCHAR (15)  NOT NULL,
    [userID]          VARCHAR (15)  NOT NULL,
    [ApplicationName] VARCHAR (25)  NOT NULL,
    [ItemTag]         VARCHAR (1)   NOT NULL,
    [Primary_Key]     NUMERIC (3)   NULL,
    [OrderID]         NUMERIC (3)   NOT NULL,
    [HaveNode]        VARCHAR (1)   DEFAULT ('Y') NULL,
    [StripName]       VARCHAR (100) NOT NULL,
    [PADName]         VARCHAR (150) NOT NULL,
    [value]           NUMERIC (1)   NULL
);


GO
CREATE CLUSTERED INDEX [IDX_UserRights]
    ON [dbo].[UserRights]([BranchID] ASC, [userID] ASC, [ApplicationName] ASC, [Primary_Key] ASC, [OrderID] ASC, [PADName] ASC);

