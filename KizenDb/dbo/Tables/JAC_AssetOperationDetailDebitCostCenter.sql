CREATE TABLE [dbo].[JAC_AssetOperationDetailDebitCostCenter] (
    [Id]                     INT             IDENTITY (1, 1) NOT NULL,
    [AssetOperationDetailId] INT             NOT NULL,
    [CostCenterId]           INT             NOT NULL,
    [Percent]                DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_AssetOperationDetailDebitCostCenter] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_AssetOperationDetailDebitCostCenter]([CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AssetOperationDetailId]
    ON [dbo].[JAC_AssetOperationDetailDebitCostCenter]([AssetOperationDetailId] ASC);

