
CREATE VIEW MedicalServices_View
 
AS
SELECT	a.BranchID,
	a.ServiceID,
	a.ServiceNameEnglish,
	a.ServiceNameArabic,
	a.DepartmentID,
	b.DepartmentNameEnglish,
	b.DepartmentNameArabic,
	a.DepartmentGroupID,
	c.GroupNameEnglish,
	c.GroupNameArabic,
	a.Nature,
	a.Status,
	a.CashPrice,
	a.CreditPrice,
	a.StaffPrice,
	a.DiscountAmt,
	a.DiscountPercent,
	a.VATApplicable,
	a.VATPercent,  
	a.remarks
from medicalservices a
left outer join MedicalDepartments b on a.DepartmentID = b.DepartmentID
left outer join MedicalDepartmentGroups c on a.DepartmentGroupID = c.DepartmentGroupID