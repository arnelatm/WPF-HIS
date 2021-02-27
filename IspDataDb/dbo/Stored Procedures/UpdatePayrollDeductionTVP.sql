








CREATE PROCEDURE  [dbo].[UpdatePayrollDeductionTVP]
  @MParam PayrollDeductionUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollDeduction A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing Deductions
UPDATE a 
SET a.Amount = B.Amount,
	a.EmployeeIdNo = B.EmployeeIdNo,
	a.DeductionIdNo = B.DeductionIdNo,
	a.PayrollIdNo = @GroupIdNo
from PayrollDeduction a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END