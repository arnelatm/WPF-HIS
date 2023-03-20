CREATE view 	CalculatedStock_View
 
as 
select 
	a.BranchID,
	a.WarehouseID,
	a.Item_code,
	sum(a.TotalQty * b.Pack2 * b.Pack3) as Qty,
	b.ItemNameEnglish,
	b.pack2,
	b.pack3,
	'PUR' as TransType
from ItemPurchase_View a
left outer join ItemDetails b on a.Item_Code = b.Item_Code and a.BranchID = b.BranchID 
Where TransType = 'PUR'
Group By
	a.BranchID,
	a.WarehouseID,
	b.ItemNameEnglish,
	b.pack2,
	b.pack3,
	a.Item_Code  
Union All
select 
	a.BranchID,
	a.WarehouseID,
	a.Item_code,
	sum(a.TotalQty * b.Pack2 * b.Pack3) as Qty,
	b.ItemNameEnglish,
	b.pack2,
	b.pack3,
	'PR' as TransType
from ItemPurchase_View a
left outer join ItemDetails b on a.Item_Code = b.Item_Code and a.BranchID = b.BranchID 
Where TransType = 'PR'
Group By
	a.BranchID,
	a.WarehouseID,
	b.ItemNameEnglish,
	b.pack2,
	b.pack3,
	a.Item_Code  
Union All
select 
	a.BranchID,
	'01' as WarehouseID,
	a.Item_code,
	sum(case When a.unit = 'Box' then a.Qty * b.Pack2 * b.Pack3 When a.Unit = 'Strip' then a.Qty * b.Pack3 else a.Qty End) as Qty,
	b.ItemNameEnglish,
	b.pack2,
	b.pack3,
	'SAL' as TransType
from PharmacySales_View  a
left outer join ItemDetails b on a.Item_Code = b.Item_Code and a.BranchID = b.BranchID 
Where BillType = 'SALE INVOICE'
Group By
	a.BranchID,
	b.ItemNameEnglish,
	b.pack2,
	b.pack3,
	a.Item_Code  
Union All
select 
	a.BranchID,
	'01' as WarehouseID,
	a.Item_code,
	sum(case When a.unit = 'Box' then a.Qty * b.Pack2 * b.Pack3 When a.Unit = 'Strip' then a.Qty * b.Pack3 else a.Qty End) as Qty,
	b.ItemNameEnglish,
	b.pack2,
	b.pack3,
	'SR' as TransType
from PharmacySales_View  a
left outer join ItemDetails b on a.Item_Code = b.Item_Code and a.BranchID = b.BranchID 
Where BillType = 'SALE RETURN'
Group By
	a.BranchID,
	b.ItemNameEnglish,
	b.pack2,
	b.pack3,
	a.Item_Code