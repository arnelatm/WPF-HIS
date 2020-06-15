








CREATE PROCEDURE  [dbo].[UpdateErJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].ErJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing ErJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.ProfitCenterIdNo = B.ProfitCenterIdNo,
	a.[Sequence] = B.[Sequence]
from ErJournalItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END