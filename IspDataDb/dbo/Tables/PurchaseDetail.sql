CREATE TABLE [dbo].[PurchaseDetail] (
    [IdNo]           INT            NULL,
    [Sequence]       SMALLINT       NULL,
    [PurchaseIdNo]   INT            NULL,
    [ProductIdNo]    INT            NULL,
    [Quantity]       SMALLINT       NULL,
    [BonusQuantity]  INT            NULL,
    [UnitIdNo]       TINYINT        NULL,
    [Price]          SMALLMONEY     NULL,
    [DiscountAmount] MONEY          NULL,
    [VatPercent]     DECIMAL (5, 2) NULL,
    [VatAmount]      SMALLMONEY     NULL,
    [NetAmount]      MONEY          NULL
);

