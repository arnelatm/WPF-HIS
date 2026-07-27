CREATE TABLE [dbo].[JTX_SourceSale] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]          INT            NOT NULL,
    [SystemId]           INT            NOT NULL,
    [SourceType]         NVARCHAR (200) NOT NULL,
    [CustomizedQuery]    NVARCHAR (MAX) NULL,
    [InvoicingStartDate] DATETIME       NULL,
    CONSTRAINT [PK_dbo.JTX_SourceSale] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JTX_SourceSale_dbo.JTX_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JTX_Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JTX_SourceSale]([CompanyId] ASC);

