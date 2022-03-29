
CREATE VIEW 	ItemPrice_View
 
AS
SELECT 	a.*,
	b.ItemNameEnglish as ItemGroupName,
	c.cashprice as itemprice
From ItemDetails a
Left Outer Join ItemGroupMaster b on b.ItemID = a.ItemGroup
Left Outer Join ItemCurrentStockPrice_View c on c.Item_code = a.Item_code and a.branchid = c.branchid
