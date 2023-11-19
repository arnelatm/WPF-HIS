

















/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[ProductMovement_TestView]
  AS
(SELECT a.ProductIdNo, b.WarehouseIdNo,0 as WarehouseToIdNo, d.UnitName, a.PurchaseIdNo as IdNo,
IIf(d.UnitQty=0,0,Cast((a.Quantity+a.BonusQuantity) as Decimal(12,4)) * d.BaseQty/UnitQty) * IIf(b.PurchaseReturn=0,1,-1) as BaseQty,
(a.Quantity+a.BonusQuantity) * IIf(b.PurchaseReturn=0,1,-1) as Quantity,
a.UnitIdNo, IIf(a.Quantity+a.BonusQuantity=0,0,a.NetAmount/(a.Quantity+a.BonusQuantity)) as UnitCost,
a.NetAmount as TotalCost,
IIf(b.PurchaseReturn=0,'Purchase','Purchase Return') as 
Description,ExpiryDate,BatchNo
  FROM dbo.PurchaseDetail a
  left join dbo.Purchase b 
  on a.PurchaseIdNo = b.IdNo
  Left Join ProductUnit_View d 
  On a.ProductIdNo = d.ProductIdNo And a.UnitIdNo = d.UnitIdNo where Posted = 1)
Union
(SELECT a.ProductIdNo, WarehouseIdNo,0 as WarehouseToIdNo, d.UnitName , 0 as IdNo,
  IIf(d.UnitQty=0,0,Cast(a.Quantity as Decimal(20,9)) * d.BaseQty / d.UnitQty),
  Quantity, a.UnitIdNo,  IIf(a.Quantity=0,0,a.TotalCost/a.Quantity) as UnitCost,a.TotalCost,'Beginning Inventory',ExpiryDate,BatchNo
  FROM dbo.BeginningInventory a
  Left Join ProductUnit_View d 
  on a.UnitIdNo = d.UnitIdNo and a.ProductIdNo = d.ProductIdNo)
UNION
(SELECT a.ProductIdNo, WarehouseIdNo, WarehouseToIdNo,d.UnitName,
		a.InvTransactionIdNo,IIf(d.UnitQty=0,0,Cast(a.Quantity as Decimal(12,4)) * d.BaseQty/UnitQty) *
		(Case WHEN c.InventoryAction = 'A' THEN 1
		 WHEN c.InventoryAction = 'D' THEN -1
		 WHEN c.InventoryAction = 'T' THEN -1
		End) as BaseQty, 
		a.Quantity *
		(Case WHEN c.InventoryAction = 'A' THEN 1
		 WHEN c.InventoryAction = 'D' THEN -1
		 WHEN c.InventoryAction = 'T' THEN -1
		End) as Quantity, 
		a.UnitIdNo, 
		a.UnitCost, 
		a.NetAmount,
		c.InvTransTypeName,
		a.ExpiryDate,
		a.BatchNo
  FROM dbo.InvTransactionDetail a
  left join dbo.InvTransaction b 
  on a.InvTransactionIdNo = b.IdNo
  Left join dbo.InvTransType c
  on b.InvTransTypeIdNo = c.IdNo
  Left Join ProductUnit_View d 
  On a.ProductIdNo = d.ProductIdNo And a.UnitIdNo = d.UnitIdNo
  where c.InventoryAction <> 'R' and Posted = 1)