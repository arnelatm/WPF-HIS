



CREATE FUNCTION [dbo].[InventoryData_Func] (@EndDate Date)
RETURNS TABLE
AS
RETURN
( With cteInventory (BranchId,WarehouseId,Item_Code,QtyBox,LatestCostPrice,LastOpenPrice) as
	(select itm.BranchID,itm.warehouseid,itm.item_code,
  	sum(qtybox) as 'QtyBox',
	(select top 1 purchaselist.Costprice 
		from (SELECT b.TransDate,a.costprice 
			FROM [iGroupClinic].[dbo].[PurchaseDetails] a
			left join PurchaseGroup b
			on a.Group_key = b.Trans_Key 
			where item_code=itm.item_code and a.branchid=itm.BranchID and b.TransDate <= @EndDate
			group by a.branchid,a.item_code,b.transdate,costprice) as PurchaseList		
			order by TransDate DESC) as 'LatestCostPrice',
	(Select TOP 1 c.CostPrice
	   From ItemMovement_View c
			where c.item_code=itm.item_code and c.transtype = 'Open ' AND c.branchid=itm.BranchID and c.warehouseid=itm.warehouseid and c.TransDate <= @EndDate
			order by c.transdate DESC) as 'LastOpenPrice'
	from ItemMovement_View as itm
	where itm.TransDate <= @EndDate
	group by BranchID,item_code,warehouseid	
	)

	select a.branchid,b.warehouseid,a.item_code,a.ItemNameEnglish,a.category,pack1,pack2,pack3,itemgroup,b.qtyBox,isnull(b.LatestCostPrice,b.LastOpenPrice) as 'UnitCost'
	from ItemDetails a
	left join cteInventory b
	on a.BranchID = b.BranchID and a.Item_Code = b.item_code
)
