










CREATE PROC [dbo].[InsertAttendanceTVP]
  @MParam AttendanceItemInsert READONLY
AS 
INSERT  INTO Attendance (DaysAbsentWithoutPay,DaysAbsentWithPay,DaysOff,DaysPresent,EmployeeIdNo,PayPeriodIdNo,Sequence)
        SELECT  DaysAbsentWithoutPay, DaysAbsentWithPay, DaysOff, DaysPresent, EmployeeIdNo, PayPeriodIdNo, Sequence FROM @MParam
SET IDENTITY_INSERT DBO.Attendance ON;