
CREATE VIEW Transactions_View
 
AS

select 
	a.BRanchID,
	a.Trans_Key,
	a.RegistrationType,
	a.TransNBR,
	a.TransDateEnglish,
	a.RegistrationNo,
	a.RegistrationDate,
	c.PatientNameEnglish,
	a.DoctorID,
	d.EmpNameEnglish,
	a.InsuranceID,
	h.NameEnglish as UnderInsuranceName,
	a.Insurancenameenglish as InsuranceName,
	a.insurancegroupid,
	f.NameEnglish as InsuranceGroupName,
	a.insurancecardno,
	a.deductioncategory,
	a.DeductibleAmt,
	a.DeductibleDiscountAmt,
	b.ServiceID,
	case when e.ServiceNameEnglish is null then j.ServiceNameEnglish else e.ServiceNameEnglish end as ServiceNameEnglish,
	i.DepartmentID,
	b.Qty,
	'B' as TransUnit,
	b.SalePrice,
	b.DiscountAmt,
	b.DiscountPer,
	g.Policy
from ClinicInvoiceGroup a
left outer join ClinicInvoiceDetails b on a.Trans_Key = b.Group_Key and a.BranchID = b.BranchID
left outer join PatientDetails c on a.RegistrationNo = c.RegistrationNo and a.RegistrationType = c.PatientType
left outer join EmployeeDetails d on a.DoctorID = d.EmpID
left outer join MedicalServices e on b.ServiceID = e.ServiceID
left outer join InsuranceDetails f on a.InsuranceGroupID = f.InsuranceID AND f.InsuranceType = 'TPA'
left outer join InsuranceDetails g on a.InsuranceID = g.InsuranceID
left outer join InsuranceDetails h on g.UnderInsuranceID = h.InsuranceID
left outer join MedicalDepartments i on e.DepartmentID = i.DepartmentID
left outer join InsuranceServicePriceList j on b.ServiceID = j.ServiceID AND a.InsuranceGroupID = j.InsuranceID
union all
select 
	a.BranchID,
	a.Trans_Key,
	a.RegistrationType,
	a.TransNBR,
	a.TransDateEnglish,
	a.RegistrationNo,
	a.RegistrationDate,
	c.PatientNameEnglish,
	a.DoctorID,
	d.EmpNameEnglish,
	a.InsuranceID,
	h.NameEnglish as UnderInsuranceName,
	a.Insurancenameenglish as InsuranceName,
	a.insurancegroupid,
	f.NameEnglish as InsuranceGroupName,
	a.insurancecardno,
	a.deductioncategory,
	a.DeductibleAmt,
	a.DeductibleDiscountAmt,
	b.Item_Code as ServiceID,
	e.ItemNameEnglish as ServiceNameEnglish,
	'008' as DepartmentID,
	b.Qty,
	Unit as TransUnit,
	b.SalePrice,
	b.DiscountAmt,
	b.DiscountPer,
	g.Policy
from PharmacyInvoiceGroup a
left outer join PharmacyInvoiceDetails b on a.Trans_Key = b.Group_Key and a.BranchID = b.BranchID
left outer join PatientDetails c on a.RegistrationNo = c.RegistrationNo and a.RegistrationType = c.PatientType
left outer join EmployeeDetails d on a.DoctorID = d.EmpID
left outer join ItemDetails e on b.Item_Code = e.Item_Code
left outer join InsuranceDetails f on a.InsuranceGroupID = f.InsuranceID AND f.InsuranceType = 'TPA'
left outer join InsuranceDetails g on a.InsuranceID = g.InsuranceID
left outer join InsuranceDetails h on g.UnderInsuranceID = h.InsuranceID
