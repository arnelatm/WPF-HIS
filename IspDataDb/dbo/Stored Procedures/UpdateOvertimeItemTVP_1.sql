













CREATE PROCEDURE  [dbo].[UpdateOvertimeItemTVP]
  @MParam OvertimeItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].OvertimeItem A WHERE A.PayrollIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing OvertimeItem
UPDATE a 
SET a.EmployeeIdNo = b.EmployeeIdNo,
	a.PayrollIdNo = @GroupIdNo,
	a.OvertimeHoliday = b.OvertimeHoliday,
	a.OvertimeRegular = b.OvertimeRegular,
	a.OvertimeSpecial = b.OvertimeSpecial
from OvertimeItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END