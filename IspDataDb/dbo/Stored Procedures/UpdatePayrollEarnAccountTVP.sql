









-- Declare @MParam As PayrollEarnAccountMerge;

CREATE PROCEDURE  [dbo].[UpdatePayrollEarnAccountTVP] 
  @MParam PayrollEarnAccountUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollEarnAccount A WHERE A.EarningIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing PayrollEarnAccounts
UPDATE A
SET a.AccountIdNo = B.AccountIdNo,
	a.EarningIdNo = @GroupIdNo,
	a.PayGroupIdNo = B.PayGroupIdNo,
	a.Sequence = B.Sequence
from [dbo].PayrollEarnAccount A INNER JOIN @MParam As B
	ON A.IDNo = B.IDNo

END