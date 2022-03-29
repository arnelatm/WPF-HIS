CREATE VIEW TransferStockView
 
AS
SELECT
	a.BranchID,
	c.BranchNameEnglish,
	a.Trans_Key,
	a.WarehouseFrom,
	d.WarehouseNameEnglish as WareHouseFromName,
	a.WarehouseTo,
	e.WarehouseNameEnglish as WareHouseToName,
	a.TransferNo,
	a.TransferDate,
	a.ReqNo,
	a.ReqDate,
	a.Amount as TransferAmunt,
	a.CostAmount,
	a.Remarks,
	a.UserID,
	a.Create_Date,
	a.MachineID,
	b.SlNo,
	b.Item_Code,
	f.ItemNameEnglish,
	b.Batch,
	b.Expiry,
	b.Qty,
	b.Unit,
	b.PcsQty,
	b.Pack1,
	b.Pack2,
	b.Pack3,
	b.Price,
	b.CostPrice,
	b.AcCode,
	b.CostOfGoodsCode,
	b.InventoryCode,
	b.CostCentreID,
	b.Amount
From TransferStockGroup a
Left outer join TransferStockDetails b on a.trans_key = b.group_key and a.BranchID = b.BranchID
Left outer join BranchDetails c on a.BranchID = c.BranchID
Left outer join WarehouseDetails d on a.WarehouseFrom = d.WarehouseID and a.BranchID = d.BranchID
Left outer join WarehouseDetails e on a.WarehouseTo = e.WarehouseID and a.BranchID = e.BranchID
Left outer join ItemDetails f on b.Item_Code = f.Item_Code and b.BranchID = f.BranchID
