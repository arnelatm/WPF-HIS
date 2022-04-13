
CREATE VIEW [dbo].[EmployeeInfo_View2]
AS
SELECT        dbo.Employee.IdNo, dbo.Employee.EmployeeCode, dbo.Employee.Title, dbo.Employee.EmployeeName, dbo.Employee.EmployeeNameAra, dbo.Employee.Gender, dbo.Employee.MaritalStatus, dbo.Employee.NationalityCode, 
                         dbo.Employee.NationalityId, dbo.Employee.ReligionIdNo, dbo.Employee.ReligionId, dbo.Employee.NationalIdNo, dbo.Employee.Street, dbo.Employee.District, dbo.Employee.TownCity, dbo.Employee.ProvinceState, 
                         dbo.Employee.CountryCode, dbo.Employee.PoBox, dbo.Employee.ZipCode, dbo.Employee.Phone1, dbo.Employee.Phone2, dbo.Employee.Email, dbo.Employee.DepartmentIdNo, dbo.Employee.DesignationIdNo, 
                         dbo.Employee.HiredDate, dbo.Employee.ReleasedDate, dbo.Employee.ArAccountIdNo, dbo.Employee.BankIdNo, dbo.Employee.BankAccountNo, dbo.Employee.IBAN, dbo.Employee.Notes, dbo.Employee.OpeningBalance, 
                         dbo.Employee.Balance, dbo.Employee.PaymentMethod, dbo.Employee.PayCycleIdNo, dbo.Employee.PayGroupIdNo, dbo.Employee.PaySalariedOrHourly, dbo.Employee.PayRateType, dbo.Employee.SponsorType, 
                         dbo.Employee.PayRateAmount, dbo.Employee.OTRateRegular, dbo.Employee.OTRateHoliday, dbo.Employee.DutyHours, dbo.Employee.OTRateSpecial, dbo.Employee.BloodType, dbo.Employee.Supervisor, 
                         dbo.Employee.SupervisorIdNo, dbo.Employee.Picture, dbo.Employee.Active, dbo.Employee.Create_Date, dbo.Country.Nationality, dbo.Religion.ReligionName, dbo.Religion.ReligionNameAra, dbo.Country.NationalityAra, 
                         dbo.Department.DepartmentName, dbo.Department.DepartmentNameAra, dbo.Bank.BankName, dbo.Bank.BankNameAra, dbo.Bank.BankCode, dbo.Department.DepartmentCode, dbo.Religion.ReligionCode, 
                         Country_1.CountryName, Country_1.CountryNameAra, dbo.Designation.DesignationCode, dbo.Designation.DesignationName, dbo.Designation.DesignationNameFemale, dbo.Designation.DesignationNameAra, 
                         dbo.Designation.DesignationNameFemaleAra, Employee_1.EmployeeName AS SupervisorName, Employee_1.EmployeeNameAra AS SupervisorNameAra, dbo.Employee.BirthDate, dbo.EmployeePhone.AreaCode, 
                         dbo.EmployeePhone.PhoneNumber, dbo.EmployeePhone.CountryTelIdNo, dbo.PayGroup.PayGroupCode, dbo.PayGroup.PayGroupName, dbo.PayGroup.PayGroupNameAra
FROM            dbo.Employee LEFT OUTER JOIN
                         dbo.PayGroup ON dbo.Employee.PayGroupIdNo = dbo.PayGroup.IdNo LEFT OUTER JOIN
                         dbo.EmployeePhone ON dbo.Employee.IdNo = dbo.EmployeePhone.EmployeeIdNo LEFT OUTER JOIN
                         dbo.Religion ON dbo.Employee.ReligionIdNo = dbo.Religion.IdNo LEFT OUTER JOIN
                         dbo.Department ON dbo.Employee.DepartmentIdNo = dbo.Department.IdNo LEFT OUTER JOIN
                         dbo.Designation ON dbo.Employee.DesignationIdNo = dbo.Designation.DesignationCode LEFT OUTER JOIN
                         dbo.Bank ON dbo.Employee.BankIdNo = dbo.Bank.IdNo LEFT OUTER JOIN
                         dbo.Country AS Country_1 ON dbo.Employee.CountryCode = Country_1.CountryCode COLLATE SQL_Latin1_General_CP1_CI_AS LEFT OUTER JOIN
                         dbo.Country ON dbo.Employee.NationalityCode = dbo.Country.CountryCode COLLATE SQL_Latin1_General_CP1_CI_AS LEFT OUTER JOIN
                         dbo.Employee AS Employee_1 ON dbo.Employee.SupervisorIdNo = Employee_1.IdNo