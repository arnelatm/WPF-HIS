
CREATE view 	PMRPatientLABHistory_View
 
as 
Select 
	'Date' as HistoryType,
	'02' as BranchID,
	a.RegistrationNo,
	a.RegistrationType,
	a.TransNBR,
	a.TransType,
	a.TransDateEnglish,
	a.DoctorID,
	a.EmpNameEnglish,
	a.ServiceID,
	a.ServiceNameEnglish,
	b.DepartmentID,
	c.DepartmentNameEnglish,
	e.TransDateEnglish as PMRDate
from patientprofile_view a 
left outer join MedicalServices b on a.ServiceID = b.ServiceID
LEFT OUTER JOIN MedicalDepartments c on b.DepartmentID = c.DepartmentID
LEFT OUTER JOIN PMRPatientGeneralInfo e on a.RegistrationNo = e.RegistrationNo AND UPPER(a.RegistrationType) = UPPER(e.PatientType) AND a.TransDateEnglish = e.TransDateEnglish and a.DoctorID = e.DoctorID 
left outer join Lab_InvoiceGroup d on a.TransNbr = d.InvoiceNo AND a.TransDateEnglish = d.InvoiceDate AND d.Status=2
where a.serviceid  <> 'CLN-DED' AND a.ServiceID <> 'CLN-DEDU' AND not a.RegistrationNo is NULL --AND NOT d.Trans_Key IS NULL 
and (a.SaleStatus = '' or a.SaleStatus is null)
group BY
	a.RegistrationNo,
	a.RegistrationType,
	a.TransNBR,
	a.TransType,
	a.TransDateEnglish,
	a.DoctorID,
	a.EmpNameEnglish,
	a.ServiceID,
	a.ServiceNameEnglish,
	b.DepartmentID,
	c.DepartmentNameEnglish,
	e.TransDateEnglish
union all
Select  
	'Date' as HistoryType,
	'01' as BranchID,
	a.RegistrationNo,
	a.RegistrationType,
	a.TransNBR,
	a.TransType,
	a.TransDateEnglish,
	a.DoctorID,
	a.EmpNameEnglish,
	'' as ServiceID,
	'Pharmacy Bill' as ServiceNameEnglish,
	'PHR' as DepartmentID,
	'Pharmacy' as DepartmentNameEnglish,
	b.TransDateEnglish as PMRDate
from pharmacypatientprofile_View a --where registrationno = 7398 and transdateenglish = '2014/08/16'
LEFT OUTER JOIN PMRPatientGeneralInfo b on a.RegistrationNo = b.RegistrationNo AND UPPER(a.RegistrationType) = UPPER(b.PatientType) AND a.TransDateEnglish = b.TransDateEnglish and a.DoctorID = b.doctorid
Where ServiceID <> 'CLN-DED' AND ServiceID <> 'CLN-DEDU' AND not a.RegistrationNo is null
Group BY
	a.TransNBR,
	a.RegistrationNo,
	a.RegistrationType,
	a.TransType,
	a.TransDateEnglish,
	a.DoctorID,
	a.EmpNameEnglish,
	b.TransDateEnglish 
-- Order by BranchID DESC,TransNBR