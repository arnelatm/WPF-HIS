CREATE TABLE [dbo].[PharmacyPreStockPurchaseDetails] (
    [Group_Key]   INT             NOT NULL,
    [BranchID]    VARCHAR (15)    DEFAULT ('01') NULL,
    [WarehouseID] VARCHAR (15)    DEFAULT ('01') NULL,
    [RowNbr]      NUMERIC (3)     NOT NULL,
    [Item_Code]   VARCHAR (15)    NOT NULL,
    [Batch]       VARCHAR (15)    NULL,
    [Expiry]      VARCHAR (10)    NULL,
    [Qty]         NUMERIC (12, 3) NULL,
    [Unit]        VARCHAR (10)    NULL,
    [PcsQty]      NUMERIC (4)     NULL,
    [Pack1]       NUMERIC (8)     NULL,
    [Pack2]       NUMERIC (8)     NULL,
    [Pack3]       NUMERIC (8)     NULL,
    [EANCode]     VARCHAR (15)    NULL,
    [SalePrice]   NUMERIC (12, 4) NULL,
    [DiscountPer] NUMERIC (12, 4) NULL,
    [DiscountAmt] NUMERIC (12, 4) NULL,
    [SaleStatus]  VARCHAR (2)     NULL,
    [Create_Date] DATETIME        DEFAULT (getdate()) NULL,
    [UserID]      VARCHAR (15)    NULL,
    [MachineID]   VARCHAR (20)    DEFAULT (host_name()) NULL
);


GO
CREATE CLUSTERED INDEX [IDX_PharmacyPreStockPurchaseDetails]
    ON [dbo].[PharmacyPreStockPurchaseDetails]([Group_Key] ASC, [Item_Code] ASC, [Expiry] ASC, [SalePrice] ASC);

