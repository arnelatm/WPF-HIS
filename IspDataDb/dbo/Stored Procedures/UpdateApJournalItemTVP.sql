







CREATE PROCEDURE  [dbo].[UpdateApJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

IF EXISTS (
    SELECT 1
    FROM dbo.ApJournalItem AS i
    INNER JOIN dbo.Reconciled AS r
        ON r.JournalCode = 'AP' AND r.JournalItemIdNo = i.IdNo
    WHERE i.JournalIdNo = @GroupIdNo
)
    THROW 51540, 'The journal contains a line reserved by an account reconciliation.', 1;

IF EXISTS (
    SELECT 1
    FROM dbo.ApJournalItem i
    INNER JOIN dbo.ApOpenInvoice o ON o.JournalCode = 'AP' AND o.JournalItemIdNo = i.IdNo
    WHERE i.JournalIdNo = @GroupIdNo
      AND NOT EXISTS (SELECT 1 FROM @MParam p WHERE p.IdNo = i.IdNo)
      AND (EXISTS (SELECT 1 FROM dbo.CdOiItem d WHERE d.ApOpenInvoiceIdNo = o.IdNo)
        OR EXISTS (SELECT 1 FROM dbo.CkOiItem k WHERE k.ApOpenInvoiceIdNo = o.IdNo)
        OR EXISTS (SELECT 1 FROM dbo.PcOiItem p WHERE p.ApOpenInvoiceIdNo = o.IdNo))
)
    THROW 51027, 'AP detail lines with payment allocations cannot be deleted.', 1;

-- Delete non existent records
DELETE A
FROM [DBO].ApJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing ApJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from ApJournalItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END

