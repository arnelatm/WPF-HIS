










CREATE PROCEDURE  [dbo].[UpdateAttendanceTVP]
  @MParam AttendanceItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].Attendance A WHERE A.PayPeriodIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing Attendances
UPDATE a 
SET a.DaysAbsentWithoutPay = b.DaysAbsentWithoutPay,
	a.DaysAbsentWithPay = b.DaysAbsentWithPay,
	a.DaysOff = b.DaysOff,
	a.DaysPresent = b.DaysPresent,
	a.EmployeeIdNo = b.EmployeeIdNo,
	a.PayPeriodIdNo = @GroupIdNo,
	a.[Sequence] = b.[Sequence]
from Attendance a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END