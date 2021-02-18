

CREATE PROC [dbo].[InsertAttendanceItemTVP]
  @MParam AttendanceItemInsert READONLY
AS 
INSERT  INTO AttendanceItem (DaysAbsentWithoutPay,DaysAbsentWithPay,DaysOff,DaysPresent,EmployeeIdNo,Overtime,PayPeriodIdNo)
        SELECT  DaysAbsentWithoutPay, DaysAbsentWithPay, DaysOff, DaysPresent, EmployeeIdNo, Overtime, PayPeriodIdNo FROM @MParam
SET IDENTITY_INSERT DBO.AttendanceItem ON;