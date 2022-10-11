
CREATE VIEW StockMovementBeforeOS_View
 
AS
select 	BranchID,
	(select DefaultWareHouseID from systemsettings) as WareHouseID,
	TransNbr as TransNo,
	TransDateEnglish as TransDate,
	Item_Code,
	case when unit='Box' then qty*pack2*pack3 
	     else case when Unit= 'Strip' then qty*pack3
	     else qty end end as PCSQty,
	case when BillType = 'SALE INVOICE' THEN 'SL' ELSE 'SR' END AS TransType,
	pack2,
	pack3,
	ItemNameEnglish
From pharmacysales_View  
where transdateenglish <(select laststocktakingdate from systemsettings)
union all
select 	BranchID,
	(select DefaultWareHouseID from systemsettings) as WareHouseID,
	TransNo,
	TransDate,
	Item_Code,
	case when Unit = 'B' then TotalQty * pack2 * pack3 
	     else case when Unit = 'S' then TotalQty * pack3 
	     else TotalQty end end as PCSQty,
	TransType,
	pack2,
	pack3,
	ItemNameEnglish
From itempurchase_view 
where transdate >=(select laststocktakingdate from systemsettings)
union all
select a.BranchID,
	(select DefaultWareHouseID from systemsettings) as WareHouseID,
	a.TransNo,
	a.TransDate,
	a.Item_Code,
	ABS(a.NQty - a.PQty) as PCSQty,
	CASE WHEN a.NQty - a.PQty > 0 THEN
	'ADD' ELSE 'LESS' END as TransType,
	b.pack2,
	b.pack3,
	b.itemnameenglish	
FROM stockadjustment a
Left Outer Join ItemDetails b on a.Item_Code = b.Item_Code and a.BranchID = b.BranchID
Where transdate <(select laststocktakingdate from systemsettings)