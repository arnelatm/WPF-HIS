







-- Declare @MParam As GeneralJournalItemMerge;

CREATE PROCEDURE  [dbo].[UpdateGeneralJournalItemTVP] 
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].GeneralJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing GeneralJournalItems
UPDATE A
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.ProfitCenterIdNo = B.ProfitCenterIdNo,
	a.[Sequence] = B.[Sequence]
from [dbo].GeneralJournalItem A INNER JOIN @MParam As B
	ON A.IDNo = B.IDNo

END

