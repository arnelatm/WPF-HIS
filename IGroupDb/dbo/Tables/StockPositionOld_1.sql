CREATE TABLE [dbo].[StockPositionOld] (
    [Primary_Key]  INT             IDENTITY (1, 1) NOT NULL,
    [BranchID]     VARCHAR (15)    NOT NULL,
    [SlNo]         NUMERIC (15)    NOT NULL,
    [StockDate]    VARCHAR (10)    NOT NULL,
    [warehouseid]  VARCHAR (5)     NOT NULL,
    [Item_Code]    VARCHAR (15)    NOT NULL,
    [Batch]        VARCHAR (15)    NOT NULL,
    [Expiry]       VARCHAR (10)    NULL,
    [CostPrice]    NUMERIC (12, 2) DEFAULT (0) NULL,
    [SellingPrice] NUMERIC (12, 2) DEFAULT (0) NULL,
    [QtyBox]       NUMERIC (10)    DEFAULT (0) NULL,
    [QtyStrips]    NUMERIC (10)    DEFAULT (0) NULL,
    [QtyPcs]       NUMERIC (10)    DEFAULT (0) NULL,
    [QtyBadBox]    NUMERIC (12, 3) DEFAULT (0) NULL,
    [QtyBadStrips] NUMERIC (12, 3) DEFAULT (0) NULL,
    [QtyBadPcs]    NUMERIC (12, 3) DEFAULT (0) NULL,
    [TQtyGood]     NUMERIC (12, 3) DEFAULT (0) NULL,
    [TQtyBad]      NUMERIC (12, 3) DEFAULT (0) NULL,
    [Stock_Type]   CHAR (1)        DEFAULT ('O') NULL,
    [PageNo]       NUMERIC (5)     DEFAULT (0) NULL,
    [Loc_Row]      VARCHAR (10)    NULL,
    [Loc_Col]      VARCHAR (10)    NULL,
    [Remarks]      VARCHAR (300)   NULL,
    [UserID]       VARCHAR (30)    NULL,
    [Create_date]  DATETIME        DEFAULT (getdate()) NULL,
    [machineID]    VARCHAR (30)    NULL,
    PRIMARY KEY CLUSTERED ([Primary_Key] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_StockPositionOld]
    ON [dbo].[StockPositionOld]([BranchID] ASC, [warehouseid] ASC, [Item_Code] ASC, [Batch] ASC, [Expiry] ASC);

