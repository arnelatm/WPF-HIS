CREATE TABLE [dbo].[JAC_Template] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]              INT            NOT NULL,
    [Name]                   NVARCHAR (100) NOT NULL,
    [Kind]                   NVARCHAR (25)  NOT NULL,
    [MainAccountId]          INT            NULL,
    [AutoReadAccountBalance] BIT            DEFAULT ((0)) NOT NULL,
    [ReverseBalance]         BIT            DEFAULT ((0)) NOT NULL,
    [NameLatin]              NVARCHAR (100) NULL,
    CONSTRAINT [PK_dbo.JAC_Template] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Template_dbo.JAC_Account_MainAccountId] FOREIGN KEY ([MainAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Template_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_MainAccountId]
    ON [dbo].[JAC_Template]([MainAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_Template]([Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndName]
    ON [dbo].[JAC_Template]([CompanyId] ASC, [Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_Template]([CompanyId] ASC);

