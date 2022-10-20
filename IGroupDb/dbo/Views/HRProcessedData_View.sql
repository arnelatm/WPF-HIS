
CREATE VIEW HRProcessedData_View
 
AS
Select 	a.*,
	b.EmpNameEnglish,
	b.Sex,
	b.Age,
	c.Department
from HRMonthlyProcessedAttendence a
left outer join HREmployeeDetails b on a.EmpID = b.EmpID
left outer join EmployeeDepartment c on a.DepartmentID = c.DeptID