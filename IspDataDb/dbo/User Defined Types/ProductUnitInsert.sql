CREATE TYPE [dbo].[ProductUnitInsert] AS TABLE (
    [BaseQty]     SMALLINT NOT NULL,
    [Multiplier]  SMALLINT NOT NULL,
    [ProductIdNo] INT      NOT NULL,
    [UnitIdNo]    SMALLINT NOT NULL);

