CREATE TABLE [dbo].[Inventory] (
    [IdNo]            INT             IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]      TINYINT         NULL,
    [ProductIdNo]     INT             NULL,
    [TransactionIdNo] INT             NULL,
    [QtyOnHand]       DECIMAL (12, 4) NULL,
    [WarehouseIdNo]   SMALLINT        NULL,
    [TransactionType] CHAR (1)        NULL,
    [BatchNo]         VARCHAR (20)    NULL,
    [ExpiryDate]      DATE            NULL,
    [UnitCost]        DECIMAL (12, 4) NULL,
    [TotalCost]       DECIMAL (9, 2)  NULL,
    [UnitSalesPrice]  DECIMAL (9, 2)  NULL,
    CONSTRAINT [PK_Inventory_1] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





