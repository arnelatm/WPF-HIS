





CREATE PROC [dbo].[InsertPayrollEarningTVP]
  @MParam PayrollEarningInsert READONLY
AS 
INSERT  INTO PayrollEarning ( Amount, EarningIdNo, EmployeeIdNo, PayrollIdNo )
        SELECT  Amount, EarningIdNo, EmployeeIdNo, PayrollIdNo
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayrollEarning ON;