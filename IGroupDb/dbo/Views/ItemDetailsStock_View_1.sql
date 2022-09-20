
CREATE view 	ItemDetailsStock_View
 
as 
select
	a.BranchID,
	'01' as WarehouseID,
	a.Item_Code,
	a.ItemNameEnglish,
	a.Ean_Code,
	case when sum(b.pcsqty) <=0 or sum(b.pcsqty) is null then 0 else (sum(b.PCSQty) / (a.pack2 * a.pack3)) end  as Qty,
	case when b.CashPrice=0 or b.CashPrice is null then 0 else b.CashPrice end as CashPrice 
From ItemDetails a
left outer join StockPositionCurrent B on a.item_Code = b.item_Code AND a.BranchID = b.BranchID and b.WarehouseID = '01' 
group by
	a.BranchID,
	a.Item_Code,
	a.ItemNameEnglish,
	a.ean_code,
	a.pack2,
	a.pack3,
	b.CashPrice