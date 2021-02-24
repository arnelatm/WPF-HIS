







CREATE PROCEDURE  [dbo].[UpdatePayrollEarningTVP]
  @MParam PayrollEarningUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollEarning A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing Earnings
UPDATE a 
SET a.Amount = B.Amount,
	a.EmployeeIdNo = B.EmployeeIdNo,
	a.EarningIdNo = B.EarningIdNo,
	a.PayrollIdNo = @GroupIdNo
from PayrollEarning a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END