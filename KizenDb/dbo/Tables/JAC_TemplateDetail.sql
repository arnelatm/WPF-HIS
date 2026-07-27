CREATE TABLE [dbo].[JAC_TemplateDetail] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [TemplateId]      INT             NOT NULL,
    [Debit]           DECIMAL (19, 4) NOT NULL,
    [Credit]          DECIMAL (19, 4) NOT NULL,
    [AccountId]       INT             NOT NULL,
    [ContraAccountId] INT             NULL,
    [CostCenterId]    INT             NULL,
    [Note]            NVARCHAR (250)  NULL,
    [CategoryId]      INT             NULL,
    CONSTRAINT [PK_dbo.JAC_TemplateDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_TemplateDetail_dbo.JAC_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[JAC_Account] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_TemplateDetail_dbo.JAC_Account_ContraAccountId] FOREIGN KEY ([ContraAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_TemplateDetail_dbo.JAC_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[JAC_Category] ([Id]),
    CONSTRAINT [FK_dbo.JAC_TemplateDetail_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_TemplateDetail_dbo.JAC_Template_TemplateId] FOREIGN KEY ([TemplateId]) REFERENCES [dbo].[JAC_Template] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CategoryId]
    ON [dbo].[JAC_TemplateDetail]([CategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_TemplateDetail]([CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ContraAccountId]
    ON [dbo].[JAC_TemplateDetail]([ContraAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[JAC_TemplateDetail]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TemplateId]
    ON [dbo].[JAC_TemplateDetail]([TemplateId] ASC);

