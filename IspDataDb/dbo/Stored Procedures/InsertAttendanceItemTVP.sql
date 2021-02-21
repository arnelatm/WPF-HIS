

CREATE PROC [dbo].[InsertAttendanceItemTVP]
  @MParam AttendanceItemInsert READONLY
AS 
INSERT  INTO AttendanceItem (DaysAbsentWithoutPay,DaysAbsentWithPay,DaysOff,DaysPresent,EmployeeIdNo,Overtime,PayrollIdNo)
        SELECT  DaysAbsentWithoutPay, DaysAbsentWithPay, DaysOff, DaysPresent, EmployeeIdNo, Overtime, PayrollIdNo FROM @MParam
SET IDENTITY_INSERT DBO.AttendanceItem ON;