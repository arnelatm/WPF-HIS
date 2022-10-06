
CREATE View [dbo].[ItemInventoryGivenDate_View]
as
(select a.branchid,b.warehouseid,a.item_code,a.ItemNameEnglish,a.category,pack1,pack2,pack3,itemgroup,b.qtyBox,isnull(b.LatestCostPrice,b.LastOpenPrice) as 'UnitCost'
from ItemDetails a
left join ItemInventory_View b
on a.BranchID = b.BranchID and a.Item_Code = b.item_code)