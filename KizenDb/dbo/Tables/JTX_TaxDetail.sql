CREATE TABLE [dbo].[JTX_TaxDetail] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [TaxId]           INT             NOT NULL,
    [Kind]            INT             NOT NULL,
    [Note]            NVARCHAR (MAX)  NULL,
    [BeforeVat]       DECIMAL (18, 2) NOT NULL,
    [ReturnBeforeVat] DECIMAL (18, 2) NOT NULL,
    [VatValue]        DECIMAL (18, 2) NOT NULL,
    [ReturnVatValue]  DECIMAL (18, 2) NOT NULL,
    [TotalVatValue]   DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.JTX_TaxDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JTX_TaxDetail_dbo.JTX_Tax_TaxId] FOREIGN KEY ([TaxId]) REFERENCES [dbo].[JTX_Tax] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TaxId]
    ON [dbo].[JTX_TaxDetail]([TaxId] ASC);

