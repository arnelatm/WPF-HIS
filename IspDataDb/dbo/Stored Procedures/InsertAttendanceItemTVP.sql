



CREATE PROC [dbo].[InsertAttendanceItemTVP]
  @MParam AttendanceItemInsert READONLY
AS 
INSERT  INTO AttendanceItem (DaysAbsentWithoutPay,DaysAbsentWithPay,DaysOff,DaysPresent,EmployeeIdNo,Overtime1,Overtime2,PayrollIdNo)
        SELECT  DaysAbsentWithoutPay, DaysAbsentWithPay, DaysOff, DaysPresent, EmployeeIdNo, Overtime1, Overtime2, PayrollIdNo FROM @MParam
SET IDENTITY_INSERT DBO.AttendanceItem ON;