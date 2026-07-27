CREATE TABLE [dbo].[JAC_Bond] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CycleId]          INT            NOT NULL,
    [PatternId]        INT            NOT NULL,
    [BranchId]         INT            NOT NULL,
    [Code]             INT            NOT NULL,
    [DateTime]         DATETIME       NOT NULL,
    [AccountId]        INT            NOT NULL,
    [EntryId]          INT            NOT NULL,
    [Note]             NVARCHAR (250) NULL,
    [UserId]           INT            NULL,
    [UserName]         NVARCHAR (250) NULL,
    [UserIdLastEdit]   INT            NULL,
    [UserNameLastEdit] NVARCHAR (250) NULL,
    CONSTRAINT [PK_dbo.JAC_Bond] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Bond_dbo.JAC_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[JAC_Account] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_Bond_dbo.JAC_Branch_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[JAC_Branch] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_Bond_dbo.JAC_Cycle_CycleId] FOREIGN KEY ([CycleId]) REFERENCES [dbo].[JAC_Cycle] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_Bond_dbo.JAC_Entry_EntryId] FOREIGN KEY ([EntryId]) REFERENCES [dbo].[JAC_Entry] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_Bond_dbo.JAC_Pattern_PatternId] FOREIGN KEY ([PatternId]) REFERENCES [dbo].[JAC_Pattern] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_EntryId]
    ON [dbo].[JAC_Bond]([EntryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[JAC_Bond]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_Bond]([Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BranchId]
    ON [dbo].[JAC_Bond]([BranchId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PatternId]
    ON [dbo].[JAC_Bond]([PatternId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CycleAndPatternAndBranchAndCode]
    ON [dbo].[JAC_Bond]([CycleId] ASC, [PatternId] ASC, [BranchId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CycleId]
    ON [dbo].[JAC_Bond]([CycleId] ASC);

