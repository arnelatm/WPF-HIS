CREATE TABLE [dbo].[JZ_InvoiceAllowanceCharge] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [InvoiceId]       INT             NOT NULL,
    [ChargeIndicator] BIT             NOT NULL,
    [Percentage]      DECIMAL (18, 2) NULL,
    [Amount]          DECIMAL (18, 2) NOT NULL,
    [BaseAmount]      DECIMAL (18, 2) NULL,
    [VATCategoryCode] NVARCHAR (10)   NOT NULL,
    [VATRate]         DECIMAL (18, 2) NOT NULL,
    [Reason]          NVARCHAR (1000) NULL,
    [ReasonCode]      NVARCHAR (10)   NULL,
    CONSTRAINT [PK_dbo.JZ_InvoiceAllowanceCharge] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JZ_InvoiceAllowanceCharge_dbo.JZ_Invoice_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[JZ_Invoice] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_InvoiceId]
    ON [dbo].[JZ_InvoiceAllowanceCharge]([InvoiceId] ASC);

