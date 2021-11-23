

CREATE VIEW [dbo].[EmployeeLeaveList_View]
AS
SELECT        dbo.EmployeeLeave.EmployeeIdNo, dbo.EmployeeLeave.IdNo, dbo.EmployeeLeave.LeaveIdNo, dbo.EmployeeLeave.StartDate, dbo.EmployeeLeave.EndDate, dbo.EmployeeLeave.FullDay, dbo.EmployeeLeave.AppliedBy, 
                         dbo.EmployeeLeave.LeaveReason, dbo.EmployeeLeave.DateCreated, dbo.EmployeeLeaveApproval.EnteredBy, dbo.EmployeeLeaveApprovalItem.Status AS LeaveStatus, dbo.EmployeeLeaveApprovalItem.Note, 
                         dbo.EmployeeLeaveApproval.DateCreated AS LeaveStatusDate, dbo.Employee.SupervisorIdNo, dbo.EmployeeLeave.DateTimeStamp, dbo.EmployeeLeaveApprovalItem.EmployeeLeaveApprovalIdNo
FROM            dbo.EmployeeLeave INNER JOIN
                         dbo.Employee ON dbo.EmployeeLeave.EmployeeIdNo = dbo.Employee.IdNo LEFT OUTER JOIN
                         dbo.EmployeeLeaveApprovalItem ON dbo.EmployeeLeave.IdNo = dbo.EmployeeLeaveApprovalItem.EmployeeLeaveIdNo LEFT OUTER JOIN
                         dbo.EmployeeLeaveApproval ON dbo.EmployeeLeaveApprovalItem.EmployeeLeaveApprovalIdNo = dbo.EmployeeLeaveApproval.IdNo