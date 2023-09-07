


CREATE PROCEDURE [dbo].[spGetLastPurchaseCost] @ProductidNo Int
AS
Declare @Quantity as Decimal(12,4) = 0 
SELECT top 1 IIf(a.BonusQuantity+a.Quantity = 0, 0 ,a.NetAmount / (a.BonusQuantity + a.Quantity)) * IIf(a.UnitIdNo = c.BaseUnitIdNo,1, Iif(b.BaseQTy = 0, 0, b.UnitQty / b.BaseQty))
  FROM [dbo].[PurchaseDetail] a 
  left join ProductUnit b
  on a.ProductIdNo = b.ProductIdNo and a.UnitIdNo = b.UnitIdNo
  left join Product c
  on a.ProductIdNo = c.IdNo 
  where a.productidno = @ProductIdNo
  order by a.IdNo desc