CREATE TABLE [dbo].[InvTransactionDetail] (
    [IdNo]               INT          IDENTITY (1, 1) NOT NULL,
    [Sequence]           SMALLINT     NULL,
    [InvTransactionIdNo] INT          NULL,
    [ProductIdNo]        INT          NULL,
    [Quantity]           SMALLINT     NULL,
    [UnitIdNo]           TINYINT      NULL,
    [BatchNo]            VARCHAR (10) NULL,
    [ExpiryDate]         DATE         NULL,
    [PurchaseDetailIdNo] INT          NULL,
    CONSTRAINT [PK_InvTransactionDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

