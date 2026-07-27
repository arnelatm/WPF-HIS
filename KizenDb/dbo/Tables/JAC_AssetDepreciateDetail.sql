CREATE TABLE [dbo].[JAC_AssetDepreciateDetail] (
    [Id]                     INT             IDENTITY (1, 1) NOT NULL,
    [DepreciateId]           INT             NOT NULL,
    [AssetId]                INT             NOT NULL,
    [CurrencyId]             INT             NOT NULL,
    [BeginDate]              DATETIME        NOT NULL,
    [EndDate]                DATETIME        NOT NULL,
    [AssetValue]             DECIMAL (19, 4) NOT NULL,
    [ScrapValue]             DECIMAL (19, 4) NOT NULL,
    [IncreaseValue]          DECIMAL (19, 4) NOT NULL,
    [DecreaseValue]          DECIMAL (19, 4) NOT NULL,
    [DepricatePercent]       DECIMAL (19, 4) NOT NULL,
    [DepricateValue]         DECIMAL (19, 4) NOT NULL,
    [DepricateAccumulated]   DECIMAL (19, 4) NOT NULL,
    [CreditCostCenterId]     INT             NULL,
    [DebitCostCenterId]      INT             NULL,
    [AssetDepreciateMethod]  INT             DEFAULT ((0)) NOT NULL,
    [AssetDepreciatePercent] DECIMAL (19, 4) NULL,
    CONSTRAINT [PK_dbo.JAC_AssetDepreciateDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AssetDepreciateDetail_dbo.JAC_Asset_AssetId] FOREIGN KEY ([AssetId]) REFERENCES [dbo].[JAC_Asset] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AssetDepreciateDetail_dbo.JAC_AssetDepreciate_DepreciateId] FOREIGN KEY ([DepreciateId]) REFERENCES [dbo].[JAC_AssetDepreciate] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AssetDepreciateDetail_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CreditCostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetDepreciateDetail_dbo.JAC_CostCenter_DebitCostCenterId] FOREIGN KEY ([DebitCostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetDepreciateDetail_dbo.JAC_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[JAC_Currency] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_DebitCostCenterId]
    ON [dbo].[JAC_AssetDepreciateDetail]([DebitCostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_AssetDepreciateDetail]([CreditCostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CurrencyId]
    ON [dbo].[JAC_AssetDepreciateDetail]([CurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AssetId]
    ON [dbo].[JAC_AssetDepreciateDetail]([AssetId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DepreciateId]
    ON [dbo].[JAC_AssetDepreciateDetail]([DepreciateId] ASC);

