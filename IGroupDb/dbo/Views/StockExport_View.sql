
CREATE VIEW StockExport_View
 
AS
select a.*,
	b.slno,
	b.item_code,
	c.itemnameenglish,
	b.batch,
	b.expiry,
	b.qty,
	b.bonus,
	b.unit,
	b.price,
	b.qty*b.price as ItemAmount,
	d.BranchNameEnglish as BranchNameFrom,
	e.BranchNameEnglish as BranchNameTo,
	f.WarehouseNameEnglish as WarehouseNameFrom,
	f.WarehouseNameEnglish as WarehouseNameTo
from stocktransfergroup a
left outer join stocktransferdetails b on a.primary_key = b.group_key and a.branchid = b.branchid
left outer join itemdetails c on b.item_code = c.item_code and b.branchid = c.branchid
left outer join branchdetails d on a.BranchFrom = d.BranchID
left outer join BranchDetails e on a.BranchTo = e.BranchID
left outer join WarehouseDetails f on a.WarehouseFrom = f.WarehouseID and f.BranchID = a.BranchFrom 
left outer join WarehouseDetails g on a.WarehouseTo = g.WarehouseID and f.BranchID = a.BranchTo