




CREATE view 	[dbo].[PMRDoctorsGenForm_View]
 
as 
SELECT a.DoctorId,
	a.TransDateEnglish as PmrDate, 
	a.RegistrationNo as FileNo, 
	case when a.transdateenglish = b.RegistrationDate then 'New' else 'Old' end as [FileType],
	a.PatientType as PType,
	b.PatientNameEnglish as PatientName,
	Cast(a.TokenNo as Int) as Token, 
	IIf(Cast(a.TokenNo as Int)=0,0,1) as Status,
	b.LastConsDate,
	a.Trans_Key,
	(SELECT MIN( g.Create_Date)
              FROM ClinicInvoiceGroup g
              WHERE a.RegistrationNo = g.RegistrationNo and a.DoctorId = g.DoctorId and a.RegistrationNo = g.RegistrationNo and a.PatientType = g.RegistrationType and a.TransDateEnglish = g.TransDateEnglish) as InvTime
FROM PMRPatientGeneralInfo a 
left outer join PatientDetails b on a.Series = b.Series AND a.RegistrationNo = b.RegistrationNo
left outer join EmployeeDetails e on a.DoctorID = e.EmpID