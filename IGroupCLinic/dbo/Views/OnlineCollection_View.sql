CREATE VIEW OnlineCollection_View
 
AS
Select Distinct(a.DoctorID),
b.EmpNameEnglish,
b.EmpNameArabic,
a.TransDateEnglish 
From ClinicInvoiceGroup a
left outer join EmployeeDetails b on a.DoctorID = b.EmpID 
union all
select Distinct(a.DoctorID),
b.EmpNameEnglish,
b.EmpNameArabic,
a.TransDateEnglish 
from IBInvoiceGroup a
left outer join EmployeeDetails b on a.DoctorID = b.EmpID 
