CREATE VIEW OpeningStock_View
 
AS
Select 
	a.*,
	b.ItemNameEnglish,
	b.Pack2,
	b.Pack3,
	c.ItemNameEnglish as ItemGroup
From StockPosition a
Left Outer Join ItemDetails b on a.Item_Code = b.Item_Code and a.BranchID = b.BranchID
Left Outer Join ItemGroupMaster c on b.itemgroup = c.itemid