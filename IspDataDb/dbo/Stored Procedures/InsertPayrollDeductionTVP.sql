






CREATE PROC [dbo].[InsertPayrollDeductionTVP]
  @MParam PayrollDeductionInsert READONLY
AS 
INSERT  INTO PayrollDeduction ( Amount, DeductionIdNo, EmployeeIdNo, PayrollIdNo )
        SELECT  Amount, DeductionIdNo, EmployeeIdNo, PayrollIdNo
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayrollDeduction ON;