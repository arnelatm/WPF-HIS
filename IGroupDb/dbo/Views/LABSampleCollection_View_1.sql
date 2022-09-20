

CREATE VIEW [dbo].[LABSampleCollection_View]
 
AS
Select a.*,
	   b.Pass,
	   b.Taken,
	   c.PatientNameEnglish,
	   c.Age,
	   c.AgeYMD,
	   c.DOB,
	   c.Sex,
	   c.Create_Date       
from Lab_SampleCollectionGroup  a
left outer join Lab_SampleCollectionDetails  b on a.Trans_Key  = b.Group_Key 
left outer join PatientDetails  c on c.RegistrationNo  = a.RegistrationNo and c.PatientType = a.PatientType
Where b.Taken = 1