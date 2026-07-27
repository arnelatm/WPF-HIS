CREATE TABLE [dbo].[JAC_PostingGroupDetail] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [PostingGroupId] INT NOT NULL,
    [GroupDetailId]  INT NOT NULL,
    [AccountId]      INT NULL,
    [CostCenterId]   INT NULL,
    [CategoryId]     INT NULL,
    CONSTRAINT [PK_dbo.JAC_PostingGroupDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_PostingGroupDetail_dbo.JAC_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingGroupDetail_dbo.JAC_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[JAC_Category] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingGroupDetail_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingGroupDetail_dbo.JAC_PostingGroup_PostingGroupId] FOREIGN KEY ([PostingGroupId]) REFERENCES [dbo].[JAC_PostingGroup] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CategoryId]
    ON [dbo].[JAC_PostingGroupDetail]([CategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_GroupGroupDetailIndex]
    ON [dbo].[JAC_PostingGroupDetail]([PostingGroupId] ASC, [GroupDetailId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_PostingGroupDetail]([CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[JAC_PostingGroupDetail]([AccountId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_GroupGroupDetail]
    ON [dbo].[JAC_PostingGroupDetail]([PostingGroupId] ASC, [GroupDetailId] ASC);

