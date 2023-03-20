

CREATE VIEW [dbo].[DrugAccept_View]
AS
SELECT      dbo.DrugAccept.IdNo, dbo.DrugAccept.AcceptDate, dbo.DrugAccept.GTIN, dbo.DrugAccept.Expiry, dbo.DrugAccept.BatchNo, dbo.DrugAccept.SerializationNo, dbo.DrugAccept.DateTimeStamp, dbo.ItemDetails.Item_Code, 
            dbo.ItemDetails.ItemNameEnglish, LTrim(DBO.DrugList.[Trade name])+' '+LTrim(dbo.DrugList.[Package size])+' '+LTrim([Strength value])+' '+LTrim([Unit of strength])+' '+LTrim(dbo.DrugList.[Package type]) as DrugName
FROM        dbo.DrugAccept 
LEFT JOIN	dbo.ItemDetails 
ON dbo.DrugAccept.GTIN = dbo.ItemDetails.GTIN
LEFT JOIN	dbo.DrugList 
ON dbo.DrugAccept.GTIN = dbo.DrugList.GTIN