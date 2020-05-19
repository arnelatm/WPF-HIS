





CREATE PROCEDURE  [dbo].[UpdateEmployeeLoanJournalItemTVP]
  @MParam EmployeeLoanJournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeeLoanJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing EmployeeLoanJournalItems
UPDATE a 
SET a.JournalIdNo = @GroupIdNo,
    a.[Sequence] = B.[Sequence],
	a.AccountIdNo = B.AccountIdNo,
	a.Debit = B.Debit,
	a.Credit = B.Credit,
	a.ProfitCenterIdNo = B.ProfitCenterIdNo,
	a.Notes = B.Notes
from EmployeeLoanJournalItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END

