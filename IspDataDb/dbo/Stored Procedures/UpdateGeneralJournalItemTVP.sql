








-- Declare @MParam As GeneralJournalItemMerge;

CREATE PROCEDURE  [dbo].[UpdateGeneralJournalItemTVP] 
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

IF EXISTS (
    SELECT 1
    FROM dbo.GeneralJournalItem AS i
    INNER JOIN dbo.Reconciled AS r
        ON r.JournalCode = 'GJ' AND r.JournalItemIdNo = i.IdNo
    WHERE i.JournalIdNo = @GroupIdNo
)
    THROW 51540, 'The journal contains a line reserved by an account reconciliation.', 1;

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
	a.PayIdNo = b.PayIdNo,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from [dbo].GeneralJournalItem A INNER JOIN @MParam As B
	ON A.IDNo = B.IDNo

END

