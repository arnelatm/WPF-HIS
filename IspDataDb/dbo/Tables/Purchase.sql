CREATE TABLE [dbo].[Purchase] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]        TINYINT        NULL,
    [SupplierIdNo]      INT            NOT NULL,
    [TransactionDate]   DATE           NULL,
    [ReferenceNo]       VARCHAR (15)   NULL,
    [AmountBeforeVat]   DECIMAL (9, 2) NULL,
    [Amount]            DECIMAL (9, 2) NOT NULL,
    [PurchaseReturn]    BIT            CONSTRAINT [DF_Purchase_PurchaseReturn] DEFAULT ((0)) NOT NULL,
    [DueDate]           DATE           NULL,
    [InvoiceNo]         VARCHAR (20)   NOT NULL,
    [InvoiceDate]       DATE           NULL,
    [VatNumber]         VARCHAR (15)   NULL,
    [VatAmount]         DECIMAL (9, 2) NULL,
    [ExtraDiscount]     DECIMAL (9, 2) NULL,
    [VatAmountDiscount] DECIMAL (9, 2) NULL,
    [WarehouseIdNo]     SMALLINT       NULL,
    [Posted]            BIT            NULL,
    [Cancelled]         BIT            NULL,
    [DateCreated]       DATETIME       CONSTRAINT [DF_PurchaseJournal_DateCreated] DEFAULT (getdate()) NOT NULL,
    [UserIdNo]          SMALLINT       NULL,
    [DateTimeStamp]     ROWVERSION     NULL,
    CONSTRAINT [PK_PurchaseIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);
















GO



GO


