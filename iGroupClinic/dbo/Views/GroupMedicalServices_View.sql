
CREATE VIEW GroupMedicalServices_View
 
AS
SELECT	a.BranchID,
    case when d.GroupServiceID is null then a.ServiceID else d.GroupServiceID end as GroupServiceID,
	case when d.serviceid is null then a.ServiceID else d.ServiceID end as ServiceID,
	case when d.serviceid is null then a.ServiceNameEnglish else (Select ServiceNameEnglish From MedicalServices Where ServiceID =  d.ServiceID) end as ServiceNameEnglish,
	case when d.serviceid is null then a.ServiceNameArabic else (Select ServiceNameArabic  From MedicalServices Where ServiceID =  d.ServiceID) end as ServiceNameArabic,
	case when d.serviceid is null then a.DepartmentID  else (Select DepartmentID  From MedicalServices Where ServiceID =  d.ServiceID) end as DepartmentID,
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
left outer join MedicalServicesGroup d on a.ServiceID = d.GroupServiceID