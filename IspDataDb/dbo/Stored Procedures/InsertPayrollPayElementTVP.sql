









CREATE PROC [dbo].[InsertPayrollPayElementTVP]
  @MParam PayrollPayElementInsert READONLY
AS 
INSERT  INTO PayrollPayElement ( Amount, [Generated], PayElementIdNo, PayrollDetailIdNo, RecurringPayElementIdNo )
        SELECT  Amount, [Generated], PayElementIdNo, PayrollDetailIdNo, RecurringPayElementIdNo
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayrollPayElement ON;