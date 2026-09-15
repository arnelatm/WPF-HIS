













CREATE PROCEDURE  [dbo].[UpdateOtWorkHourTVP]
  @MParam OtWorkHourUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].OtWorkHour A WHERE A.PayrollIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing OtWorkHour
UPDATE a 
SET a.EmployeeIdNo = b.EmployeeIdNo,
	a.PayrollIdNo = @GroupIdNo,
	a.HoursWorked = b.HoursWorked,
	a.OvertimeHoliday = b.OvertimeHoliday,
	a.OvertimeRegular = b.OvertimeRegular,
	a.OvertimeSpecial = b.OvertimeSpecial,
	a.[Sequence] = b.[Sequence]
from OtWorkHour a INNER JOIN @MParam As b
on a.IdNo = b.IdNo
WHERE EXISTS (SELECT a.EmployeeIdNo, a.PayrollIdNo, a.HoursWorked, a.OvertimeHoliday, a.OvertimeRegular,
                     a.OvertimeSpecial, a.[Sequence]
              EXCEPT SELECT b.EmployeeIdNo, @GroupIdNo, b.HoursWorked, b.OvertimeHoliday, b.OvertimeRegular,
                     b.OvertimeSpecial, b.[Sequence])

END
