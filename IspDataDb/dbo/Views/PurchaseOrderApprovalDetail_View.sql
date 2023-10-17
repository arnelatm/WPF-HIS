












CREATE VIEW [dbo].[PurchaseOrderApprovalDetail_View]
AS
SELECT        dbo.PurchaseOrderDetail.IdNo, dbo.PurchaseOrderDetail.Sequence, dbo.PurchaseOrderDetail.PurchaseOrderIdNo, dbo.PurchaseOrderDetail.ProductIdNo, dbo.PurchaseOrderDetail.Quantity, dbo.PurchaseOrderDetail.BonusQuantity, dbo.PurchaseOrderDetail.UnitIdNo, 
                         dbo.PurchaseOrderDetail.Price, dbo.PurchaseOrderDetail.DiscountAmount, dbo.PurchaseOrderDetail.UnitSalesPrice, dbo.PurchaseOrderDetail.VatPercent, dbo.PurchaseOrderDetail.VatAmount, dbo.PurchaseOrderDetail.NetAmount, dbo.Product.ProductCode, dbo.Product.ProductName, 
                         dbo.Product.ProductNameAra, dbo.Product.Barcode, dbo.Product.GTIN, dbo.Product.BaseUnitIdNo, dbo.Unit.UnitCode, dbo.Unit.UnitName, dbo.Unit.UnitNameAra, dbo.Category.VatSaleAccountIdNo, 
                         dbo.Category.VatPurchaseAccountIdNo, dbo.Category.VatPercentage, dbo.Category.SaleAccountIdNo, dbo.Category.PurchaseAccountIdNo, dbo.Product.CategoryIdNo, (select count(dbo.ProductUnit.ProductIdNo) from dbo.ProductUnit where dbo.ProductUnit.ProductIdNo = dbo.PurchaseOrderDetail.ProductIdNo) as UnitCount,
						 dbo.PurchaseOrderDetail.Quantity * dbo.PurchaseOrderDetail.Price as 'GrossAmount', IIf(dbo.PurchaseOrderDetail.Quantity * dbo.PurchaseOrderDetail.Price = 0,0, dbo.PurchaseOrderDetail.DiscountAmount / (dbo.PurchaseOrderDetail.Quantity * dbo.PurchaseOrderDetail.Price) * 100) as 'DiscountPercent',
						 IIf(dbo.PurchaseOrderDetail.Quantity * dbo.PurchaseOrderDetail.Price = 0,0, dbo.PurchaseOrderDetail.Quantity * dbo.PurchaseOrderDetail.Price) - dbo.PurchaseOrderDetail.DiscountAmount as 'AmtBefVat',
						 dbo.ProductUnit_View.UnitName as 'BaseUnitName', dbo.InventoryCount_View.QtyOnHand as 'QtyOnHand', dbo.InventoryCount_View.UnitCost, dbo.PurchaseOrderSupplied.QtySupplied as 'QtySupplied'
FROM            dbo.PurchaseOrderDetail 
				LEFT OUTER JOIN dbo.Unit ON dbo.PurchaseOrderDetail.UnitIdNo = dbo.Unit.IdNo 
				LEFT OUTER JOIN dbo.Product ON dbo.PurchaseOrderDetail.ProductIdNo = dbo.Product.IdNo 
				LEFT OUTER JOIN dbo.PurchaseOrder on dbo.PurchaseOrderDetail.PurchaseOrderIdNo = dbo.PurchaseOrder.IdNo
				LEFT OUTER JOIN dbo.Category ON dbo.Product.CategoryIdNo = dbo.Category.IdNo
				LEFT OUTER JOIN dbo.ProductUnit_View on dbo.Product.BaseUnitIdNo = dbo.ProductUnit_View.UnitIdNo and dbo.ProductUnit_View.ProductIdNo = dbo.Product.IdNo
				LEFT OUTER JOIN dbo.InventoryCount_View on dbo.PurchaseOrderDetail.ProductIdNo = dbo.InventoryCount_View.ProductIdNo and dbo.InventoryCount_View.WarehouseIdNo = dbo.PurchaseOrder.WarehouseIdNo
				LEFT OUTER JOIN dbo.PurchaseOrderSupplied on dbo.PurchaseOrderDetail.IdNo = dbo.PurchaseOrderSupplied.PurchaseOrderDetailIdNo