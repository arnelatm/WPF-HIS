DECLARE @Max INT;
SET @Max = (SELECT MAX (IdNo) FROM SecurityObject);
DBCC CHECKIDENT(SecurityObject, RESEED, @Max);

DBCC CHECKIDENT(HolidayTransfer, RESEED, 0);