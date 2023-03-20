CREATE TABLE [dbo].[PurchaseGroup] (
    [Trans_Key]          INT             NOT NULL,
    [BranchID]           VARCHAR (15)    NOT NULL,
    [TransType]          VARCHAR (5)     NOT NULL,
    [TransSeries]        CHAR (10)       NOT NULL,
    [TransNo]            NUMERIC (10)    NOT NULL,
    [TransDate]          VARCHAR (10)    NOT NULL,
    [HijriDate]          VARCHAR (10)    NULL,
    [PONo]               NUMERIC (10)    NULL,
    [PODate]             VARCHAR (10)    NULL,
    [WarehouseID]        VARCHAR (15)    NOT NULL,
    [PurchaseType]       CHAR (10)       NULL,
    [PurchaseFrom]       CHAR (10)       NULL,
    [SupplierID]         VARCHAR (10)    NOT NULL,
    [InvoiceNo]          VARCHAR (20)    NULL,
    [InvoiceDate]        VARCHAR (10)    NULL,
    [Reference]          VARCHAR (20)    NULL,
    [InvoiceAmt]         NUMERIC (12, 2) DEFAULT (0) NULL,
    [CurrencyCode]       VARCHAR (5)     NOT NULL,
    [ConversionRate]     NUMERIC (10, 5) DEFAULT (0) NULL,
    [GrossAmt]           NUMERIC (12, 2) DEFAULT (0) NULL,
    [TotalExpenses]      NUMERIC (12, 2) DEFAULT (0) NULL,
    [SpecialDiscountPer] NUMERIC (7, 3)  DEFAULT (0) NULL,
    [SpecialDiscountAmt] NUMERIC (12, 2) DEFAULT (0) NULL,
    [SalesmanID]         VARCHAR (15)    NULL,
    [Remarks]            VARCHAR (300)   NULL,
    [PostInAccounts]     CHAR (1)        DEFAULT ('N') NULL,
    [PostInStock]        CHAR (1)        DEFAULT ('N') NULL,
    [AccountsUpdate]     VARCHAR (10)    DEFAULT ('N') NULL,
    [PurchaseGrossAmt]   NUMERIC (12, 2) NULL,
    [PurchaseCostAmt]    NUMERIC (12, 2) NULL,
    [PurchaseSaleAmt]    NUMERIC (12, 2) NULL,
    [PurchaseProfitPer]  NUMERIC (12, 2) NULL,
    [PurchaseProfitAmt]  NUMERIC (12, 2) NULL,
    [EnteredBy]          VARCHAR (15)    NULL,
    [CheckedBy]          VARCHAR (15)    NULL,
    [ApprovedBy]         VARCHAR (15)    NULL,
    [UserID]             VARCHAR (15)    DEFAULT ('Admin') NULL,
    [Create_Date]        DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]          VARCHAR (20)    DEFAULT (host_name()) NULL,
    [VATAmt]             NUMERIC (10, 2) DEFAULT ((0)) NULL,
    [VATIncludingInCost] INT             DEFAULT ((0)) NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_PurchaseGroup]
    ON [dbo].[PurchaseGroup]([BranchID] ASC, [TransType] ASC, [TransSeries] ASC, [TransNo] ASC, [Trans_Key] ASC);

