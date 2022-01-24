
CREATE PROC [dbo].[InsertAttendanceItemTVP]
  @MParam AttendanceItemInsert READONLY
AS 
INSERT  INTO AttendanceItem (DaysAbsentWithoutPay,DaysAbsentWithPay,DaysOff,DaysPresent,DaysTotal,DaysVacationLeave,EmployeeIdNo,PayrollIdNo,[Sequence])
        SELECT  DaysAbsentWithoutPay, DaysAbsentWithPay, DaysOff, DaysPresent, DaysTotal, DaysVacationLeave, EmployeeIdNo, PayrollIdNo, [Sequence] FROM @MParam
SET IDENTITY_INSERT DBO.AttendanceItem ON;