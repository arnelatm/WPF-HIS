
CREATE VIEW InsuranceServicePriceListPrint_View
 
AS
select 
	a.InsuranceID as InsuranceGroupID,
	c.NameEnglish,
	a.DepartmentID,
	d.DepartmentNameEnglish,
	case when b.AltServiceID is null then a.ServiceID else b.AltServiceID end as ServiceID,
	case when b.AltServiceID is null then a.ServiceNameEnglish else b.AltServiceNameEnglish end as ServiceNameEnglish,
	a.Price,
	a.DiscountPercent,
	a.DiscountAmt,
	e.Logo
from InsuranceServicePriceList a
left outer join InsuranceAltServicePriceList b on a.InsuranceID = b.InsuranceID and a.ServiceId = b.ServiceID
left outer join InsuranceDetails c on a.InsuranceID = c.InsuranceID and c.InsuranceType = 'TPA'
left outer join MedicalDepartments d on a.DepartmentID = d.DepartmentID
left outer join InsuranceCoLogo e on a.InsuranceID = e.InsuranceID
--where a.insuranceid = '1001'
