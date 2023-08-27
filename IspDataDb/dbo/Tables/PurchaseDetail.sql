CREATE TABLE [dbo].[PurchaseDetail] (
    [IdNo]           INT             IDENTITY (1, 1) NOT NULL,
    [Sequence]       SMALLINT        NULL,
    [PurchaseIdNo]   INT             NULL,
    [ProductIdNo]    INT             NULL,
    [Quantity]       SMALLINT        NULL,
    [BonusQuantity]  SMALLINT        NULL,
    [UnitIdNo]       TINYINT         NULL,
    [BatchNo]        VARCHAR (20)    NULL,
    [Price]          DECIMAL (9, 2)  NULL,
    [DiscountAmount] DECIMAL (12, 2) NULL,
    [UnitSalesPrice] DECIMAL (9, 2)  NULL,
    [ExpiryDate]     DATE            NULL,
    [NetAmount]      DECIMAL (12, 2) NULL,
    [VatAmount]      DECIMAL (12, 2) NULL,
    [VatPercent]     DECIMAL (5, 2)  NULL,
    [ExtraDiscount]  DECIMAL (5, 2)  NULL,
    CONSTRAINT [PK_PurchaseDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);











