CREATE View PMRPatientDisplay_View
 
as 
SELECT 
	distinct(Cast(a.TokenNo as varchar(3))) as [Token],
	case when f.TokenNo is null then '0' else '1' end as Status,
	cast(a.RegistrationNo as varchar(7)) as [File No],
	d.PatientNameEnglish as [Name],
	case when a.transdateenglish = d.RegistrationDate then 'New' else 'Old' end as [Type],
	case when a.TransType = 'CA' then 'Cash' else 'Credit' end as [Inv Type],
	'Regular' as [Appointment],
	a.TokenNo,
	a.Trans_Key,
	d.RegistrationDate,
	a.transdateenglish,
	a.doctorid,
	Host_name() as MachineID
FROM ClinicInvoiceGroup a 
left outer join ClinicInvoiceDetails b on a.Trans_Key = b.Group_Key
left outer join patientdetails d on a.registrationno = d.registrationno and a.registrationtype = d.patienttype 
left outer join systemsettings e on 1=1 
left outer join PMRTokenDetails f on f.PMRDateEnglish = a.TransDateEnglish AND a.DoctorID = f.DoctorID AND a.TokenNo = f.TokenNo 
where b.ServiceID <> 'CLN-DED' AND b.ServiceID <> 'CLN-DEDU'
group by a.tokenno,f.tokenno,a.registrationno,d.patientnameenglish,d.registrationdate,a.transdateenglish,a.transtype,a.doctorid,a.trans_Key
