CREATE TABLE [dbo].[PurchaseOrderDetail] (
    [IdNo]              INT             IDENTITY (1, 1) NOT NULL,
    [Sequence]          SMALLINT        NULL,
    [PurchaseOrderIdNo] INT             NULL,
    [ProductIdNo]       INT             NULL,
    [Quantity]          DECIMAL(12, 4)        NULL,
    [BonusQuantity]     DECIMAL(12, 4)        NULL,
    [UnitIdNo]          TINYINT         NULL,
    [Price]             DECIMAL (9, 2)  NULL,
    [DiscountAmount]    DECIMAL (9, 2) NULL,
    [UnitSalesPrice]    DECIMAL (9, 2)  NULL,
    [NetAmount]         DECIMAL (9, 2) NULL,
    [VatAmount]         DECIMAL (9, 2) NULL,
    [VatPercent]        DECIMAL (5, 2)  NULL,
    CONSTRAINT [PK_PurchaseOrderDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



