
CREATE VIEW 	StockPositionCurrent_View
 
AS
SELECT	 	a.BranchID			,
		a.WarehouseID			,
		a.item_code			,
		a.batch			,
		a.expiry			,
		(a.PCSQty-a.TMPStock) as Qty,
		a.CashPrice			,
		a.CostPrice     		,
		b.Pack2				,
		b.Pack3				,
		CONVERT(numeric(10,4),(a.PCSQty - a.tmpStock)/(b.Pack2*b.Pack3)) as QtyInBox,
		a.PurchaseNo
FROM 		StockPositionCurrent a, ItemDetails b
WHERE 		(a.PcsQty)>0 and
		a.Item_Code=b.Item_Code and a.BranchID=b.BranchID and b.item_blocked <> 'Y'