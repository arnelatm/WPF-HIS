







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
WHERE ISNULL(a.EmployeeIdNo, 0) <> ISNULL(@GroupIdNo, 0)
   OR ISNULL(a.PhoneTypeIdNo, 0) <> ISNULL(b.PhoneTypeIdNo, 0)
   OR ISNULL(a.CountryTelIdNo, 0) <> ISNULL(b.CountryTelIdNo, 0)
   OR ISNULL(a.AreaCode, '') <> ISNULL(b.AreaCode, '')
   OR ISNULL(a.PhoneNumber, '') <> ISNULL(b.PhoneNumber, '')
   OR ISNULL(a.[Sequence], 0) <> ISNULL(b.[Sequence], 0)

END
