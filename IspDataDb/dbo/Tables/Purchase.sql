CREATE TABLE [dbo].[Purchase] (
    [IdNo]            INT          IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]      TINYINT      NULL,
    [SupplierIdNo]    INT          NOT NULL,
    [TransactionDate] DATE         NULL,
    [Amount]          MONEY        NOT NULL,
    [DueDate]         DATE         NULL,
    [InvoiceNo]       VARCHAR (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [InvoiceDate]     DATE         NULL,
    [VatNumber]       VARCHAR (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [VatAmount]       MONEY        NULL,
    [WarehouseIdNo]   SMALLINT     NULL,
    [Posted]          BIT          NULL,
    [Cancelled]       BIT          NULL,
    [DateCreated]     DATETIME     CONSTRAINT [DF_PurchaseJournal_DateCreated] DEFAULT (getdate()) NOT NULL,
    [UserIdNo]        SMALLINT     NULL,
    [DateTimeStamp]   ROWVERSION   NOT NULL,
    CONSTRAINT [PK_PurchaseIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);








GO
CREATE NONCLUSTERED INDEX [IX_PurchaseSupplierIdNo]
    ON [dbo].[Purchase]([SupplierIdNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseInvoiceNo]
    ON [dbo].[Purchase]([InvoiceNo] ASC);

