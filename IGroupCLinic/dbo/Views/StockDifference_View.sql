
CREATE VIEW StockDifference_View
 
AS
select a.item_code,
	sum(a.pcsqty/(c.pack2*c.pack3)) as OldQtyBox,
	sum(a.pcsqty/(c.pack2*c.pack3)*a.costprice) as OldCostAmt,
	sum(a.pcsqty/(c.pack2*c.pack3)*a.cashprice) as OldSaleAmt,
        0 as newqtybox,
	0 as newcostamt,
	0 as newsaleamt,
	c.itemnameenglish
from stockphysicalold a
left outer join itemdetails c on a.item_code = c.item_code AND a.branchid = c.branchid 	
group by a.item_code,
	 c.itemnameenglish,
	 c.pack2,
	 c.pack3
union all
select a.item_code,
	0 as oldqtybox,
	0 as oldcostamt,
	0 as oldsaleamt,
	sum(a.tqtygood/(c.pack2*c.pack3)) as OldQtyBox,
	sum(a.tqtygood/(c.pack2*c.pack3)*a.costprice) as OldCostAmt,
	sum(a.tqtygood/(c.pack2*c.pack3)*a.sellingprice) as OldSaleAmt,
	c.itemnameenglish
from stockposition a
left outer join itemdetails c on a.item_code = c.item_code AND a.branchid = c.branchid 	
group by a.item_code,
	 c.itemnameenglish,
	 c.pack2,
	 c.pack3
