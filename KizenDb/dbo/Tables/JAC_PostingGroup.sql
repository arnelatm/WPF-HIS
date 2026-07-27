CREATE TABLE [dbo].[JAC_PostingGroup] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [PostingId]            INT            NOT NULL,
    [Type]                 INT            NOT NULL,
    [SystemId]             INT            NOT NULL,
    [GroupId]              INT            NOT NULL,
    [Caption]              NVARCHAR (100) NULL,
    [AutoGenerateAccounts] BIT            DEFAULT ((0)) NOT NULL,
    [ParentAccountId]      INT            NULL,
    [AccountCodingMethod]  INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_PostingGroup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_PostingGroup_dbo.JAC_Account_ParentAccountId] FOREIGN KEY ([ParentAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingGroup_dbo.JAC_Posting_PostingId] FOREIGN KEY ([PostingId]) REFERENCES [dbo].[JAC_Posting] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ParentAccountId]
    ON [dbo].[JAC_PostingGroup]([ParentAccountId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Caption]
    ON [dbo].[JAC_PostingGroup]([Caption] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PostingId]
    ON [dbo].[JAC_PostingGroup]([PostingId] ASC);

