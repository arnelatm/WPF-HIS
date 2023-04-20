CREATE TABLE [dbo].[ProductUnit] (
    [IdNo]        INT      IDENTITY (1, 1) NOT NULL,
    [ProductIdNo] INT      NOT NULL,
    [UnitIdNo]    SMALLINT NOT NULL,
    [UnitQty]     SMALLINT NOT NULL,
    [BaseQty]     SMALLINT NOT NULL,
    CONSTRAINT [PK_ProductUnit] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);









