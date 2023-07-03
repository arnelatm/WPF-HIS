CREATE VIEW [dbo].[ItemDetailsQty_View]
AS
SELECT  a.BranchID, a.Category, a.Created_By_Branch, d.[Dosage Form] AS DosageForm, a.Primary_Key, a.Item_Status, a.Item_Code, a.ItemNameEnglish, a.ItemGroup, a.Pack1, a.Pack2, a.Pack3, d.[Package size] AS PackageSize, 
        d.[Package type] AS PackageType, d.RegistrationNo, a.SaleStrip, d.[Strength value] AS StrengthValue, d.[Unit of strength] AS UnitOfStrength, d.[Unit of volume] AS UnitOfVolume, a.UserId, d.Volume, 
        d.[Generic name] AS GenericName, d.[Route of Administration] AS RouteOfAdministration, a.GTIN, a.Price_Cash, d.[Trade name] AS TradeName, d.[Public Price], a.DateTimeStamp, C.QtyOnHand
FROM    dbo.ItemDetails AS a 
LEFT OUTER JOIN dbo.DrugList AS d 
ON a.GTIN = d.GTIN 
LEFT OUTER JOIN (SELECT SUM(s.PCSQty) / i.Pack2 / i.Pack3 AS QtyOnHand, s.Item_Code
                 FROM dbo.StockPositionCurrent_View AS s 
				 LEFT OUTER JOIN dbo.ItemDetails AS i 
				 ON s.Item_Code = i.Item_Code AND s.BranchID = i.BranchID
                 WHERE s.BranchID = '01' AND s.WarehouseID = '01'
                 GROUP BY s.Item_Code, s.BranchID, i.Pack2, i.Pack3, s.WarehouseID) AS C 
ON C.Item_Code = a.Item_Code
WHERE (a.BranchID = '01') AND (a.ItemGroup = 'MD')
GO



GO


