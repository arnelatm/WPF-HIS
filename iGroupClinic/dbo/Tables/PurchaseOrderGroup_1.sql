CREATE TABLE [dbo].[PurchaseOrderGroup] (
    [Trans_Key]        INT             NOT NULL,
    [BranchID]         VARCHAR (15)    NOT NULL,
    [TransType]        VARCHAR (5)     NOT NULL,
    [TransSeries]      CHAR (10)       NOT NULL,
    [TransNo]          NUMERIC (10)    NOT NULL,
    [TransDate]        VARCHAR (10)    NOT NULL,
    [HijriDate]        VARCHAR (10)    NULL,
    [PurchaseFrom]     CHAR (10)       NULL,
    [SupplierID]       VARCHAR (10)    NOT NULL,
    [CurrencyCode]     VARCHAR (5)     NULL,
    [ConversionRate]   NUMERIC (10, 5) DEFAULT (0) NULL,
    [SalesmanID]       VARCHAR (15)    NULL,
    [Remarks]          VARCHAR (300)   NULL,
    [PostInPurchase]   CHAR (1)        DEFAULT ('N') NULL,
    [PurchaseGrossAmt] NUMERIC (12, 2) NULL,
    [PurchaseCostAmt]  NUMERIC (12, 2) NULL,
    [PurchaseSaleAmt]  NUMERIC (12, 2) NULL,
    [EnteredBy]        VARCHAR (15)    NULL,
    [CheckedBy]        VARCHAR (15)    NULL,
    [ApprovedBy]       VARCHAR (15)    NULL,
    [Reference]        VARCHAR (100)   NULL,
    [ValidityNote]     VARCHAR (300)   NULL,
    [DeliveryNote]     VARCHAR (150)   NULL,
    [Prices]           VARCHAR (100)   NULL,
    [UserID]           VARCHAR (15)    DEFAULT ('Admin') NULL,
    [Create_Date]      DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (20)    DEFAULT (host_name()) NULL,
    [VATAmt]           NUMERIC (10, 2) DEFAULT ((0)) NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_PurchaseOrderGroup]
    ON [dbo].[PurchaseOrderGroup]([BranchID] ASC, [TransType] ASC, [TransSeries] ASC, [TransNo] ASC);

