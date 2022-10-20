

CREATE VIEW [dbo].[stockpositioncurrentwh01_view]
AS

SELECT [BranchID]
      ,[Item_Code]
      ,[Batch]
      ,[Expiry]
      ,[WarehouseID]
      ,[PCSQty]
      ,[CashPrice]
      ,[CreditPrice]
      ,[CostPrice]
      ,[PurchaseNo]
  FROM [dbo].[StockPositionCurrent] 
  WHERE WAREHOUSEID='01' AND BranchID = '02'