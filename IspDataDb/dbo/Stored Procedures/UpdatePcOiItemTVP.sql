

CREATE PROCEDURE  [dbo].[UpdatePcOiItemTVP]
  @MParam PcOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PcOiItem A WHERE A.DjIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing PcOiItems
UPDATE a 
SET a.Amount = B.Amount,
	a.DjIdNo = @GroupIdNo,
	a.DiscountTaken = B.DiscountTaken,
	a.ApOpenInvoiceIdNo = B.ApOpenInvoiceIdNo,
    a.[Sequence] = B.[Sequence]
from PcOiItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END