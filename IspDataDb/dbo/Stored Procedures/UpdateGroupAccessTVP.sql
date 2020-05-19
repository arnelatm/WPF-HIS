


Create PROCEDURE  [dbo].[UpdateGroupAccessTVP]
  @MParam GroupAccessUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN
-- Delete non existent records
DELETE A
FROM [DBO].GroupAccess A WHERE A.SecurityGroupIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

UPDATE a 
SET a.SecurityGroupIDNo = @GroupIdNo ,
    a.SecurityObjectIDNo = B.SecurityObjectIDNo ,
	a.Visible = B.Visible ,
	a.Editable = B.Editable
from GroupAccess a INNER JOIN @MParam as B
on a.IDNo = b.IDNo

END
