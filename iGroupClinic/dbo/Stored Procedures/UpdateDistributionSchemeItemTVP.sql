





-- Declare @MParam As DistributionSchemeItemMerge;

CREATE PROCEDURE  [dbo].[UpdateDistributionSchemeItemTVP] 
  @MParam DistributionSchemeItemUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].DistributionSchemeItem A WHERE A.DistributionSchemeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing DistributionSchemeItems
UPDATE A
SET A.DistributionSchemeIdNo = @GroupIdNo,
    A.[Sequence] = B.[Sequence],
	A.RevCostCenteridNo = B.RevCostCenterIdNo,
	A.Percentage = B.Percentage
from [dbo].DistributionSchemeItem A INNER JOIN @MParam As B
	ON A.IDNo = B.IDNo

END

