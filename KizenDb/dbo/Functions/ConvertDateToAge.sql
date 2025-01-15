
CREATE FUNCTION [dbo].[ConvertDateToAge](@FromDate date,@ToDate date = NULL)
RETURNS nvarchar(255)
AS
BEGIN 

IF @FromDate is null return null;

IF @ToDate Is null  SET @ToDate = GetDate()
 
DECLARE  @tmpdate date, @years int, @months int, @days int
 
SELECT @tmpdate = @FromDate

SELECT 
@years = DATEDIFF(yy, @tmpdate, @ToDate) - 
		 CASE WHEN (MONTH(@FromDate) > MONTH(@ToDate)) OR 
				   (MONTH(@FromDate) = MONTH(@ToDate) AND 
					DAY(@FromDate) > DAY(@ToDate)) 
		 THEN 1 ELSE 0 END

SELECT @tmpdate = DATEADD(yy, @years, @tmpdate)

SELECT @months = DATEDIFF(m, @tmpdate, @ToDate) - 
				 CASE WHEN DAY(@FromDate) > DAY(@ToDate) 
				 THEN 1 ELSE 0 END

SELECT @tmpdate = DATEADD(m, @months, @tmpdate)

SELECT @days = DATEDIFF(d, @tmpdate, @ToDate)

Return cast(@years as nvarchar) + 'Year , ' + 
       cast(@months as nvarchar)  + ' Month , ' + 
	   cast(@days as nvarchar)  + ' Day'
END