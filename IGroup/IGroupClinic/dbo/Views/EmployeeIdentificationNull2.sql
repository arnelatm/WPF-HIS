

create view [dbo].[EmployeeIdentificationNull2] 
as
select 
a.*,
b.Photo  
from HREmployee_View  a
left outer join PatientImagesDatabase..EmployeeDocuments b on a.EmpID = b.EmpID and b.DocumentID ='005'
WHERE A.EMPID = 'E00447' OR A.EMPID='E00064'