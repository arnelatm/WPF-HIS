








CREATE VIEW [dbo].[InvRequestQtyOnHand_View] as 
Select a.IdNo,e.ProductCode,b.IdNo as InvTransactionIdNo,b.WarehouseIdNo,a.ProductIdNo,IIf(c.UnitQty=0,0,Cast(a.Quantity as Decimal(12,2)) * c.BaseQty / c.UnitQty) as Quantity,
       IIf((cast(a.Quantity as Decimal(12,2)) * c.BaseQty / c.UnitQty)=0,0,a.NetAmount / (cast(a.Quantity as Decimal(12,2)) * c.BaseQty / c.UnitQty)) as UnitCost, a.NetAmount , a.BatchNo, a.ExpiryDate , IsNull(d.QtyOnHand,0) as QtyOnHand, IsNull(f.QtySupplied,0) as QtySupplied
       From InvTransactionDetail a 
	   Left Join InvTransaction b 
	   On a.InvTransactionIdNo = b.IdNo 
	   Left Join ProductUnit_View c 
	   On a.ProductIdNo = c.ProductIdNo And a.UnitIdNo = c.UnitIdNo
	   left join InventoryCount_View d 
	   on a.ProductIdNo = d.ProductIdNo and b.WarehouseIdNo = d.WarehouseIdNo
	   left join Product e
	   on a.ProductIdNo = e.IdNo 
	   left join InvRequestSupplied f
	   on a.IdNo = f.InvTransactionDetailIdNo
	   where b.InvTransTypeIdNo = 15