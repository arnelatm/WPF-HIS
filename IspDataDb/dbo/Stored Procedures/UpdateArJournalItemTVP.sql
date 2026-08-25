








CREATE PROCEDURE  [dbo].[UpdateArJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

IF EXISTS (
    SELECT 1
    FROM dbo.ArJournalItem AS i
    INNER JOIN dbo.Reconciled AS r
        ON r.JournalCode = 'AR' AND r.JournalItemIdNo = i.IdNo
    WHERE i.JournalIdNo = @GroupIdNo
)
    THROW 51540, 'The journal contains a line reserved by an account reconciliation.', 1;

IF EXISTS (
    SELECT 1
    FROM dbo.ArJournalItem i
    INNER JOIN dbo.ArOpenInvoice o ON o.JournalCode = 'AR' AND o.JournalItemIdNo = i.IdNo
    WHERE i.JournalIdNo = @GroupIdNo
      AND NOT EXISTS (SELECT 1 FROM @MParam p WHERE p.IdNo = i.IdNo)
      AND EXISTS (SELECT 1 FROM dbo.CsrOiItem c WHERE c.ArOpenInvoiceIdNo = o.IdNo)
)
    THROW 51127, 'AR detail lines with collection allocations cannot be deleted.', 1;

-- Delete non existent records
DELETE A
FROM [DBO].ArJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing ArJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from ArJournalItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END

