










-- Declare @MParam As SalesJournalItemMerge;

CREATE PROCEDURE  [dbo].[UpdateSalesJournalItemTVP] 
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

IF EXISTS (
    SELECT 1
    FROM dbo.SalesJournalItem AS i
    INNER JOIN dbo.Reconciled AS r
        ON r.JournalCode = 'SJ' AND r.JournalItemIdNo = i.IdNo
    WHERE i.JournalIdNo = @GroupIdNo
)
    THROW 51540, 'The journal contains a line reserved by an account reconciliation.', 1;

-- Delete non existent records
DELETE A
FROM [DBO].SalesJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing SalesJournalItems
UPDATE A
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.PayIdNo = b.PayIdNo,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from [dbo].SalesJournalItem A INNER JOIN @MParam As B
	ON A.IDNo = B.IDNo

END

