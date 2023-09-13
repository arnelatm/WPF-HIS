


/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[InventoryCount_View]
as
SELECT [BranchIdNo]
      ,[ProductIdNo]
      ,sUM([QtyOnHand]) as QtyOnHand
      ,[ProductCode]
      ,[ProductName]
      ,[WarehouseIdNo]
      ,iif(sum([QtyOnHand])=0,0,sUM([TotalCost])/Sum([QtyOnHand])) as UnitCost
      ,sUM([TotalCost]) AS TotalCost
  FROM [dbo].[Inventory_View]
  GROUP BY BRANCHIDNO,PRODUCTIDNO,PRODUCTCODE,ProductName,WAREHOUSEIDNO