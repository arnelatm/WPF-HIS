CREATE TYPE [dbo].[ProductUnitUpdate] AS TABLE (
    [BaseQty]     SMALLINT NOT NULL,
    [IdNo]        INT      NOT NULL,
    [Multiplier]  SMALLINT NOT NULL,
    [ProductIdNo] INT      NOT NULL,
    [UnitIdNo]    SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

