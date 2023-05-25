












CREATE PROCEDURE  [dbo].[UpdatePurchaseDetailTVP]
  @MParam PurchaseDetailUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PurchaseDetail A 
WHERE  (PurchaseIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo ) )

-- Update existing Details
UPDATE a 
SET a.BatchNo = b.BatchNo,
	a.BonusQuantity = b.BonusQuantity,
	a.DiscountAmount = b.DiscountAmount,
	a.ExpiryDate = b.ExpiryDate,
	a.NetAmount = b.NetAmount,
	a.Price = b.Price,
	a.ProductIdNo = b.ProductIdNo ,
	a.PurchaseIdNo = b.PurchaseIdNo,
	a.Quantity = b.Quantity,
	a.[Sequence] = b.[Sequence],
	a.UnitIdNo = b.UnitIdNo,
	a.UnitSalesPrice = b.UnitSalesPrice,
	a.VatAmount = b.VatAmount,
	a.VatPercent = b.VatPercent
from PurchaseDetail a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END