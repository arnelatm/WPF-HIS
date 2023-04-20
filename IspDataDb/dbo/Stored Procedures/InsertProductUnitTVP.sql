












CREATE PROC [dbo].[InsertProductUnitTVP]
  @MParam ProductUnitInsert READONLY
AS 
INSERT  INTO ProductUnit (BaseQty, ProductIdNo, UnitIdNo, UnitQty)
        SELECT  BaseQty, ProductIdNo, UnitIdNo, UnitQty
        FROM    @MParam
SET IDENTITY_INSERT DBO.ProductUnit ON;