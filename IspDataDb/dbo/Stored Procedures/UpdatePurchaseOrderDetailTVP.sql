













CREATE PROCEDURE  [dbo].[UpdatePurchaseOrderDetailTVP]
  @MParam PurchaseOrderDetailUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PurchaseOrderDetail A 
WHERE  (PurchaseOrderIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo ) )

-- Update existing Details
UPDATE a 
SET a.BonusQuantity = b.BonusQuantity,
	a.DiscountAmount = b.DiscountAmount,
	a.NetAmount = b.NetAmount,
	a.Price = b.Price,
	a.ProductIdNo = b.ProductIdNo ,
	a.PurchaseOrderIdNo = b.PurchaseOrderIdNo,
	a.Quantity = b.Quantity,
	a.[Sequence] = b.[Sequence],
	a.UnitIdNo = b.UnitIdNo,
	a.VatAmount = b.VatAmount,
	a.VatPercent = b.VatPercent
from PurchaseOrderDetail a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END