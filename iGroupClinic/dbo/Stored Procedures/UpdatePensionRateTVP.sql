








CREATE PROCEDURE  [dbo].[UpdatePensionRateTVP]
  @MParam PensionRateUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PensionRate A WHERE A.PensionSchemeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing PensionRates
UPDATE a 
SET a.EmployerShare = B.EmployerShare,
	a.EmployeeShare = B.EmployeeShare,
	a.HighRange = B.HighRange,
	a.LowRange = B.LowRange,
	a.MaxAmount = B.MaxAmount,
	a.PensionSchemeIdNo = @GroupIdNo,
	a.[Sequence] = B.[Sequence]
from PensionRate a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END
