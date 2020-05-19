






CREATE PROCEDURE  [dbo].[UpdateSalesCashItemTVP]
  @MParam SalesCashItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].SalesCashItem A WHERE A.SalesJournalIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing SalesCashItems
UPDATE a 
SET a.CashCode = B.CashCode,
	a.DepositAmount = b.DepositAmount,
	a.SaleAmount = B.SaleAmount,
	a.SalesJournalIdNo = B.SalesJournalIdNo,
    a.[Sequence] = B.[Sequence]
from SalesCashItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END
