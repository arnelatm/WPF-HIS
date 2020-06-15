CREATE TABLE [dbo].[ErOpenInvoice] (
    [IdNo]            INT      IDENTITY (1, 1) NOT NULL,
    [JournalCode]     CHAR (2) NOT NULL,
    [JournalIdNo]     INT      NOT NULL,
    [JournalItemIdNo] INT      NOT NULL,
    [PaidAmount]      MONEY    CONSTRAINT [DF_ErOpenInvoice_PaidAmount] DEFAULT ((0)) NOT NULL,
    [DiscountTaken]   MONEY    NOT NULL,
    CONSTRAINT [PK_ErOpenInvoice] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

