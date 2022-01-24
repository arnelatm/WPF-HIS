
















CREATE PROCEDURE  [dbo].[UpdateAttendanceItemTVP]
  @MParam AttendanceItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].AttendanceItem A WHERE A.PayrollIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing AttendanceItem
UPDATE a 
SET	a.DaysAbsentWithoutPay = b.DaysAbsentWithoutPay,
	a.DaysAbsentWithPay = b.DaysAbsentWithPay,
	a.DaysOff = b.DaysOff,
	a.DaysPresent = b.DaysPresent,
	a.DaysTotal = b.DaysTotal,
    a.DaysVacationLeave = b.DaysVacationLeave,
	a.EmployeeIdNo = b.EmployeeIdNo,
	a.PayrollIdNo = @GroupIdNo,
	a.[Sequence] = b.[Sequence]
from AttendanceItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END