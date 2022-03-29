
CREATE VIEW HRReArrangeAttendence_View
 
AS

select 	a.*,
	c.AttendenceID,
	c.DepartmentID,
	c.punchNecessary,
	c.DutyHRS,
	c.EmpMarketing,
	c.SundayOff,
	c.MondayOff,
	c.TuesDayOff,
	c.WednesDayOff,
	c.ThursDayOff,
	c.FriDayOff,
	c.SaturDayOff,
	d.LeaveType,
	e.Department
from HRScratchFile1 a
left outer join HREmployeeDetails c on a.EmpID = c.empID
left outer join HREmployeeLeaveDetails d on a.EmpID = d.EmpID AND a.Date BETWEEN d.DateFrom AND d.DateUpto
left outer join EmployeeDepartment e on c.DepartmentID = e.DeptID
