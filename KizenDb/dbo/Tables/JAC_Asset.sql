CREATE TABLE [dbo].[JAC_Asset] (
    [Id]                          INT             IDENTITY (1, 1) NOT NULL,
    [CompanyId]                   INT             NOT NULL,
    [Code]                        NVARCHAR (50)   NOT NULL,
    [Name]                        NVARCHAR (255)  NOT NULL,
    [DepreciationKind]            INT             NOT NULL,
    [ProductionPeriod]            REAL            NOT NULL,
    [ProductionPeriodKind]        INT             NOT NULL,
    [DepreciationStartDate]       DATETIME        NOT NULL,
    [CurrencyId]                  INT             NOT NULL,
    [ScrapValue]                  DECIMAL (19, 4) NOT NULL,
    [Note]                        NVARCHAR (250)  NULL,
    [GroupId]                     INT             NOT NULL,
    [AssetAccountId]              INT             NULL,
    [DepreciateAccountId]         INT             NULL,
    [AccumulatedAccountId]        INT             NULL,
    [ExpenseAccountId]            INT             NULL,
    [ProfitAccountId]             INT             NULL,
    [LossAccountId]               INT             NULL,
    [RevaluationSurplusAccountId] INT             NULL,
    [RevaluationDeficitAccountId] INT             NULL,
    [CountryOrigin]               NVARCHAR (50)   NULL,
    [Measurement]                 NVARCHAR (50)   NULL,
    [Class]                       NVARCHAR (50)   NULL,
    [Status]                      NVARCHAR (50)   NULL,
    [Color]                       NVARCHAR (50)   NULL,
    [Weight]                      NVARCHAR (50)   NULL,
    [StructureNumber]             NVARCHAR (50)   NULL,
    [BranchId]                    INT             NULL,
    [TaxAccountId]                INT             NULL,
    [TaxPercent]                  DECIMAL (19, 4) DEFAULT ((0)) NOT NULL,
    [LocationId]                  INT             NULL,
    [NameLatin]                   NVARCHAR (255)  NULL,
    [DepreciateMethod]            INT             DEFAULT ((0)) NOT NULL,
    [DepreciatePercent]           DECIMAL (19, 4) NULL,
    CONSTRAINT [PK_dbo.JAC_Asset] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Account_AccumulatedAccountId] FOREIGN KEY ([AccumulatedAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Account_AssetAccountId] FOREIGN KEY ([AssetAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Account_DepreciateAccountId] FOREIGN KEY ([DepreciateAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Account_ExpenseAccountId] FOREIGN KEY ([ExpenseAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Account_LossAccountId] FOREIGN KEY ([LossAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Account_ProfitAccountId] FOREIGN KEY ([ProfitAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Account_RevaluationDeficitAccountId] FOREIGN KEY ([RevaluationDeficitAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Account_RevaluationSurplusAccountId] FOREIGN KEY ([RevaluationSurplusAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Account_TaxAccountId] FOREIGN KEY ([TaxAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_AssetGroup_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[JAC_AssetGroup] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Branch_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[JAC_Branch] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[JAC_Currency] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_Asset_dbo.JAC_Location_LocationId] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[JAC_Location] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_LocationId]
    ON [dbo].[JAC_Asset]([LocationId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TaxAccountId]
    ON [dbo].[JAC_Asset]([TaxAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BranchId]
    ON [dbo].[JAC_Asset]([BranchId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RevaluationDeficitAccountId]
    ON [dbo].[JAC_Asset]([RevaluationDeficitAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RevaluationSurplusAccountId]
    ON [dbo].[JAC_Asset]([RevaluationSurplusAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LossAccountId]
    ON [dbo].[JAC_Asset]([LossAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProfitAccountId]
    ON [dbo].[JAC_Asset]([ProfitAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ExpenseAccountId]
    ON [dbo].[JAC_Asset]([ExpenseAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccumulatedAccountId]
    ON [dbo].[JAC_Asset]([AccumulatedAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DepreciateAccountId]
    ON [dbo].[JAC_Asset]([DepreciateAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AssetAccountId]
    ON [dbo].[JAC_Asset]([AssetAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_GroupId]
    ON [dbo].[JAC_Asset]([GroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CurrencyId]
    ON [dbo].[JAC_Asset]([CurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_Asset]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_Asset]([Code] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndName]
    ON [dbo].[JAC_Asset]([CompanyId] ASC, [Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndCode]
    ON [dbo].[JAC_Asset]([CompanyId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_Asset]([CompanyId] ASC);

