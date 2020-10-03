







CREATE PROC [dbo].[InsertPayrollEarnAccountTVP]
  @MParam PayrollEarnAccountInsert READONLY
AS 
INSERT  INTO PayrollEarnAccount (AccountIdNo, EarningIdNo, PayGroupIdNo, Sequence)
        SELECT  AccountIdNo, EarningIdNo, PayGroupIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayrollEarnAccount ON;