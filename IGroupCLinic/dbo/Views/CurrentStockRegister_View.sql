CREATE VIEW CurrentStockRegister_View
 
AS
SELECT 	A.*,
	B.ItemNameEnglish,
	b.Pack2,
	b.Pack3,
	c.ItemNameEnglish as ItemGroup,
	B.ean_code  
FROM StockPositionCurrent a
Left Outer Join ItemDetails b on a.Item_code = b.Item_Code and a.BranchID = b.BranchID
left Outer Join ItemGroupMaster c on b.Itemgroup = c.itemID
where a.pcsqty <> 0
