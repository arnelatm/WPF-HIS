








CREATE VIEW [dbo].[PurchaseHistory_View]
AS
SELECT        dbo.PurchaseDetail.IdNo, dbo.PurchaseDetail.PurchaseIdNo, dbo.PurchaseDetail.ProductIdNo, dbo.PurchaseDetail.Quantity, dbo.PurchaseDetail.BonusQuantity, dbo.PurchaseDetail.ExpiryDate, dbo.PurchaseDetail.UnitIdNo, dbo.PurchaseDetail.BatchNo,
                         dbo.PurchaseDetail.Price, dbo.PurchaseDetail.DiscountAmount, dbo.PurchaseDetail.UnitSalesPrice, dbo.PurchaseDetail.VatPercent, dbo.PurchaseDetail.VatAmount, dbo.PurchaseDetail.NetAmount, dbo.Product.ProductCode, dbo.Product.ProductName, 
                         dbo.Product.ProductNameAra, dbo.Product.Barcode, dbo.Product.GTIN, dbo.Product.BaseUnitIdNo, dbo.Unit.UnitCode, dbo.Unit.UnitName, dbo.Unit.UnitNameAra, dbo.Category.VatSaleAccountIdNo, 
                         dbo.Category.VatPurchaseAccountIdNo, dbo.Category.VatPercentage, dbo.Category.SaleAccountIdNo, dbo.Category.PurchaseAccountIdNo, dbo.Product.CategoryIdNo, (select count(dbo.ProductUnit.ProductIdNo) from dbo.ProductUnit where dbo.ProductUnit.ProductIdNo = dbo.PurchaseDetail.ProductIdNo) as UnitCount,
						 dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price as 'GrossAmount',
						 IIf(dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price = 0,0, dbo.PurchaseDetail.DiscountAmount / (dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price) * 100) as 'DiscountPercent',
						 IIf(dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price = 0,0, dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price) - dbo.PurchaseDetail.DiscountAmount as 'AmtBefVat',
						 IIf((dbo.PurchaseDetail.Quantity + dbo.PurchaseDetail.BonusQuantity) = 0,0,((dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price - dbo.PurchaseDetail.DiscountAmount) / (dbo.PurchaseDetail.Quantity + dbo.PurchaseDetail.BonusQuantity))) as 'UnitCost',
						 dbo.Supplier.SupplierName,dbo.Supplier.SupplierCode,dbo.Supplier.SupplierNameAra
FROM            dbo.PurchaseDetail 
				LEFT OUTER JOIN dbo.Unit ON dbo.PurchaseDetail.UnitIdNo = dbo.Unit.IdNo 
				LEFT OUTER JOIN dbo.Product ON dbo.PurchaseDetail.ProductIdNo = dbo.Product.IdNo 
				LEFT OUTER JOIN dbo.Category ON dbo.Product.CategoryIdNo = dbo.Category.IdNo
				LEFT OUTER JOIN dbo.Purchase On dbo.PurchaseDetail.PurchaseIdNo = dbo.Purchase.SupplierIdNo
				LEFT OUTER JOIN dbo.Supplier on dbo.Purchase.SupplierIdNo = dbo.Supplier.IdNo