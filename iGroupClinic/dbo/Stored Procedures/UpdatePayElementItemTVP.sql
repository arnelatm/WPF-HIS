

-- Declare @MParam As PayElementItem;

CREATE PROCEDURE  [dbo].[UpdatePayElementItemTVP] 
  @MParam PayElementItemUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayElementItem A WHERE A.ParentIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing PayElementItems
UPDATE A
SET a.FactorType = B.FactorType,
	a.FactorValue = B.FactorValue,
	a.ParentIdNo = @GroupIdNo,
	a.PayElementIdNo = b.PayElementIdNo,
	a.Sequence = B.Sequence
from [dbo].PayElementItem A INNER JOIN @MParam As B
	ON A.IDNo = B.IDNo

END
