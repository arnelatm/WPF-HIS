


CREATE PROCEDURE  [dbo].[UpdateCkOiItemTVP]
  @MParam CkOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CkOiItem A WHERE A.DjIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CkOiItems
UPDATE a 
SET a.Amount = B.Amount,
	a.ApOpenInvoiceIdNo = B.ApOpenInvoiceIdNo,
	a.DiscountTaken = B.DiscountTaken,
	a.DjIdNo = @GroupIdNo,
    a.[Sequence] = B.[Sequence]
from CkOiItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END
