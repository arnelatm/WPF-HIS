















CREATE PROCEDURE  [dbo].[UpdateEmployeeLeaveEarnedApprovalItemTVP]
  @MParam EmployeeLeaveEarnedApprovalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeeLeaveEarnedApprovalItem A WHERE A.EmployeeLeaveEarnedApprovalIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing LeaveEarnedCredits
UPDATE a 
Set a.ApprovalNote = b.ApprovalNote,
	a.EmployeeLeaveEarnedApprovalIdNo = b.EmployeeLeaveEarnedApprovalIdNo,
	a.EmployeeLeaveEarnedIdNo = b.EmployeeLeaveEarnedIdNo,
	a.Status = b.Status
from EmployeeLeaveEarnedApprovalItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END