


CREATE PROCEDURE  [dbo].[UpdateInsertHolidayTransferItemTVP]
  @MParam1 HolidayTransferItemUpdate READONLY, @MParam2 HolidayTransferItemInsert READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].HolidayTransferItem A 
WHERE A.HolidayTransferIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam1 where IdNo = A.IdNo )

-- Update existing Details
UPDATE a 
SET a.EmployeeIdNo = B.EmployeeIdNo,
	a.HolidayTransferIdNo = @GroupIdNo
from HolidayTransferItem a INNER JOIN @MParam1 As b
on a.IdNo = b.IdNo

INSERT  INTO [DBO].HolidayTransferItem (EmployeeIdNo, HolidayTransferIdNo )
        SELECT  EmployeeIdNo, HolidayTransferIdNo
        FROM    @MParam2
SET IDENTITY_INSERT DBO.HolidayTransferItem ON;

END