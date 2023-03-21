CREATE TABLE [dbo].[Category] (
    [IdNo]                   SMALLINT       IDENTITY (1, 1) NOT NULL,
    [CategoryCode]           VARCHAR (5)    NULL,
    [CategoryName]           VARCHAR (50)   NULL,
    [CategoryNameAra]        NVARCHAR (50)  NULL,
    [PurchaseAccountIdNo]    SMALLINT       NULL,
    [SaleAccountIdNo]        SMALLINT       NULL,
    [VatSaleAccountIdNo]     SMALLINT       NULL,
    [VatPurchaseAccountIdNo] SMALLINT       NULL,
    [VatPercentage]          DECIMAL (5, 2) NULL,
    [Notes]                  NVARCHAR (255) NULL,
    [datetimestamp]          ROWVERSION     NULL,
    CONSTRAINT [PK_Category_1] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





