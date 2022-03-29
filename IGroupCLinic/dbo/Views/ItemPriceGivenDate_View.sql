Create View [dbo].ItemPriceGivenDate_View
as
select itm.Item_Code,itm.itemnameenglish,itm.category,	
	(select top 1 purchaselist.Costprice 
		from (SELECT b.TransDate,a.costprice 
			FROM [iGroupClinic].[dbo].[PurchaseDetails] a
			left join PurchaseGroup b
			on a.Group_key = b.Trans_Key 		
			where a.item_code=itm.item_code and a.branchid='02' and b.TransDate <= '2018/01/31'
			group by a.item_code,b.transdate,costprice) as PurchaseList
			order by TransDate DESC)/itm.pack2/itm.pack3 as 'LatestCostPrice',
	(Select TOP 1 c.CostPrice
	   From StockPosition c
			where c.item_code=itm.item_code AND c.StockDate <= '2018/01/31' and c.BranchID = '02'
			order by c.StockDate DESC)/itm.pack2/itm.pack3  as 'LastOpenPrice'
from itemdetails as itm
where branchid='02'
