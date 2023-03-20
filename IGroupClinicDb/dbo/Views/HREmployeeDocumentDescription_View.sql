
CREATE VIEW HREmployeeDocumentDescription_View
 
AS
select   a.EmpID,
		 a.EmpNameEnglish ,
		 a.EmpNameArabic,
		 a.NationalID,
		 b.docid,
		 b.DocumentNo,
		 b.IssueDate,
		 b.ExpiryDate,
		 e.CountryNameEng,
		 c.description,
		 d.photo
from HREmployeeDetails a
left outer join EmployeeDocumentsDetail b on a.EmpID  COLLATE database_default= b.EmpID COLLATE database_default
left outer join EmpDocumentType c on b.DocID COLLATE database_default= c.DocID COLLATE database_default
left outer join PatientImagesDataBase..EmployeeDocuments d on a.EmpID COLLATE database_default = d.EmpID COLLATE database_default and b.DocID COLLATE database_default = d.DocumentID COLLATE database_default
left outer join CountryMaster e  on b.Issuecountry COLLATE database_default= e.CountryIOTA COLLATE database_default