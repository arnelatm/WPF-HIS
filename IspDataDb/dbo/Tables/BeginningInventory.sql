CREATE TABLE [dbo].[BeginningInventory] (
    [IdNo]            INT             IDENTITY (1, 1) NOT NULL,
    [TransactionDate] DATE            NULL,
    [BranchIdNo]      SMALLINT        NOT NULL,
    [WarehouseIdNo]   SMALLINT        NULL,
    [ProductIdNo]     INT             NULL,
    [Item_Code]       VARCHAR (15)    NOT NULL,
    [BatchNo]         VARCHAR (20)    NOT NULL,
    [ExpiryDate]      DATETIME        NOT NULL,
    [Quantity]        NUMERIC (10, 4) NULL,
    [UnitCost]        NUMERIC (12, 2) NULL,
    CONSTRAINT [PK_BeginningInventory] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

