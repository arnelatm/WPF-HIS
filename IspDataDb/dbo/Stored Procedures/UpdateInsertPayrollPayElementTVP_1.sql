








CREATE PROCEDURE  [dbo].[UpdateInsertPayrollPayElementTVP]
  @MParam1 PayrollPayElementUpdate READONLY, @MParam2 PayrollPayElementInsert READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollPayElement A 
Left Join [DBO].PayrollDetail D
On A.PayrollDetailIdNo = D.IdNo 
WHERE (payrollIdNo is Null) or (D.PayrollIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam1 where IdNo = A.IdNo ) )

-- Update existing PayElements
UPDATE a 
SET a.Amount = B.Amount,
	a.PayElementIdNo = B.PayElementIdNo,
	a.PayrollDetailIdNo = b.PayrollPayDetailIdNo
from PayrollPayElement a INNER JOIN @MParam1 As b
on a.IdNo = b.IdNo

EXEC dbo.InsertPayrollPayElementTVP @MParam2  

END