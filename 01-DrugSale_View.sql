USE [iGroupClinic]
GO

/****** Object:  View [dbo].[DrugSale_View]    Script Date: 08/11/2022 8:23:06 am ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[DrugSale_View]
AS
SELECT      dbo.DrugSale.IdNo, dbo.DrugSale.SaleDate, dbo.DrugSale.GTIN, dbo.DrugSale.Expiry, dbo.DrugSale.BatchNo, dbo.DrugSale.SerializationNo, dbo.DrugSale.DateTimeStamp, dbo.ItemDetails.Item_Code, 
            dbo.ItemDetails.ItemNameEnglish, LTrim(DBO.DrugList.[Trade name])+' '+LTrim(dbo.DrugList.[Package size])+' '+LTrim([Strength value])+' '+Trim([Unit of strength])+' '+LTrim(dbo.DrugList.[Package type]) as DrugName
FROM        dbo.DrugSale 
LEFT JOIN	dbo.ItemDetails 
ON dbo.DrugSale.GTIN = dbo.ItemDetails.GTIN
LEFT JOIN	dbo.DrugList 
ON dbo.DrugSale.GTIN = dbo.DrugList.GTIN
GO


