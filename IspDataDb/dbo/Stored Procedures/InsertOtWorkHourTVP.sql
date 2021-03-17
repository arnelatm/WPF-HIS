



CREATE PROC [dbo].[InsertOtWorkHourTVP]
  @MParam OtWorkHourInsert READONLY
AS 
INSERT  INTO OtWorkHour (EmployeeIdNo,OvertimeHoliday,OvertimeRegular,OvertimeSpecial,PayrollIdNo)
        SELECT  EmployeeIdNo,  OvertimeHoliday, OvertimeRegular, OvertimeSpecial, PayrollIdNo FROM @MParam
SET IDENTITY_INSERT DBO.OtWorkHour ON;