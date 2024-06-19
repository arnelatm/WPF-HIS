




CREATE VIEW [dbo].[LABSampleCollectionLabServices_View]
 
AS
Select a.*,
	   b.Pass,
	   b.Taken,
	   c.PatientNameEnglish,
	   c.Age,
	   c.AgeYMD,
	   c.DOB,
	   c.Sex,
	   m.ServiceNameEnglish,
	   c.Create_Date       
from ClinicInvoiceDetails d
left join Lab_SampleCollectionGroup a on d.Group_Key = a.Trans_Key
left join Lab_SampleCollectionDetails  b on a.Trans_Key  = b.Group_Key 
left join PatientDetails  c on c.RegistrationNo  = a.RegistrationNo and c.PatientType = a.PatientType
left join MedicalServices m on d.ServiceID = m.ServiceID
Where b.Taken = 1 AND m.ServiceGroup = '201'