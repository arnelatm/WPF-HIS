CREATE TABLE [dbo].[StockAdjustment] (
    [BranchID]     VARCHAR (15)    NOT NULL,
    [TransNo]      NUMERIC (15)    NOT NULL,
    [TransDate]    VARCHAR (10)    NOT NULL,
    [SlNo]         NUMERIC (10)    DEFAULT (0) NOT NULL,
    [WarehouseID]  VARCHAR (5)     NOT NULL,
    [Item_Code]    VARCHAR (15)    NOT NULL,
    [Batch]        VARCHAR (15)    NOT NULL,
    [Expiry]       VARCHAR (10)    NULL,
    [CostPrice]    NUMERIC (12, 2) DEFAULT (0) NOT NULL,
    [SellingPrice] NUMERIC (12, 2) DEFAULT (0) NOT NULL,
    [SPriceNew]    NUMERIC (12, 2) DEFAULT (0) NOT NULL,
    [PQtyBox]      NUMERIC (10)    DEFAULT (0) NOT NULL,
    [PQtyStrip]    NUMERIC (10)    DEFAULT (0) NOT NULL,
    [PQtyPcs]      NUMERIC (10)    DEFAULT (0) NOT NULL,
    [pQty]         NUMERIC (12, 3) DEFAULT (0) NOT NULL,
    [NQtyBox]      NUMERIC (10)    DEFAULT (0) NOT NULL,
    [NQtyStrip]    NUMERIC (10)    DEFAULT (0) NOT NULL,
    [NQtyPcs]      NUMERIC (10)    DEFAULT (0) NOT NULL,
    [NQty]         NUMERIC (12, 3) DEFAULT (0) NOT NULL,
    [rec_type]     CHAR (1)        DEFAULT ('O') NOT NULL,
    [stk_update]   CHAR (1)        DEFAULT ('1') NOT NULL,
    [remarks]      VARCHAR (300)   NULL,
    [UserID]       VARCHAR (15)    DEFAULT ('Admin') NULL,
    [Create_Date]  DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]    VARCHAR (20)    DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_StockAdjustment]
    ON [dbo].[StockAdjustment]([BranchID] ASC, [TransNo] ASC, [SlNo] ASC);

