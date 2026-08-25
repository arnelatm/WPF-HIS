








CREATE PROCEDURE [dbo].[UpdateAccountReconciliationItemTVP]
  @MParam AccountReconciliationItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

IF EXISTS (
    SELECT 1
    FROM dbo.AccountReconciliation
    WHERE IdNo = @GroupIdNo
      AND (ISNULL(Posted, 0) = 1 OR ISNULL(Status, 'Draft') <> 'Draft')
)
    THROW 51511, 'Completed or finalized reconciliations cannot be changed. Reopen the review first.', 1;

IF EXISTS (
    SELECT 1
    FROM @MParam AS source
    INNER JOIN dbo.Reconciled AS existing WITH (UPDLOCK, HOLDLOCK)
        ON existing.JournalCode = source.JournalCode
       AND existing.JournalItemIdNo = source.JournalItemIdNo
       AND existing.ReconciliationIdNo <> @GroupIdNo
)
    THROW 51513, 'One or more transactions are already reserved by another reconciliation.', 1;

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

