CREATE view 	PMRPatientGeneralInfo_View
 
as 
SELECT a.*,
	b.PatientNameEnglish,
	b.RegistrationDate,
	b.Age,
	b.AgeYMD,
	b.IqamaNo,
	b.Mobile,
	b.LastConsDate,
	b.InsCardNo,
	c.NameEnglish as InsuranceName,
	d.NameEnglish as InsuranceGroupName,
	e.EMPNameEnglish as DoctorNameEnglish
FROM PMRPatientGeneralInfo a
left outer join PatientDetails b on a.Series = b.Series AND a.RegistrationNo = b.RegistrationNo
left outer join InsuranceDetails c on a.InsuranceID = c.InsuranceID
left outer join InsuranceDetails d on a.InsuranceGroupID = c.InsuranceID AND c.InsuranceType = 'TPA'
left outer join EmployeeDetails e on a.DoctorID = e.EmpID
