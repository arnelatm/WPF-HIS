CREATE TABLE [dbo].[JAC_FinancialStatementDetailAccount] (
    [Id]                         INT IDENTITY (1, 1) NOT NULL,
    [FinancialStatementDetailId] INT NOT NULL,
    [AccountId]                  INT NOT NULL,
    [Index]                      INT NOT NULL,
    CONSTRAINT [PK_dbo.JAC_FinancialStatementDetailAccount] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_FinancialStatementDetailAccount_dbo.JAC_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[JAC_Account] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_FinancialStatementDetailAccount_dbo.JAC_FinancialStatementDetail_FinancialStatementDetailId] FOREIGN KEY ([FinancialStatementDetailId]) REFERENCES [dbo].[JAC_FinancialStatementDetail] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[JAC_FinancialStatementDetailAccount]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FinancialStatementDetailId]
    ON [dbo].[JAC_FinancialStatementDetailAccount]([FinancialStatementDetailId] ASC);

