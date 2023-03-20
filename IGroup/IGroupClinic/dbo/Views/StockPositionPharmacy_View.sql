CREATE VIEW dbo.StockPositionPharmacy_View
AS
SELECT        dbo.StockPositionCurrent.Item_Code, dbo.ItemDetails.ItemNameEnglish, dbo.StockPositionCurrent.Batch, dbo.StockPositionCurrent.Expiry, dbo.StockPositionCurrent.PCSQty, dbo.StockPositionCurrent.CashPrice, 
                         dbo.ItemDetails.ItemGroup, dbo.StockPositionCurrent.BranchID
FROM            dbo.StockPositionCurrent INNER JOIN
                         dbo.ItemDetails ON dbo.StockPositionCurrent.BranchID = dbo.ItemDetails.BranchID AND dbo.StockPositionCurrent.Item_Code = dbo.ItemDetails.Item_Code
WHERE        (dbo.ItemDetails.ItemGroup = 'MD') AND (dbo.StockPositionCurrent.PCSQty > 0) AND (dbo.StockPositionCurrent.BranchID = '01')