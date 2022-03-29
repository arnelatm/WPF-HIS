
CREATE VIEW BestInventory_View
 
AS
SELECT 	a.branchID,
	a.Item_Code,
	a.TransDateEnglish as TransDate,
	a.ItemNameEnglish,
	SUM(CASE WHEN a.Unit = 'Box' THEN a.Qty ELSE 
		CASE WHEN a.Unit = 'Strip' THEN a.Qty/b.Pack2 ELSE
		a.Qty /( b.Pack2 * b.Pack3) END END) AS Qty,
	SUM((CASE WHEN a.Unit = 'Box' THEN a.CostPrice ELSE 
		CASE WHEN a.Unit = 'Strip' THEN a.CostPrice/b.Pack2 ELSE
		a.CostPrice /( b.Pack2 * b.Pack3) END END) * a.Qty) AS CostAmt,
	SUM(a.SalePrice) AS SalePrice,
	SUM(a.SalePrice - ((CASE WHEN a.Unit = 'Box' THEN a.CostPrice ELSE 
		CASE WHEN a.Unit = 'Strip' THEN a.CostPrice/b.Pack2 ELSE
		a.CostPrice /( b.Pack2 * b.Pack3) END END) - a.DiscountAmt - a.ItemDeductibleAmt - a.ItemDiscount)+a.ItemRoundOFF) AS Profit ,
	SUM(a.DiscountPer) AS DiscountPer,
	SUM(a.DiscountAmt) AS DiscountAmt,
	SUM(a.ItemDeductibleAmt) AS DiductibleAmt,
	SUM(a.ItemRoundOFF) AS RoundOFF,
	SUM(a.ItemDiscount) AS EextraDiscount
FROM PharmacySales_View A
LEFT OUTER JOIN ItemDetails B on a.item_code = b.Item_code and a.BranchID = b.BranchID
--WHERE a.TRANSDATEENGLISH BETWEEN '2013/08/12' AND '2013/08/12' and a.item_code = '7099'
GROUP BY a.BranchID,
	 a.Item_Code,
	 a.ItemNameEnglish,
	 a.transDateEnglish	
