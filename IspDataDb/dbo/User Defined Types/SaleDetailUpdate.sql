CREATE TYPE [dbo].[SaleDetailUpdate] AS TABLE (
    [BatchNo]        VARCHAR(10)     NULL,
    [DiscountAmount] DECIMAL (8, 2)  NOT NULL,
    [ExpiryDate]     DATE            NULL,
    [IdNo]           INT             NOT NULL,
    [NetAmount]      DECIMAL (10, 2) NOT NULL,
    [Price]          DECIMAL (8, 2)  NOT NULL,
    [ProductIdNo]    INT             NOT NULL,
    [SaleIdNo]   INT             NOT NULL,
    [Quantity]       SMALLINT        NOT NULL,
    [Sequence]       SMALLINT        NOT NULL,
    [UnitIdNo]       TINYINT         NOT NULL,
    [VatAmount]      DECIMAL (8, 2)  NULL,
    [VatPercent]     DECIMAL (5, 2)  NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

