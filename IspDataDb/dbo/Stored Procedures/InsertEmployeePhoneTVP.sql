








CREATE PROC [dbo].[InsertEmployeePhoneTVP]
  @MParam EmployeePhoneInsert READONLY
AS 
INSERT  INTO EmployeePhone (AreaCode, EmployeeIdNo, CountryTelIdNo, PhoneTypeIdNo, PhoneNumber, Sequence)
        SELECT  AreaCode, EmployeeIdNo, CountryTelIdNo, PhoneTypeIdNo, PhoneNumber, Sequence
        FROM    @MParam
