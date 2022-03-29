

create view [dbo].[EmployeeIdentificationNull] 
as
select 
a.*,
b.Photo  
from HREmployee_View  a
left outer join PatientImagesDatabase..EmployeeDocuments b on a.EmpID = b.EmpID and b.DocumentID ='005'
where b.photo is null


