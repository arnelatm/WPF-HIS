








CREATE PROCEDURE  [dbo].[UpdateInsertEmployeePayrollPayElementTVP]
  @MParam1 PayrollPayElementUpdate READONLY, @MParam2 PayrollPayElementInsert READONLY, @GroupIdNo1 as INT, @GroupIdNo2 as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollPayElement A 
WHERE PayrollDetailIdNo = @GroupIdNo1 and NOT EXISTS (SELECT * FROM @MParam1 where IdNo = A.IdNo ) 

-- Update existing PayElements
UPDATE a 
SET a.Amount = B.Amount,
    a.[Generated] = b.[Generated],
	a.PayElementIdNo = B.PayElementIdNo,
	a.PayrollDetailIdNo = b.PayrollDetailIdNo,
	a.RecurringPayElementIdNo = b.RecurringPayElementIdNo
from PayrollPayElement a INNER JOIN @MParam1 As b
on a.IdNo = b.IdNo

INSERT  INTO PayrollPayElement ( Amount, [Generated], PayElementIdNo, PayrollDetailIdNo, RecurringPayElementIdNo )
        SELECT  Amount, [Generated], PayElementIdNo, PayrollDetailIdNo, RecurringPayElementIdNo
        FROM    @MParam2

SET IDENTITY_INSERT DBO.PayrollPayElement ON;
END