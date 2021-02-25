






CREATE PROCEDURE  [dbo].[UpdateEmployeeEarningTVP]
  @MParam EmployeeEarningUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeeEarning A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing Earnings
UPDATE a 
SET a.Amount = B.Amount,
	a.EmployeeIdNo = @GroupIdNo,
	a.EarningIdNo = B.EarningIdNo,
	a.Rate = B.Rate,
	a.[Sequence] = B.[Sequence]
from EmployeeEarning a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END