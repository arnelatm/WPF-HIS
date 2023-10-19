CREATE TYPE [dbo].[PurchaseOrderDetailInsert] AS TABLE (
    [BonusQuantity]     DECIMAL (12, 4) NOT NULL,
    [DiscountAmount]    DECIMAL (12, 4) NOT NULL,
    [NetAmount]         DECIMAL (9, 2)  NOT NULL,
    [Price]             DECIMAL (9, 2)  NOT NULL,
    [ProductIdNo]       INT             NOT NULL,
    [PurchaseOrderIdNo] INT             NOT NULL,
    [Quantity]          DECIMAL (12, 4) NOT NULL,
    [Sequence]          SMALLINT        NOT NULL,
    [UnitIdNo]          TINYINT         NOT NULL,
    [VatAmount]         DECIMAL (9, 2)  NULL,
    [VatPercent]        DECIMAL (5, 2)  NULL);



