CREATE TABLE [dbo].[JAC_CostCenterDistrib] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [CostCenterId]        INT             NOT NULL,
    [CostCenterDistribId] INT             NOT NULL,
    [Percent]             DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_CostCenterDistrib] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_CostCenterDistrib_dbo.JAC_CostCenter_CostCenterDistribId] FOREIGN KEY ([CostCenterDistribId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_CostCenterDistrib_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterDistribId]
    ON [dbo].[JAC_CostCenterDistrib]([CostCenterDistribId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_CostCenterDistrib]([CostCenterId] ASC);

