CREATE VIEW InsuranceInvoice_View
 
AS
SELECT 	0 as CS,
	c.InsCardNo,
	a.registrationno,
	c.PatientNameEnglish,
	a.transnbr,
	a.transdateenglish,
	0 as ApprovalNo,
	'' as ICD10Code,
	'' as Diagnosis1,
	'' as Diagnosis2,
	'' as Diagnosis3,
	'' as ClinicalData,
	'O' as claimType,
	b.ServiceID,
	d.ServiceNameEnglish,
	a.TransDateEnglish as TreatmentDate,
	b.qty,
	b.SalePrice as Amount,
	b.qty * b.SalePrice as GrossAmount,
	case when b.DiscountAmt <> 0 then 
		b.DiscountAmt 
	     else 
		((b.Qty * b.SalePrice * b.DiscountPer) / 100) 
	     end as DiscountAmt,
	0 as AdditionalDiscountAmt,
	b.DeductiblePer,
	b.DeductibleAmt,
	a.DoctorID,
	h.EmpNameEnglish,
	e.Policy,
	a.InsuranceID,
	e.NameEnglish,
	a.InsuranceGroupID,
	f.NameEnglish as GroupInsuranceName,
	g.InsuranceID as UnderInsuranceID,
	g.NameEnglish as UnderInsuranceName,
	a.Create_Date,
	'Clinic' as TrType
from ClinicInvoiceGroup a
left outer join ClinicInvoiceDetails b on a.Trans_Key = b.Group_Key AND a.BranchID = b.BranchID
left outer join PatientDetails c on a.RegistrationNo = c.RegistrationNo AND upper(a.RegistrationType) = upper(c.PatientType) AND a.BranchID = c.BranchID
left outer join InsuranceServicePriceList d on b.ServiceID = d.ServiceID AND d.InsuranceID = a.InsuranceGroupID AND a.BranchID = d.BranchID
left outer join InsuranceDetails e on e.InsuranceID = a.InsuranceID AND a.BranchID = e.BranchID
left outer join InsuranceDetails f on f.InsuranceID = a.InsuranceGroupID AND f.InsuranceType = 'TPA' AND a.BranchID = e.BranchID
left outer join InsuranceDetails g on g.InsuranceID = e.UnderInsuranceID
left outer join EmployeeDetails h on a.DoctorID = h.EmpID
where a.BillType = 'CR' AND a.TransType = 'CR' AND upper(a.RegistrationType) = 'INSURANCE' AND (Reject=0 or Reject is null)
union all
SELECT 	0 as CS,
	c.InsCardNo,
	a.registrationno,
	c.PatientNameEnglish,
	a.transnbr,
	a.transdateenglish,
	0 as ApprovalNo,
	'' as ICD10Code,
	'' as Diagnosis1,
	'' as Diagnosis2,
	'' as Diagnosis3,
	'' as ClinicalData,
	'O' as claimType,
	b.Item_Code as ServiceID,
	d.ItemNameEnglish as ServiceNameEnglish,
	a.TransDateEnglish as TreatmentDate,
	b.qty,
	b.SalePrice as Amount,
	b.qty * b.SalePrice as GrossAmount,
	case when b.DiscountAmt <> 0 then 
		b.DiscountAmt 
	     else 
		((b.Qty * b.SalePrice * b.DiscountPer) / 100) 
	     end as DiscountAmt,
	0 as AdditionalDiscountAmt,
	b.DeductiblePer,
	b.DeductibleAmt,
	a.DoctorID,
	h.EmpNameEnglish,
	e.policy,
	a.InsuranceID,
	e.NameEnglish,
	e.GroupInsuranceID as GroupInsuranceID,
	f.NameEnglish as GroupInsuranceName,
	g.InsuranceID as UnderInsuranceID,
	g.NameEnglish as UnderInsuranceName,
	a.Create_Date,
	'Pharmacy' as TrType
from PharmacyInvoiceGroup a
left outer join PharmacyInvoiceDetails b on a.Trans_Key = b.Group_Key AND a.BranchID = b.BranchID
left outer join PatientDetails c on a.RegistrationNo = c.RegistrationNo and c.Series = 'CR'
left outer join ItemDetails d on b.Item_Code = d.Item_Code AND a.BranchID = d.BranchID
left outer join InsuranceDetails e on e.InsuranceID = a.InsuranceID
left outer join InsuranceDetails f on f.InsuranceID = e.GroupInsuranceID AND f.InsuranceType = 'TPA'
left outer join InsuranceDetails g on g.InsuranceID = e.UnderInsuranceID
left outer join EmployeeDetails h on a.DoctorID = h.EmpID
where a.BillType = 'SALE INVOICE' AND a.TransType = 'CR' AND UPPER(a.RegistrationType) = 'CREDIT'
