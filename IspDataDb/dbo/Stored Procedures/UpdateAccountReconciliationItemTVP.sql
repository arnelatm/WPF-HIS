








CREATE   PROCEDURE  [dbo].[UpdateAccountReconciliationItemTVP]
  @MParam AccountReconciliationItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE a
FROM [DBO].AccountReconciliationItem a WHERE a.AccountReconciliationIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = a.IdNo )

-- Update existing AccountReconciliationItems
UPDATE a 
SET a.[AccountReconciliationIdNo] = @GroupIdNo,
	a.[Cleared]= b.[Cleared],
	a.[JournalCode] = b.[JournalCode],
	a.[JournalItemIdNo] = b.[JournalItemIdNo],
    a.[Sequence] = b.[Sequence]
from AccountReconciliationItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END

