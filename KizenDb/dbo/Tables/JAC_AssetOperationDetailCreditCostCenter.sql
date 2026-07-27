CREATE TABLE [dbo].[JAC_AssetOperationDetailCreditCostCenter] (
    [Id]                     INT             IDENTITY (1, 1) NOT NULL,
    [AssetOperationDetailId] INT             NOT NULL,
    [CostCenterId]           INT             NOT NULL,
    [Percent]                DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_AssetOperationDetailCreditCostCenter] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AssetOperationDetailCostCenter_dbo.JAC_AssetOperationDetail_AssetOperationDetailId] FOREIGN KEY ([AssetOperationDetailId]) REFERENCES [dbo].[JAC_AssetOperationDetail] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AssetOperationDetailCostCenter_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_AssetOperationDetailCreditCostCenter]([CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AssetOperationDetailId]
    ON [dbo].[JAC_AssetOperationDetailCreditCostCenter]([AssetOperationDetailId] ASC);

