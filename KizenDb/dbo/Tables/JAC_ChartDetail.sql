CREATE TABLE [dbo].[JAC_ChartDetail] (
    [Id]                         INT IDENTITY (1, 1) NOT NULL,
    [ChartId]                    INT NOT NULL,
    [AccountId]                  INT NULL,
    [CostCenterId]               INT NULL,
    [Color]                      INT NOT NULL,
    [FinancialStatementDetailId] INT NULL,
    CONSTRAINT [PK_dbo.JAC_ChartDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_ChartDetail_dbo.JAC_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_ChartDetail_dbo.JAC_Chart_ChartId] FOREIGN KEY ([ChartId]) REFERENCES [dbo].[JAC_Chart] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_ChartDetail_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_ChartDetail_dbo.JAC_FinancialStatementDetail_FinancialStatementDetailId] FOREIGN KEY ([FinancialStatementDetailId]) REFERENCES [dbo].[JAC_FinancialStatementDetail] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FinancialStatementDetailId]
    ON [dbo].[JAC_ChartDetail]([FinancialStatementDetailId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_ChartDetail]([CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[JAC_ChartDetail]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ChartId]
    ON [dbo].[JAC_ChartDetail]([ChartId] ASC);

