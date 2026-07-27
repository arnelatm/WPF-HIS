CREATE TABLE [dbo].[JAC_CostCenterBudget] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [CyclePeriodId] INT             NULL,
    [AccountId]     INT             NOT NULL,
    [CurrencyId]    INT             NOT NULL,
    [Debit]         DECIMAL (19, 4) NOT NULL,
    [Credit]        DECIMAL (19, 4) NOT NULL,
    [CostCenterId]  INT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_CostCenterBudget] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_BudgetCostCenterDetail_dbo.JAC_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[JAC_Account] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_BudgetCostCenterDetail_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_BudgetCostCenterDetail_dbo.JAC_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[JAC_Currency] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_BudgetCostCenterDetail_dbo.JAC_CyclePeriod_CyclePeriodId] FOREIGN KEY ([CyclePeriodId]) REFERENCES [dbo].[JAC_CyclePeriod] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CurrencyId]
    ON [dbo].[JAC_CostCenterBudget]([CurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[JAC_CostCenterBudget]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CyclePeriodId]
    ON [dbo].[JAC_CostCenterBudget]([CyclePeriodId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CenterAndPeriodAndAccount]
    ON [dbo].[JAC_CostCenterBudget]([CostCenterId] ASC, [CyclePeriodId] ASC, [AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_CostCenterBudget]([CostCenterId] ASC);

