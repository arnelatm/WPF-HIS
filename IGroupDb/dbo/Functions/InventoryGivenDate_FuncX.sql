



CREATE FUNCTION [dbo].[InventoryGivenDate_FuncX] (@EndDate Date)
RETURNS TABLE
AS
RETURN
(  
	select a.branchid,b.warehouseid,a.item_code,a.ItemNameEnglish,a.category,pack1,pack2,pack3,itemgroup,b.qtyBox,isnull(b.LatestCostPrice,b.LastOpenPrice) as 'UnitCost'
	from ItemDetails a
	left join InventoryData_Func(@EndDate) b
	on a.BranchID = b.BranchID and a.Item_Code = b.item_code
)