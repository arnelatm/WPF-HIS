Create View [dbo].[StockConsumptionGivenDate_View]
as
select itm.BranchTo,itm.warehouseTo,itm.Category,itm.item_code,
	sum(qtybox) as 'QtyBox',
	(select top 1 purchaselist.Costprice 
		from (SELECT b.TransDate,a.costprice 
			FROM [iGroupClinic].[dbo].[PurchaseDetails] a
			left join PurchaseGroup b
			on a.Group_key = b.Trans_Key 
			where item_code=itm.item_code and a.branchid='02' and b.TransDate <= '2018/09/31'
			group by a.branchid,a.item_code,b.transdate,costprice) as PurchaseList
			order by TransDate DESC) as 'LatestCostPrice',
	(Select TOP 1 c.CostPrice
	   From StockPosition c
			where c.item_code=itm.item_code AND c.StockDate <= '2018/09/31'
			order by c.StockDate DESC) as 'LastOpenPrice'
from StockConsumption_View as itm
where itm.transDate >= '2018/09/01' and itm.TransDate <= '2018/09/31'
group by itm.branchto,itm.WareHouseTo,itm.Category,itm.Item_Code