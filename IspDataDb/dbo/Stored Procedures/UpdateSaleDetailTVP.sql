












CREATE PROCEDURE  [dbo].[UpdateSaleDetailTVP]
  @MParam SaleDetailUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].SaleDetail A 
WHERE  (SaleIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo ) )

-- Update existing Details
UPDATE a 
SET a.BatchNo = b.BatchNo,
	a.DiscountAmount = b.DiscountAmount,
	a.ExpiryDate = b.ExpiryDate,
	a.NetAmount = b.NetAmount,
	a.Price = b.Price,
	a.ProductIdNo = b.ProductIdNo ,
	a.SaleIdNo = b.SaleIdNo,
	a.Quantity = b.Quantity,
	a.[Sequence] = b.[Sequence],
	a.UnitIdNo = b.UnitIdNo,
	a.VatAmount = b.VatAmount,
	a.VatPercent = b.VatPercent
from SaleDetail a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END