









CREATE PROC [dbo].[InsertPayrollPayElementTVP]
  @MParam PayrollPayElementInsert READONLY
AS 
INSERT  INTO PayrollPayElement ( Amount, PayElementIdNo, PayrollDetailIdNo, RecurringPayElementIdNo )
        SELECT  Amount, PayElementIdNo, PayrollDetailIdNo, RecurringPayElementIdNo
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayrollPayElement ON;