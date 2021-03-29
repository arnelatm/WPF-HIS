









CREATE PROCEDURE  [dbo].[UpdatePayrollDetailTVP]
  @MParam PayrollDetailUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollDetail A 
WHERE  (PayrollIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo ) )

-- Update existing Details
UPDATE a 
SET a.EmployeeIdNo = B.EmployeeIdNo,
	a.PayrollIdNo = @GroupIdNo
from PayrollDetail a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END