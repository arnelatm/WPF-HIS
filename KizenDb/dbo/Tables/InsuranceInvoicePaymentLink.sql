CREATE TABLE [dbo].[InsuranceInvoicePaymentLink] (
    [ID]                        INT             IDENTITY (1, 1) NOT NULL,
    [InsuranceInvoiceID]        INT             NOT NULL,
    [InsuranceInvoicePaymentID] INT             NOT NULL,
    [InvoiceShare]              DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_InsuranceInvoicePaymentLink] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_InsuranceInvoicePaymentLink_InsuranceInvoicePaymentID]
    ON [dbo].[InsuranceInvoicePaymentLink]([InsuranceInvoicePaymentID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_InsuranceInvoicePaymentLink_InsuranceInvoiceID]
    ON [dbo].[InsuranceInvoicePaymentLink]([InsuranceInvoiceID] ASC);

