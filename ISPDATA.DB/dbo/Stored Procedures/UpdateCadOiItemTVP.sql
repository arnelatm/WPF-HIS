





CREATE PROCEDURE  [dbo].[UpdateCadOiItemTVP]
  @MParam CadOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CadOiItem A WHERE A.CadIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CadOiItems
UPDATE a 
SET a.Amount = B.Amount,
	a.CadIdNo = @GroupIdNo,
	a.DiscountTaken = B.DiscountTaken,
	a.JournalItemIdNo = B.JournalItemIdNo,
    a.[Sequence] = B.[Sequence]
from CadOiItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END

