
CREATE VIEW HRAttendenceDisplay_View
 
AS
select 	a.empid,
	a.empnameenglish,
	b.date,
	b.shiftid,
	a.departmentid,
	d.Department,
	b.timein1,
	b.TimeOut1,
	b.TimeIn2,
	b.TimeOut2,
	case when (b.status=1 or a.punchnecessary = 0 or b.offday = 1) then 'P' else 'A' end as status,
	b.splduty,
	b.offday,
	b.onleave,
	b.leavetype,
	b.punchnecessary,
	b.totalhrs,
	b.dutyhrs,
	b.othrs,
	b.latehrs,
	b.processingstatus,
	b.authanticate,
	b.authreason,
	a.empMarketing,
	e.shifttype,
	case when c.empid is null then 0 else 1 end as Vacation,
	case when b.timein1 = '' then 1 else 0 end as AutoTimeIn1,
	case when (b.timeout1 = '' and e.ShiftType = 0) then 1 else 0 end as AutoTimeOut1,
	case when b.timein2 = '' and e.ShiftType = 0 then 1 else 0 end as AutoTimeIn2,
	case when b.timeout2 = '' then  1 else 0 end as AutoTimeOut2
from HREmployeeDetails a
left outer join HRAttendenceDetails b on a.empid = b.empid
left outer join HRemployeeVacationSchedule c on b.empid = c.empid and b.date between c.datefrom and c.dateupto
left outer join EmployeeDepartment d on b.DepartmentID = d.DeptID
left outer join HRShiftDetails e on e.ShiftID = b.ShiftID 
where a.servicestatus = 1 AND b.Date is not null