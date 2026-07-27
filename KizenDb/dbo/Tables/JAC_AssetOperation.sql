CREATE TABLE [dbo].[JAC_AssetOperation] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CycleId]          INT            NOT NULL,
    [BranchId]         INT            NOT NULL,
    [Code]             INT            NOT NULL,
    [Kind]             INT            NOT NULL,
    [DateTime]         DATETIME       NOT NULL,
    [AccountId]        INT            NULL,
    [EntryId]          INT            NULL,
    [Note]             NVARCHAR (250) NULL,
    [UserId]           INT            NULL,
    [UserName]         NVARCHAR (250) NULL,
    [UserIdLastEdit]   INT            NULL,
    [UserNameLastEdit] NVARCHAR (250) NULL,
    CONSTRAINT [PK_dbo.JAC_AssetOperation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AssetOperation_dbo.JAC_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetOperation_dbo.JAC_Branch_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[JAC_Branch] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AssetOperation_dbo.JAC_Cycle_CycleId] FOREIGN KEY ([CycleId]) REFERENCES [dbo].[JAC_Cycle] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetOperation_dbo.JAC_Entry_EntryId] FOREIGN KEY ([EntryId]) REFERENCES [dbo].[JAC_Entry] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_EntryId]
    ON [dbo].[JAC_AssetOperation]([EntryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[JAC_AssetOperation]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Kind]
    ON [dbo].[JAC_AssetOperation]([Kind] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_AssetOperation]([Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BranchId]
    ON [dbo].[JAC_AssetOperation]([BranchId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CycleAndBranchAndCodeAndKind]
    ON [dbo].[JAC_AssetOperation]([CycleId] ASC, [BranchId] ASC, [Code] ASC, [Kind] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CycleId]
    ON [dbo].[JAC_AssetOperation]([CycleId] ASC);

