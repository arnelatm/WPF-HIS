
CREATE VIEW 	StockPositionReturn_View
 
AS
SELECT	 	a.BranchID			,
		a.WarehouseID			,
		a.item_code			,
		a.batch			        ,
		a.expiry			,
		(a.PCSQty-a.TMPStock) as Qty    ,
		a.CashPrice			,
		a.CostPrice     		,
		b.Pack2				,
		b.Pack3				,
		(case a.PCSQty When 0 Then 0 Else CONVERT(numeric(10,4),a.PCSQty/(b.Pack2*b.Pack3)) End) as QtyInBox
FROM 		StockPositionCurrent a, ItemDetails b
WHERE 		a.Item_Code=b.Item_Code and a.BranchID=b.BranchID