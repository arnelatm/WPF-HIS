CREATE TABLE [dbo].[PurchaseJournal] (
    [IdNo]               INT            IDENTITY (1, 1) NOT NULL,
    [SupplierIdNo]       INT            NOT NULL,
    [TransactionDate]    DATE           NULL,
    [ReferenceNo]        VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Amount]             MONEY          NOT NULL,
    [AccountIdNo]        SMALLINT       NOT NULL,
    [DueDate]            DATE           NULL,
    [SettlementDueDate]  DATE           NULL,
    [SettlementDiscount] DECIMAL (5, 2) NULL,
    [InvoiceNo]          VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [InvoiceDate]        DATE           NULL,
    [VatNumber]          VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [VatAmount]          MONEY          NULL,
    [Notes]              NVARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Approved]           BIT            NULL,
    [Posted]             BIT            NULL,
    [Cancelled]          BIT            NULL,
    [DateCreated]        DATETIME       CONSTRAINT [DF_PurchaseJournal_DateCreated] DEFAULT (getdate()) NOT NULL,
    [DateTimeStamp]      ROWVERSION     NOT NULL,
    CONSTRAINT [PK_PurchaseIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseInvoiceNo]
    ON [dbo].[PurchaseJournal]([InvoiceNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseReferenceNo]
    ON [dbo].[PurchaseJournal]([ReferenceNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseSupplierIdNo]
    ON [dbo].[PurchaseJournal]([SupplierIdNo] ASC);

