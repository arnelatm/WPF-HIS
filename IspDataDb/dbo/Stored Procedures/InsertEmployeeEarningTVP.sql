




CREATE PROC [dbo].[InsertEmployeeEarningTVP]
  @MParam EmployeeEarningInsert READONLY
AS 
INSERT  INTO EmployeeEarning ( Amount, EarningIdNo, EmployeeIdNo, Sequence )
        SELECT  Amount, EarningIdNo, EmployeeIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeEarning ON;