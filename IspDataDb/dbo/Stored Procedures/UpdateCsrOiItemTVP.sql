





CREATE PROCEDURE  [dbo].[UpdateCsrOiItemTVP]
  @MParam CsrOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CsrOiItem A WHERE A.CsrIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CsrOiItems
UPDATE a 
SET a.Amount = B.Amount,
	a.ApOpenInvoiceIdNo= B.ApOpenInvoiceIdNo,
	a.CsrIdNo = @GroupIdNo,
	a.DiscountTaken = B.DiscountTaken,
    a.[Sequence] = B.[Sequence]
from CsrOiItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END

