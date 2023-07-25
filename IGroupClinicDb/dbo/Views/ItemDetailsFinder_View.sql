
CREATE VIEW [dbo].[ItemDetailsFinder_View]
AS
SELECT  a.Primary_Key as IdNO, a.Item_Code as ItemDetailsCode, a.ItemNameEnglish as ItemDetailsName, a.Ean_Code as BarCode, b.[Generic name] AS GenericName, a.GTIN
FROM    dbo.ItemDetails AS a 
LEFT OUTER JOIN dbo.DrugList AS b
ON a.GTIN = b.GTIN 
WHERE (a.BranchID = '01') AND (a.ItemGroup = 'MD')