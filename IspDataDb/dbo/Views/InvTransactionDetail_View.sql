








CREATE VIEW [dbo].[InvTransactionDetail_View]
AS
SELECT        dbo.InvTransactionDetail.IdNo, dbo.InvTransactionDetail.Sequence, dbo.InvTransactionDetail.InvTransactionIdNo, dbo.InvTransactionDetail.ProductIdNo, dbo.InvTransactionDetail.Quantity, dbo.InvTransactionDetail.ExpiryDate, dbo.InvTransactionDetail.UnitIdNo, dbo.InvTransactionDetail.BatchNo,
                         dbo.InvTransactionDetail.NetAmount, dbo.Product.ProductCode, dbo.Product.ProductName,dbo.Product.ProductNameAra, dbo.Product.Barcode, dbo.Product.GTIN, dbo.Product.BaseUnitIdNo, dbo.Unit.UnitCode, dbo.Unit.UnitName, dbo.Unit.UnitNameAra, dbo.Category.VatSaleAccountIdNo, 
                         dbo.Category.SaleAccountIdNo, dbo.Category.PurchaseAccountIdNo, dbo.Product.CategoryIdNo, (select count(dbo.ProductUnit.ProductIdNo) from dbo.ProductUnit where dbo.ProductUnit.ProductIdNo = dbo.InvTransactionDetail.ProductIdNo) as UnitCount,
						 dbo.Category.NeedsExpiryDate, dbo.InvTransactionDetail.UnitCost, dbo.invTransactionDetail.InventoryIdNo
FROM            dbo.InvTransactionDetail LEFT OUTER JOIN
                         dbo.Unit ON dbo.InvTransactionDetail.UnitIdNo = dbo.Unit.IdNo LEFT OUTER JOIN
                         dbo.Product ON dbo.InvTransactionDetail.ProductIdNo = dbo.Product.IdNo LEFT OUTER JOIN
                         dbo.Category ON dbo.Product.CategoryIdNo = dbo.Category.IdNo