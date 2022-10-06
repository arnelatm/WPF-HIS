CREATE VIEW dbo.StockConsumption_View
  AS
(  SELECT 
    'BrTransfer' as 'TransType',
	TD.BranchID,
	TD.SlNo,
	Tg.TransDate as 'TransDate',
	str(TG.TRANSNO,10,0) as 'TransNBR',
	TG.WareHouseFrom,
	TD.Item_Code,
	TD.Batch,
	TD.Expiry,
	(TD.QTY*-1)/(iif(left(td.unit,1)='B',1,iif(left(td.unit,1)='S',it5.pack2,it5.pack2*it5.pack3))) as 'QtyBox',
	td.CostPrice*(iif(left(td.unit,1)='B',1,iif(left(td.unit,1)='S',it5.pack2,it5.pack2*it5.pack3))) as 'CostPrice',
	it5.ItemNameEnglish,
	it5.pack1,
	it5.pack2,
	it5.pack3,
	it5.category,
	tg.BranchTo as 'BranchTo',
	tg.WareHouseTo 'WareHouseTo',
	td.PostInStock 	as 'PostedInStock'
  from StockTransferDetails as TD
  left join StockTransferGroup as TG
  on TD.Group_Key = TG.Primary_Key
  left join itemdetails as it5
  on td.Item_Code = it5.Item_Code and td.BranchID = it5.BranchID
  where tg.BranchFrom = it5.BranchID and tg.TransType='Export'

UNION 
  SELECT 
	'WHTransfer',
	TD.BranchID,
	TD.SlNo,
	Tg.TransferDate,
	str(TG.TransferNo,10,0),
	TG.WareHouseFrom,
	TD.Item_Code,
	TD.Batch,
	TD.Expiry,
	(TD.QTY*-1)/(iif(left(td.unit,1)='B',1,iif(left(td.unit,1)='S',it5.pack2,it5.pack2*it5.pack3))),
	td.CostPrice*(iif(left(td.unit,1)='B',1,iif(left(td.unit,1)='S',it5.pack2,it5.pack2*it5.pack3))),
	it5.ItemNameEnglish,
	it5.pack1,
	it5.pack2,
	it5.pack3,
	it5.Category,
	tg.BranchID,
	tg.WareHouseTo,
	td.PostInStock
  from TransferStockDetails as TD
  left join TransferStockGroup as TG
  on TD.Group_Key = TG.Trans_Key
  left join itemdetails as it5
  on td.Item_Code = it5.Item_Code and td.BranchID = it5.BranchID)