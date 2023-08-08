CREATE TYPE [dbo].[InvTransactionDetailInsert] AS TABLE (
    [BatchNo]            VARCHAR (10)    NULL,
    [ExpiryDate]         DATE            NULL,
    [InventoryIdNo]      INT             NOT NULL,
    [InvTransactionIdNo] INT             NOT NULL,
    [NetAmount]          DECIMAL (9, 2)  NOT NULL,
    [ProductIdNo]        INT             NOT NULL,
    [Quantity]           SMALLINT        NOT NULL,
    [Sequence]           SMALLINT        NOT NULL,
    [UnitCost]           DECIMAL (11, 4) NOT NULL,
    [UnitIdNo]           TINYINT         NOT NULL);



