
CREATE VIEW [dbo].[ItemDetails_View]
AS
SELECT        a.BranchID, a.Category, a.Created_By_Branch, d.[Dosage Form] AS DosageForm, a.Primary_Key, a.Item_Status, a.Item_Code, a.ItemNameEnglish, a.ItemGroup, a.Pack1, a.Pack2, a.Pack3, d.[Package size] AS PackageSize, 
                         d.[Package type] AS PackageType, d.RegistrationNo, a.SaleStrip, d.[Strength value] AS StrengthValue, d.[Unit of strength] AS UnitOfStrength, d.[Unit of volume] AS UnitOfVolume, a.UserId, d.Volume, 
                         d.[Generic name] AS GenericName, d.[Route of Administration] AS RouteOfAdministration
FROM            dbo.itemdetails AS a LEFT OUTER JOIN
                         dbo.ItemRegistration AS b ON a.Item_Code = b.Item_Code LEFT OUTER JOIN
                         dbo.DrugList AS d ON b.RegistrationNo = d.RegistrationNo