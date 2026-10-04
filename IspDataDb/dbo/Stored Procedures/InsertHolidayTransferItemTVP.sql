










CREATE PROC [dbo].[InsertHolidayTransferItemTVP]
  @MParam HolidayTransferItemInsert READONLY
AS 
INSERT  INTO HolidayTransferItem (EmployeeIdNo, HolidayTransferIdNo)
        SELECT  EmployeeIdNo, HolidayTransferIdNo
        FROM    @MParam
