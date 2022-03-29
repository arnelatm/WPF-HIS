


Create VIEW [dbo].[IBLABSampleCollection_View]
 
AS
Select 	a.BranchID,
		a.Trans_Key,
		a.TransType,
		a.SampleNo,
		a.TakenDate,
		a.TakenTime,
		a.TransNo,
		a.TransDate,
		a.PatientType,
		a.RegistrationNo,
		a.TakenByID,
		a.TakenByName,
		a.PassedByID,
		a.PassedByName,
		a.Remark,
		a.PassedDate,
		a.PassedTime,
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
left outer join PatientDetails  c on a.RegistrationNo  = c.RegistrationNo and a.PatientType = c.PatientType
Where b.Taken = 1
