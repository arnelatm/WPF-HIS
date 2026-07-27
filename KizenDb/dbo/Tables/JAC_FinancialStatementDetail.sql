CREATE TABLE [dbo].[JAC_FinancialStatementDetail] (
    [Id]                   INT             IDENTITY (1, 1) NOT NULL,
    [ParentId]             INT             NULL,
    [FinancialStatementId] INT             NOT NULL,
    [Name]                 NVARCHAR (100)  NOT NULL,
    [NameLatin]            NVARCHAR (100)  NULL,
    [Type]                 NVARCHAR (15)   NULL,
    [ValueSource]          NVARCHAR (15)   NULL,
    [UseContraAccount]     BIT             NOT NULL,
    [Font]                 NVARCHAR (250)  NULL,
    [ForeColor]            BIGINT          NOT NULL,
    [BackColor]            BIGINT          NOT NULL,
    [FixedValue]           DECIMAL (19, 4) NOT NULL,
    [Note]                 NVARCHAR (250)  NULL,
    [RowOrder]             INT             NOT NULL,
    CONSTRAINT [PK_dbo.JAC_FinancialStatementDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_FinancialStatementDetail_dbo.JAC_FinancialStatement_FinancialStatementId] FOREIGN KEY ([FinancialStatementId]) REFERENCES [dbo].[JAC_FinancialStatement] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_FinancialStatementDetail_dbo.JAC_FinancialStatementDetail_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[JAC_FinancialStatementDetail] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_FinancialStatementDetail]([Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_FinancialStatementAndName]
    ON [dbo].[JAC_FinancialStatementDetail]([FinancialStatementId] ASC, [Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FinancialStatementId]
    ON [dbo].[JAC_FinancialStatementDetail]([FinancialStatementId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ParentId]
    ON [dbo].[JAC_FinancialStatementDetail]([ParentId] ASC);

