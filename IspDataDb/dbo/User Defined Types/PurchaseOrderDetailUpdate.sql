CREATE TYPE [dbo].[PurchaseOrderDetailUpdate] AS TABLE (
    [IdNo]              INT             NOT NULL,
    [PurchaseOrderIdNo] INT             NOT NULL,
    [NetAmount]         DECIMAL (9, 2)  NOT NULL,
    [ProductIdNo]       INT             NOT NULL,
    [Quantity]          SMALLINT        NOT NULL,
    [Sequence]          SMALLINT        NOT NULL,
    [UnitCost]          DECIMAL (11, 4) NOT NULL,
    [UnitIdNo]          TINYINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

