



CREATE PROCEDURE  [dbo].[UpdatePcsOiItemTVP]
  @MParam PcsOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE a
FROM [DBO].PcsOiItem A WHERE a.PcsIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing PtcOIItems
UPDATE a 
SET a.Amount = b.Amount,
	a.ApOpenInvoiceIdNo = b.ApOpenInvoiceIdNo,
	a.DiscountTaken = b.DiscountTaken,
	a.PcsIdNo = @GroupIdNo,
	a.[Sequence] = b.[Sequence]
from PcsOiItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END

