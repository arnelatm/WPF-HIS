CREATE 	PROCEDURE Date2Date_ItemMovement_FromStockDate_Proc
  		(   @Item_Code varchar(15),
  		    @DateFrom varchar(10),
		    @DateUpto varchar(10)
		) 
 
AS 
DECLARE @SQLString varchar(8000)
-- if exists (select * from sysobjects where id=object_id(N'ItemMovement') and OBJECTPROPERTY(id,N'IsUserTable')=1)
-- 	begin
-- 		CREATE TABLE ItemMovement 
-- 		(
-- 			BranchID varchar (15),
-- 			WarehouseID varchar (15),
-- 			TransNo numeric(15, 0) NOT NULL ,
-- 			TransDate varchar (10),
-- 			item_code varchar (15),
-- 			PCSQty numeric(38, 3) NULL ,
-- 			TransType varchar (5),
-- 			pack2 numeric(8, 0) NULL ,
-- 			pack3 numeric(8, 0) NULL ,
-- 			ItemNameEnglish varchar (50),
-- 			MachineID varchar (20) Default host_name()
-- 		)
-- 	END

DELETE ItemMovement Where MachineID = HOST_NAME()
SET @SQLString = 'INSERT INTO ItemMovement 
(
	BranchID,
	WareHouseID,
	TransNo,
	TransDate,
	Item_Code,
	PCSQty,
	TransType,
	Pack2,
	Pack3,
	ItemNameEnglish,
	MachineID
) 
(
SELECT 	BranchID,
	WarehouseID,
	0 as TransNo,
	"'+@DateFrom+'" as TransDate ,
	item_code,
	sum(case when transtype = "OS" or 
		  transtype = "SR" or 
		  transtype = "PUR" or 
		  transtype = "ADD" then PCSQty 
	     else PCSQty * -1  end) as PCSQty,
	"OS" as TransType,
	pack2,
	pack3,
	ItemNameEnglish,
	"'+Host_Name()+'" as MachineID
FROM StockMovement_View 
Where TransDate = "'+@DateFrom+'" AND TRANSTYPE = "OS" AND Item_Code = "'+@Item_Code+'"
group by
	BranchID,
	WareHouseID,
	Item_Code,
	Pack2,
	Pack3,
	ItemNameEnglish
union all
select 	BranchID,
	(select DefaultWareHouseID from systemsettings) as WareHouseID,
	TransNbr as TransNo,
	TransDateEnglish as TransDate,
	Item_Code,
	case when unit="Box" then qty*pack2*pack3 
	     else case when Unit= "Strip" then qty*pack3
	     else qty end end as PCSQty,
	case when BillType = "SALE INVOICE" THEN "SL" ELSE "SR" END AS TransType,
	pack2,
	pack3,
	ItemNameEnglish,
	"'+Host_Name()+'" as MachineID
From pharmacysales_View  
where transdateenglish between "'+@dateFrom+'" AND "'+@DateUpto+'" and Item_Code = "'+@Item_Code+'"
union all
select 	BranchID,
	(select DefaultWareHouseID from systemsettings) as WareHouseID,
	TransNo,
	TransDate,
	Item_Code,
	case when Unit = "B" then TotalQty * pack2 * pack3 
	     else case when Unit = "S" then TotalQty * pack3 
	     else TotalQty end end as PCSQty,
	TransType,
	pack2,
	pack3,
	ItemNameEnglish,
	"'+Host_Name()+'" as MachineID
From itempurchase_view 
where transdate between "'+@DateFrom+'" AND "'+@DateUpto+'" and Item_Code = "'+@Item_Code+'"
union all
select a.BranchID,
	(select DefaultWareHouseID from systemsettings) as WareHouseID,
	a.TransNo,
	a.TransDate,
	a.Item_Code,
	ABS(a.NQty - a.PQty) as PCSQty,
	CASE WHEN a.NQty - a.PQty > 0 THEN
	"ADD" ELSE "LESS" END as TransType,
	b.pack2,
	b.pack3,
	b.itemnameenglish,
	"'+Host_Name()+'" as MachineID
FROM StockAdjustment a
Left Outer Join ItemDetails b on a.Item_Code = b.Item_Code and a.BranchID = b.BranchID
Where transdate between "'+@DateFrom+'" AND "'+@DateUpto+'" and a.Item_Code = "'+@Item_Code+'"
)'
EXECUTE (@SQLString)
SET QUOTED_IDENTIFIER ON
SET NOCOUNT OFF
