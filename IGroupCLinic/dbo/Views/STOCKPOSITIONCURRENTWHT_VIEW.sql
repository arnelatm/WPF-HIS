
CREATE VIEW [dbo].[STOCKPOSITIONCURRENTWHT_VIEW]
AS
SELECT TOP 1000 [BranchID]
      ,[Item_Code]
      ,[Batch]
      ,[Expiry]
      ,[WarehouseID]
      ,[PCSQty]
      ,[CashPrice]
      ,[CreditPrice]
      ,[CostPrice]
      ,[PurchaseNo]
      ,[TmpStock]
  FROM [dbo].[StockPositionCurrent]
  WHERE LEN(PURCHASENO) > 3 AND BRANCHID = '02' AND WAREHOUSEID='01'
  ORDER BY ITEM_CODE,BATCH
