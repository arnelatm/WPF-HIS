
CREATE VIEW HREmployeeOT_View
 
AS
SELECT 	a.empID,
	a.EmpNameEnglish,
	a.DepartmentID,
	c.Department,
	b.PeriodMonth,
	b.PeriodYear,
	b.OTHrs
From HREmployeeDetails a
LEFT OUTER JOIN HROTHrs b on a.BranchID = b.BranchID 
			 AND a.EmpID = b.EmpID 
LEFT OUTER JOIN EmployeeDepartment C on a.DepartmentID = c.DeptID
WHERE  a.ServiceStatus = 1