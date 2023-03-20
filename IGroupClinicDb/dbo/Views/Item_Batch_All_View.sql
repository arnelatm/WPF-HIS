
CREATE view 	Item_Batch_All_View
 
as
select 		a.branchid				,
		a.warehouseid				,
		a.item_code			,
		a.batch			,
		a.expiry			,
		(a.pcsqty) as StockQty,
		a.cashprice			,
		a.costprice     			,
		b.itemnameenglish
from 		stockpositioncurrent a
left outer join itemdetails b on a.item_code = b.item_code and a.branchid = b.branchid