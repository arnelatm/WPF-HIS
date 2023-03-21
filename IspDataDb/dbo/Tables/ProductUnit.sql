CREATE TABLE [dbo].[ProductUnit] (
    [IdNo]        INT      IDENTITY (1, 1) NOT NULL,
    [ProductIdNo] INT      NULL,
    [UnitIdNo]    SMALLINT NULL,
    [Multiplier]  SMALLINT NULL,
    [ToUnitIdNo]  SMALLINT NULL,
    CONSTRAINT [PK_ProductUnit] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

