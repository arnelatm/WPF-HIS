









CREATE PROCEDURE  [dbo].[UpdateCdJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

IF EXISTS (
    SELECT 1
    FROM dbo.CdJournalItem AS i
    INNER JOIN dbo.Reconciled AS r
        ON r.JournalCode = 'CD' AND r.JournalItemIdNo = i.IdNo
    WHERE i.JournalIdNo = @GroupIdNo
)
    THROW 51540, 'The journal contains a line reserved by an account reconciliation.', 1;

-- Delete non existent records
DELETE A
FROM [DBO].CdJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CdJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from CdJournalItem a
JOIN @MParam b
on a.IDNo = b.IDNo

END
