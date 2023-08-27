









CREATE VIEW [dbo].[PurchaseOrderDetail_View]
AS
SELECT        dbo.PurchaseOrderDetail.IdNo, dbo.PurchaseOrderDetail.Sequence, dbo.PurchaseOrderDetail.PurchaseOrderIdNo, dbo.PurchaseOrderDetail.ProductIdNo, dbo.PurchaseOrderDetail.Quantity, dbo.PurchaseOrderDetail.UnitIdNo, 
                         dbo.PurchaseOrderDetail.NetAmount, dbo.Product.ProductCode, dbo.Product.ProductName,dbo.Product.ProductNameAra, dbo.Product.Barcode, dbo.Product.GTIN, dbo.Product.BaseUnitIdNo, dbo.Unit.UnitCode, dbo.Unit.UnitName, dbo.Unit.UnitNameAra, dbo.Category.VatSaleAccountIdNo, 
                         dbo.Category.SaleAccountIdNo, dbo.Category.PurchaseAccountIdNo, dbo.Product.CategoryIdNo, (select count(dbo.ProductUnit.ProductIdNo) from dbo.ProductUnit where dbo.ProductUnit.ProductIdNo = dbo.PurchaseOrderDetail.ProductIdNo) as UnitCount,
						 dbo.Category.NeedsExpiryDate, dbo.PurchaseOrderDetail.UnitCost
FROM            dbo.PurchaseOrderDetail LEFT OUTER JOIN
                         dbo.Unit ON dbo.PurchaseOrderDetail.UnitIdNo = dbo.Unit.IdNo LEFT OUTER JOIN
                         dbo.Product ON dbo.PurchaseOrderDetail.ProductIdNo = dbo.Product.IdNo LEFT OUTER JOIN
                         dbo.Category ON dbo.Product.CategoryIdNo = dbo.Category.IdNo