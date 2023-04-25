












CREATE PROC [dbo].[InsertProductUnitTVP]
  @MParam ProductUnitInsert READONLY
AS 
INSERT  INTO ProductUnit (BaseQty, ProductIdNo, Sequence, UnitIdNo, UnitQty)
        SELECT  BaseQty, ProductIdNo, Sequence, UnitIdNo, UnitQty
        FROM    @MParam
SET IDENTITY_INSERT DBO.ProductUnit ON;