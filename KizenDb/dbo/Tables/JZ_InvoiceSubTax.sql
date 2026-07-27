CREATE TABLE [dbo].[JZ_InvoiceSubTax] (
    [Id]                       INT             IDENTITY (1, 1) NOT NULL,
    [InvoiceId]                INT             NOT NULL,
    [VATCategoryTaxableAmount] DECIMAL (18, 2) NOT NULL,
    [VATCategoryTaxAmount]     DECIMAL (18, 2) NOT NULL,
    [VATCategoryCode]          NVARCHAR (10)   NOT NULL,
    [VATCategoryRate]          DECIMAL (18, 2) NULL,
    [VATExemptionReasonCode]   NVARCHAR (50)   NULL,
    [VATExemptionReason]       NVARCHAR (1000) NULL,
    CONSTRAINT [PK_dbo.JZ_InvoiceSubTax] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JZ_InvoiceSubTax_dbo.JZ_Invoice_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[JZ_Invoice] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_InvoiceId]
    ON [dbo].[JZ_InvoiceSubTax]([InvoiceId] ASC);

