CREATE TABLE [dbo].[JAC_AccountMatchingGroupDetail] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [GroupId]    INT NOT NULL,
    [MatchingId] INT NOT NULL,
    CONSTRAINT [PK_dbo.JAC_AccountMatchingGroupDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AccountMatchingGroupDetail_dbo.JAC_AccountMatching_MatchingId] FOREIGN KEY ([MatchingId]) REFERENCES [dbo].[JAC_AccountMatching] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AccountMatchingGroupDetail_dbo.JAC_AccountMatchingGroup_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[JAC_AccountMatchingGroup] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_MatchingId]
    ON [dbo].[JAC_AccountMatchingGroupDetail]([MatchingId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_GroupId]
    ON [dbo].[JAC_AccountMatchingGroupDetail]([GroupId] ASC);

