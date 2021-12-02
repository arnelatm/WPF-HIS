











CREATE PROCEDURE  [dbo].[UpdateHolidayTransferItemTVP]
  @MParam HolidayTransferItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].HolidayTransferItem A 
WHERE  (HolidayTransferIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo ) )

-- Update existing Items
UPDATE a 
SET a.EmployeeIdNo = B.EmployeeIdNo,
	a.HolidayTransferIdNo = @GroupIdNo
from HolidayTransferItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END