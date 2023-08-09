






CREATE VIEW [dbo].[ProductUnitV]
AS
(SELECT dbo.ProductUnit.UnitIdNo as IdNo, dbo.Unit.UnitCode as ProductUnitVCode, dbo.Unit.UnitName as ProductUnitVName, dbo.ProductUnit.ProductIdNo, dbo.ProductUnit.UnitQty, dbo.ProductUnit.BaseQty
 FROM   dbo.ProductUnit 
 Left outer JOIN dbo.Unit ON dbo.ProductUnit.UnitIdNo = dbo.Unit.IdNo
 Union 
 Select dbo.Product.BaseUnitIdNo, dbo.Unit.UnitCode, dbo.Unit.UnitName, dbo.Product.IdNo, 1, 1
 From dbo.Product
 Left outer Join dbo.Unit on dbo.Product.BaseUnitIdNo = dbo.Unit.IdNo
 )