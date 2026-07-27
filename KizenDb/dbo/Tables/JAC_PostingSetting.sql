CREATE TABLE [dbo].[JAC_PostingSetting] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [PostingId]        INT           NOT NULL,
    [Caption]          NVARCHAR (50) NOT NULL,
    [EntryGroupByMode] INT           NOT NULL,
    [PatternId]        INT           NULL,
    CONSTRAINT [PK_dbo.JAC_PostingSetting] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_PostingSetting_dbo.JAC_Pattern_PatternId] FOREIGN KEY ([PatternId]) REFERENCES [dbo].[JAC_Pattern] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSetting_dbo.JAC_Posting_PostingId] FOREIGN KEY ([PostingId]) REFERENCES [dbo].[JAC_Posting] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PatternId]
    ON [dbo].[JAC_PostingSetting]([PatternId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PostingIdCaption]
    ON [dbo].[JAC_PostingSetting]([PostingId] ASC, [Caption] ASC);

