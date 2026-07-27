CREATE TABLE [dbo].[JAC_Location] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId] INT            NOT NULL,
    [Code]      NVARCHAR (50)  NOT NULL,
    [Name]      NVARCHAR (255) NOT NULL,
    [BranchId]  INT            NOT NULL,
    [ParentId]  INT            NULL,
    [NameLatin] NVARCHAR (255) NULL,
    CONSTRAINT [PK_dbo.JAC_Location] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Location_dbo.JAC_Branch_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[JAC_Branch] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_Location_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Location_dbo.JAC_Location_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[JAC_Location] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ParentId]
    ON [dbo].[JAC_Location]([ParentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BranchId]
    ON [dbo].[JAC_Location]([BranchId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_Location]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_Location]([Code] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndName]
    ON [dbo].[JAC_Location]([CompanyId] ASC, [Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndCode]
    ON [dbo].[JAC_Location]([CompanyId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_Location]([CompanyId] ASC);

