
CREATE VIEW HREmployeeShift_View
 
AS
select 	a.empid,
	a.empnameenglish,
	a.DepartmentID,
	d.Department,
	b.shiftid,
	case when b.punchnecessary = 1 then 'Yes' else 'No' end as punchnecessary,
	c.shiftdescription,
	case when c.shifttype=1 then 'Direct' else 'Split' end as ShiftType,
	case when c.OverNight=1 then 'Over Night' else 'Day Shift' end as OverNight,
	c.ShiftStart,
	c.ShiftEnd,
	c.RestStart,
	c.RestEnd
from HREmployeeDetails a
left outer join HREmployeeShiftDetails b on a.EmpID = b.EmpID
left outer join HRShiftDetails c on c.ShiftID = b.ShiftID
left outer join EmployeeDepartment d on a.DepartmentID = d.DeptID