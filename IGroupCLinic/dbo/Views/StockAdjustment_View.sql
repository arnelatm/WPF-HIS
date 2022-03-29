
CREATE VIEW StockAdjustment_View
 
AS
select 	a.*,
	b.ItemNameEnglish,
	c.WarehouseNameEnglish 
from StockAdjustment a
left outer join ItemDetails b on a.Item_Code = b.Item_Code AND a.BranchID = b.BranchID
left outer join WareHouseDetails c on a.WarehouseID = c.WarehouseID and a.BranchID  = c.BranchID  
