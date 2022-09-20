CREATE VIEW PharmacyOldPurchaseDisplayView
 
AS
SELECT  a.BranchID,
	a.Item_Code,
	a.TransNo as [P.No.],
	convert(varchar(10),convert(datetime,a.TransDate),103) as [P.Date],
	convert(numeric(5), a.userqty) as [Qty],
	convert(numeric(5),a.bonusqty) as [Bonus],
	convert(numeric(7,2),sum(d.pcsqty/(a.pack2*a.pack3))) as [Stock], 
	case when a.unit='B' then 'Box' else case when a.unit = 'S' then 'Strip' else 'Pcs' end end as [Unit],
	convert(varchar(10),convert(datetime,a.expiry),103) as [Expiry],
	convert(numeric(7,2),a.costprice) as [Cost],
	convert(numeric(7,2),a.purchaseprice) as [P.Price],
	a.SupplierNameEnglish as [Supplier],
	a.WarehouseID
from ItemPurchase_View a
left outer join stockpositioncurrent d on a.item_code = d.item_code and d.BranchID = a.BranchID and d.pcsqty <> 0 and d.WarehouseID = a.WarehouseID
group by
	a.BranchID,
	a.Item_Code,
	a.TransNo,
	a.TransDate,
	a.UserQty,
	a.BonusQty,
	a.Unit,
	a.Expiry,
	a.CostPrice,
	a.PurchasePrice,
	a.SupplierNameEnglish,
	a.WareHouseID