CREATE TABLE [dbo].[RevCostCenter] (
    [IdNo]                INT           NOT NULL,
    [RevCostCenterCode]    VARCHAR (5)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [RevCostCenterName]    VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ParentIdNo]          INT           NULL,
    [RevCostCenterNameAra] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [RevCostCenterType]    CHAR (1)      COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]               VARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]       ROWVERSION    NULL,
    CONSTRAINT [PK__RevCostCenterID] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [FK__ProfitCen__Paren__6BAEFA67] FOREIGN KEY ([ParentIdNo]) REFERENCES [dbo].[RevCostCenter] ([IdNo]),
    CONSTRAINT [IX_RevCostCenterCode] UNIQUE NONCLUSTERED ([RevCostCenterCode] ASC),
    CONSTRAINT [IX_RevCostCenterNameAra] UNIQUE NONCLUSTERED ([RevCostCenterNameAra] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_RevCostCenterName]
    ON [dbo].[RevCostCenter]([RevCostCenterName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RevCostCenterParent]
    ON [dbo].[RevCostCenter]([ParentIdNo] ASC);

