

CREATE VIEW [dbo].[EmployeeLeaveEarnedLatestApproval_View]
AS
SELECT a.IdNo, a.EmployeeLeaveEarnedApprovalIdNo, a.EmployeeLeaveEarnedIdNo, e.DateCreated, e.ApprovedBy
FROM     dbo.EmployeeLeaveEarnedApprovalItem AS a INNER JOIN
                  dbo.EmployeeLeaveEarnedApproval AS e ON a.EmployeeLeaveEarnedApprovalIdNo = e.IdNo INNER JOIN
                      (SELECT b.EmployeeLeaveEarnedIdNo, MAX(c.DateCreated) AS MaxDate
                       FROM      dbo.EmployeeLeaveEarnedApprovalItem AS b INNER JOIN
                                         dbo.EmployeeLeaveEarnedApproval AS c ON b.EmployeeLeaveEarnedApprovalIdNo = c.IdNo
                       GROUP BY b.EmployeeLeaveEarnedIdNo) AS d ON a.EmployeeLeaveEarnedIdNo = d.EmployeeLeaveEarnedIdNo AND e.DateCreated = d.MaxDate