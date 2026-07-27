

CREATE FUNCTION [dbo].[DateToAge]
	(@dateOfBirth datetime,
	@ReferenceDate datetime)
	returns VarChar(100)
BEGIN

Declare @thisYearBirthDay datetime  
Declare @thisMonthBirthDay datetime  
Declare @PreviousMonthBirthDay datetime  
Declare @nYears Int
Declare @nMonths Int
Declare @nDays Int
Declare @years varchar(40)  
Declare @months varchar(30)  
Declare @days varchar(30)  
Declare @age Varchar(50)
Declare @reverse Bit
Declare @BegDate as DateTime
Declare @EndDate as DateTime
Declare @result as Varchar(50)
Declare @maxEndOfMonthDay as Int
Declare @maxEndOfMonthDayPM as Int
Select @reverse = IIf(IsNull(@dateOfBirth,GetDate()) > IsNull(@ReferenceDate,GetDate()),0,1)
Select @BegDate = IIf(@reverse=0,IsNull(@ReferenceDate,GetDate()),IsNull(@dateOfBirth,GetDate()))
Select @EndDate = IIf(@reverse=0,IsNull(@DateOfBirth,GetDate()),IsNull(@ReferenceDate,GetDate()))
SELECT @thisYearBirthDay = DATEADD(year, DATEDIFF(year, @BegDate, @EndDate), @BegDate) 
Select @MaxEndofMonthDay = Day(EOMONTH(DATEFROMPARTS(Year(@EndDate), month(@EndDate), 1)))
SELECT @thisMonthBirthDay = DATEFROMPARTS(Year(@EndDate), month(@EndDate), IIf(day(@BegDate)>@maxEndOfMonthDay,@maxEndOfMonthDay,day(@BegDate)))
SELECT @previousMonthBirthDay = DATEADD(month, -1, @thisMonthBirthDay)
Select @MaxEndofMonthDayPM = Day(EOMONTH(DATEFROMPARTS(Year(@previousMonthBirthDay), month(@previousMonthBirthDay), 1)))
SELECT @previousMonthBirthDay = DATEFROMPARTS(Year(@previousMonthBirthday), month(@previousMonthBirthday), IIf(day(@BegDate)>@MaxEndofMonthDayPM,@MaxEndofMonthDayPM,day(@BegDate)))
SELECT @nYears = DATEDIFF(year, @BegDate, @EndDate) - (CASE WHEN @thisYearBirthDay > @EndDate THEN 1 ELSE 0 END)
SELECT @nMonths = CASE WHEN @EndDate < @ThisYearBirthday THEN 12+DateDiff(Month, @thisYearBirthday, @EndDate)+ IIf(Day(@BegDate) > Day(@EndDate),-1, 0) ELSE DateDiff(Month, @thisYearBirthday, @EndDate) END
SELECT @nDays = CASE When Day(@EndDate) >= Day(@BegDate) Then Day(@EndDate)-Day(@BegDate) ELSE DateDiff(day,@PreviousMonthBirthday,@EndDate) END
Select @years = IIf(@nYears=0,''  ,IIf(@reverse=0,'-','')+Convert(Varchar,@nYears)  + IIf(@nYears>1 ,' years',' year'))
Select @months = IIf(@nMonths=0,'',IIf(@reverse=0,'-','')+Convert(Varchar,@nMonths) + IIf(@nMonths>1,' months',' month'))
Select @days = iif(@nDays=0,''    ,IIf(@reverse=0,'-','')+Convert(Varchar,@nDays)   + IIf(@nDays>1  ,' days',' day'))
Select @result = IIf(@nDays = 0 and @nMonths = 0 and @nYears = 0,'0 day', @years) +
				 IIf(@nYears > 0 and (@nMonths > 0 or @nDays >0), ', ' + '' + @months, @months) + 
				 Iif(@nMonths > 0 and @nDays > 0, ', ' + @days, @days)			 
return @result
END