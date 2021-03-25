








CREATE PROCEDURE  [dbo].[UpdateEmployeePayElementTVP]
  @MParam EmployeePayElementUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeePayElement A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing PayElements
UPDATE a 
SET a.Amount = B.Amount,
	a.EmployeeIdNo = @GroupIdNo,
	a.PayElementIdNo = B.PayElementIdNo,
	a.Rate = B.Rate,
	a.[Sequence] = B.[Sequence],
	a.Unit = b.Unit
from EmployeePayElement a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END