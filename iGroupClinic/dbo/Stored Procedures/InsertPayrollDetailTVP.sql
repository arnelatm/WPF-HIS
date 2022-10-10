









CREATE PROC [dbo].[InsertPayrollDetailTVP]
  @MParam PayrollDetailInsert READONLY
AS 
INSERT  INTO PayrollDetail (BankTransfer, EmployeeIdNo, PayrollIdNo )
        SELECT  BankTransfer, EmployeeIdNo, PayrollIdNo
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayrollDetail ON;