







CREATE PROCEDURE  [dbo].[UpdateEmployeePhoneTVP]
  @MParam EmployeePhoneUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeePhone A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing Phones
UPDATE a 
SET a.AreaCode = B.AreaCode,
	a.EmployeeIdNo = @GroupIdNo,
	a.CountryTelIdNo = B.CountryTelIdNo,
	a.PhoneTypeIdNo = B.PhoneTypeIdNo,
	a.PhoneNumber = B.PhoneNumber,
	a.[Sequence] = B.[Sequence]
from EmployeePhone a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END