CREATE TABLE [dbo].[JAC_FinancialStatement] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]       INT            NOT NULL,
    [Code]            NVARCHAR (15)  NOT NULL,
    [Name]            NVARCHAR (100) NOT NULL,
    [NameLatin]       NVARCHAR (100) NULL,
    [ContraAccountId] INT            NULL,
    [IsCash]          BIT            NOT NULL,
    [Note]            NVARCHAR (250) NULL,
    CONSTRAINT [PK_dbo.JAC_FinancialStatement] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_FinancialStatement_dbo.JAC_Account_ContraAccountId] FOREIGN KEY ([ContraAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_FinancialStatement_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ContraAccountId]
    ON [dbo].[JAC_FinancialStatement]([ContraAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_FinancialStatement]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_FinancialStatement]([Code] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndName]
    ON [dbo].[JAC_FinancialStatement]([CompanyId] ASC, [Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndCode]
    ON [dbo].[JAC_FinancialStatement]([CompanyId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_FinancialStatement]([CompanyId] ASC);

