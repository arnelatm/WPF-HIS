

CREATE VIEW [dbo].[ItemMovement_View]
  AS
(SELECT 
	'Open ' as 'TransType',
	OS.BranchID,
	os.SlNo,
	os.StockDate as 'TransDate',
	os.StockDate as 'TransNBR',
	os.warehouseid,
	OS.Item_Code,
	os.Batch,
	os.Expiry,
	((QtyBox+QTYSTRIPS/IT1.PACK2+QtyPcs/IT1.pack2/it1.pack3)) as 'QtyBox',
	OS.CostPrice,
	it1.ItemNameEnglish,
	it1.pack1,
	it1.pack2,
	it1.pack3,
	'Y' as 'PostedInStock'
  FROM [iGroupClinic].[dbo].[StockPosition] as OS
  left join itemdetails as it1 
  on OS.ITEM_CODE = it1.item_code AND OS.BRANCHID = IT1.BranchID
UNION
  Select 
	'Purchase',
	PD.BranchID,
	PD.SlNo,
	PG.TransDate,
	str(pg.TransNo,10,0),
	pg.Warehouseid,
	pd.Item_Code,
	pd.batch,
	pd.Expiry,
	iif(pd.unit='B',userqty+bonusqty,(userqty+bonusqty)/(iif(pd.unit='S',it2.pack2,it2.pack2*it2.pack3))),
    pd.CostPrice*(iif(pd.unit='B',1,iif(pd.unit='S',it2.pack2,it2.pack2*it2.pack3))),
    it2.ItemNameEnglish,
	it2.pack1,
	it2.pack2,
	it2.pack3,
	pg.PostInStock
  FROM [iGroupClinic].[dbo].[PurchaseDetails] as PD
  left join PurchaseGroup as PG
  ON PD.Group_key = PG.Trans_Key 
  left join itemdetails as it2
  on pd.Item_Code = it2.Item_Code and pd.BranchID = it2.BranchID
  where pg.TransType='PUR'
UNION
  Select 'PurReturn',
	PD.BranchID,
	PD.SlNo,
	PG.TransDate,
	str(pg.TransNo,10,0),
	pg.Warehouseid,
	pd.Item_Code,
	pd.batch,
	pd.Expiry,
	(iif(pd.unit='B',userqty+bonusqty,(userqty+bonusqty)/(iif(pd.unit='S',it2.pack2,it2.pack2*it2.pack3))))*-1,
	pd.CostPrice*(iif(pd.unit='B',1,iif(pd.unit='S',it2.pack2,it2.pack2*it2.pack3))),
	it2.ItemNameEnglish,
	it2.pack1,
	it2.pack2,
	it2.pack3,
	pg.PostInStock
  FROM [iGroupClinic].[dbo].[PurchaseDetails] as PD
  left join PurchaseGroup as PG
  on PD.Group_key = PG.Trans_Key 
  left join itemdetails as it2
  on pd.Item_Code = it2.Item_Code and pd.BranchID = it2.BranchID 
  where pg.TransType='PR'
UNION 
  Select 
	iif(ig.BillType='SALE INVOICE','Sale ','Return'),
	ID.BranchID,
	ID.RowNbr,
	IG.TransDateEnglish,
	STR(ig.TransNbr,10,0),
	ig.WareHouseID,
	id.item_code,
	id.Batch,
	id.Expiry,
	id.qty/(iif(id.unit='B',1,iif(id.unit='S',IT3.pack2,it3.pack2*it3.pack3))*iif(ig.BillType='SALE INVOICE',-1,1)),
	id.saleprice*(iif(id.unit='B',1,iif(id.unit='S',it3.pack2,it3.pack2*it3.pack3))),
	it3.ItemNameEnglish,
	it3.pack1,
	it3.pack2,
	it3.pack3,
	'Y'
  FROM [iGroupClinic].[dbo].[PharmacyInvoiceDetails] as ID
  left join PharmacyInvoiceGroup as IG
  on id.group_key = ig.Trans_Key
  left join itemdetails as it3
  on id.Item_Code = it3.Item_Code and id.BranchID = it3.BranchID

UNION
  Select 
	'Adjustment',
	SA.BranchID,
	1,
	SA.TransDate,
	str(SA.TransNo,10,0),
	SA.WarehouseID,
	SA.Item_Code,
	SA.Batch,
	SA.Expiry,
	(PQtyBox-nQtyBox+(pQTyStrip-nQtyStrip)/it4.pack2+(pQtyPcs-nQtyPcs)/(it4.pack2*it4.pack3))*-1,
	sellingprice-spriceNew,
	it4.ItemNameEnglish,
	it4.pack1,
	it4.pack2,
	it4.pack3,
	'Y'
  FROM [iGroupClinic].[dbo].[StockAdjustment] as SA
  left join itemdetails as it4
  on sa.Item_Code = it4.Item_Code and sa.BranchID = it4.BranchID

UNION 
  SELECT 
    'BrTransfer',
	TD.BranchID,
	TD.SlNo,
	Tg.TransDate,
	str(TG.TRANSNO,10,0),
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
	td.PostInStock
  from StockTransferDetails as TD
  left join StockTransferGroup as TG
  on TD.Group_Key = TG.Primary_Key
  left join itemdetails as it5
  on td.Item_Code = it5.Item_Code and td.BranchID = it5.BranchID
  where tg.BranchFrom = it5.BranchID and tg.TransType='Export'

UNION
  SELECT 
	'BrImport',
	TD.BranchID,
	TD.SlNo,
	Tg.TransDate,
	str(TG.TRANSNO,10,0),
	TG.WareHouseFrom,
	TD.Item_Code,
	TD.Batch,
	TD.Expiry,
	(TD.QTY)/(iif(left(td.unit,1)='B',1,iif(left(td.unit,1)='S',it5.pack2,it5.pack2*it5.pack3))),
	td.CostPrice*(iif(left(td.unit,1)='B',1,iif(left(td.unit,1)='S',it5.pack2,it5.pack2*it5.pack3))),
	it5.ItemNameEnglish,
	it5.pack1,
	it5.pack2,
	it5.pack3,
	td.PostInStock
  from StockTransferDetails as TD
  left join StockTransferGroup as TG
  on TD.Group_Key = TG.Primary_Key
  left join itemdetails as it5
  on td.Item_Code = it5.Item_Code and td.BranchID = it5.BranchID
  where tg.BranchTo = it5.BranchID and tg.TransType='Import'

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
	td.PostInStock
  from TransferStockDetails as TD
  left join TransferStockGroup as TG
  on TD.Group_Key = TG.Trans_Key
  left join itemdetails as it5
  on td.Item_Code = it5.Item_Code and td.BranchID = it5.BranchID

UNION 
  SELECT 
	'Destroy',
	DD.BranchID,
	DD.SlNo,
	DG.TransDate,
	str(DG.TransNo,10,0),
	DG.WarehouseFrom,
	DD.Item_Code,
	DD.Batch,
	DD.Expiry,
	(DD.PCSQty*-1)/	iif(DD.unit='B',it6.pack2*it6.pack3,(iif(DD.unit='S',it6.pack2,it6.pack2*it6.pack3))),
	DD.CostPrice*(iif(left(DD.unit,1)='B',1,iif(left(DD.unit,1)='S',it6.pack2,it6.pack2*it6.pack3))),
	it6.ItemNameEnglish,
	it6.pack1,
	it6.pack2,
	it6.pack3,
	dd.PostInStock
  FROM [iGroupClinic].[dbo].[StockDestroyedDetails] AS DD
  left join StockDestroyedGroup as DG
  ON DD.Group_Key = DG.Primary_Key
  left join itemdetails as IT6
  on DD.Item_Code = IT6.ITEM_Code and DD.BranchID = it6.BranchID
  where DG.BranchFrom = IT6.BranchID )