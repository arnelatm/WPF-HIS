








CREATE PROC [dbo].[InsertEmployeePhoneTVP]
  @MParam EmployeePhoneInsert READONLY
AS 
INSERT  INTO EmployeePhone (AreaCode, EmployeeIdNo, InternationalCode, PhoneTypeIdNo, PhoneNumber, Sequence)
        SELECT  AreaCode, EmployeeIdNo, InternationalCode, PhoneTypeIdNo, PhoneNumber, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeePhone ON;