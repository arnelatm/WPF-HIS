CREATE TABLE [dbo].[newstock] (
    [BranchID]    VARCHAR (15)    NOT NULL,
    [Item_code]   VARCHAR (15)    NOT NULL,
    [Batch]       VARCHAR (15)    NOT NULL,
    [Expiry]      DATETIME        NOT NULL,
    [Warehouseid] VARCHAR (5)     NOT NULL,
    [PCSQty]      NUMERIC (38, 3) NULL,
    [CashPrice]   NUMERIC (12, 2) NULL,
    [CreditPrice] NUMERIC (12, 2) NULL,
    [CostPrice]   NUMERIC (12, 2) NULL,
    [PurchaseNo]  INT             NOT NULL,
    [tmpStock]    INT             NOT NULL
);

