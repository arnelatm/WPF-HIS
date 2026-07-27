CREATE TABLE [dbo].[JAC_Posting] (
    [Id]                             INT IDENTITY (1, 1) NOT NULL,
    [CompanyId]                      INT NOT NULL,
    [EntryGroupByMode]               INT NOT NULL,
    [PatternId]                      INT NULL,
    [RePostingWhenAccountChanged]    BIT DEFAULT ((0)) NOT NULL,
    [RePostingWhenCostCenterChanged] BIT DEFAULT ((0)) NOT NULL,
    [DisableSearchEntryCode]         BIT DEFAULT ((0)) NOT NULL,
    [GroupByDate]                    INT DEFAULT ((0)) NOT NULL,
    [AllowChangeWhenPosting]         BIT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_Posting] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Posting_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_Posting_dbo.JAC_Pattern_PatternId] FOREIGN KEY ([PatternId]) REFERENCES [dbo].[JAC_Pattern] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_PatternId]
    ON [dbo].[JAC_Posting]([PatternId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Company]
    ON [dbo].[JAC_Posting]([CompanyId] ASC);

