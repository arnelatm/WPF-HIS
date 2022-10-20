CREATE view 	PMRMedicalRecord_View
 
as 
select 		a.*,
			b.patientnameenglish as patient ,
			b.age,
			b.sex,
			b.ageYMD,
			b.iqamano,
			d.EmpNameEnglish,
			e.countrynameeng,
			f.nameenglish
from 		PMRMedicalReport a	
left outer join PatientDetails	b on a.RegistrationNo=b.RegistrationNo and a.series=b.series 
left outer join EmployeeDetails	d on a.doctorID =d.empID
left outer join CountryMaster 	e on b.CountryIOTA  =e.CountryIOTA 
left outer join InsuranceDetails f on a.InsuranceID=f.InsuranceID