CREATE TABLE [dbo].[AnalisysItemDisplay] (
    [BranchID]         VARCHAR (15)    NOT NULL,
    [SupplierID]       VARCHAR (15)    NULL,
    [SupplierName]     VARCHAR (50)    NULL,
    [item_code]        VARCHAR (15)    NOT NULL,
    [Description]      VARCHAR (50)    NULL,
    [Selected]         NUMERIC (1)     DEFAULT (0) NULL,
    [SaleQty]          NUMERIC (10, 3) DEFAULT (0) NULL,
    [StockQty]         NUMERIC (10, 3) DEFAULT (0) NULL,
    [PriceSale]        NUMERIC (7, 2)  DEFAULT (0) NULL,
    [BestCost]         NUMERIC (7, 2)  DEFAULT (0) NULL,
    [BestPurchase]     NUMERIC (10, 3) DEFAULT (0) NULL,
    [BestBonus]        NUMERIC (10, 3) DEFAULT (0) NULL,
    [BestBonusPer]     NUMERIC (5, 2)  DEFAULT (0) NULL,
    [LastPurchaseDate] VARCHAR (10)    NULL,
    [CreateDate]       DATETIME        DEFAULT (getdate()) NULL,
    [UserID]           VARCHAR (10)    NULL,
    [machineId]        VARCHAR (20)    DEFAULT (host_name()) NULL,
    [SDate]            VARCHAR (10)    NULL
);

