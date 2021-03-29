








CREATE PROC [dbo].[InsertPayrollDetailTVP]
  @MParam PayrollDetailInsert READONLY
AS 
INSERT  INTO PayrollDetail ( EmployeeIdNo, PayrollIdNo )
        SELECT  EmployeeIdNo, PayrollIdNo
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayrollDetail ON;