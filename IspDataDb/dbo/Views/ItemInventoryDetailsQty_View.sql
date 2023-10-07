Create VIEW ItemInventoryDetailsQty_View as 
Select a.IdNo,a.ProductIdNo,IIf(c.UnitQty=0,0,Cast(a.Quantity as Decimal(12,2)) * c.BaseQty / c.UnitQty) as Quantity,
       IIf((cast(a.Quantity as Decimal(12,2)) * c.BaseQty / c.UnitQty)=0,0,a.NetAmount / (cast(a.Quantity as Decimal(12,2)) * c.BaseQty / c.UnitQty)) as UnitCost, a.NetAmount , a.BatchNo, a.ExpiryDate 
       From InvTransactionDetail a Left Join InvTransaction b On a.InvTransactionIdNo = b.IdNo 
       Left Join ProductUnit_View c On a.ProductIdNo = c.ProductIdNo And a.UnitIdNo = c.UnitIdNo