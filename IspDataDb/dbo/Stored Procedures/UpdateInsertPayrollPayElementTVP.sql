












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
    a.[Generated] = b.[Generated],
	a.PayElementIdNo = B.PayElementIdNo,
	a.PayrollDetailIdNo = b.PayrollDetailIdNo,
	a.RecurringPayElementIdNo = b.RecurringPayElementIdNo
from PayrollPayElement a INNER JOIN @MParam1 As b
on a.IdNo = b.IdNo
WHERE ISNULL(a.Amount, 0) <> ISNULL(b.Amount, 0)
   OR ISNULL(a.[Generated], 0) <> ISNULL(b.[Generated], 0)
   OR ISNULL(a.PayElementIdNo, 0) <> ISNULL(b.PayElementIdNo, 0)
   OR ISNULL(a.PayrollDetailIdNo, 0) <> ISNULL(b.PayrollDetailIdNo, 0)
   OR ISNULL(a.RecurringPayElementIdNo, 0) <> ISNULL(b.RecurringPayElementIdNo, 0)

EXEC dbo.InsertPayrollPayElementTVP @MParam2  

END

GO

