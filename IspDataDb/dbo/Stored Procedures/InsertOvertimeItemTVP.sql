



CREATE PROC [dbo].[InsertOvertimeItemTVP]
  @MParam OvertimeItemInsert READONLY
AS 
INSERT  INTO OvertimeItem (EmployeeIdNo,OvertimeHoliday,OvertimeRegular,OvertimeSpecial,PayrollIdNo)
        SELECT  EmployeeIdNo,  OvertimeHoliday, OvertimeRegular, OvertimeSpecial, PayrollIdNo FROM @MParam
SET IDENTITY_INSERT DBO.OvertimeItem ON;