


















CREATE PROCEDURE  [dbo].[UpdateInvTransactionDetailTVP]
  @MParam InvTransactionDetailUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].InvTransactionDetail A 
WHERE  (InvTransactionIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo ) )

-- Update existing Details
UPDATE a 
SET a.BatchNo = b.BatchNo,
	a.ExpiryDate = b.ExpiryDate,
	a.InventoryIdNo = b.InventoryIdNo,
	a.InvTransactionIdNo = b.InvTransactionIdNo,
	a.NetAmount = b.NetAmount,
	a.ProductIdNo = b.ProductIdNo ,
	a.Quantity = b.Quantity,
	a.[Sequence] = b.[Sequence],
	a.UnitCost = b.UnitCost,
	a.UnitIdNo = b.UnitIdNo
from InvTransactionDetail a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END