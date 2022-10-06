ALTER view 	[dbo].[PMRDoctorsGenForm_View]
 
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
	Min(c.Create_Date) as InvTime
FROM PMRPatientGeneralInfo a 
left outer join PatientDetails b on a.Series = b.Series AND a.RegistrationNo = b.RegistrationNo
left outer join EmployeeDetails e on a.DoctorID = e.EmpID
left outer join ClinicInvoiceGroup c on c.TransDateEnglish = a.TransDateEnglish and c.RegistrationNo = a.RegistrationNo and c.TransType = a.TransType 
group by a.Trans_Key,a.DoctorId,a.TokenNo,a.TransDateEnglish,a.RegistrationNo,a.TransType,a.PatientType,b.PatientNameEnglish,b.RegistrationDate,b.LastConsDate
GO