CREATE TABLE [dbo].[JAC_AssetDepreciate] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CycleId]          INT            NOT NULL,
    [BranchId]         INT            NOT NULL,
    [Code]             INT            NOT NULL,
    [DateTime]         DATETIME       NOT NULL,
    [GroupId]          INT            NULL,
    [AssetId]          INT            NULL,
    [EntryId]          INT            NULL,
    [ToDate]           DATETIME       NOT NULL,
    [Note]             NVARCHAR (250) NULL,
    [UserId]           INT            NULL,
    [UserName]         NVARCHAR (250) NULL,
    [UserIdLastEdit]   INT            NULL,
    [UserNameLastEdit] NVARCHAR (250) NULL,
    CONSTRAINT [PK_dbo.JAC_AssetDepreciate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AssetDepreciate_dbo.JAC_Asset_AssetId] FOREIGN KEY ([AssetId]) REFERENCES [dbo].[JAC_Asset] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetDepreciate_dbo.JAC_AssetGroup_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[JAC_AssetGroup] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetDepreciate_dbo.JAC_Branch_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[JAC_Branch] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AssetDepreciate_dbo.JAC_Cycle_CycleId] FOREIGN KEY ([CycleId]) REFERENCES [dbo].[JAC_Cycle] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AssetDepreciate_dbo.JAC_Entry_EntryId] FOREIGN KEY ([EntryId]) REFERENCES [dbo].[JAC_Entry] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_EntryId]
    ON [dbo].[JAC_AssetDepreciate]([EntryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AssetId]
    ON [dbo].[JAC_AssetDepreciate]([AssetId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_GroupId]
    ON [dbo].[JAC_AssetDepreciate]([GroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_AssetDepreciate]([Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BranchId]
    ON [dbo].[JAC_AssetDepreciate]([BranchId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CycleAndBranchAndCode]
    ON [dbo].[JAC_AssetDepreciate]([CycleId] ASC, [BranchId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CycleId]
    ON [dbo].[JAC_AssetDepreciate]([CycleId] ASC);

