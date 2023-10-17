CREATE TYPE [dbo].[PurchaseDetailInsert] AS TABLE (
    [BatchNo]        VARCHAR (10)    NULL,
    [BonusQuantity]  DECIMAL (12, 4) NOT NULL,
    [DiscountAmount] DECIMAL (9, 2) NOT NULL,
    [ExpiryDate]     DATE            NULL,
    [NetAmount]      DECIMAL (9, 2) NOT NULL,
    [Price]          DECIMAL (9, 2)  NOT NULL,
    [ProductIdNo]    INT             NOT NULL,
    [PurchaseIdNo]   INT             NOT NULL,
    [Quantity]       DECIMAL (12, 4) NOT NULL,
    [Sequence]       SMALLINT        NOT NULL,
    [UnitIdNo]       TINYINT         NOT NULL,
    [UnitSalesPrice] DECIMAL (9, 2)  NOT NULL,
    [VatAmount]      DECIMAL (9, 2) NULL,
    [VatPercent]     DECIMAL (5, 2)  NULL);



