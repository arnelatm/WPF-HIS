










-- Declare @MParam As PayElementAccountMerge;

CREATE PROCEDURE  [dbo].[UpdatePayElementAccountTVP] 
  @MParam PayElementAccountUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayElementAccount A WHERE A.PayElementIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing PayElementAccounts
UPDATE A
SET a.AccountIdNo = B.AccountIdNo,
	a.PayElementIdNo = @GroupIdNo,
	a.PayGroupIdNo = B.PayGroupIdNo,
	a.Sequence = B.Sequence
from [dbo].PayElementAccount A INNER JOIN @MParam As B
	ON A.IDNo = B.IDNo

END