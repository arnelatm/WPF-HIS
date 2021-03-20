








CREATE PROCEDURE  [dbo].[UpdatePayrollPayElementTVP]
  @MParam PayrollPayElementUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollPayElement A WHERE A.PayrollDetailIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing PayElements
UPDATE a 
SET a.Amount = B.Amount,
	a.PayElementIdNo = B.PayElementIdNo,
	a.PayrollDetailIdNo = @GroupIdNo
from PayrollPayElement a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END