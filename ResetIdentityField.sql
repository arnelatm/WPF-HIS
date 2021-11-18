DECLARE @Max INT;
SET @Max = (SELECT MAX (IdNo) FROM SecurityObject);
DBCC CHECKIDENT('SecurityObject', RESEED, @Max);