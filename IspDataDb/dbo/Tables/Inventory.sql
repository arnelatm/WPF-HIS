CREATE TABLE [dbo].[Inventory] (
    [IdNo]         INT            IDENTITY (1, 1) NOT NULL,
    [ProductIdNo]  INT            NULL,
    [Quantity]     DECIMAL (9, 3) NULL,
    [TotalCost]    DECIMAL (9, 2) NULL,
    [LastUnitCost] DECIMAL (9, 3) NULL,
    CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [IX_InventoryProductIdNo] UNIQUE NONCLUSTERED ([ProductIdNo] ASC)
);

