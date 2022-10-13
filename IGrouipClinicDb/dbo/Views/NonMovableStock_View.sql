CREATE view 	NonMovableStock_View
 
as 
select 
	distinct(a.item_code) as item_Code,
	c.ItemNameEnglish,
	a.branchid,
	a.warehouseid,
	a.batch,
	a.pcsqty as Qty,
	a.costPrice,
	a.CashPrice,
	a.Expiry,
	case When a.expiry < GETDATE() Then 'Expired' else 'Not Expired' end as Expired,
	b.transdateenglish,
	c.pack1,
	c.pack2,
	c.pack3,
	a.pcsqty / (c.pack2*c.pack3) as QtyInBox
from stockpositioncurrent a 
left outer join pharmacysales_view b on a.item_code = b.item_code and a.branchid = b.branchid 
left outer join itemdetails c on a.item_code = c.item_code and a.branchid = c.branchid
where a.pcsqty > 0 and b.transdateenglish is null