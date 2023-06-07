











CREATE VIEW [dbo].[PurchaseHistory_View]
AS
SELECT        dbo.PurchaseDetail.IdNo, dbo.PurchaseDetail.PurchaseIdNo,dbo.Purchase.TransactionDate, dbo.PurchaseDetail.ProductIdNo, dbo.PurchaseDetail.Quantity, dbo.PurchaseDetail.BonusQuantity, dbo.PurchaseDetail.ExpiryDate, dbo.PurchaseDetail.BatchNo,
                         dbo.PurchaseDetail.UnitSalesPrice, dbo.Unit.UnitName, dbo.Unit.UnitNameAra, 
						 IIf((dbo.PurchaseDetail.Quantity + dbo.PurchaseDetail.BonusQuantity) = 0,0,((dbo.PurchaseDetail.Quantity * dbo.PurchaseDetail.Price - dbo.PurchaseDetail.DiscountAmount) / (dbo.PurchaseDetail.Quantity + dbo.PurchaseDetail.BonusQuantity))) as 'UnitCost',
						 dbo.Supplier.SupplierName,dbo.Supplier.SupplierCode,dbo.Supplier.SupplierNameAra,dbo.Purchase.BranchIdNo
FROM            dbo.PurchaseDetail 
				LEFT OUTER JOIN dbo.Unit ON dbo.PurchaseDetail.UnitIdNo = dbo.Unit.IdNo 
				LEFT OUTER JOIN dbo.Product ON dbo.PurchaseDetail.ProductIdNo = dbo.Product.IdNo 
				LEFT OUTER JOIN dbo.Category ON dbo.Product.CategoryIdNo = dbo.Category.IdNo
				LEFT OUTER JOIN dbo.Purchase On dbo.PurchaseDetail.PurchaseIdNo = dbo.Purchase.IdNo
				LEFT OUTER JOIN dbo.Supplier on dbo.Purchase.SupplierIdNo = dbo.Supplier.IdNo