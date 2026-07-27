CREATE TABLE [dbo].[JAC_FinancialStatementDetailSubDetail] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [DetailId]    INT NOT NULL,
    [SubDetailId] INT NOT NULL,
    [RowOrder]    INT NOT NULL,
    CONSTRAINT [PK_dbo.JAC_FinancialStatementDetailSubDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_FinancialStatementDetailSubDetail_dbo.JAC_FinancialStatementDetail_DetailId] FOREIGN KEY ([DetailId]) REFERENCES [dbo].[JAC_FinancialStatementDetail] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_FinancialStatementDetailSubDetail_dbo.JAC_FinancialStatementDetail_SubDetailId] FOREIGN KEY ([SubDetailId]) REFERENCES [dbo].[JAC_FinancialStatementDetail] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_SubDetailId]
    ON [dbo].[JAC_FinancialStatementDetailSubDetail]([SubDetailId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DetailId]
    ON [dbo].[JAC_FinancialStatementDetailSubDetail]([DetailId] ASC);

