





CREATE PROC [dbo].[InsertEmployeePayElementTVP]
  @MParam EmployeePayElementInsert READONLY
AS 
INSERT  INTO EmployeePayElement ( Amount, PayElementIdNo, EmployeeIdNo, Rate, Sequence )
        SELECT  Amount, PayElementIdNo, EmployeeIdNo, Rate, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeePayElement ON;