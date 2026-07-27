CREATE TABLE [dbo].[JAC_Account] (
    [Id]                       INT             IDENTITY (1, 1) NOT NULL,
    [CompanyId]                INT             NOT NULL,
    [Code]                     NVARCHAR (50)   NOT NULL,
    [Name]                     NVARCHAR (250)  NOT NULL,
    [Kind]                     NVARCHAR (15)   NOT NULL,
    [ClosingId]                INT             NULL,
    [ParentId]                 INT             NULL,
    [FinancialStatementNoteId] INT             NULL,
    [SystemId]                 INT             NOT NULL,
    [SourceType]               INT             NULL,
    [SourceId]                 INT             NULL,
    [CostCenterIsMandatory]    BIT             DEFAULT ((0)) NOT NULL,
    [CostCenterId]             INT             NULL,
    [Type]                     NVARCHAR (15)   DEFAULT ('') NOT NULL,
    [NameLatin]                NVARCHAR (250)  NULL,
    [CategoryIsMandatory]      BIT             DEFAULT ((0)) NOT NULL,
    [CategoryId]               INT             NULL,
    [Comment]                  NVARCHAR (250)  NULL,
    [TaxEnabled]               BIT             DEFAULT ((0)) NOT NULL,
    [TaxAccountId]             INT             NULL,
    [TaxPercent]               DECIMAL (19, 4) NULL,
    [TaxPercentIsFixed]        BIT             DEFAULT ((0)) NOT NULL,
    [TaxNumber]                NVARCHAR (50)   NULL,
    [Disabled]                 BIT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_Account] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Account_dbo.JAC_Account_ClosingId] FOREIGN KEY ([ClosingId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Account_dbo.JAC_Account_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Account_dbo.JAC_Account_TaxAccountId] FOREIGN KEY ([TaxAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Account_dbo.JAC_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[JAC_Category] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Account_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Account_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Account_dbo.JAC_FinancialStatementNote_FinancialStatementNoteId] FOREIGN KEY ([FinancialStatementNoteId]) REFERENCES [dbo].[JAC_FinancialStatementNote] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TaxAccountId]
    ON [dbo].[JAC_Account]([TaxAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CategoryId]
    ON [dbo].[JAC_Account]([CategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_Account]([CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FinancialStatementNoteId]
    ON [dbo].[JAC_Account]([FinancialStatementNoteId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ParentId]
    ON [dbo].[JAC_Account]([ParentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ClosingId]
    ON [dbo].[JAC_Account]([ClosingId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_Account]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_Account]([Code] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndName]
    ON [dbo].[JAC_Account]([CompanyId] ASC, [Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndCode]
    ON [dbo].[JAC_Account]([CompanyId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_Account]([CompanyId] ASC);

