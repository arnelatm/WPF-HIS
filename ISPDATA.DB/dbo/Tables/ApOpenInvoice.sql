CREATE TABLE [dbo].[ApOpenInvoice] (
    [IdNo]            INT           IDENTITY (1, 1) NOT NULL,
    [JournalCode]     VARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [JournalIdNo]     INT           NULL,
    [JournalItemIdNo] INT           NOT NULL,
    [PaidAmount]      MONEY         CONSTRAINT [DF_ApOpenInvoice_PaidAmount] DEFAULT ((0)) NOT NULL,
    [DiscountTaken]   MONEY         CONSTRAINT [DF_ApOpenInvoice_DiscountTaken] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ApOpenInvoice] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_ApOpenInvoiceJournalCode]
    ON [dbo].[ApOpenInvoice]([JournalCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ApOpenInvoiceJournalItemIdNo]
    ON [dbo].[ApOpenInvoice]([JournalItemIdNo] ASC);

