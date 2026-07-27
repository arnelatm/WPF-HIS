CREATE TABLE [dbo].[JAC_FinancialStatementDetailNote] (
    [Id]                         INT IDENTITY (1, 1) NOT NULL,
    [FinancialStatementDetailId] INT NOT NULL,
    [FinancialStatementNoteId]   INT NOT NULL,
    [RowOrder]                   INT NOT NULL,
    CONSTRAINT [PK_dbo.JAC_FinancialStatementDetailNote] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_FinancialStatementDetailNote_dbo.JAC_FinancialStatementDetail_FinancialStatementDetailId] FOREIGN KEY ([FinancialStatementDetailId]) REFERENCES [dbo].[JAC_FinancialStatementDetail] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_FinancialStatementDetailNote_dbo.JAC_FinancialStatementNote_FinancialStatementNoteId] FOREIGN KEY ([FinancialStatementNoteId]) REFERENCES [dbo].[JAC_FinancialStatementNote] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FinancialStatementNoteId]
    ON [dbo].[JAC_FinancialStatementDetailNote]([FinancialStatementNoteId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FinancialStatementDetailId]
    ON [dbo].[JAC_FinancialStatementDetailNote]([FinancialStatementDetailId] ASC);

