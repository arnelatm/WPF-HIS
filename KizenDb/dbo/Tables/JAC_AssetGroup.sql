CREATE TABLE [dbo].[JAC_AssetGroup] (
    [Id]                          INT             IDENTITY (1, 1) NOT NULL,
    [CompanyId]                   INT             NOT NULL,
    [Code]                        NVARCHAR (50)   NOT NULL,
    [Name]                        NVARCHAR (250)  NOT NULL,
    [ParentId]                    INT             NULL,
    [AssetAccountId]              INT             NULL,
    [DepreciateAccountId]         INT             NULL,
    [AccumulatedAccountId]        INT             NULL,
    [ExpenseAccountId]            INT             NULL,
    [ProfitAccountId]             INT             NULL,
    [LossAccountId]               INT             NULL,
    [RevaluationSurplusAccountId] INT             NULL,
    [RevaluationDeficitAccountId] INT             NULL,
    [TaxAccountId]                INT             NULL,
    [TaxPercent]                  DECIMAL (19, 4) DEFAULT ((0)) NOT NULL,
    [NameLatin]                   NVARCHAR (250)  NULL,
    CONSTRAINT [PK_dbo.JAC_AssetGroup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AssetGroup_dbo.JAC_Account_AccumulatedAccountId] FOREIGN KEY ([AccumulatedAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetGroup_dbo.JAC_Account_AssetAccountId] FOREIGN KEY ([AssetAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetGroup_dbo.JAC_Account_DepreciateAccountId] FOREIGN KEY ([DepreciateAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetGroup_dbo.JAC_Account_ExpenseAccountId] FOREIGN KEY ([ExpenseAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetGroup_dbo.JAC_Account_LossAccountId] FOREIGN KEY ([LossAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetGroup_dbo.JAC_Account_ProfitAccountId] FOREIGN KEY ([ProfitAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetGroup_dbo.JAC_Account_RevaluationDeficitAccountId] FOREIGN KEY ([RevaluationDeficitAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetGroup_dbo.JAC_Account_RevaluationSurplusAccountId] FOREIGN KEY ([RevaluationSurplusAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetGroup_dbo.JAC_Account_TaxAccountId] FOREIGN KEY ([TaxAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetGroup_dbo.JAC_AssetGroup_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[JAC_AssetGroup] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AssetGroup_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TaxAccountId]
    ON [dbo].[JAC_AssetGroup]([TaxAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RevaluationDeficitAccountId]
    ON [dbo].[JAC_AssetGroup]([RevaluationDeficitAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RevaluationSurplusAccountId]
    ON [dbo].[JAC_AssetGroup]([RevaluationSurplusAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LossAccountId]
    ON [dbo].[JAC_AssetGroup]([LossAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProfitAccountId]
    ON [dbo].[JAC_AssetGroup]([ProfitAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ExpenseAccountId]
    ON [dbo].[JAC_AssetGroup]([ExpenseAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccumulatedAccountId]
    ON [dbo].[JAC_AssetGroup]([AccumulatedAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DepreciateAccountId]
    ON [dbo].[JAC_AssetGroup]([DepreciateAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AssetAccountId]
    ON [dbo].[JAC_AssetGroup]([AssetAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ParentId]
    ON [dbo].[JAC_AssetGroup]([ParentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_AssetGroup]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_AssetGroup]([Code] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndName]
    ON [dbo].[JAC_AssetGroup]([CompanyId] ASC, [Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndCode]
    ON [dbo].[JAC_AssetGroup]([CompanyId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_AssetGroup]([CompanyId] ASC);

