CREATE TABLE [dbo].[JZ_InvoiceLine] (
    [Id]                          INT             IDENTITY (1, 1) NOT NULL,
    [InvoiceId]                   INT             NOT NULL,
    [Identifier]                  INT             NOT NULL,
    [InvoicedQuantity]            DECIMAL (18, 2) NOT NULL,
    [NetAmount]                   DECIMAL (18, 2) NOT NULL,
    [VATLineAmount]               DECIMAL (18, 2) NULL,
    [LineAmountWithVAT]           DECIMAL (18, 2) NOT NULL,
    [ItemName]                    NVARCHAR (1000) NOT NULL,
    [ItemNetPrice]                DECIMAL (18, 2) NOT NULL,
    [InvoicedItemVATCategoryCode] NVARCHAR (10)   NOT NULL,
    [InvoicedItemVATRate]         DECIMAL (18, 2) NOT NULL,
    [HasAllowance]                BIT             NOT NULL,
    [AllowancePercentage]         DECIMAL (18, 2) NULL,
    [AllowanceAmount]             DECIMAL (18, 2) NULL,
    [AllowanceBaseAmount]         DECIMAL (18, 2) NULL,
    [HasCharge]                   BIT             NOT NULL,
    [ChargePercentage]            DECIMAL (18, 2) NULL,
    [ChargeAmount]                DECIMAL (18, 2) NULL,
    [ChargeBaseAmount]            DECIMAL (18, 2) NULL,
    [ChargeReason]                NVARCHAR (1000) NULL,
    [ChargeReasonCode]            NVARCHAR (10)   NULL,
    CONSTRAINT [PK_dbo.JZ_InvoiceLine] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JZ_InvoiceLine_dbo.JZ_Invoice_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[JZ_Invoice] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_InvoiceId]
    ON [dbo].[JZ_InvoiceLine]([InvoiceId] ASC);

