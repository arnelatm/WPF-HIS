

CREATE PROCEDURE  [dbo].[UpdateInsertPayrollDetailTVP]
  @MParam1 PayrollDetailUpdate READONLY, @MParam2 PayrollDetailInsert READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollDetail A WHERE A.PayrollIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam1 where IdNo = A.IdNo )

-- Update existing Details
UPDATE a 
SET a.BankTransfer = B.BankTransfer,
	a.EmployeeIdNo = B.EmployeeIdNo,
	a.PayrollIdNo = @GroupIdNo
from PayrollDetail a INNER JOIN @MParam1 As b
on a.IdNo = b.IdNo

INSERT  INTO [DBO].PayrollDetail (BankTransfer, EmployeeIdNo, PayrollIdNo )
        SELECT  BankTransfer, EmployeeIdNo, PayrollIdNo
        FROM    @MParam2
SET IDENTITY_INSERT DBO.PayrollDetail ON;

END