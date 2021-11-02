










CREATE PROC [dbo].[InsertEmployeeIdPrintingTvp]
  @MParam EmployeeIdPrintingInsert READONLY
AS 
INSERT  INTO EmployeeIdPrinting (EmployeeIdNo, TransactionNumber)
        SELECT  EmployeeIdNo, TransactionNumber
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeIdPrinting ON;