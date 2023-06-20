












CREATE view 	[dbo].[PrescriptionDetail_View] 
as 
select 	
	a.[Trans_Key], 
	a.[TransNBR],
	a.[TransDateEnglish],
	a.[Series],
	a.[RegistrationNo],
	a.[DoctorID],
	b.RowNBR,
	b.Item_Code,
	b.ItemNameEnglish as ItemNameEnglish,
	b.DosageEnglish ,
	b.Duration,
	c.PatientNameEnglish ,
	c.Age,
	Iif(c.Sex='M','Male',IIf(c.Sex='F','Female','Unspecified')) as 'Gender',
	IIf(c.AgeYMD='Y','year(s)',iif(c.AgeYMD='M','month(s)',iif(c.AgeYMD='D','day(s)',''))) as 'AgeYMD'
from 	PMRPatientGeneralInfo			A	
left outer join PMRPrescription_View 	B on a.trans_key=b.Trans_key 
left outer join PatientDetails 			C on a.registrationno =c.registrationno and a.series=c.series
where ItemNameEnglish Is Not Null OR ItemnameEnglish <> ''