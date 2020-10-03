









-- Declare @MParam As PayrollDeductAccountMerge;

CREATE PROCEDURE  [dbo].[UpdatePayrollDeductAccountTVP] 
  @MParam PayrollDeductAccountUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollDeductAccount A WHERE A.DeductionIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing PayrollDeductAccounts
UPDATE A
SET a.AccountIdNo = B.AccountIdNo,
	a.DeductionIdNo = @GroupIdNo,
	a.PayGroupIdNo = B.PayGroupIdNo	
from [dbo].PayrollDeductAccount A INNER JOIN @MParam As B
	ON A.IdNo = B.IdNo

END