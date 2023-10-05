










CREATE VIEW [dbo].[PurchaseOrderApprovalDetail_View]
AS
SELECT        dbo.PurchaseOrderDetail.IdNo, dbo.PurchaseOrderDetail.Sequence, dbo.PurchaseOrderDetail.PurchaseOrderIdNo, dbo.PurchaseOrderDetail.ProductIdNo, dbo.PurchaseOrderDetail.Quantity, dbo.PurchaseOrderDetail.BonusQuantity, dbo.PurchaseOrderDetail.UnitIdNo, 
                         dbo.PurchaseOrderDetail.Price, dbo.PurchaseOrderDetail.DiscountAmount, dbo.PurchaseOrderDetail.UnitSalesPrice, dbo.PurchaseOrderDetail.VatPercent, dbo.PurchaseOrderDetail.VatAmount, dbo.PurchaseOrderDetail.NetAmount, dbo.Product.ProductCode, dbo.Product.ProductName, 
                         dbo.Product.ProductNameAra, dbo.Product.Barcode, dbo.Product.GTIN, dbo.Product.BaseUnitIdNo, dbo.Unit.UnitCode, dbo.Unit.UnitName, dbo.Unit.UnitNameAra, dbo.Category.VatSaleAccountIdNo, 
                         dbo.Category.VatPurchaseAccountIdNo, dbo.Category.VatPercentage, dbo.Category.SaleAccountIdNo, dbo.Category.PurchaseAccountIdNo, dbo.Product.CategoryIdNo, (select count(dbo.ProductUnit.ProductIdNo) from dbo.ProductUnit where dbo.ProductUnit.ProductIdNo = dbo.PurchaseOrderDetail.ProductIdNo) as UnitCount,
						 dbo.PurchaseOrderDetail.Quantity * dbo.PurchaseOrderDetail.Price as 'GrossAmount', IIf(dbo.PurchaseOrderDetail.Quantity * dbo.PurchaseOrderDetail.Price = 0,0, dbo.PurchaseOrderDetail.DiscountAmount / (dbo.PurchaseOrderDetail.Quantity * dbo.PurchaseOrderDetail.Price) * 100) as 'DiscountPercent',
						 IIf(dbo.PurchaseOrderDetail.Quantity * dbo.PurchaseOrderDetail.Price = 0,0, dbo.PurchaseOrderDetail.Quantity * dbo.PurchaseOrderDetail.Price) - dbo.PurchaseOrderDetail.DiscountAmount as 'AmtBefVat'
FROM            dbo.PurchaseOrderDetail LEFT OUTER JOIN
                         dbo.Unit ON dbo.PurchaseOrderDetail.UnitIdNo = dbo.Unit.IdNo LEFT OUTER JOIN
                         dbo.Product ON dbo.PurchaseOrderDetail.ProductIdNo = dbo.Product.IdNo LEFT OUTER JOIN
                         dbo.Category ON dbo.Product.CategoryIdNo = dbo.Category.IdNo