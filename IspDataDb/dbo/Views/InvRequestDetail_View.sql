








CREATE VIEW [dbo].[InvRequestDetail_View] as 
Select a.IdNo,		
		a.Quantity,
		a.UnitIdNo,
		pu.UnitName,
		p.BaseUnitIdNo,
		bu.UnitName as BaseUnitName,
		p.ProductCode,
		p.ProductName,
		p.ProductNameAra,
		a.ProductIdNo,
		IIf(c.UnitQty=0,0,Cast(a.Quantity as Decimal(12,2)) * c.BaseQty / c.UnitQty) as BaseQuantity,
        IIf((cast(a.Quantity as Decimal(12,2)) * c.BaseQty / c.UnitQty)=0,0,a.NetAmount / (cast(a.Quantity as Decimal(12,2)) * c.BaseQty / c.UnitQty)) as UnitCost, 
		a.NetAmount, 
		IIf(c.BaseQty=0,0,d.QtyOnHand * c.UnitQty / c.BaseQty) as QtyOnHand,
		a.Sequence, 
		IsNull(s.QtySupplied,0) * c.BaseQTy/c.UnitQty as QtySupplied,

		a.InvTransactionIdNo
	From InvTransactionDetail a 
 	Left Join InvTransaction b 
 	On a.InvTransactionIdNo = b.IdNo 
	Left Join ProductUnit_View c 
	On a.ProductIdNo = c.ProductIdNo And a.UnitIdNo = c.UnitIdNo
	left join InventoryCount_View d 
	on a.ProductIdNo = d.ProductIdNo and b.WarehouseIdNo = d.WarehouseIdNo
	left join Product p
	on a.ProductIdNo = p.IdNo 
	left join InvRequestSupplied s
	on a.IdNo = s.InvTransactionDetailIdNo
	left join Unit pu
	on a.UnitIdNo = pu.IdNo
	left join Unit bu
	on p.BaseUnitIdNo = bu.IdNo