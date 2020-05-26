




CREATE PROCEDURE  [dbo].[UpdateCkdOiItemTVP]
  @MParam CkdOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CkdOiItem A WHERE A.CkdIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CkdOiItems
UPDATE a 
SET a.Amount = B.Amount,
	a.CkdIdNo = @GroupIdNo,
	a.DiscountTaken = B.DiscountTaken,
	a.ApOpenInvoiceIdNo = B.JournalItemIdNo,
    a.[Sequence] = B.[Sequence]
from CkdOiItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END

