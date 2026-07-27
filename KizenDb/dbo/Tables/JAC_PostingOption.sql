CREATE TABLE [dbo].[JAC_PostingOption] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [PostingId] INT            NOT NULL,
    [SystemId]  SMALLINT       NOT NULL,
    [OptionId]  SMALLINT       NOT NULL,
    [Data]      NVARCHAR (MAX) NULL,
    [BranchId]  INT            NULL,
    CONSTRAINT [PK_dbo.JAC_PostingOption] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_PostingOption_dbo.JAC_Branch_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[JAC_Branch] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingOption_dbo.JAC_Posting_PostingId] FOREIGN KEY ([PostingId]) REFERENCES [dbo].[JAC_Posting] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BranchId]
    ON [dbo].[JAC_PostingOption]([BranchId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PostingId]
    ON [dbo].[JAC_PostingOption]([PostingId] ASC);

