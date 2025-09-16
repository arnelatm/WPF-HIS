














CREATE VIEW [dbo].[InventoryGivenDate_View]
AS
SELECT  a.IdNo, a.BranchIdNo, a.ProductIdNo, a.TransactionIdNo, a.QtyOnHand, a.BatchNo, a.ExpiryDate, a.UnitSalesPrice, 
        b.ProductCode, b.ProductName,a.TransactionType,a.WarehouseIdNo,IIf(a.QtyOnHand=0,a.UnitCost,a.TotalCost / a.QtyOnHand) as UnitCost, a.TotalCost 
FROM    dbo.Inventory a 
		left JOIN dbo.Product b
		ON a.ProductIdNo = b.IdNo