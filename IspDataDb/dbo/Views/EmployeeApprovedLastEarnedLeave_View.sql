



CREATE VIEW [dbo].[EmployeeApprovedLastEarnedLeave_View]
AS
SELECT  a.EmployeeIdNo, a.LeaveIdNo,Max(a.EndDate) as LastLeaveApplied
FROM     [dbo].EmployeeLeaveEarned a
left join [dbo].EmployeeLeaveEarnedApprovalItem b
on a.IdNo = b.EmployeeLeaveEarnedIdNo 
left join [dbo].EmployeeLeaveEarnedApproval c
on b.EmployeeLeaveEarnedApprovalIdNo = c.IdNo
Where b.Approved = 1 
Group By EmployeeIdNo,LeaveIdNo