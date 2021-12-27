













CREATE PROCEDURE  [dbo].[EmployeeLeaveApprovalItemTVP]
  @MParam EmployeeLeaveApprovalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeeLeaveApprovalItem A 
WHERE  (EmployeeLeaveApprovalIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo ) )

-- Update existing Items
UPDATE a 
SET a.ApprovalNote = b.ApprovalNote,
	a.EmployeeLeaveApprovalIdNo = @GroupIdNo,
	a.EmployeeLeaveIdNo = B.EmployeeLeaveIdNo,
	a.[Status] = b.[Status]
from EmployeeLeaveApprovalItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END