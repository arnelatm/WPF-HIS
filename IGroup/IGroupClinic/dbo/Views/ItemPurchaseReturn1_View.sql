CREATE VIEW ItemPurchaseReturn1_View
 
AS
select 
		a.*,
		c.SupplierNameEnglish,
		d.WarehouseNameEnglish
from PurchaseReturnGroup a
left outer join SupplierDetails c on a.SupplierID = c.SupplierID 
left outer join WarehouseDetails d on a.WarehouseID = d.WareHouseID and a.BranchID = d.BranchID