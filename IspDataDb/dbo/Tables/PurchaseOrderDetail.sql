CREATE TABLE [dbo].[PurchaseOrderDetail] (
    [IdNo]              INT             IDENTITY (1, 1) NOT NULL,
    [Sequence]          SMALLINT        NULL,
    [PurchaseOrderIdNo] INT             NULL,
    [ProductIdNo]       INT             NULL,
    [Quantity]          SMALLINT        NULL,
    [UnitIdNo]          TINYINT         NULL,
    [UnitCost]          DECIMAL (11, 4) NULL,
    [NetAmount]         DECIMAL (9, 2)  NULL,
    CONSTRAINT [PK_PurchaseOrderDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

