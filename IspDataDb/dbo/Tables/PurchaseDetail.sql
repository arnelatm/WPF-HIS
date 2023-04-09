CREATE TABLE [dbo].[PurchaseDetail] (
    [IdNo]           INT            IDENTITY (1, 1) NOT NULL,
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
    [NetAmount]      MONEY          NULL,
    CONSTRAINT [PK_PurchaseDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



