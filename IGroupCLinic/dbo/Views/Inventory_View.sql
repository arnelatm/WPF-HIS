



CREATE view [dbo].[Inventory_View]
AS
(select itm.BranchID,itm.warehouseid,itm.item_code,
	sum(qtybox) as 'QtyBox',
	(select top 1 purchaselist.Costprice 
		from (SELECT b.TransDate,a.costprice 
			FROM [iGroupClinic].[dbo].[PurchaseDetails] a
			left join PurchaseGroup b
			on a.Group_key = b.Trans_Key 
			where item_code=itm.item_code and a.branchid=itm.BranchID and b.TransDate <= '2020/01/31'
			group by a.branchid,a.item_code,b.transdate,costprice) as PurchaseList		
			order by TransDate DESC) as 'LatestCostPrice',
	(Select TOP 1 c.CostPrice
	   From ItemMovement_View c
			where c.item_code=itm.item_code and c.transtype = 'Open ' AND c.branchid=itm.BranchID and c.warehouseid=itm.warehouseid and c.TransDate <= '2020/01/31'
			order by c.transdate DESC) as 'LastOpenPrice'
from ItemMovement_View as itm
where itm.TransDate <= '2020/01/31'
group by BranchID,item_code,warehouseid)
