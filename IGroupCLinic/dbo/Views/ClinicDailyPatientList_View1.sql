CREATE VIEW [ClinicDailyPatientList_View1]
AS
SELECT
	DISTINCT(a.RegistrationNo),
	a.RegistrationType as PatientType,
	b.Series,
	a.Transdateenglish,
	b.patientnameenglish,
	b.countryiota,
	c.countrynameeng,
	b.mobile,
	a.DoctorID,
	d.EmpNameEnglish,
	b.Age,
	b.AgeYMD
from clinicinvoicegroup a
left outer join patientdetails b on a.RegistrationNo = b.RegistrationNo AND upper(a.RegistrationType)=upper(b.PatientType)
left outer join countrymaster c on c.countryiota =b.countryiota
left outer join EmployeeDetails d on a.DoctorID=d.EmpID
