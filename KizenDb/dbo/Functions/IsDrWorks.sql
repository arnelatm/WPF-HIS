
CREATE FUNCTION [dbo].[IsDrWorks](@DrID int,@TargetDate datetime = NULL)
RETURNS int
AS
BEGIN 

IF @TargetDate Is null  SET @TargetDate = GetDate()

Declare @CT nvarchar(max);
set @CT =  REPLACE(convert(char(5), dateadd(minute, datediff(minute,0,@TargetDate) / 15 * 15, 0), 108), '00', '0') + '!Work' ;
set @ct =  substring(@ct, patindex('%[^0]%',@ct), 10)

Declare @Res int;

Declare @NameOfDay nvarchar(max);
set @NameOfDay =  DATENAME(dw,@TargetDate);

Declare @CD date;
set @CD = Convert(date,@TargetDate)

if (select Count(*) from AppBlockedDate Where ResourceID = @DrID and  (@CD between BlcoedDate and BlcoedDateTo or @CD = BlcoedDate ) ) > 0  return 0

if (
	select Count(aa.ID) from AppWorkTime as aa join (
		select ResourceID, MIN(DATEDIFF(d, DateFrom, DateTo)) AS MinDuration From dbo.AppWorkTime as a 
		where ResourceID = @DrID and (Disabled = 0 or Disabled is null)
		and ((IsInterval = 1 and DateFrom  = @CD) or ( (IsInterval = 0 or IsInterval is null) and @CD between DateFrom and DateTo)  )
		group by ResourceID) as aaa on aa.ResourceID = aaa.ResourceID and  DATEDIFF(d, aa.DateFrom, aa.DateTo) = aaa.MinDuration
							where (
							( IsInterval = 1 and [Time] like ('%'+ @CT +'%')) 
							or (@NameOfDay = 'Saturday' and Sat like ('%'+ @CT +'%')) 
							or (@NameOfDay = 'Sunday' and Sun like ('%'+ @CT +'%')) 
							or (@NameOfDay = 'Monday' and Mon like ('%'+ @CT +'%')) 
							or (@NameOfDay = 'Tuesday' and Tue like ('%'+ @CT +'%')) 
							or (@NameOfDay = 'Wednesday' and Wed like ('%'+ @CT +'%')) 
							or (@NameOfDay = 'Thursday' and Thu like ('%'+ @CT +'%'))
							or (@NameOfDay = 'Friday' and Fri like ('%'+ @CT +'%'))
							)
  ) > 0 
	set @res =1 ;
else 
	set @res =0 ;

Return @res
END