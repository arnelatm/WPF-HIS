







CREATE PROC [dbo].[InsertPayrollDeductAccountTVP]
  @MParam PayrollDeductAccountInsert READONLY
AS 
INSERT  INTO PayrollDeductAccount (AccountIdNo, DeductionIdNo, PayGroupIdNo, Sequence)
        SELECT  AccountIdNo, DeductionIdNo, PayGroupIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayrollDeductAccount ON;