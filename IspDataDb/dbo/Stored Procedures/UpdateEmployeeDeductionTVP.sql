






CREATE PROCEDURE  [dbo].[UpdateEmployeeDeductionTVP]
  @MParam EmployeeDeductionUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeeDeduction A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing Deductions
UPDATE a 
SET a.Amount = B.Amount,
	a.EmployeeIdNo = @GroupIdNo,
	a.DeductionIdNo = B.DeductionIdNo,
	a.[Sequence] = B.[Sequence]
from EmployeeDeduction a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END