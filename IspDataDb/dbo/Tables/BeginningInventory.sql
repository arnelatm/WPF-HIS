CREATE TABLE [dbo].[BeginningInventory] (
    [IdNo]            INT             IDENTITY (1, 1) NOT NULL,
    [TransactionDate] DATE            NULL,
    [BranchIdNo]      SMALLINT        NOT NULL,
    [WarehouseIdNo]   SMALLINT        NULL,
    [ProductIdNo]     INT             NULL,
    [UnitIdNo]        INT             NULL,
    [Item_Code]       VARCHAR (15)    NOT NULL,
    [BatchNo]         VARCHAR (20)    NOT NULL,
    [ExpiryDate]      DATE            NOT NULL,
    [Quantity]        DECIMAL (12, 4) NULL,
    [UnitCost]        DECIMAL (12, 4) NULL,
    [TotalCost]       DECIMAL (12, 2) NULL,
    CONSTRAINT [PK_BeginningInventory] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);







