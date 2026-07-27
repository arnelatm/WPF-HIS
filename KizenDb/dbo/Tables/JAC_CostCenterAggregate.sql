CREATE TABLE [dbo].[JAC_CostCenterAggregate] (
    [Id]                    INT IDENTITY (1, 1) NOT NULL,
    [CostCenterId]          INT NOT NULL,
    [CostCenterAggregateId] INT NOT NULL,
    CONSTRAINT [PK_dbo.JAC_CostCenterAggregate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_CostCenterAggregate_dbo.JAC_CostCenter_CostCenterAggregateId] FOREIGN KEY ([CostCenterAggregateId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_CostCenterAggregate_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterAggregateId]
    ON [dbo].[JAC_CostCenterAggregate]([CostCenterAggregateId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_CostCenterAggregate]([CostCenterId] ASC);

