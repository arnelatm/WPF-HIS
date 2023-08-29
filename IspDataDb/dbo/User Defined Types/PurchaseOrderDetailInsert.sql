CREATE TYPE [dbo].[PurchaseOrderDetailInsert] AS TABLE (
    [BonusQuantity]     SMALLINT        NOT NULL,
    [DiscountAmount]    DECIMAL (8, 2)  NOT NULL,
    [NetAmount]         DECIMAL (10, 2) NOT NULL,
    [Price]             DECIMAL (8, 2)  NOT NULL,
    [ProductIdNo]       INT             NOT NULL,
    [PurchaseOrderIdNo] INT             NOT NULL,
    [Quantity]          SMALLINT        NOT NULL,
    [Sequence]          SMALLINT        NOT NULL,
    [UnitIdNo]          TINYINT         NOT NULL,
    [VatAmount]         DECIMAL (8, 2)  NULL,
    [VatPercent]        DECIMAL (5, 2)  NULL);



