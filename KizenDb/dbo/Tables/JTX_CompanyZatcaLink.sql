CREATE TABLE [dbo].[JTX_CompanyZatcaLink] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [CompanyId]      INT NOT NULL,
    [ZatcaCompanyId] INT NOT NULL,
    CONSTRAINT [PK_dbo.JTX_CompanyZatcaLink] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JTX_CompanyZatcaLink_dbo.JTX_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JTX_Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JTX_CompanyZatcaLink]([CompanyId] ASC);

