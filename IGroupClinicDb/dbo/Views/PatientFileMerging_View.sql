
CREATE VIEW PatientFileMerging_View
 
AS
select  a.RegistrationNo,
	a.PatientType,
	a.MergedRegistrationNo,
	a.MergedPatientType,
	b.PatientNameEnglish,
	b.RegistrationDate,
	case when b.mobile is null or b.mobile='' then b.phoner else b.mobile end as mobile,
	b.age,
	b.ageymd,
	b.sex
from PatientFileMerging a
left outer join patientdetails b on a.mergedregistrationno = b.registrationno and a.mergedpatienttype = b.patienttype