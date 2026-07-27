CREATE TABLE [dbo].[JAC_AccountBudget] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [AccountId]     INT             NOT NULL,
    [CyclePeriodId] INT             NULL,
    [CostCenterId]  INT             NULL,
    [CurrencyId]    INT             NOT NULL,
    [Debit]         DECIMAL (19, 4) NOT NULL,
    [Credit]        DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_AccountBudget] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AccountBudget_dbo.JAC_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[JAC_Account] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AccountBudget_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AccountBudget_dbo.JAC_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[JAC_Currency] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AccountBudget_dbo.JAC_CyclePeriod_CyclePeriodId] FOREIGN KEY ([CyclePeriodId]) REFERENCES [dbo].[JAC_CyclePeriod] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CurrencyId]
    ON [dbo].[JAC_AccountBudget]([CurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_AccountBudget]([CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CyclePeriodId]
    ON [dbo].[JAC_AccountBudget]([CyclePeriodId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountAndPeriodAndCostCenter]
    ON [dbo].[JAC_AccountBudget]([AccountId] ASC, [CyclePeriodId] ASC, [CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[JAC_AccountBudget]([AccountId] ASC);

