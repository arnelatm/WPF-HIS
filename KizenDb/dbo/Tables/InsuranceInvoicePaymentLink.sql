CREATE TABLE [dbo].[InsuranceInvoicePaymentLink] (
    [ID]                        INT             IDENTITY (1, 1) NOT NULL,
    [InsuranceInvoiceID]        INT             NOT NULL,
    [InsuranceInvoicePaymentID] INT             NOT NULL,
    [InvoiceShare]              DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_InsuranceInvoicePaymentLink] PRIMARY KEY CLUSTERED ([ID] ASC)
);

