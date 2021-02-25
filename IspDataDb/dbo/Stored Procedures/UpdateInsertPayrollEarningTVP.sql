







CREATE PROCEDURE  [dbo].[UpdateInsertPayrollEarningTVP]
  @MParam1 PayrollEarningUpdate READONLY, @MParam2 PayrollEarningInsert READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollEarning A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam1 where IdNo = A.IdNo )

-- Update existing Earnings
UPDATE a 
SET a.Amount = B.Amount,
	a.EmployeeIdNo = B.EmployeeIdNo,
	a.EarningIdNo = B.EarningIdNo,
	a.PayrollIdNo = @GroupIdNo
from PayrollEarning a INNER JOIN @MParam1 As b
on a.IdNo = b.IdNo

INSERT  INTO [DBO].PayrollEarning ( Amount, EarningIdNo, EmployeeIdNo, PayrollIdNo )
        SELECT  Amount, EarningIdNo, EmployeeIdNo, PayrollIdNo
        FROM    @MParam2
SET IDENTITY_INSERT DBO.PayrollEarning ON;

END