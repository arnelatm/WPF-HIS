









CREATE PROCEDURE  [dbo].[UpdateGroupAccessTVP]
  @MParam GroupAccessUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].GroupAccess A WHERE A.SecurityGroupIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing GroupAccesss
UPDATE a 
SET a.Editable = B.Editable,
	a.SecurityGroupIdNo = @GroupIdNo,
    a.SecurityObjectIDNo = B.SecurityObjectIDNo ,
	a.Visible = B.Visible	
from GroupAccess a JOIN @MParam b
on a.IDNo = b.IDNo

END
