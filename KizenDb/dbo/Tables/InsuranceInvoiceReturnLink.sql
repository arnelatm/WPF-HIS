CREATE TABLE [dbo].[InsuranceInvoiceReturnLink] (
    [ID]                       INT             IDENTITY (1, 1) NOT NULL,
    [InsuranceInvoiceID]       INT             NOT NULL,
    [InsuranceInvoiceReturnID] INT             NOT NULL,
    [InvoiceShare]             DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_InsuranceInvoiceReturnLink] PRIMARY KEY CLUSTERED ([ID] ASC)
);

