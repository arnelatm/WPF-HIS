CREATE TABLE [dbo].[JAC_Category] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId] INT            NOT NULL,
    [Code]      NVARCHAR (50)  NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [ParentId]  INT            NULL,
    [NameLatin] NVARCHAR (100) NULL,
    CONSTRAINT [PK_dbo.JAC_Category] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Category_dbo.JAC_Category_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[JAC_Category] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Category_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ParentId]
    ON [dbo].[JAC_Category]([ParentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_Category]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_Category]([Code] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndName]
    ON [dbo].[JAC_Category]([CompanyId] ASC, [Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndCode]
    ON [dbo].[JAC_Category]([CompanyId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_Category]([CompanyId] ASC);

