CREATE TABLE [dbo].[StockTransferDetails] (
    [BranchID]       VARCHAR (15)    NULL,
    [Group_Key]      NUMERIC (15)    NOT NULL,
    [SlNo]           NUMERIC (3)     NOT NULL,
    [Item_Code]      VARCHAR (20)    NULL,
    [Batch]          VARCHAR (15)    NULL,
    [Expiry]         VARCHAR (10)    NULL,
    [Qty]            NUMERIC (12, 3) NULL,
    [Bonus]          NUMERIC (12, 3) NULL,
    [PCSQty]         NUMERIC (12, 3) NULL,
    [Unit]           VARCHAR (10)    NULL,
    [Pack1]          NUMERIC (8)     NULL,
    [Pack2]          NUMERIC (8)     NULL,
    [Pack3]          NUMERIC (8)     NULL,
    [Price]          NUMERIC (12, 4) NULL,
    [CostPrice]      NUMERIC (12, 2) NULL,
    [SallingPrice]   NUMERIC (12, 2) NULL,
    [CostInUnit]     NUMERIC (12, 2) NULL,
    [Amount]         NUMERIC (12, 2) NULL,
    [PostInAccounts] CHAR (1)        DEFAULT ('N') NULL,
    [PostInStock]    CHAR (1)        DEFAULT ('N') NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_StockTransferDetails]
    ON [dbo].[StockTransferDetails]([BranchID] ASC, [Group_Key] ASC, [SlNo] ASC);

