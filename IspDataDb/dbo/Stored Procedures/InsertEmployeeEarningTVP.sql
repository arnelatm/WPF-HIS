




CREATE PROC [dbo].[InsertEmployeeEarningTVP]
  @MParam EmployeeEarningInsert READONLY
AS 
INSERT  INTO EmployeeEarning ( Amount, EarningIdNo, EmployeeIdNo, Rate, Sequence )
        SELECT  Amount, EarningIdNo, EmployeeIdNo, Rate, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeEarning ON;