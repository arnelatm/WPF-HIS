CREATE VIEW [dbo].[Employe_Kizen_View]
AS
SELECT 
    IdNo,
    EmployeeCode,
    EmployeeName,
    EmployeeNameAra,
    Gender,
    BirthDate,
    MaritalStatus,
    NationalityCode,
    NationalityId,
    ReligionIdNo,
    ReligionId,
    NationalIdNo,
    Street,
    District,
    TownCity,
    ProvinceState,
    CountryCode,
    PoBox,
    ZipCode,
    Phone1,
    Email,
    HiredDate
FROM dbo.Employee;

GO

