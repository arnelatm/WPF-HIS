CREATE TABLE [dbo].[StockPositionCurrent] (
    [BranchID]    VARCHAR (15)    NOT NULL,
    [Item_Code]   VARCHAR (15)    NOT NULL,
    [Batch]       VARCHAR (15)    NOT NULL,
    [Expiry]      DATETIME        NOT NULL,
    [WarehouseID] VARCHAR (5)     NOT NULL,
    [PCSQty]      NUMERIC (12, 3) DEFAULT (0) NULL,
    [CashPrice]   NUMERIC (12, 2) DEFAULT (0) NULL,
    [CreditPrice] NUMERIC (12, 2) DEFAULT (0) NULL,
    [CostPrice]   NUMERIC (12, 2) DEFAULT (0) NULL,
    [PurchaseNo]  NUMERIC (10)    NULL,
    [TmpStock]    NUMERIC (12, 3) DEFAULT (0) NULL
);


GO
CREATE NONCLUSTERED INDEX [IDX_StockPositionCurrent]
    ON [dbo].[StockPositionCurrent]([BranchID] ASC, [WarehouseID] ASC, [Item_Code] ASC, [Batch] ASC, [Expiry] ASC);

