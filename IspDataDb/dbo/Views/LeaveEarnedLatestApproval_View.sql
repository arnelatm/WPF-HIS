
CREATE VIEW [dbo].[LeaveEarnedLatestApproval_View]
AS
SELECT a.IdNo, a.EmployeeLeaveApprovalIdNo, a.EmployeeLeaveIdNo, a.Status AS LeaveStatus, e.DateCreated, e.ApprovedBy, dbo.EmployeeLeaveEarnedApprovalItem.EmployeeLeaveEarnedIdNo
FROM     dbo.EmployeeLeaveEarnedApproval INNER JOIN
                  dbo.EmployeeLeaveEarnedApprovalItem ON dbo.EmployeeLeaveEarnedApproval.IdNo = dbo.EmployeeLeaveEarnedApprovalItem.EmployeeLeaveEarnedApprovalIdNo CROSS JOIN
                  dbo.EmployeeLeaveApprovalItem AS a 
				  INNER JOIN dbo.EmployeeLeaveApproval AS e ON a.EmployeeLeaveApprovalIdNo = e.IdNo INNER JOIN
                      (SELECT b.EmployeeLeaveIdNo, MAX(c.DateCreated) AS MaxDate
                       FROM      dbo.EmployeeLeaveApprovalItem AS b INNER JOIN
                                         dbo.EmployeeLeaveApproval AS c ON b.EmployeeLeaveApprovalIdNo = c.IdNo
                       GROUP BY b.EmployeeLeaveIdNo) AS d ON a.EmployeeLeaveIdNo = d.EmployeeLeaveIdNo AND e.DateCreated = d.MaxDate