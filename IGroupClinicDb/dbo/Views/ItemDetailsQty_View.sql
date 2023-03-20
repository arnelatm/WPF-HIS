



CREATE VIEW [dbo].[ItemDetailsQty_View]
AS
SELECT  a.BranchID, a.Category, a.Created_By_Branch, d.[Dosage Form] AS DosageForm, a.Primary_Key, a.Item_Status, a.Item_Code, a.ItemNameEnglish, a.ItemGroup, a.Pack1, a.Pack2, a.Pack3, d.[Package size] AS PackageSize, 
        d.[Package type] AS PackageType, d.RegistrationNo, a.SaleStrip, d.[Strength value] AS StrengthValue, d.[Unit of strength] AS UnitOfStrength, d.[Unit of volume] AS UnitOfVolume, a.UserId, d.Volume, 
        d.[Generic name] AS GenericName, d.[Route of Administration] AS RouteOfAdministration, a.GTIN, a.Price_Cash, d.[Trade name], d.[Public price], a.DateTimeStamp, c.QtyOnHand
FROM    dbo.ItemDetails AS a 
LEFT OUTER JOIN dbo.DrugList AS d 
ON a.GTIN = d.GTIN
LEFT OUTER JOIN (Select sum(s.PCSQty)/i.Pack2/i.pack3 as QtyOnHand,s.Item_Code
				 FROM StockPositionCurrent_View s
				LEFT JOIN ItemDetails i
				on s.Item_Code = i.Item_Code and s.BranchID = i.BranchID
				where s.BranchId = '01' and s.warehouseid='01'
				group by s.item_code, s.BranchID, i.pack2, i.pack3, s.warehouseid) as C
On c.Item_Code = a.Item_Code
where A.BranchID = '01' AND A.ItemGroup='MD'