

CREATE VIEW [dbo].[EmployeeLeaveEarnedApprovalItem_View]
AS
SELECT  b.EnteredBy, 
		b.LeaveIdNo, 
		b.StartDate, 
		b.EndDate, 
		b.DaysEarned, 
		a.Status, 
		a.ApprovalNote, 
		a.EmployeeLeaveEarnedApprovalIdNo,
		b.EmployeeIdNo, 
		b.DateCreated as 'LeaveDate', 
		b.Reason, 
		c.SupervisorIdNo, 
		c.EmployeeName, 
		c.EmployeeNameAra, 
        d.LeaveName, 
		d.LeaveNameAra, 
		a.EmployeeLeaveEarnedIdNo, 
		a.IdNo
FROM    dbo.EmployeeLeaveEarned AS b 
		INNER JOIN dbo.EmployeeLeaveEarnedApprovalItem AS a 
		ON b.IdNo = a.EmployeeLeaveEarnedIdNo 
		LEFT OUTER JOIN dbo.Leave AS d 
		ON b.LeaveIdNo = d.IdNo 
		LEFT OUTER JOIN dbo.Employee AS c 
		ON b.EmployeeIdNo = c.IdNo