CREATE VIEW ItemPurchaseReturn_View
 
AS
select 
		a.*,
		b.Item_Code,
		c.SupplierNameEnglish,
		d.WarehouseNameEnglish,
		e.ItemNameEnglish    
from PurchaseReturnGroup a
left outer Join PurchaseReturnDetails b on a.Trans_Key = b.Group_key 
left outer join SupplierDetails c on a.SupplierID = c.SupplierID 
left outer join WarehouseDetails d on a.WarehouseID = d.WareHouseID and a.BranchID = d.BranchID 
left outer join ItemDetails e on b.Item_Code = e.Item_Code and a.BranchID = e.BranchID 
