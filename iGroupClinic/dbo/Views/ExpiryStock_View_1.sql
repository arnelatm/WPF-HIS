
CREATE view 	ExpiryStock_View
 
as 
select 	a.BranchID,
	a.WarehouseID,
	a.item_code,
	b.ItemNameEnglish,
	a.Batch,
	a.Expiry,
	A.Qty ,
	a.QtyInBox,
	a.CashPrice,
	a.CostPrice,
	case When a.expiry < GETDATE() Then 'Expired' else 'Not Expired' end as Expired,
	B.PACK1,
	b.pack2,
	b.pack3,
	A.Expiry AS TRANSDATE
from	StockPositionCurrent_View a,
	ItemDetails b
where	a.Item_Code=b.Item_Code
	and a.BranchID=b.BranchID