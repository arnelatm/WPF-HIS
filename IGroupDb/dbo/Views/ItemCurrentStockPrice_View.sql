
CREATE VIEW 	ItemCurrentStockPrice_View
 
AS
SELECT 	a.BranchID,
	a.Item_Code,
	max(a.cashprice) as CashPrice,
	b.ItemNameEnglish as ItemName
From StockPositionCurrent a
Left Outer Join ItemDetails b on b.Item_code = a.Item_code and a.branchid = b.branchid
group by 
	a.branchid,
	a.item_code,
	b.itemnameenglish