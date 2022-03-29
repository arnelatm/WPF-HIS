
CREATE VIEW HRSalary_View
 
AS
SELECT 	a.*,
	b.EmpNameEnglish,
	b.DepartmentID,
	c.Department
from HRPayrollDetails a
left outer join HREmployeeDetails b on a.EmpID = b.EmpID AND a.BranchID = b.BranchID
left outer join EmployeeDepartment c on b.DepartmentID = c.DeptID
Where b.ServiceStatus = 1
