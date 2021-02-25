








CREATE PROCEDURE  [dbo].[UpdateInsertPayrollDeductionTVP]
  @MParam1 PayrollDeductionUpdate READONLY, @MParam2 PayrollDeductionInsert READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollDeduction A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam1 where IdNo = A.IdNo )

-- Update existing Deductions
UPDATE a 
SET a.Amount = B.Amount,
	a.EmployeeIdNo = B.EmployeeIdNo,
	a.DeductionIdNo = B.DeductionIdNo,
	a.PayrollIdNo = @GroupIdNo
from PayrollDeduction a INNER JOIN @MParam1 As b
on a.IdNo = b.IdNo

INSERT  INTO [DBO].PayrollDeduction ( Amount, DeductionIdNo, EmployeeIdNo, PayrollIdNo )
        SELECT  Amount, DeductionIdNo, EmployeeIdNo, PayrollIdNo
        FROM    @MParam2
SET IDENTITY_INSERT DBO.PayrollDeduction ON;

END