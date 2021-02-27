




CREATE PROC [dbo].[InsertEmployeeDeductionTVP]
  @MParam EmployeeDeductionInsert READONLY
AS 
INSERT  INTO EmployeeDeduction ( Amount, DeductionIdNo, EmployeeIdNo, Rate, Sequence )
        SELECT  Amount, DeductionIdNo, EmployeeIdNo, Rate, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeDeduction ON;