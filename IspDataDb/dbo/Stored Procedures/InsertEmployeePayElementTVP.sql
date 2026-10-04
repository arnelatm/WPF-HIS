






CREATE PROC [dbo].[InsertEmployeePayElementTVP]
  @MParam EmployeePayElementInsert READONLY
AS 
INSERT  INTO EmployeePayElement ( Amount, PayElementIdNo, EmployeeIdNo, Rate, Sequence, Unit )
        SELECT  Amount, PayElementIdNo, EmployeeIdNo, Rate, Sequence, Unit
        FROM    @MParam
