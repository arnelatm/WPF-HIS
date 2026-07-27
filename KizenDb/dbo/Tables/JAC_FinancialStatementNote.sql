CREATE TABLE [dbo].[JAC_FinancialStatementNote] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId] INT            NOT NULL,
    [Code]      NVARCHAR (15)  NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [NameLatin] NVARCHAR (100) NULL,
    [Type]      NVARCHAR (10)  NULL,
    [IsCash]    BIT            NOT NULL,
    [Note]      NVARCHAR (250) NULL,
    CONSTRAINT [PK_dbo.JAC_FinancialStatementNote] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_FinancialStatementNote_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_FinancialStatementNote]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_FinancialStatementNote]([Code] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndName]
    ON [dbo].[JAC_FinancialStatementNote]([CompanyId] ASC, [Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndCode]
    ON [dbo].[JAC_FinancialStatementNote]([CompanyId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_FinancialStatementNote]([CompanyId] ASC);

