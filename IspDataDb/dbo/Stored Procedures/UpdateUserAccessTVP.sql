
CREATE PROCEDURE  [dbo].[UpdateUserAccessTVP]
  @MParam UserAccessUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].UserAccess A WHERE A.UserIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing UserAccesss
UPDATE a 
SET a.Editable = B.Editable,
	a.UserIdNo = @GroupIdNo,
    a.SecurityObjectIDNo = B.SecurityObjectIDNo ,
	a.Visible = B.Visible	
from UserAccess a JOIN @MParam b
on a.IDNo = b.IDNo

END

GO

