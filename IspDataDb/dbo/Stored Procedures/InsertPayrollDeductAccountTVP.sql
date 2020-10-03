







CREATE PROC [dbo].[InsertPayrollDeductAccountTVP]
  @MParam PayrollDeductAccountInsert READONLY
AS 
INSERT  INTO PayrollDeductAccount (AccountIdNo, DeductionIdNo, PayGroupIdNo)
        SELECT  AccountIdNo, DeductionIdNo, PayGroupIdNo
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayrollDeductAccount ON;