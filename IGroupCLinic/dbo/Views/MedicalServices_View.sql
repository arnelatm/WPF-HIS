create view MedicalServices_View
as SELECT a.BranchID,
a.ServiceID,
a.ServiceNameEnglish,
a.ServiceNameArabiC, 
a.DepartmentID,
a.ServiceGroup,
b.DepartmentNameEngliSh,
b.DepartmentNameArabic,
a.DepartmentGroupID,
c.GroupNameEnglish,
c.GroupNameArabic,
a.Nature,
a.Status,
a.CaShPrice,
a.CreditPrice,
a.StaffPrice,
a.DiscountAmt,
a.DiscountPercent,
a.VATApplicable,
a.VATPercent,
a.remarks,
d.GroupName
from MedicalServices as a
left outer join MedicalDepartmentS b on a.DepartmentID = b.DepartmentID
left outer join MedicalDepartmentGroups c on a.DepartmentGroupID = C.DepartmentGroupID
left outer join ServicesGroup d on a.ServiceGroup = d.ServiceGroupCode