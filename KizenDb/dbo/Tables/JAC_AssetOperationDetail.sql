CREATE TABLE [dbo].[JAC_AssetOperationDetail] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [OperationId]        INT             NOT NULL,
    [AssetId]            INT             NOT NULL,
    [CurrencyId]         INT             NOT NULL,
    [Value]              DECIMAL (19, 4) NOT NULL,
    [SumIncrease]        DECIMAL (19, 4) NOT NULL,
    [SumDecrease]        DECIMAL (19, 4) NOT NULL,
    [SumDepreciation]    DECIMAL (19, 4) NOT NULL,
    [CreditCostCenterId] INT             NULL,
    [Note]               NVARCHAR (250)  NULL,
    [TaxPercent]         DECIMAL (19, 4) DEFAULT ((0)) NOT NULL,
    [TaxValue]           DECIMAL (19, 4) DEFAULT ((0)) NOT NULL,
    [TaxValueIsFixed]    BIT             DEFAULT ((0)) NOT NULL,
    [ValueBeforeTax]     DECIMAL (19, 4) DEFAULT ((0)) NOT NULL,
    [CategoryId]         INT             NULL,
    [DebitCostCenterId]  INT             NULL,
    [InvoiceNumber]      NVARCHAR (250)  NULL,
    [TaxNumber]          NVARCHAR (50)   NULL,
    [Comment]            NVARCHAR (250)  NULL,
    CONSTRAINT [PK_dbo.JAC_AssetOperationDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AssetOperationDetail_dbo.JAC_Asset_AssetId] FOREIGN KEY ([AssetId]) REFERENCES [dbo].[JAC_Asset] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AssetOperationDetail_dbo.JAC_AssetOperation_OperationId] FOREIGN KEY ([OperationId]) REFERENCES [dbo].[JAC_AssetOperation] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AssetOperationDetail_dbo.JAC_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[JAC_Category] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetOperationDetail_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CreditCostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetOperationDetail_dbo.JAC_CostCenter_DebitCostCenterId] FOREIGN KEY ([DebitCostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetOperationDetail_dbo.JAC_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[JAC_Currency] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_DebitCostCenterId]
    ON [dbo].[JAC_AssetOperationDetail]([DebitCostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CategoryId]
    ON [dbo].[JAC_AssetOperationDetail]([CategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_AssetOperationDetail]([CreditCostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CurrencyId]
    ON [dbo].[JAC_AssetOperationDetail]([CurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AssetId]
    ON [dbo].[JAC_AssetOperationDetail]([AssetId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OperationId]
    ON [dbo].[JAC_AssetOperationDetail]([OperationId] ASC);

