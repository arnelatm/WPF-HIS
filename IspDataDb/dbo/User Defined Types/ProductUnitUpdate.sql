CREATE TYPE [dbo].[ProductUnitUpdate] AS TABLE (
    [BaseQty]     SMALLINT NOT NULL,
    [IdNo]        INT      NOT NULL,
    [ProductIdNo] INT      NOT NULL,
    [Sequence]    SMALLINT NOT NULL,
    [UnitIdNo]    SMALLINT NOT NULL,
    [UnitQty]     SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));



