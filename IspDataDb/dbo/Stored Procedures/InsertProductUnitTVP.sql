












CREATE PROC [dbo].[InsertProductUnitTVP]
  @MParam ProductUnitInsert READONLY
AS 
INSERT  INTO ProductUnit (BaseQty, Multiplier, ProductIdNo, UnitIdNo)
        SELECT  BaseQty, Multiplier, ProductIdNo, UnitIdNo
        FROM    @MParam
SET IDENTITY_INSERT DBO.ProductUnit ON;