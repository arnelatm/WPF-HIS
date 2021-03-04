











-- Declare @MParam As EarningSummaryMerge;

CREATE PROCEDURE  [dbo].[UpdateEarningSummaryTVP] 
  @MParam EarningSummaryUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EarningSummary A WHERE A.EarningSummaryIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing EarningSummarys
UPDATE A
SET a.EarningSummaryIdNo = @GroupIdNo,
	a.EarningIdNo = b.EarningIdNo,
	a.Multiplier = B.Multiplier,
	a.Sequence = B.Sequence
from [dbo].EarningSummary A INNER JOIN @MParam As B
	ON A.IDNo = B.IDNo

END