


CREATE View [dbo].[ItemUnitCost]
as
select itm.Item_Code,itm.ItemNameEnglish,
	(select top 1 purchaselist.Costprice 
		from (SELECT b.TransDate,a.costprice 
			FROM [iGroupClinic].[dbo].[PurchaseDetails] a
			left join PurchaseGroup b
			on a.Group_key = b.Trans_Key 		
			where a.item_code=itm.item_code and a.branchid='02' and b.TransDate <= '2019/12/31'
			group by a.item_code,b.transdate,costprice) as PurchaseList
			order by TransDate DESC) as 'LatestCostPrice',
	(Select TOP 1 c.CostPrice
	   From StockPosition c
			where c.item_code=itm.Item_Code AND c.StockDate <= '2019/12/31' and c.BranchID = '02'
			order by c.StockDate DESC) as 'LastOpenPrice'
FROM ItemDetails AS Itm
WHERE branchid='02' AND Category='IN'
