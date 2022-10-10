










CREATE PROC [dbo].[InsertHolidayTransferItemTVP]
  @MParam HolidayTransferItemInsert READONLY
AS 
INSERT  INTO HolidayTransferItem (EmployeeIdNo, HolidayTransferIdNo)
        SELECT  EmployeeIdNo, HolidayTransferIdNo
        FROM    @MParam
SET IDENTITY_INSERT DBO.HolidayTransferItem ON;