CREATE TABLE [dbo].[ClinicStockPhysicalOld] (
    [BranchID]    VARCHAR (15)    NULL,
    [Item_Code]   VARCHAR (15)    NULL,
    [Batch]       VARCHAR (15)    NULL,
    [Expiry]      DATETIME        NULL,
    [WarehouseID] VARCHAR (5)     NULL,
    [PCSQty]      NUMERIC (12, 3) NULL,
    [CashPrice]   NUMERIC (12, 2) NULL,
    [CreditPrice] NUMERIC (12, 2) NULL,
    [CostPrice]   NUMERIC (12, 2) NULL,
    [PurchaseNo]  NUMERIC (10)    NULL,
    [TmpStock]    NUMERIC (12, 3) NULL
);

