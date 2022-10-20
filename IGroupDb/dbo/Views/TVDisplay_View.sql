--- Sum of DoctorsCombinedIncome_View
CREATE view 	TVDisplay_View
 
as
select 
	b.OPDNo,
	a.TransDateEnglish,
	b.EmpNameEnglish,
	b.EmpNameArabic,
	a.TokenNo as TokenNo,
	a.RegistrationNo,
	c.PatientNameEnglish,
	a.RegistrationType
from clinicinvoicegroup a
left outer join EmployeeDetails b on a.DoctorID = b.EmpID
left outer join PatientDetails c on a.RegistrationNo = c.RegistrationNo and a.RegistrationType = c.PatientType
where b.empnameenglish is not null and UPPER(b.empnameenglish) <> 'OUT PATIENT'
group by
	b.opdno,
	a.TransDateEnglish,
	a.TokenNo,
	b.empnameenglish,
	b.EmpNameArabic,
	a.RegistrationNo,
	c.patientnameenglish,
	a.RegistrationType