select e.idno,e.EmployeeName from employee e
where e.idNo not In
(SELECT a.EmployeeIdnO FROM holidaytransferitem a
LEFT JOIN holidaytransfer b
on a.HolidayTransferIdNo = b.IdNo
where b.HolidayIdNo=3)