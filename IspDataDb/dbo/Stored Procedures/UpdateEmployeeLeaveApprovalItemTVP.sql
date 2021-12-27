














CREATE PROCEDURE  [dbo].[UpdateEmployeeLeaveApprovalItemTVP]
  @MParam EmployeeLeaveApprovalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeeLeaveApprovalItem A WHERE A.EmployeeLeaveApprovalIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing LeaveCredits
UPDATE a 
Set a.ApprovalNote = b.ApprovalNote,
	a.EmployeeLeaveApprovalIdNo = b.EmployeeLeaveApprovalIdNo,
	a.EmployeeLeaveIdNo = b.EmployeeLeaveIdNo,
	a.Status = b.Status
from EmployeeLeaveApprovalItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END