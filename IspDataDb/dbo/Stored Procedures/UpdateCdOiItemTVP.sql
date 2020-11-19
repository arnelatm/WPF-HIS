






CREATE PROCEDURE  [dbo].[UpdateCdOiItemTVP]
  @MParam CdOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CdOiItem A WHERE A.CdIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CdOiItems
UPDATE a 
SET a.Amount = B.Amount,
	a.CjIdNo = @GroupIdNo,
	a.DiscountTaken = B.DiscountTaken,
	a.ApOpenInvoiceIdNo = B.ApOpenInvoiceIdNo,
    a.[Sequence] = B.[Sequence]
from CdOiItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END