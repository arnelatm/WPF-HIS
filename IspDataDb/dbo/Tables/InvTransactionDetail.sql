CREATE TABLE [dbo].[InvTransactionDetail] (
    [IdNo]               INT             IDENTITY (1, 1) NOT NULL,
    [Sequence]           SMALLINT        NULL,
    [InvTransactionIdNo] INT             NULL,
    [ProductIdNo]        INT             NULL,
    [Quantity]           DECIMAL (12, 4) NULL,
    [UnitIdNo]           TINYINT         NULL,
    [BatchNo]            VARCHAR (20)    NULL,
    [UnitCost]           DECIMAL (11, 4) NULL,
    [NetAmount]          DECIMAL (9, 2)  NULL,
    [ExpiryDate]         DATE            NULL,
    [InventoryIdNo]      INT             NULL,
    CONSTRAINT [PK_InvTransactionDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);







