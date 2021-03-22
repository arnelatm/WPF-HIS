



CREATE PROC [dbo].[InsertOtWorkHourTVP]
  @MParam OtWorkHourInsert READONLY
AS 
INSERT  INTO OtWorkHour (EmployeeIdNo,HoursWorked,OvertimeHoliday,OvertimeRegular,OvertimeSpecial,PayrollIdNo,[Sequence])
        SELECT  EmployeeIdNo,  HoursWorked, OvertimeHoliday, OvertimeRegular, OvertimeSpecial, PayrollIdNo, [Sequence] FROM @MParam
SET IDENTITY_INSERT DBO.OtWorkHour ON;