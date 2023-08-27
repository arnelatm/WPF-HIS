



















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
SET a.PurchaseOrderIdNo = b.PurchaseOrderIdNo,
	a.NetAmount = b.NetAmount,
	a.ProductIdNo = b.ProductIdNo ,
	a.Quantity = b.Quantity,
	a.[Sequence] = b.[Sequence],
	a.UnitCost = b.UnitCost,
	a.UnitIdNo = b.UnitIdNo
from PurchaseOrderDetail a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END