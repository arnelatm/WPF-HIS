CREATE TYPE [dbo].[InvTransactionDetailUpdate] AS TABLE (
    [BatchNo]            VARCHAR (10)    NULL,
    [ExpiryDate]         DATE            NULL,
    [IdNo]               INT             NOT NULL,
    [InventoryIdNo]      INT             NOT NULL,
    [InvTransactionIdNo] INT             NOT NULL,
    [NetAmount]          DECIMAL (9, 2)  NOT NULL,
    [ProductIdNo]        INT             NOT NULL,
    [Quantity]           SMALLINT        NOT NULL,
    [Sequence]           SMALLINT        NOT NULL,
    [UnitCost]           DECIMAL (11, 4) NOT NULL,
    [UnitIdNo]           TINYINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));



