CREATE TABLE [dbo].[JAC_CostCenter] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]              INT            NOT NULL,
    [Code]                   NVARCHAR (50)  NOT NULL,
    [Name]                   NVARCHAR (250) NOT NULL,
    [ParentId]               INT            NULL,
    [Kind]                   INT            DEFAULT ((0)) NOT NULL,
    [PercentagesAreNotFixed] BIT            DEFAULT ((0)) NOT NULL,
    [NameLatin]              NVARCHAR (250) NULL,
    CONSTRAINT [PK_dbo.JAC_CostCenter] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_CostCenter_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_CostCenter_dbo.JAC_CostCenter_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[JAC_CostCenter] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ParentId]
    ON [dbo].[JAC_CostCenter]([ParentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_CostCenter]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_CostCenter]([Code] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndName]
    ON [dbo].[JAC_CostCenter]([CompanyId] ASC, [Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndCode]
    ON [dbo].[JAC_CostCenter]([CompanyId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_CostCenter]([CompanyId] ASC);

