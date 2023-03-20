CREATE TABLE [dbo].[PharmacyPreStockItems] (
    [Item_Code] VARCHAR (15)    NOT NULL,
    [EANCode]   VARCHAR (15)    NULL,
    [Expiry]    VARCHAR (10)    NULL,
    [SalePrice] NUMERIC (12, 4) NULL,
    [QtyBox]    NUMERIC (5)     NULL,
    [QtyStips]  NUMERIC (5)     NULL,
    [QtyPcs]    NUMERIC (5)     NULL,
    [Pack1]     NUMERIC (1)     NULL,
    [Pack2]     NUMERIC (3)     NULL,
    [Pack3]     NUMERIC (3)     NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PharmacyPreStockItems]
    ON [dbo].[PharmacyPreStockItems]([Item_Code] ASC, [Expiry] ASC, [SalePrice] ASC);

