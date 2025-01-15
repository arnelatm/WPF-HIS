
CREATE FUNCTION [dbo].[ConvertDateToAgeRounded](@Birthday date,@ToDate date)
RETURNS @InfoTable TABLE (
Age int,
AgeUnit Varchar)
AS
BEGIN

Declare @Age as int;
Declare @AgeUnit as varchar;  

IF @Birthday is null or @ToDate is null
BEGIN
 INSERT INTO @InfoTable VALUES (NULL,NULL)
 return
END

DECLARE  @tmpdate date, @years int, @months int, @days int;
SELECT @tmpdate = @Birthday;

SELECT @years = DATEDIFF(yy, @tmpdate, @ToDate) - 
		 CASE WHEN (MONTH(@Birthday) > MONTH(@ToDate)) OR 
				   (MONTH(@Birthday) = MONTH(@ToDate) AND 
					DAY(@Birthday) > DAY(@ToDate)) 
		 THEN 1 ELSE 0 END
SELECT @tmpdate = DATEADD(yy, @years, @tmpdate)
SELECT @months = DATEDIFF(m, @tmpdate, @ToDate) - 
				 CASE WHEN DAY(@Birthday) > DAY(@ToDate) 
				 THEN 1 ELSE 0 END
SELECT @tmpdate = DATEADD(m, @months, @tmpdate)
SELECT @days = DATEDIFF(d, @tmpdate, @ToDate)

IF @years > 0   
BEGIN
 BEGIN
  Set @Age = @years;
  Set @AgeUnit = 'Y';
 End
END
ELSE     	   
 IF @months > 0   
  BEGIN
	Set @Age = @months;
	Set @AgeUnit = 'M';   
  END
 ELSE
  BEGIN
   Set @Age = @days;
   Set @AgeUnit = 'D';   
  END
  INSERT INTO @InfoTable VALUES (@Age,@AgeUnit)

RETURN
END