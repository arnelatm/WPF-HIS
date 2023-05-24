CREATE TYPE [dbo].[PurchaseDetailUpdate] AS TABLE (
    [BonusQuantity]  SMALLINT        NOT NULL,
    [DiscountAmount] DECIMAL (8, 2)  NOT NULL,
    [ExpiryDate]     DATE            NULL,
    [IdNo]           INT             NOT NULL,
    [NetAmount]      DECIMAL (10, 2) NOT NULL,
    [Price]          DECIMAL (8, 2)  NOT NULL,
    [ProductIdNo]    INT             NOT NULL,
    [PurchaseIdNo]   INT             NOT NULL,
    [Quantity]       SMALLINT        NOT NULL,
    [Sequence]       SMALLINT        NOT NULL,
    [UnitIdNo]       TINYINT         NOT NULL,
    [UnitSalesPrice] DECIMAL (9, 2)  NOT NULL,
    [VatAmount]      DECIMAL (8, 2)  NULL,
    [VatPercent]     DECIMAL (5, 2)  NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));



