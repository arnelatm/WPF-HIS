CREATE TABLE [dbo].[UserControls] (
    [BranchID]        VARCHAR (15)  NOT NULL,
    [ApplicationName] VARCHAR (50)  NOT NULL,
    [ItemTag]         VARCHAR (1)   NOT NULL,
    [Primary_Key]     NUMERIC (3)   NULL,
    [OrderID]         NUMERIC (3)   NOT NULL,
    [HaveNode]        VARCHAR (1)   DEFAULT ('Y') NULL,
    [StripName]       VARCHAR (100) NOT NULL,
    [StripNameArabic] VARCHAR (100) NULL,
    [PADName]         VARCHAR (150) NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IX_UserControls]
    ON [dbo].[UserControls]([BranchID] ASC, [Primary_Key] ASC, [OrderID] ASC, [PADName] ASC);

