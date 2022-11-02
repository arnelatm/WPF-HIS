CREATE TABLE [dbo].[StockPositionCurrent] (
    [IdNo]        INT             IDENTITY (1, 1) NOT NULL,
    [BranchID]    VARCHAR (15)    NOT NULL,
    [Item_Code]   VARCHAR (15)    NOT NULL,
    [Batch]       VARCHAR (20)    NOT NULL,
    [Expiry]      DATETIME        NOT NULL,
    [WarehouseID] VARCHAR (5)     NOT NULL,
    [PCSQty]      NUMERIC (12, 3) CONSTRAINT [DF__StockPosi__PCSQt__3C1FE2D6] DEFAULT ((0)) NULL,
    [CashPrice]   NUMERIC (12, 2) CONSTRAINT [DF__StockPosi__CashP__3D14070F] DEFAULT ((0)) NULL,
    [CreditPrice] NUMERIC (12, 2) CONSTRAINT [DF__StockPosi__Credi__3E082B48] DEFAULT ((0)) NULL,
    [CostPrice]   NUMERIC (12, 2) CONSTRAINT [DF__StockPosi__CostP__3EFC4F81] DEFAULT ((0)) NULL,
    [PurchaseNo]  NUMERIC (10)    NULL,
    [TmpStock]    NUMERIC (12, 3) CONSTRAINT [DF__StockPosi__TmpSt__3FF073BA] DEFAULT ((0)) NULL,
    [SerialNo]    VARCHAR (20)    NULL,
    CONSTRAINT [PK_StockPositionCurrent] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_StockPositionCurrent]
    ON [dbo].[StockPositionCurrent]([Item_Code] ASC, [Batch] ASC, [Expiry] ASC, [WarehouseID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_StockPositionCurrent]
    ON [dbo].[StockPositionCurrent]([BranchID] ASC, [WarehouseID] ASC, [Item_Code] ASC, [Batch] ASC, [Expiry] ASC);

