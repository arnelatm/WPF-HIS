CREATE TABLE [dbo].[ArOpenInvoice] (
    [IdNo]            INT      IDENTITY (1, 1) NOT NULL,
    [JournalCode]     CHAR (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [JournalIdNo]     INT      NOT NULL,
    [JournalItemIdNo] INT      NOT NULL,
    [DiscountTaken]   MONEY    NULL,
    [PaidAmount]      MONEY    NULL,
    CONSTRAINT [PK_ArOpenInvoice] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

