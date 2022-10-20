
CREATE VIEW 	StockPositionOnDate_View
 
AS
SELECT 	a.BranchID,
	a.WareHouseID,
	a.StockDate,
	a.SlNo,
	a.Item_Code,
	b.ItemNameEnglish,
	a.Batch,
	right(a.expiry,2)+substring(a.expiry,8,1)+substring(a.expiry,6,2)+substring(a.expiry,5,1)+left(a.expiry,4) as expiry,
	a.QtyBox,
	a.QtyStrips,
	a.QtyPcs,
	a.QtyBadBox,
	(a.qtyBox * b.pack2 * b.pack3)+(a.QtyStrips * b.pack3)+a.QtyPcs as QtyInPcs,
	a.costprice, 
	(a.costprice/(b.pack2*b.pack3)*((a.qtyBox * b.pack2 * b.pack3)+(a.QtyStrips * b.pack3)+ a.QtyPcs)) AS Amount, 
	a.sellingprice,
	b.pack1,
	b.pack2,
	b.pack3,
	b.bin_row,
	b.bin_col 
FROM 	StockPosition a 
	Left Outer Join ItemDetails b on a.item_code=b.item_code AND a.branchID=b.branchID