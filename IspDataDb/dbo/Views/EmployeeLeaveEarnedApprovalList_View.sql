
CREATE VIEW [dbo].[EmployeeLeaveEarnedApprovalList_View]
AS
SELECT      b.IdNo, b.EnteredBy, b.LeaveIdNo, b.StartDate, b.EndDate, b.DaysEarned, a.Status, a.EmployeeLeaveEarnedApprovalIdNo, b.EmployeeIdNo, 
			b.DateCreated, c.ApprovedBy, b.Reason, a.ApprovalNote, c.DateCreated AS ApprovalDate, a.EmployeeLeaveEarnedIdNo
FROM        dbo.EmployeeLeaveEarned AS b 
			INNER JOIN dbo.EmployeeLeaveEarnedApprovalItem AS a 
				ON b.IdNo = a.EmployeeLeaveEarnedIdNo 
			INNER JOIN dbo.EmployeeLeaveEarnedApproval AS c 
				ON a.EmployeeLeaveEarnedApprovalIdNo = c.IdNo