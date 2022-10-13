CREATE TABLE [dbo].[StockPositionCurrentBackup] (
    [BranchID]    VARCHAR (15)    NOT NULL,
    [Item_Code]   VARCHAR (15)    NOT NULL,
    [Batch]       VARCHAR (15)    NOT NULL,
    [Expiry]      DATETIME        NOT NULL,
    [WarehouseID] VARCHAR (5)     NOT NULL,
    [PCSQty]      NUMERIC (12, 3) NULL,
    [CashPrice]   NUMERIC (12, 2) NULL,
    [CreditPrice] NUMERIC (12, 2) NULL,
    [CostPrice]   NUMERIC (12, 2) NULL,
    [PurchaseNo]  NUMERIC (10)    NULL,
    [TmpStock]    NUMERIC (12, 3) NULL
);

