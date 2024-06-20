



CREATE VIEW [dbo].[LABSampleCollectionServices_View2]
 
AS
Select Distinct 
	p.PatientNameEnglish,
	   p.Age,
	   p.AgeYMD,
	   p.DOB,
	   p.Sex,
	   m.ServiceNameEnglish,
	   l.TakenDate,
	   Convert(varchar(8),CONVERT(Time,l.TakenTime)) as 'TakenTime',
	   Convert(Date,c.TransDateEnglish) as 'TransDateEnglish',
	   l.SampleNo,
	   c.RegistrationNo,
	   l.TakenByName,
	   l.TakenByID,
	   c.TransNbr,
	   e.ShortName as DrNameShort,
	   p.IqamaNo,
	   i.Status
from ClinicInvoiceDetails a
left join MedicalServices m on a.ServiceID = m.ServiceID 
left join clinicinvoicegroup c on a.Group_key = c.Trans_Key
left join PatientDetails  p on p.RegistrationNo  = c.RegistrationNo
left join EmployeeDetails e on c.DoctorId = e.EmpID
left join Lab_SampleCollectionGroup l on  c.TransNbr = l.TransNo 
left join Lab_InvoiceGroup i on Convert(Int,i.Sampleno) = l.SampleNo