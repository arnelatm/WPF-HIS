CREATE TABLE [dbo].[JAC_Pattern] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId] INT            NOT NULL,
    [Name]      NVARCHAR (25)  NOT NULL,
    [Kind]      NVARCHAR (25)  NOT NULL,
    [Order]     INT            NOT NULL,
    [Data]      NVARCHAR (MAX) NULL,
    [NameLatin] NVARCHAR (25)  NULL,
    CONSTRAINT [PK_dbo.JAC_Pattern] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Pattern_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_Pattern]([Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndName]
    ON [dbo].[JAC_Pattern]([CompanyId] ASC, [Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_Pattern]([CompanyId] ASC);

