CREATE VIEW dbo.SalesStock_View
AS
SELECT        dbo.PharmacyInvoiceDetails.Batch, dbo.PharmacyInvoiceDetails.Expiry, dbo.PharmacyInvoiceDetails.Item_Code, dbo.ItemDetails.GTIN, dbo.ItemDetails.ItemNameEnglish, dbo.StockPositionCurrent.SerialNo, 
                         dbo.PharmacyInvoiceGroup.TransDateEnglish, dbo.PharmacyInvoiceGroup.TransNbr, dbo.PharmacyInvoiceDetails.Group_Key, dbo.StockPositionCurrent.PurchaseNo, dbo.StockPositionCurrent.CostPrice
FROM            dbo.PharmacyInvoiceDetails INNER JOIN
                         dbo.PharmacyInvoiceGroup ON dbo.PharmacyInvoiceDetails.Group_Key = dbo.PharmacyInvoiceGroup.Trans_Key INNER JOIN
                         dbo.StockPositionCurrent ON dbo.PharmacyInvoiceDetails.Batch = dbo.StockPositionCurrent.Batch AND CONVERT(date, dbo.PharmacyInvoiceDetails.Expiry) = dbo.StockPositionCurrent.Expiry AND 
                         dbo.PharmacyInvoiceDetails.Item_Code = dbo.StockPositionCurrent.Item_Code INNER JOIN
                         dbo.ItemDetails ON dbo.PharmacyInvoiceDetails.Item_Code = dbo.ItemDetails.Item_Code
GO



GO


