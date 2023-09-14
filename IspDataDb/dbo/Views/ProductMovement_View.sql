




/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[ProductMovement_View]
  AS
(SELECT a.ProductIdNo, b.WarehouseIdNo,0 as WarehouseToIdNo, d.UnitName, a.PurchaseIdNo as IdNo,b.TransactionDate,
IIf(d.UnitQty=0,0,Cast((a.Quantity+a.BonusQuantity) as Decimal(12,4)) * d.BaseQty/UnitQty) as BaseQty,
a.Quantity+a.BonusQuantity as Quantity,
a.UnitIdNo, IIf(a.Quantity+a.BonusQuantity=0,0,a.NetAmount/(a.Quantity+a.BonusQuantity)) as UnitCost,'Purchase' as 
Description
  FROM dbo.PurchaseDetail a
  left join dbo.Purchase b 
  on a.PurchaseIdNo = b.IdNo
  Left Join ProductUnit_View d 
  On a.ProductIdNo = d.ProductIdNo And a.UnitIdNo = d.UnitIdNo where TransactionDate > '2023/08/21' and Posted = 1)
Union
(SELECT ProductIdNo, WarehouseIdNo,0 as WarehouseToIdNo, 'Box' , 0 as IdNo,TransactionDate,
  Quantity,Quantity, 1, UnitCost,'Beginning Inventory' 
  FROM dbo.BeginningInventory a)
UNION
(SELECT a.ProductIdNo, WarehouseIdNo, WarehouseToIdNo,d.UnitName,
		a.InvTransactionIdNo,b.TransactionDate,IIf(d.UnitQty=0,0,Cast(a.Quantity as Decimal(12,4)) * d.BaseQty/UnitQty) *
		(Case WHEN c.InventoryAction = 'A' THEN 1
		 WHEN c.InventoryAction = 'D' THEN -1
		 WHEN c.InventoryAction = 'T' THEN -1
		End) as BaseQty, 
		a.Quantity *
		(Case WHEN c.InventoryAction = 'A' THEN 1
		 WHEN c.InventoryAction = 'D' THEN -1
		 WHEN c.InventoryAction = 'T' THEN -1
		End) as Quantity, 
		a.UnitIdNo, a.UnitCost, c.InvTransTypeName
  FROM dbo.InvTransactionDetail a
  left join dbo.InvTransaction b 
  on a.InvTransactionIdNo = b.IdNo
  Left join dbo.InvTransType c
  on b.InvTransTypeIdNo = c.IdNo
  Left Join ProductUnit_View d 
  On a.ProductIdNo = d.ProductIdNo And a.UnitIdNo = d.UnitIdNo
  where c.InventoryAction <> 'R' and Posted = 1)