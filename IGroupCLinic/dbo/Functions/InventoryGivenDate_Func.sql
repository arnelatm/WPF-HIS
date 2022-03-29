



CREATE FUNCTION [dbo].[InventoryGivenDate_Func] (@EndDate Date)
RETURNS TABLE
AS
RETURN
(  
	With cteInventoryData(branchid,warehouseid,qtyBox,item_code,LatestCostPrice,LastOpenPrice) as 
	(Select * from InventoryData_Func(@EndDate))
	select a.branchid,b.warehouseid,a.item_code,a.ItemNameEnglish,a.category,pack1,pack2,pack3,itemgroup,b.qtyBox,isnull(b.LatestCostPrice,b.LastOpenPrice) as 'UnitCost'
	from ItemDetails a
	left join cteInventoryData b
	on a.BranchID = b.BranchID and a.Item_Code = b.item_code
)
