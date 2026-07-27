CREATE TABLE [dbo].[JAC_AssetDepreciateDetailCreditCostCenter] (
    [Id]                      INT             IDENTITY (1, 1) NOT NULL,
    [AssetDepreciateDetailId] INT             NOT NULL,
    [CostCenterId]            INT             NOT NULL,
    [Percent]                 DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_AssetDepreciateDetailCreditCostCenter] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AssetDepreciateDetailCostCenter_dbo.JAC_AssetDepreciateDetail_AssetDepreciateDetailId] FOREIGN KEY ([AssetDepreciateDetailId]) REFERENCES [dbo].[JAC_AssetDepreciateDetail] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AssetDepreciateDetailCostCenter_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_AssetDepreciateDetailCreditCostCenter]([CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AssetDepreciateDetailId]
    ON [dbo].[JAC_AssetDepreciateDetailCreditCostCenter]([AssetDepreciateDetailId] ASC);

