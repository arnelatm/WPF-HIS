



CREATE VIEW [dbo].[EmployeeLeaveEarnedApproval_View]
AS
SELECT        a.IdNo, a.LeaveIdNo, a.StartDate, a.EndDate, a.DaysEarned, b.EmployeeLeaveEarnedIdNo, b.LatestStatusUpdate, dbo.EmployeeLeaveEarned.DateCreated, dbo.EmployeeLeaveEarned.EmployeeIdNo, dbo.EmployeeLeaveEarned.Reason, 
                         dbo.Employee.SupervisorIdNo, a.EmployeeLeaveEarnedApprovalIdNo, a.Status, a.ApprovedBy, a.EnteredBy, a.ApprovalNote, a.ApprovalDate
FROM            dbo.EmployeeLeaveEarnedApprovalList_View AS a LEFT OUTER JOIN
                             (SELECT        c.EmployeeLeaveEarnedIdNo, MAX(d.DateCreated) AS LatestStatusUpdate
                               FROM            dbo.EmployeeLeaveEarnedApprovalItem AS c LEFT OUTER JOIN
                                                         dbo.EmployeeLeaveEarnedApproval AS d ON c.EmployeeLeaveEarnedApprovalIdNo = d.IdNo
                               GROUP BY c.EmployeeLeaveEarnedIdNo) AS b ON a.IdNo = b.EmployeeLeaveEarnedIdNo AND a.DateCreated = b.LatestStatusUpdate LEFT OUTER JOIN
                         dbo.EmployeeLeaveEarned ON a.IdNo = dbo.EmployeeLeaveEarned.IdNo LEFT OUTER JOIN
                         dbo.Employee ON dbo.EmployeeLeaveEarned.EmployeeIdNo = dbo.Employee.IdNo