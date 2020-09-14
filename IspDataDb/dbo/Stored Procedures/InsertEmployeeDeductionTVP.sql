




CREATE PROC [dbo].[InsertEmployeeDeductionTVP]
  @MParam EmployeeDeductionInsert READONLY
AS 
INSERT  INTO EmployeeDeduction ( Amount, DeductionIdNo, EmployeeIdNo, Sequence )
        SELECT  Amount, DeductionIdNo, EmployeeIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeDeduction ON;