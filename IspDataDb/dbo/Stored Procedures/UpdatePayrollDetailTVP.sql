










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
SET a.BankTransfer = B.BankTransfer,
	a.EmployeeIdNo = B.EmployeeIdNo,
	a.PayrollIdNo = @GroupIdNo
from PayrollDetail a INNER JOIN @MParam As b
on a.IdNo = b.IdNo
WHERE ISNULL(a.BankTransfer, 0) <> ISNULL(b.BankTransfer, 0)
   OR ISNULL(a.EmployeeIdNo, 0) <> ISNULL(b.EmployeeIdNo, 0)
   OR ISNULL(a.PayrollIdNo, 0) <> ISNULL(@GroupIdNo, 0)

END

GO

