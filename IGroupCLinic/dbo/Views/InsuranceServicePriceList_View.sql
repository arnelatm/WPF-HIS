
CREATE VIEW InsuranceServicePriceList_View
 
AS
SELECT	a.BranchID,
	a.insuranceid,
	a.ServiceID,
	case when d.ServiceNameEnglish is null then a.ServiceNameEnglish else d.ServiceNameEnglish end as servicenameenglish,
	d.ServiceNameArabic,
	a.DepartmentID,
	b.DepartmentNameEnglish,
	b.DepartmentNameArabic,
	b.DepartmentGroupID,
	c.GroupNameEnglish,
	c.GroupNameArabic,
	a.price,
	a.discountpercent,
	a.discountamt,
	d.Status,
	d.remarks
from insuranceservicepricelist a
left outer join MedicalDepartments b on a.DepartmentID = b.DepartmentID
left outer join MedicalDepartmentGroups c on b.DepartmentGroupID = c.DepartmentGroupID
left outer join MedicalServices d on a.ServiceID = d.ServiceID AND a.DepartmentID = d.DepartmentID
