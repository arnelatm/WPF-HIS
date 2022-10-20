
CREATE VIEW HREmployee_View
 
AS
SELECT 
	a.BranchID,
	a.FileNo,
	a.EmpID,
	a.AttendenceID,
	a.EmpNameEnglish,
	a.EmpNameArabic,
	a.NationalID,
	b.CountryNameEng,
	a.ReligionID,
	c.DescriptionEng as Religion,
	a.DepartmentID,
	d.Department,
	a.DesignationID,
	e.Description as Designation,
	a.JoinDate,
	a.DutyHRS,
	a.ServiceStatus,
	a.Mobile,
	a.eMail,
	a.PassportNo,
	a.PassportExpiry,
	a.IqamaNo,
	a.IqamaExpiry,
	a.DrvLicense,
	a.DrvLicenseExpiry,
	a.InsuranceNo,
	a.InsuranceExpiry,
	a.GOSI,
	CASE WHEN a.EmpMarketing=1 THEN 'Y' ELSE 'N' END as MarketingEmployee,
	f.OTApply
FROM HREmployeeDetails a
LEFT OUTER JOIN CountryMaster b on b.CountryIOTA = a.NationalID
LEFT OUTER JOIN Religions c on c.ReligionID = a.ReligionID
LEFT OUTER JOIN EmployeeDepartment d on d.DeptID = a.DepartmentID
LEFT OUTER JOIN EmployeeDesignation e on e.DesID = a.DesignationID
LEFT OUTER JOIN HREmployeeSalaryMaster f on a.EmpID = f.EmpID AND a.BranchID = f.BranchID