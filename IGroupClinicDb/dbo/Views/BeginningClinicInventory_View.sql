/****** Script for SelectTopNRows command from SSMS  ******/
Create View BeginningClinicInventory_View
as
SELECT 1 as BranchId
      ,b.IdNo as WarehouseIdNo
	  ,c.IdNo as ProductIdNo
      ,[Item_Code]
      ,[Batch] as BatchNo
      ,[Expiry] as ExpiryDate
      ,[QtyInBox] as Quantity
      ,[CostPrice] as UnitCost
  FROM [iGroupClinic].[dbo].[StockPositionCurrent_View] a 
  left join [IspData].[dbo].Warehouse b 
  on a.WareHouseID = b.WarehouseCode
  left join [IspData].[dbo].Product c
  on a.Item_Code = c.ProductCode and a.BranchID = '02' and c.BranchIdNo = 1
  where a.branchid = '02' and QtyInBox <> 0 and b.IdNo <> 1 and b.idno = 3