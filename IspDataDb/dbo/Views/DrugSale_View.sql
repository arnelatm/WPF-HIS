


CREATE VIEW [dbo].[DrugSale_View]
AS
SELECT      dbo.DrugSale.IdNo, dbo.DrugSale.SaleDate, dbo.DrugSale.GTIN, dbo.DrugSale.Expiry, dbo.DrugSale.BatchNo, dbo.DrugSale.SerializationNo, dbo.DrugSale.DateTimeStamp, dbo.Product.ProductCode, 
            dbo.Product.ProductName, LTrim(DBO.DrugList.[Trade name])+' '+LTrim(dbo.DrugList.[Package size])+' '+LTrim([Strength value])+' '+LTrim([Unit of strength])+' '+LTrim(dbo.DrugList.[Package type]) as DrugName
FROM        dbo.DrugSale 
LEFT JOIN	dbo.Product 
ON dbo.DrugSale.GTIN = dbo.Product.GTIN
LEFT JOIN	dbo.DrugList 
ON dbo.DrugSale.GTIN = dbo.DrugList.GTIN