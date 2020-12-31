
CREATE PROC [dbo].[InsertAttendanceItemTVP]
  @MParam AttendanceItemInsert READONLY
AS 
INSERT  INTO AttendanceItem (DaysAbsentWithoutPay,DaysAbsentWithPay,DaysOff,DaysPresent,EmployeeIdNo,PayPeriodIdNo,Sequence)
        SELECT  DaysAbsentWithoutPay, DaysAbsentWithPay, DaysOff, DaysPresent, EmployeeIdNo, PayPeriodIdNo, Sequence FROM @MParam
SET IDENTITY_INSERT DBO.AttendanceItem ON;