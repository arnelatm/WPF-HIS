
CREATE VIEW HRAttendenceAdjustedDisplay_View
 
AS
select 	a.empid,
	a.empnameenglish,
	b.date,
	b.shiftid,
	a.departmentid,
	d.Department,
	case when b.timein1 = '' then b.date + ' ' + (Select ShiftStart From HRShiftDetails Where ShiftID = b.ShiftID) else TimeIn1 end as TimeIn1,
	case when b.timeout1 = '' and (select ShiftType From HRShiftDetails Where ShiftID = b.ShiftID) = 0 then b.date + ' ' + (Select RestStart From HRShiftDetails Where ShiftID = b.ShiftID) else TimeOut1 end as TimeOut1,
	case when b.timein2 = '' and (select ShiftType From HRShiftDetails Where ShiftID = b.ShiftID) = 0 then b.date + ' ' + (Select RestEnd From HRShiftDetails Where ShiftID = b.ShiftID) else TimeIn2 end as TimeIn2,
	case when b.timeout2 = '' then b.date + ' ' + (Select ShiftEnd From HRShiftDetails Where ShiftID = b.ShiftID) else TimeOut2 end as TimeOut2,
	case when b.status=1 then 'P' else 'A' end as status,
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
	case when c.empid is null then 0 else 1 end as Vacation,
	case when b.timein1 = '' then 1 else 0 end as AutoTimeIn1,
	case when b.timeout1 = '' and (select ShiftType From HRShiftDetails Where ShiftID = b.ShiftID) = 0 then 0 else 1 end as AutoTimeOut1,
	case when b.timein2 = '' and (select ShiftType From HRShiftDetails Where ShiftID = b.ShiftID) = 0 then 0 else 1 end as AutoTimeIn2,
	case when b.timeout2 = '' then  0 else 1 end as AutoTimeOut2
from hremployeedetails a
left outer join hrattendencedetails b on a.empid = b.empid
left outer join hremployeevacationschedule c on b.empid = c.empid and b.date between c.datefrom and c.dateupto
left outer join EmployeeDepartment d on b.DepartmentID = d.DeptID
where a.servicestatus = 1
