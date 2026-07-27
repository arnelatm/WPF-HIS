CREATE TABLE [dbo].[JAC_Branch] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [CompanyId]        INT             NOT NULL,
    [Code]             NVARCHAR (50)   NOT NULL,
    [Name]             NVARCHAR (50)   NOT NULL,
    [Telephone]        NVARCHAR (50)   NULL,
    [Fax]              NVARCHAR (50)   NULL,
    [Address]          NVARCHAR (100)  NULL,
    [NameLatin]        NVARCHAR (50)   NULL,
    [HeaderImageBytes] VARBINARY (MAX) NULL,
    [FooterImageBytes] VARBINARY (MAX) NULL,
    CONSTRAINT [PK_dbo.JAC_Branch] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Branch_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_Branch]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_Branch]([Code] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndName]
    ON [dbo].[JAC_Branch]([CompanyId] ASC, [Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndCode]
    ON [dbo].[JAC_Branch]([CompanyId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_Branch]([CompanyId] ASC);

