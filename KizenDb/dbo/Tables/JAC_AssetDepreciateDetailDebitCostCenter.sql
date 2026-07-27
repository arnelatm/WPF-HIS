CREATE TABLE [dbo].[JAC_AssetDepreciateDetailDebitCostCenter] (
    [Id]                      INT             IDENTITY (1, 1) NOT NULL,
    [AssetDepreciateDetailId] INT             NOT NULL,
    [CostCenterId]            INT             NOT NULL,
    [Percent]                 DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_AssetDepreciateDetailDebitCostCenter] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_AssetDepreciateDetailDebitCostCenter]([CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AssetDepreciateDetailId]
    ON [dbo].[JAC_AssetDepreciateDetailDebitCostCenter]([AssetDepreciateDetailId] ASC);

