CREATE TABLE [dbo].[SaleDetail] (
    [IdNo]           INT             IDENTITY (1, 1) NOT NULL,
    [Sequence]       SMALLINT        NULL,
    [SaleIdNo]       INT             NULL,
    [ProductIdNo]    INT             NULL,
    [Quantity]       DECIMAL(12, 4)        NULL,
    [UnitIdNo]       TINYINT         NULL,
    [BatchNo]        VARCHAR (10)    NULL,
    [Price]          DECIMAL (9, 2)  NULL,
    [DiscountAmount] DECIMAL (9, 2) NULL,
    [ExpiryDate]     DATE            NULL,
    [VatAmount]      DECIMAL (9, 2) NULL,
    [VatPercent]     DECIMAL (5, 2)  NULL,
    [NetAmount]      DECIMAL (9, 2) NULL,
    CONSTRAINT [PK_SaleDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

