CREATE TABLE [dbo].[JAC_EntryDetail] (
    [Id]                    INT             IDENTITY (1, 1) NOT NULL,
    [EntryId]               INT             NOT NULL,
    [CurrencyId]            INT             NOT NULL,
    [Debit]                 DECIMAL (19, 4) NOT NULL,
    [Credit]                DECIMAL (19, 4) NOT NULL,
    [AccountId]             INT             NOT NULL,
    [ContraAccountId]       INT             NULL,
    [CostCenterId]          INT             NULL,
    [Note]                  NVARCHAR (250)  NULL,
    [SystemId]              INT             NOT NULL,
    [SourceType]            INT             NOT NULL,
    [SourceDetailType]      INT             NOT NULL,
    [SourceId]              INT             NOT NULL,
    [RowOrder]              INT             NOT NULL,
    [CategoryId]            INT             NULL,
    [IsAutoDetail]          BIT             DEFAULT ((0)) NOT NULL,
    [TaxAccountId]          INT             NULL,
    [TaxPercent]            DECIMAL (19, 4) NULL,
    [TaxValue]              DECIMAL (19, 4) NULL,
    [InvoiceNumber]         NVARCHAR (250)  NULL,
    [TaxNumber]             NVARCHAR (50)   NULL,
    [Comment]               NVARCHAR (250)  NULL,
    [SourceParentReference] NVARCHAR (50)   NULL,
    [DateTime]              DATETIME        NULL,
    CONSTRAINT [PK_dbo.JAC_EntryDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_EntryDetail_dbo.JAC_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[JAC_Account] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_EntryDetail_dbo.JAC_Account_ContraAccountId] FOREIGN KEY ([ContraAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_EntryDetail_dbo.JAC_Account_TaxAccountId] FOREIGN KEY ([TaxAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_EntryDetail_dbo.JAC_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[JAC_Category] ([Id]),
    CONSTRAINT [FK_dbo.JAC_EntryDetail_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_EntryDetail_dbo.JAC_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[JAC_Currency] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_EntryDetail_dbo.JAC_Entry_EntryId] FOREIGN KEY ([EntryId]) REFERENCES [dbo].[JAC_Entry] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SourceParentReference]
    ON [dbo].[JAC_EntryDetail]([SourceParentReference] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EntryId_SystemId_SourceType]
    ON [dbo].[JAC_EntryDetail]([EntryId] ASC, [SystemId] ASC, [SourceType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_EntryDetail]([CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RowOrder]
    ON [dbo].[JAC_EntryDetail]([RowOrder] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemId_SourceType_SourceId]
    ON [dbo].[JAC_EntryDetail]([SystemId] ASC, [SourceType] ASC, [SourceId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemId_SourceType_SourceDetailType_SourceId]
    ON [dbo].[JAC_EntryDetail]([SystemId] ASC, [SourceType] ASC, [SourceDetailType] ASC, [SourceId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TaxAccountId]
    ON [dbo].[JAC_EntryDetail]([TaxAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CategoryId]
    ON [dbo].[JAC_EntryDetail]([CategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SourceId]
    ON [dbo].[JAC_EntryDetail]([SourceId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SourceDetailType]
    ON [dbo].[JAC_EntryDetail]([SourceDetailType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SourceType]
    ON [dbo].[JAC_EntryDetail]([SourceType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemId]
    ON [dbo].[JAC_EntryDetail]([SystemId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[JAC_EntryDetail]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ContraAccountId]
    ON [dbo].[JAC_EntryDetail]([ContraAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemId_SourceType_SourceId_AccountId_CostCenterId]
    ON [dbo].[JAC_EntryDetail]([SystemId] ASC, [SourceType] ASC, [SourceDetailType] ASC, [SourceId] ASC, [AccountId] ASC, [CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CurrencyId]
    ON [dbo].[JAC_EntryDetail]([CurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EntryId]
    ON [dbo].[JAC_EntryDetail]([EntryId] ASC);

