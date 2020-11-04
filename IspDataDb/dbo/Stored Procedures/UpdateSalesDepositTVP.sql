







CREATE PROCEDURE  [dbo].[UpdateSalesDepositTVP]
  @MParam SalesDepositUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].SalesDeposit A WHERE A.SalesJournalIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing SalesDeposits
UPDATE a 
SET a.PaymentTypeIdNo = B.PaymentTypeIdNo,
	a.DepositAmount = b.DepositAmount,
	a.SaleAmount = B.SaleAmount,
	a.SalesJournalIdNo = B.SalesJournalIdNo,
    a.[Sequence] = B.[Sequence]
from SalesDeposit a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END